using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using TagDataTranslation.DigitalLink;
using TagDataTranslation.Encoding;
using TagDataTranslation.Models;
using TagDataTranslation.Tables;

namespace TagDataTranslation
{
    /// <summary>
    /// TDT 2.2 compliant Tag Data Translation Engine.
    /// Provides translation between different EPC encoding levels.
    /// Licensed under BSL 1.1 -- production use requires a commercial license from tdt@mimasu.nl.
    /// </summary>
    public class TDTEngine
    {
        // compiled regex cache shared across all engine instances
        private static readonly ConcurrentDictionary<string, Regex> _regexCache = new();

        private static Regex GetCachedRegex(string pattern)
        {
            return _regexCache.GetOrAdd(pattern, p =>
                new Regex(p, RegexOptions.Compiled, TimeSpan.FromMilliseconds(200)));
        }

        // TDT 2.2 JSON scheme data
        private readonly List<EpcTagDataTranslation> epcTagDataTranslations = new List<EpcTagDataTranslation>();

        // GCP prefix length lookup
        private readonly Dictionary<string, int> gcpPrefixLengths = new Dictionary<string, int>();

        // Filter value tables
        private readonly Dictionary<string, Dictionary<int, string>> filterValueTables = new Dictionary<string, Dictionary<int, string>>();

        // TDT 2.2 Tables
        private TableF tableF = null!;
        private TableK tableK = null!;
        private TableE tableE = null!;
        private TableB tableB = null!;

        // encoding codecs
        private EncodedAICodec encodedAICodec = null!;
        private VariableLengthFieldCodec variableLengthFieldCodec = null!;
        private AidcDataCodec aidcDataCodec = null!;


        // static compiled regex for grammar string parsing
        private static readonly Regex GrammarRegex = new(@"\'.*?\'|\s*[\w]+\s*", RegexOptions.Compiled);

        // cached grammar tokens: grammar string → array of (isLiteral, value)
        private static readonly ConcurrentDictionary<string, GrammarToken[]> _grammarTokenCache = new();

        private readonly record struct GrammarToken(bool IsLiteral, string Value);

        private static GrammarToken[] ParseGrammarTokens(string grammar)
        {
            return _grammarTokenCache.GetOrAdd(grammar, g =>
            {
                var matches = GrammarRegex.Matches(g);
                var tokens = new GrammarToken[matches.Count];
                for (int i = 0; i < matches.Count; i++)
                {
                    string s = matches[i].Value;
                    if (s[0] == '\'')
                    {
                        tokens[i] = new GrammarToken(true, s.Substring(1, s.Length - 2));
                    }
                    else
                    {
                        tokens[i] = new GrammarToken(false, s.Trim());
                    }
                }
                return tokens;
            });
        }

        /// <summary>
        /// TDT 2.2 Level Types.
        /// </summary>
        public enum LevelType
        {
            BINARY,
            TAG_ENCODING,
            PURE_IDENTITY,
            ELEMENT_STRING,
            BARE_IDENTIFIER,
            BARE_IDENTIFIER_ALT,
            GS1_DIGITAL_LINK,
            GS1_AI_JSON,
            TEI
        }

        /// <summary>
        /// Contains any errors encountered while loading scheme files.
        /// Inspect this property to debug missing or malformed schemes.
        /// </summary>
        public IReadOnlyList<string> LoadErrors => _loadErrors;
        private readonly List<string> _loadErrors = new List<string>();

        /// <summary>
        /// Creates a new TDTEngine instance and loads all scheme files.
        /// </summary>
        public TDTEngine()
        {

            var assembly = typeof(TDTEngine).GetTypeInfo().Assembly;
            var schemeFilenameStart = "TagDataTranslation.Schemes.";
            var tableFilenameStart = "TagDataTranslation.Tables.";
            var filterFilenameStart = "TagDataTranslation.FilterValueTables.";

            foreach (string filename in assembly.GetManifestResourceNames())
            {
                // load TDT 2.2 JSON schemes from Schemes folder
                if (filename.EndsWith(".json", StringComparison.CurrentCulture) && filename.StartsWith(schemeFilenameStart, StringComparison.CurrentCulture))
                {
                    using (var stream = assembly.GetManifestResourceStream(filename))
                    {
                        if (stream == null) continue;
                        try
                        {
                            var root = JsonSerializer.Deserialize(stream, TdtJsonContext.Default.TdtRoot);
                            if (root?.EpcTagDataTranslation?.Scheme != null)
                            {
                                epcTagDataTranslations.Add(root.EpcTagDataTranslation);
                            }
                        }
                        catch (JsonException ex)
                        {
                            _loadErrors.Add($"Failed to load scheme {filename}: {ex.Message}");
                        }
                    }
                }

                // Load Tables (F, K, E, B)
                if (filename.EndsWith(".json", StringComparison.CurrentCulture) && filename.StartsWith(tableFilenameStart, StringComparison.CurrentCulture))
                {
                    using (var stream = assembly.GetManifestResourceStream(filename))
                    {
                        if (stream == null) continue;
                        if (filename.Contains("TableF"))
                        {
                            tableF = TableLoader.LoadTableF(stream);
                        }
                        else if (filename.Contains("TableK"))
                        {
                            tableK = TableLoader.LoadTableK(stream);
                        }
                        else if (filename.Contains("TableE"))
                        {
                            tableE = TableLoader.LoadTableE(stream);
                        }
                        else if (filename.Contains("TableB"))
                        {
                            tableB = TableLoader.LoadTableB(stream);
                        }
                    }
                }

                // Load filter value tables
                if (filename.EndsWith(".csv", StringComparison.CurrentCulture) && filename.StartsWith(filterFilenameStart, StringComparison.CurrentCulture))
                {
                    using (var stream = assembly.GetManifestResourceStream(filename))
                    {
                        if (stream == null) continue;
                        using (StreamReader sr = new StreamReader(stream))
                        {
                            string scheme = filename.Split('.')[2].Split('-')[1];

                            filterValueTables.Add(scheme, new Dictionary<int, string>());

                            string? line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                int filterValue = int.Parse(line.Split(',')[0]);
                                string description = line.Split(',')[1].Trim('"');
                                filterValueTables[scheme].Add(filterValue, description);
                            }
                        }
                    }
                }

                // Load GCP prefix length table
                if (filename.EndsWith("gcpprefixformatlist.xml", StringComparison.CurrentCulture))
                {
                    using (var stream = assembly.GetManifestResourceStream(filename))
                    {
                        if (stream == null) continue;
                        var xdoc = XDocument.Load(stream);
                        gcpPrefixLengths = xdoc.Root!.Descendants().ToDictionary(k => (string)k.FirstAttribute!.Value, k => int.Parse(k.LastAttribute!.Value));
                    }
                }
            }

            encodedAICodec = new EncodedAICodec(tableF, tableB);
            variableLengthFieldCodec = new VariableLengthFieldCodec(tableB);
            aidcDataCodec = new AidcDataCodec(tableF, tableK, encodedAICodec);

            // pre-sort fields and rules so we don't sort on every call
            foreach (var translation in epcTagDataTranslations)
            {
                var scheme = translation.Scheme;
                if (scheme?.Level == null) continue;

                foreach (var level in scheme.Level)
                {
                    // pre-sort rules into extract and format lists
                    if (level.Rule != null)
                    {
                        level.ExtractRules = level.Rule
                            .Where(r => r.Type == "EXTRACT")
                            .OrderBy(r => r.Seq)
                            .ToList();
                        level.FormatRules = level.Rule
                            .Where(r => r.Type == "FORMAT")
                            .OrderBy(r => r.Seq)
                            .ToList();
                    }

                    // pre-sort fields by seq in each option
                    if (level.Option != null)
                    {
                        foreach (var option in level.Option)
                        {
                            option.Field?.Sort((a, b) => a.Seq.CompareTo(b.Seq));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Translates an EPC identifier to the specified output format.
        /// </summary>
        /// <param name="epcIdentifier">The input EPC identifier.</param>
        /// <param name="parameterList">Semicolon-separated list of key=value parameters.</param>
        /// <param name="outputFormat">The desired output format (e.g., "BINARY", "PURE_IDENTITY", "GS1_DIGITAL_LINK").</param>
        /// <returns>The translated EPC identifier string, or null if translation fails.</returns>
        public string? Translate(string epcIdentifier, string parameterList, string outputFormat)
        {
            var result = TranslateDetails(epcIdentifier, parameterList, outputFormat)?.Output;
            return string.IsNullOrEmpty(result) ? null : result;
        }

        /// <summary>
        /// Translates an EPC identifier and returns detailed results.
        /// </summary>
        /// <param name="epcIdentifier">The input EPC identifier.</param>
        /// <param name="parameterList">Semicolon-separated list of key=value parameters.</param>
        /// <param name="outputFormat">The desired output format.</param>
        /// <returns>Translation result with output and parameter dictionary, or null if translation fails.</returns>
        public TranslateResult? TranslateDetails(string epcIdentifier, string parameterList, string outputFormat)
        {
            var parameterDictionary = ProcessInput(epcIdentifier, parameterList);

            if (parameterDictionary == null)
            {
                return null;
            }

            var outputResult = ProcessOutput(parameterDictionary, outputFormat);

            // Return result even if output format translation fails
            // This allows the decoded fields to still be returned
            return new TranslateResult()
            {
                ParameterDictionary = parameterDictionary,
                Output = outputResult ?? ""  // empty if requested format isn't supported
            };
        }

        /// <summary>
        /// Attempts to translate an EPC identifier without throwing exceptions.
        /// </summary>
        /// <param name="epcIdentifier">The input EPC identifier.</param>
        /// <param name="parameterList">Semicolon-separated list of key=value parameters.</param>
        /// <param name="outputFormat">The desired output format (e.g., "BINARY", "PURE_IDENTITY", "GS1_DIGITAL_LINK").</param>
        /// <param name="result">When successful, contains the translated EPC identifier string; otherwise null.</param>
        /// <param name="errorCode">When translation fails, contains the error code; otherwise null.</param>
        /// <returns>True if translation succeeded; false otherwise.</returns>
        public bool TryTranslate(string epcIdentifier, string parameterList, string outputFormat, out string? result, out string? errorCode)
        {
            if (TryTranslateDetails(epcIdentifier, parameterList, outputFormat, out var translateResult, out errorCode))
            {
                result = translateResult?.Output;
                return result != null;
            }

            result = null;
            return false;
        }

        /// <summary>
        /// Attempts to translate an EPC identifier and returns detailed results without throwing exceptions.
        /// </summary>
        /// <param name="epcIdentifier">The input EPC identifier.</param>
        /// <param name="parameterList">Semicolon-separated list of key=value parameters.</param>
        /// <param name="outputFormat">The desired output format.</param>
        /// <param name="result">When successful, contains the translation result; otherwise null.</param>
        /// <param name="errorCode">When translation fails, contains the error code; otherwise null.</param>
        /// <returns>True if translation succeeded; false otherwise.</returns>
        public bool TryTranslateDetails(string epcIdentifier, string parameterList, string outputFormat, out TranslateResult? result, out string? errorCode)
        {
            try
            {
                result = TranslateDetails(epcIdentifier, parameterList, outputFormat);
                if (result == null)
                {
                    errorCode = "TDTSchemeNotFound";
                    return false;
                }
                errorCode = null;
                return true;
            }
            catch (TDTTranslationException ex)
            {
                result = null;
                errorCode = ex.Message;
                return false;
            }
            catch (Exception)
            {
                result = null;
                errorCode = "TDTUnknownError";
                return false;
            }
        }

        /// <summary>
        /// Processes the input EPC identifier and extracts field values.
        /// </summary>
        public Dictionary<string, string>? ProcessInput(string epcIdentifier, string parameterList)
        {
            // handle null input
            if (string.IsNullOrEmpty(epcIdentifier))
            {
                return null;
            }

            // 1. SETUP - Populate parameter dictionary
            Dictionary<string, string> parameterDictionary = new Dictionary<string, string>();
            if (parameterList != null)
            {
                try
                {
                    ParseInput(parameterList, parameterDictionary);
                }
                catch (Exception)
                {
                    throw new TDTTranslationException("TDTParameterErrorException");
                }
            }

            // 2. DETERMINE THE CODING SCHEME AND INBOUND REPRESENTATION LEVEL
            var inputLevelsSchemes = new Dictionary<Level, Scheme>();

            foreach (var translation in epcTagDataTranslations)
            {
                var scheme = translation.Scheme;
                if (scheme?.Level == null) continue;

                foreach (var level in scheme.Level)
                {
                    if (level.PrefixMatch == null) continue;

                    if (epcIdentifier.StartsWith(level.PrefixMatch, StringComparison.Ordinal))
                    {
                        // Check taglength parameter matches if specified
                        if (parameterDictionary.TryGetValue("taglength", out string? taglength))
                        {
                            bool isVarLength = taglength.Equals("var", StringComparison.OrdinalIgnoreCase);
                            bool schemeHasFixedLength = scheme.TagLength.HasValue && scheme.TagLength.Value > 0;

                            if (isVarLength)
                            {
                                // tagLength=var should match variable-length schemes (no fixed tagLength)
                                if (schemeHasFixedLength)
                                {
                                    continue;  // Skip fixed-length schemes when var is requested
                                }
                            }
                            else if (schemeHasFixedLength)
                            {
                                // Specific tagLength requested - must match scheme's tagLength
                                if (!taglength!.Equals(scheme.TagLength!.Value.ToString()))
                                {
                                    continue;  // Skip schemes with non-matching tagLength
                                }
                            }
                            else
                            {
                                // Specific tagLength requested but scheme has no fixed length
                                continue;  // Skip variable-length schemes when specific length requested
                            }
                        }

                        inputLevelsSchemes.Add(level, scheme);
                    }
                }
            }

            if (inputLevelsSchemes.Count == 0)
            {
                throw new TDTTranslationException("TDTSchemeNotFound");
            }

            // 3. DETERMINE THE OPTION THAT MATCHES THE INPUT VALUE
            Level? inputLevel = null;
            Scheme? inputScheme = null;
            Option? inputOption = null;

            // Sort by longest prefix matches
            inputLevelsSchemes = inputLevelsSchemes.OrderByDescending(i => i.Key.PrefixMatch?.Length ?? 0).ToDictionary(x => x.Key, y => y.Value);

            foreach (var kvp in inputLevelsSchemes)
            {
                Level level = kvp.Key;
                Scheme scheme = kvp.Value;

                foreach (var option in level.Option ?? Enumerable.Empty<Option>())
                {
                    // Check optionKey if specified
                    if (scheme.OptionKey != null)
                    {
                        string? value;

                        if (int.TryParse(scheme.OptionKey, out _))
                        {
                            value = scheme.OptionKey;
                        }
                        else
                        {
                            parameterDictionary.TryGetValue(scheme.OptionKey, out value);
                        }

                        if (value != null && option.OptionKey != value)
                        {
                            continue;
                        }
                    }

                    // match against the original input (patterns expect percent-encoded chars)
                    var pattern = option.Pattern ?? "";
                    var isMatch = GetCachedRegex(pattern).IsMatch(epcIdentifier);
                    if (isMatch)
                    {
                        inputScheme = scheme;
                        inputLevel = level;
                        inputOption = option;
                        break;
                    }
                }

                if (inputOption != null)
                {
                    break;
                }
            }

            if (inputOption == null || inputScheme == null || inputLevel == null)
            {
                throw new TDTTranslationException("TDTOptionNotFound");
            }

            // Add option key and scheme name to parameter dictionary
            parameterDictionary["optionKey"] = inputOption.OptionKey ?? "";
            parameterDictionary["schemeName"] = inputScheme.Name ?? "";
            if (!parameterDictionary.ContainsKey("taglength") && inputScheme.TagLength.HasValue)
            {
                parameterDictionary["taglength"] = inputScheme.TagLength.Value.ToString();
            }

            // Set the scheme's optionKey field (e.g., gs1companyprefixlength) to the matched option's key
            // This ensures the decoded result includes the actual GCP length used in the encoding
            if (!string.IsNullOrEmpty(inputScheme.OptionKey) && !string.IsNullOrEmpty(inputOption.OptionKey))
            {
                parameterDictionary[inputScheme.OptionKey] = inputOption.OptionKey;
            }

            // Check required parsing parameters
            if (inputLevel.RequiredParsingParameters != null)
            {
                foreach (string param in inputLevel.RequiredParsingParameters.Split(','))
                {
                    if (!parameterDictionary.ContainsKey(param))
                    {
                        throw new TDTTranslationException("TDTUndefinedField");
                    }
                }
            }

            // 4. PARSE THE INPUT VALUE TO EXTRACT VALUES FOR EACH FIELD
            var pattern2 = inputOption.Pattern ?? "";
            Match match = GetCachedRegex(pattern2).Match(epcIdentifier);

            if (!match.Success)
            {
                throw new TDTTranslationException("TDTOptionNotFound");
            }

            // fields are pre-sorted by seq at load time
            var fieldsSorted = inputOption.Field ?? new List<Field>();
            var inputLevelType = ParseLevelType(inputLevel.Type!);

            for (int i = 1; i <= fieldsSorted.Count; i++)
            {
                var inputField = fieldsSorted[i - 1];
                string name = inputField.Name ?? "";
                string variableElement = match.Groups[i].Value;

                // Validate character set
                if (inputField.CharacterSet != null)
                {
                    if (!RuleExecutor.ValidateCharacterset(variableElement, inputField.CharacterSet))
                    {
                        throw new TDTTranslationException("TDTFieldOutsideCharacterSet");
                    }
                }

                // Handle BINARY level
                if (inputLevelType == LevelType.BINARY)
                {
                    // Handle special encodings (e.g., dateYYMMDD for DSGTIN+)
                    if (!string.IsNullOrEmpty(inputField.Encoding))
                    {
                        if (inputField.Encoding.Equals("dateYYMMDD", StringComparison.OrdinalIgnoreCase))
                        {
                            variableElement = DecodeDateYYMMDD(variableElement);
                        }
                        else
                        {
                            // Unknown encoding, treat as numeric
                            variableElement = BinaryConverter.BinaryStringToBigInteger(variableElement).ToString();
                        }
                    }
                    else if (!string.IsNullOrEmpty(inputField.Compaction))
                    {
                        int compactionBits = GetCompactionBits(inputField.Compaction);
                        variableElement = DecompactBinaryToString(variableElement, compactionBits);
                        variableElement = variableElement.TrimEnd('\0').TrimEnd('@');
                    }
                    else if (inputField.BitLength.HasValue)
                    {
                        // Check if this is BCD encoding (only for ++ schemes)
                        // BCD is indicated when: scheme is ++, and bitLength == length * 4 (4 bits per digit)
                        bool isPlusPlusScheme = inputScheme.Name?.EndsWith("++") == true;
                        bool isBcd = isPlusPlusScheme &&
                                     inputField.Length.HasValue &&
                                     inputField.BitLength.Value == inputField.Length.Value * 4;

                        if (isBcd)
                        {
                            // BCD decoding: each 4 bits represents one decimal digit
                            var decodedBuilder = new StringBuilder();
                            for (int j = 0; j < variableElement.Length; j += 4)
                            {
                                if (j + 4 <= variableElement.Length)
                                {
                                    int digit = Convert.ToInt32(variableElement.Substring(j, 4), 2);
                                    decodedBuilder.Append(digit);
                                }
                            }
                            variableElement = decodedBuilder.ToString();
                        }
                        else
                        {
                            // Regular binary to decimal
                            variableElement = BinaryConverter.BinaryStringToBigInteger(variableElement).ToString();
                        }
                    }
                    else
                    {
                        variableElement = BinaryConverter.BinaryStringToBigInteger(variableElement).ToString();
                    }

                    // Handle padding from TAG_ENCODING level
                    var tagEncodingField = FindCorrespondingField(inputScheme, "TAG_ENCODING", inputOption.OptionKey ?? "", name);
                    variableElement = HandlePaddingOnDecode(variableElement, inputField, tagEncodingField);
                }

                // Validate minimum/maximum
                if (inputField.DecimalMinimum != null && variableElement.Length > 0)
                {
                    try
                    {
                        BigInteger integer = BigInteger.Parse(variableElement);
                        if (RuleExecutor.IsBelowMinimum(integer, inputField.DecimalMinimum))
                        {
                            throw new TDTTranslationException("TDTFieldBelowMinimum");
                        }
                    }
                    catch (TDTTranslationException)
                    {
                        throw;
                    }
                    catch (Exception)
                    {
                        throw new TDTTranslationException("TDTNumericOverflow");
                    }
                }

                if (inputField.DecimalMaximum != null && variableElement.Length > 0)
                {
                    try
                    {
                        BigInteger integer = BigInteger.Parse(variableElement);
                        if (RuleExecutor.IsAboveMaximum(integer, inputField.DecimalMaximum))
                        {
                            throw new TDTTranslationException("TDTFieldAboveMaximum");
                        }
                    }
                    catch (TDTTranslationException)
                    {
                        throw;
                    }
                    catch (Exception)
                    {
                        throw new TDTTranslationException("TDTNumericOverflow");
                    }
                }

                parameterDictionary[name] = variableElement;
            }

            // 4b. DECODE ENCODED AI DATA (for "+" schemes with BINARY input)
            int encodedAIBitsConsumed = 0;
            if (inputLevelType == LevelType.BINARY && inputOption.EncodedAI != null && inputOption.EncodedAI.Count > 0)
            {
                // Calculate the bit position where encodedAI data starts
                // The pattern matched the fixed fields, so we need to find where they end
                int fixedBitsLength = CalculateFixedBitsLength(inputOption);

                if (epcIdentifier.Length > fixedBitsLength)
                {
                    string encodedAIBinary = epcIdentifier.Substring(fixedBitsLength);
                    encodedAIBitsConsumed = encodedAICodec.DecodeEncodedAI(encodedAIBinary, inputOption.EncodedAI, parameterDictionary);
                }
            }

            // 4c. DECODE VARIABLE-LENGTH FIELDS (for "++" schemes with BINARY input, TDS 2.3)
            // Order matches the grammar: delimited numeric → variable-length alphanumeric/numeric → hostname
            // Also decodes +AIDC data when dataToggle=1
            if (inputLevelType == LevelType.BINARY)
            {
                int fixedBitsLength = CalculateFixedBitsLength(inputOption);
                int bitPosition = fixedBitsLength + encodedAIBitsConsumed;

                // Decode delimited numeric field first (e.g., giai, cpi) - comes before other variable fields
                if (inputOption.DelimitedNumericField != null && epcIdentifier.Length > bitPosition)
                {
                    string remainingBinary = epcIdentifier.Substring(bitPosition);
                    var (value, bitsConsumed) = variableLengthFieldCodec.DecodeDelimitedNumericField(remainingBinary, inputOption.DelimitedNumericField);
                    if (value != null)
                    {
                        parameterDictionary[inputOption.DelimitedNumericField.Name ?? "value"] = value;
                        bitPosition += bitsConsumed;
                    }
                }

                // Decode variable-length alphanumeric field (e.g., serial)
                if (inputOption.VariableLengthField != null && epcIdentifier.Length > bitPosition)
                {
                    string remainingBinary = epcIdentifier.Substring(bitPosition);
                    var (value, bitsConsumed) = variableLengthFieldCodec.DecodeVariableLengthField(remainingBinary, inputOption.VariableLengthField);
                    if (value != null)
                    {
                        parameterDictionary[inputOption.VariableLengthField.Name ?? "serial"] = value;
                        bitPosition += bitsConsumed;
                    }
                }

                // Decode variable-length numeric field (e.g., serial for CPI++/SGCN++)
                if (inputOption.VariableLengthNumericField != null && epcIdentifier.Length > bitPosition)
                {
                    string remainingBinary = epcIdentifier.Substring(bitPosition);
                    var (value, bitsConsumed) = variableLengthFieldCodec.DecodeVariableLengthNumericField(remainingBinary, inputOption.VariableLengthNumericField);
                    if (value != null)
                    {
                        parameterDictionary[inputOption.VariableLengthNumericField.Name ?? "serialNumber"] = value;
                        bitPosition += bitsConsumed;
                    }
                }

                // Decode hostname field (for ++ schemes) - always last EPC field
                if (inputOption.HostnameField != null && epcIdentifier.Length > bitPosition)
                {
                    string remainingBinary = epcIdentifier.Substring(bitPosition);
                    var hostname = VariableLengthFieldCodec.DecodeHostnameField(remainingBinary);
                    if (hostname != null)
                    {
                        parameterDictionary[inputOption.HostnameField.Name ?? "hostname"] = hostname;
                        bitPosition += HostnameEncoder.CalculateBitLength(remainingBinary);
                    }
                }

                // 4d. DECODE +AIDC DATA (TDS 2.3 Section 15.3)
                // when dataToggle=1 and there are remaining bits after the EPC
                if (parameterDictionary.TryGetValue("datatoggle", out var dataToggle) &&
                    dataToggle == "1" &&
                    bitPosition < epcIdentifier.Length)
                {
                    string aidcBinary = epcIdentifier.Substring(bitPosition);
                    if (aidcBinary.Length >= 8)
                    {
                        var aidcEntries = aidcDataCodec.Decode(aidcBinary);
                        foreach (var entry in aidcEntries)
                        {
                            parameterDictionary[$"aidc_{entry.AI}"] = entry.Value;
                        }
                    }
                }
            }

            // 5. PERFORM EXTRACT RULES
            if (inputLevel.ExtractRules != null)
            {
                RuleExecutor.ExecuteRules(inputLevel.ExtractRules, parameterDictionary);
            }

            // 5.5. Handle scheme-specific field conversions for '++' schemes
            var schemeName = parameterDictionary.GetValueOrDefault("schemeName", "");
            if (schemeName == "DSGTIN++")
            {
                PlusPlusFieldConverter.ExtractDateFromDateBinary(parameterDictionary);
            }
            else if (schemeName == "ITIP++")
            {
                PlusPlusFieldConverter.ExtractItipFieldsFromItipBinary(parameterDictionary);
            }

            return parameterDictionary;
        }

        /// <summary>
        /// Processes the output format and generates the translated EPC identifier.
        /// </summary>
        private string? ProcessOutput(Dictionary<string, string> parameterDictionary, string outputFormat)
        {
            // Parse output format type
            LevelType outputFormatType;
            try
            {
                outputFormatType = ParseLevelType(outputFormat);
            }
            catch (Exception)
            {
                throw new TDTTranslationException("TDTOutputFormatUnknownException");
            }

            // 6. FIND THE CORRESPONDING OPTION IN THE OUTBOUND REPRESENTATION
            Scheme? outputScheme = null;
            Level? outputLevel = null;
            Option? outputOption = null;

            foreach (var e in epcTagDataTranslations)
            {
                var s = e.Scheme;
                if (s?.Name != parameterDictionary["schemeName"]) continue;

                outputScheme = s;

                foreach (var l in s.Level ?? Enumerable.Empty<Level>())
                {
                    if (l.Type == null || ParseLevelType(l.Type) != outputFormatType) continue;

                    outputLevel = l;

                    foreach (var o in l.Option ?? Enumerable.Empty<Option>())
                    {
                        if (o.OptionKey == parameterDictionary["optionKey"])
                        {
                            outputOption = o;
                        }
                    }
                }
            }

            if (outputLevel == null || outputOption == null || outputScheme == null)
            {
                throw new TDTTranslationException("TDTLevelNotFound");
            }

            // Check required formatting parameters (case-insensitive)
            if (outputLevel.RequiredFormattingParameters != null)
            {
                foreach (string s in outputLevel.RequiredFormattingParameters.Split(','))
                {
                    var paramName = s.Trim().ToLower();
                    if (!parameterDictionary.ContainsKey(paramName))
                    {
                        // Provide default for uriStem
                        if (paramName == "uristem")
                        {
                            parameterDictionary["uristem"] = "https://id.gs1.org";
                            continue;
                        }
                        throw new TDTTranslationException("TDTUndefinedField");
                    }
                }
            }

            // 7. PERFORM FORMAT RULES
            if (outputLevel.FormatRules != null)
            {
                RuleExecutor.ExecuteRules(outputLevel.FormatRules, parameterDictionary);
            }

            // 7.5. Handle DSGTIN++/ITIP++ date binary conversion
            if (outputScheme?.Name == "DSGTIN++" && outputFormatType == LevelType.BINARY)
            {
                PlusPlusFieldConverter.ComputeDsgtinPlusPlusDateBinary(parameterDictionary);
            }
            else if (outputScheme?.Name == "ITIP++" && outputFormatType == LevelType.BINARY)
            {
                PlusPlusFieldConverter.ComputeItipPlusPlusItipBinary(parameterDictionary);
            }

            // 8. BUILD OUTPUT VALUE FROM GRAMMAR STRING
            string grammarstring = outputOption.Grammar ?? "";

            StringBuilder outputString = new StringBuilder(128);

            var tokens = ParseGrammarTokens(grammarstring);

            foreach (var token in tokens)
            {
                if (token.IsLiteral)
                {
                    outputString.Append(token.Value);
                }
                else
                {
                    string s = token.Value;

                    // Handle encodedAI token for "+" schemes (SGTIN+, SSCC+, GRAI+, etc.)
                    if (s.Equals("encodedAI", StringComparison.OrdinalIgnoreCase) && outputOption.EncodedAI != null)
                    {
                        var encodedAIBits = encodedAICodec.ProcessEncodedAI(outputOption.EncodedAI, parameterDictionary);
                        outputString.Append(encodedAIBits);
                        continue;
                    }

                    // Handle serialEncoded token for "++" schemes (TDS 2.3)
                    if (s.Equals("serialEncoded", StringComparison.OrdinalIgnoreCase) && outputOption.VariableLengthField != null)
                    {
                        if (parameterDictionary.TryGetValue(outputOption.VariableLengthField.Name ?? "serial", out var serialValue))
                        {
                            var serialBits = variableLengthFieldCodec.EncodeVariableLengthField(serialValue, outputOption.VariableLengthField);
                            outputString.Append(serialBits);
                        }
                        continue;
                    }

                    // Handle serialNumericEncoded token for "++" schemes with numeric serial (SGCN++, CPI++)
                    if (s.Equals("serialNumericEncoded", StringComparison.OrdinalIgnoreCase) && outputOption.VariableLengthNumericField != null)
                    {
                        if (parameterDictionary.TryGetValue(outputOption.VariableLengthNumericField.Name ?? "serialNumber", out var serialValue))
                        {
                            var serialBits = variableLengthFieldCodec.EncodeVariableLengthNumericField(serialValue, outputOption.VariableLengthNumericField);
                            outputString.Append(serialBits);
                        }
                        continue;
                    }

                    // Handle extensionEncoded, glnExtensionEncoded, etc. tokens (suffix "Encoded")
                    if (s.EndsWith("Encoded", StringComparison.OrdinalIgnoreCase) && !s.Equals("hostnameEncoded", StringComparison.OrdinalIgnoreCase))
                    {
                        // Find the field name by removing "Encoded" suffix (7 chars)
                        var fieldName = s.Substring(0, s.Length - 7);

                        // Try to find the corresponding variable-length field definition
                        if (outputOption.VariableLengthField != null &&
                            outputOption.VariableLengthField.Name?.Equals(fieldName, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (parameterDictionary.TryGetValue(fieldName, out var fieldValue))
                            {
                                var bits = variableLengthFieldCodec.EncodeVariableLengthField(fieldValue, outputOption.VariableLengthField);
                                outputString.Append(bits);
                            }
                            continue;
                        }
                        else if (outputOption.VariableLengthNumericField != null &&
                                 outputOption.VariableLengthNumericField.Name?.Equals(fieldName, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (parameterDictionary.TryGetValue(fieldName, out var fieldValue))
                            {
                                var bits = variableLengthFieldCodec.EncodeVariableLengthNumericField(fieldValue, outputOption.VariableLengthNumericField);
                                outputString.Append(bits);
                            }
                            continue;
                        }
                        else if (outputOption.DelimitedNumericField != null &&
                                 outputOption.DelimitedNumericField.Name?.Equals(fieldName, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (parameterDictionary.TryGetValue(fieldName, out var fieldValue))
                            {
                                var bits = variableLengthFieldCodec.EncodeDelimitedNumericField(fieldValue, outputOption.DelimitedNumericField);
                                outputString.Append(bits);
                            }
                            continue;
                        }
                    }

                    // Handle giaiBinary, cpiBinary, etc. tokens (suffix "Binary" - 6 chars)
                    if (s.EndsWith("Binary", StringComparison.OrdinalIgnoreCase) && s.Length > 6)
                    {
                        // Find the field name by removing "Binary" suffix (6 chars)
                        var fieldName = s.Substring(0, s.Length - 6);

                        // Try to find the corresponding delimited numeric field definition
                        if (outputOption.DelimitedNumericField != null &&
                            outputOption.DelimitedNumericField.Name?.Equals(fieldName, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (parameterDictionary.TryGetValue(fieldName, out var fieldValue))
                            {
                                var bits = variableLengthFieldCodec.EncodeDelimitedNumericField(fieldValue, outputOption.DelimitedNumericField);
                                outputString.Append(bits);
                            }
                            continue;
                        }
                    }

                    // Handle serialNumeric, etc. tokens (suffix "Numeric" - 7 chars)
                    if (s.EndsWith("Numeric", StringComparison.OrdinalIgnoreCase) && s.Length > 7)
                    {
                        // Find the field name by removing "Numeric" suffix (7 chars)
                        var fieldName = s.Substring(0, s.Length - 7);

                        // Try to find the corresponding variable-length numeric field definition
                        if (outputOption.VariableLengthNumericField != null &&
                            outputOption.VariableLengthNumericField.Name?.Equals(fieldName, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (parameterDictionary.TryGetValue(fieldName, out var fieldValue))
                            {
                                var bits = variableLengthFieldCodec.EncodeVariableLengthNumericField(fieldValue, outputOption.VariableLengthNumericField);
                                outputString.Append(bits);
                            }
                            continue;
                        }
                    }

                    // Handle hostnameEncoded token for "++" schemes (TDS 2.3)
                    if (s.Equals("hostnameEncoded", StringComparison.OrdinalIgnoreCase) && outputOption.HostnameField != null)
                    {
                        if (parameterDictionary.TryGetValue(outputOption.HostnameField.Name ?? "hostname", out var hostnameValue))
                        {
                            var hostnameBits = HostnameEncoder.Encode(hostnameValue);
                            outputString.Append(hostnameBits);
                        }
                        continue;
                    }

                    string? variableElement;
                    if (!parameterDictionary.TryGetValue(s, out variableElement))
                    {
                        // Try case-insensitive lookup
                        var key = parameterDictionary.Keys.FirstOrDefault(k => k.Equals(s, StringComparison.OrdinalIgnoreCase));
                        if (key != null)
                        {
                            variableElement = parameterDictionary[key];
                        }
                        else
                        {
                            return null;
                        }
                    }

                    // Handle BINARY output
                    if (outputFormatType == LevelType.BINARY)
                    {
                        var tagEncodingField = FindCorrespondingField(outputScheme!, "TAG_ENCODING", outputOption.OptionKey ?? "", s);
                        var binaryField = outputOption.Field?.FirstOrDefault(f => f.Name == s);

                        variableElement = HandlePaddingOnEncode(variableElement ?? "", tagEncodingField, binaryField);

                        // Handle special encodings (e.g., dateYYMMDD for DSGTIN+)
                        if (binaryField != null && !string.IsNullOrEmpty(binaryField.Encoding))
                        {
                            if (binaryField.Encoding.Equals("dateYYMMDD", StringComparison.OrdinalIgnoreCase))
                            {
                                variableElement = EncodeDateYYMMDD(variableElement, binaryField.BitLength ?? 16);
                            }
                            else
                            {
                                // Unknown encoding, treat as numeric
                                Int64 result;
                                if (!Int64.TryParse(variableElement, out result))
                                {
                                    result = 0;
                                }
                                variableElement = Convert.ToString(result, 2);
                            }
                        }
                        else if (binaryField != null && !string.IsNullOrEmpty(binaryField.Compaction))
                        {
                            int compactionBits = GetCompactionBits(binaryField.Compaction);
                            variableElement = CompactStringToBinary(variableElement, compactionBits);
                        }
                        else if (binaryField != null && binaryField.BitLength.HasValue)
                        {
                            // Check if this should be BCD encoding (only for ++ schemes)
                            // BCD is indicated when: scheme is ++, and bitLength == length * 4 (4 bits per digit)
                            bool isPlusPlusScheme = outputScheme?.Name?.EndsWith("++") == true;
                            bool useBcd = isPlusPlusScheme &&
                                          binaryField.Length.HasValue &&
                                          binaryField.BitLength.Value == binaryField.Length.Value * 4 &&
                                          variableElement.All(char.IsDigit);

                            if (useBcd)
                            {
                                // BCD encoding: 4 bits per decimal digit
                                var bcdBuilder = new StringBuilder();
                                foreach (char digitChar in variableElement.PadLeft(binaryField.Length!.Value, '0'))
                                {
                                    int digit = digitChar - '0';
                                    bcdBuilder.Append(Convert.ToString(digit, 2).PadLeft(4, '0'));
                                }
                                variableElement = bcdBuilder.ToString();
                            }
                            else if (BigInteger.TryParse(variableElement, out var result))
                            {
                                // Regular binary encoding
                                variableElement = EncodedAICodec.ToBinaryString(result).PadLeft(binaryField.BitLength.Value, '0');
                            }
                            else
                            {
                                variableElement = new string('0', binaryField.BitLength.Value);
                            }
                        }
                        else
                        {
                            BigInteger result;
                            if (!BigInteger.TryParse(variableElement, out result))
                            {
                                result = 0;
                            }
                            variableElement = EncodedAICodec.ToBinaryString(result);
                        }

                        // Handle bit padding for non-BCD fields
                        if (binaryField?.BitPadDir != null && binaryField.BitLength.HasValue &&
                            variableElement.Length < binaryField.BitLength.Value)
                        {
                            if (binaryField.BitPadDir.Equals("LEFT", StringComparison.OrdinalIgnoreCase))
                            {
                                variableElement = variableElement.PadLeft(binaryField.BitLength.Value, '0');
                            }
                            else
                            {
                                variableElement = variableElement.PadRight(binaryField.BitLength.Value, '0');
                            }
                        }
                    }
                    else
                    {
                        // Validate and format field for non-binary output
                        var field = outputOption.Field?.FirstOrDefault(f => f.Name == s);
                        if (field?.CharacterSet != null)
                        {
                            if (!RuleExecutor.ValidateCharacterset(variableElement, field.CharacterSet))
                            {
                                throw new TDTTranslationException("TDTFieldOutsideCharacterSet");
                            }
                        }

                        // Apply padding if specified in output field definition
                        if (field != null && field.Length.HasValue && !string.IsNullOrEmpty(field.PadChar))
                        {
                            char padChar = field.PadChar[0];
                            if (field.PadDir?.Equals("LEFT", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                variableElement = variableElement.PadLeft(field.Length.Value, padChar);
                            }
                            else
                            {
                                variableElement = variableElement.PadRight(field.Length.Value, padChar);
                            }
                        }
                    }

                    // Apply URI encoding for PURE_IDENTITY and TAG_ENCODING
                    // Skip encoding for fields that are already escaped/encoded (contain "Escaped" or "Encoded" in name)
                    if ((outputFormatType == LevelType.PURE_IDENTITY || outputFormatType == LevelType.TAG_ENCODING) &&
                        !s.Contains("Escaped", StringComparison.OrdinalIgnoreCase) &&
                        !s.Contains("Encoded", StringComparison.OrdinalIgnoreCase))
                    {
                        variableElement = UriEncoder.UrnEncode(variableElement);
                    }
                    // URL encoding for GS1_DIGITAL_LINK is handled by rules (URLENCODE function)
                    // DO NOT auto-encode here - the grammar may include uriStem which should not be encoded

                    outputString.Append(variableElement);
                }
            }

            // Encode +AIDC data for BINARY output (TDS 2.3 Section 15.3)
            if (outputFormatType == LevelType.BINARY)
            {
                var aidcEntries = CollectAidcEntries(parameterDictionary);
                if (aidcEntries.Count > 0)
                {
                    // set dataToggle=1 if not already set
                    parameterDictionary["datatoggle"] = "1";

                    string aidcBinary = aidcDataCodec.Encode(aidcEntries);
                    int totalBits = outputString.Length + aidcBinary.Length;

                    if (totalBits > 496)
                    {
                        throw new TDTTranslationException("TDTAidcDataExceeds496Bits");
                    }

                    outputString.Append(aidcBinary);
                }

                // pad to 16-bit word boundary
                int remainder = outputString.Length % 16;
                if (remainder != 0)
                {
                    outputString.Append(new string('0', 16 - remainder));
                }
            }

            // Handle special outputs
            if (outputFormatType == LevelType.GS1_AI_JSON)
            {
                return FormatAsAiJson(parameterDictionary, outputOption);
            }

            // Append AIDC data to non-BINARY output formats
            if (outputFormatType != LevelType.BINARY)
            {
                var aidcEntries = CollectAidcEntries(parameterDictionary);
                if (aidcEntries.Count > 0)
                {
                    if (outputFormatType == LevelType.GS1_DIGITAL_LINK)
                    {
                        // append AIDC AIs as query parameters
                        var output = outputString.ToString();
                        char separator = output.Contains('?') ? '&' : '?';
                        foreach (var entry in aidcEntries)
                        {
                            outputString.Append(separator);
                            outputString.Append(entry.AI);
                            outputString.Append('=');
                            outputString.Append(Uri.EscapeDataString(entry.Value));
                            separator = '&';
                        }
                    }
                    else if (outputFormatType == LevelType.BARE_IDENTIFIER ||
                             outputFormatType == LevelType.BARE_IDENTIFIER_ALT)
                    {
                        // append as ;aidc:AI=VALUE
                        foreach (var entry in aidcEntries)
                        {
                            outputString.Append(";aidc:");
                            outputString.Append(entry.AI);
                            outputString.Append('=');
                            outputString.Append(entry.Value);
                        }
                    }
                }
            }

            return outputString.ToString();
        }


        #region Hex/Binary Conversion

        /// <summary>
        /// Converts a hexadecimal string to binary.
        /// </summary>
        public string HexToBinary(string hex) => BinaryConverter.HexToBinary(hex);

        /// <summary>
        /// Converts a binary string to hexadecimal.
        /// </summary>
        public string BinaryToHex(string binary) => BinaryConverter.BinaryToHex(binary);

        #endregion

        #region Helper Methods

        private void ParseInput(string input, Dictionary<string, string> parameterDictionary)
        {
            if (input.Length > 0)
            {
                foreach (string s in input.Split(';'))
                {
                    var idx = s.IndexOf('=');
                    if (idx > 0)
                    {
                        parameterDictionary[s.Substring(0, idx).Trim().ToLower()] = s.Substring(idx + 1).Trim();
                    }
                }
            }
        }

        /// <summary>
        /// Gets the GCP prefix length for a given input string.
        /// </summary>
        public PrefixLengthResult GetPrefixLength(string input)
        {
            var prefixLength = gcpPrefixLengths.Where(x => input.StartsWith(x.Key, StringComparison.Ordinal)).FirstOrDefault();

            return new PrefixLengthResult() { Prefix = prefixLength.Key, Length = prefixLength.Value };
        }

        /// <summary>
        /// Gets the filter value table for a scheme.
        /// </summary>
        public Dictionary<int, string> GetFilterValueTable(string scheme)
        {
            var filterValueTable = new Dictionary<int, string>();
            scheme = scheme.ToUpper();

            if (filterValueTables.ContainsKey(scheme))
            {
                filterValueTable = filterValueTables[scheme];
            }

            return filterValueTable;
        }

        private LevelType ParseLevelType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException("Level type cannot be null or empty");
            }

            return type.ToUpper() switch
            {
                "BINARY" => LevelType.BINARY,
                "TAG_ENCODING" => LevelType.TAG_ENCODING,
                "PURE_IDENTITY" => LevelType.PURE_IDENTITY,
                "ELEMENT_STRING" => LevelType.ELEMENT_STRING,
                "BARE_IDENTIFIER" => LevelType.BARE_IDENTIFIER,
                "BARE_IDENTIFIER_ALT" => LevelType.BARE_IDENTIFIER_ALT,
                "GS1_DIGITAL_LINK" => LevelType.GS1_DIGITAL_LINK,
                "GS1_AI_JSON" => LevelType.GS1_AI_JSON,
                "TEI" => LevelType.TEI,
                // Legacy mappings for backward compatibility
                "LEGACY" => LevelType.BARE_IDENTIFIER,
                "LEGACY_ALT" => LevelType.BARE_IDENTIFIER_ALT,
                "LEGACY_AI" => LevelType.ELEMENT_STRING,
                _ => throw new ArgumentException($"Unknown level type: {type}")
            };
        }

        private Field? FindCorrespondingField(Scheme scheme, string levelType, string optionKey, string fieldName)
        {
            if (scheme.Level == null) return null;

            foreach (var l in scheme.Level)
            {
                if (l.Type?.ToUpper() != levelType?.ToUpper()) continue;

                foreach (var o in l.Option ?? Enumerable.Empty<Option>())
                {
                    if (o.OptionKey == optionKey)
                    {
                        return o.Field?.FirstOrDefault(f => f.Name == fieldName);
                    }
                }
            }
            return null;
        }

        private int GetCompactionBits(string compaction)
        {
            return compaction?.ToLower() switch
            {
                "5-bit" or "5bit" => 5,
                "6-bit" or "6bit" => 6,
                "7-bit" or "7bit" => 7,
                "8-bit" or "8bit" => 8,
                _ => 8
            };
        }

        private string DecompactBinaryToString(string binary, int compactionBits)
        {
            List<byte> byteList = new List<byte>();
            for (int j = 0; j < binary.Length; j += compactionBits)
            {
                if (j + compactionBits <= binary.Length)
                {
                    string character = binary.Substring(j, compactionBits);
                    if (compactionBits == 5)
                    {
                        character = "010" + character;
                    }
                    else if (compactionBits == 6)
                    {
                        if (character[0] == '1')
                        {
                            character = "00" + character;
                        }
                        else
                        {
                            character = "01" + character;
                        }
                    }
                    byteList.Add(Convert.ToByte(character, 2));
                }
            }

            return System.Text.Encoding.UTF8.GetString(byteList.ToArray(), 0, byteList.Count);
        }

        /// <summary>
        /// Encodes a YYMMDD date string to binary representation.
        /// Uses TDS 2.3 packed date encoding: YY(7) + MM(4) + DD(5) = 16 bits.
        /// </summary>
        private string EncodeDateYYMMDD(string yymmdd, int bitLength)
        {
            return EncodedAICodec.PackDateYYMMDD(yymmdd);
        }

        /// <summary>
        /// Decodes a binary date representation back to YYMMDD format.
        /// Uses TDS 2.3 packed date encoding: YY(7) + MM(4) + DD(5) = 16 bits.
        /// </summary>
        private string DecodeDateYYMMDD(string binary)
        {
            return EncodedAICodec.UnpackDateYYMMDD(binary);
        }

        private string CompactStringToBinary(string text, int compactionBits)
        {
            StringBuilder bits = new StringBuilder();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);

            foreach (byte b in bytes)
            {
                string binary = Convert.ToString(b, 2);
                if (binary.Length > compactionBits)
                {
                    binary = binary.Substring(binary.Length - compactionBits);
                }
                else if (binary.Length < compactionBits)
                {
                    binary = binary.PadLeft(compactionBits, '0');
                }
                bits.Append(binary);
            }

            return bits.ToString();
        }

        private string HandlePaddingOnDecode(string value, Field? inputField, Field? tagEncodingField)
        {
            bool padCharInBinary = inputField?.PadChar != null;
            bool padCharInTagEncoding = tagEncodingField?.PadChar != null;

            if (padCharInBinary && !padCharInTagEncoding)
            {
                if (inputField!.PadDir?.ToUpper() == "LEFT")
                {
                    value = value.TrimStart(inputField.PadChar![0]);
                }
                else
                {
                    value = value.TrimEnd(inputField.PadChar![0]);
                }
            }

            if (!padCharInBinary && padCharInTagEncoding)
            {
                if (tagEncodingField!.PadDir?.ToUpper() == "LEFT")
                {
                    value = value.PadLeft(tagEncodingField.Length ?? 0, tagEncodingField.PadChar![0]);
                }
                else
                {
                    value = value.PadRight(tagEncodingField.Length ?? 0, tagEncodingField!.PadChar![0]);
                }

                if ((tagEncodingField.Length ?? 0) == 0)
                {
                    value = "";
                }
            }

            return value;
        }

        private string HandlePaddingOnEncode(string value, Field? tagEncodingField, Field? binaryField)
        {
            bool padCharInTagEncoding = tagEncodingField?.PadChar != null;
            bool padCharInBinary = binaryField?.PadChar != null;

            if (padCharInTagEncoding && !padCharInBinary)
            {
                if (tagEncodingField!.PadDir?.ToUpper() == "LEFT")
                {
                    value = value.TrimStart(tagEncodingField.PadChar![0]);
                }
                else
                {
                    value = value.TrimEnd(tagEncodingField!.PadChar![0]);
                }
            }

            if (!padCharInTagEncoding && padCharInBinary)
            {
                if (binaryField!.PadDir?.ToUpper() == "LEFT")
                {
                    value = value.PadLeft(binaryField.Length ?? 0, binaryField.PadChar![0]);
                }
                else
                {
                    value = value.PadRight(binaryField!.Length ?? 0, binaryField.PadChar![0]);
                }
            }

            return value;
        }

        #endregion

        #region Bit Length Calculation

        /// <summary>
        /// Calculates the total bit length of fixed fields in a BINARY option.
        /// This is used to find where the encodedAI data starts.
        /// </summary>
        private int CalculateFixedBitsLength(Option option)
        {
            if (option?.Grammar == null)
            {
                return 0;
            }

            // Parse the grammar to count fixed bits
            // Grammar format: "'11111011' dataToggle filter '0100' expDate encodedAI"
            int totalBits = 0;
            var tokens = ParseGrammarTokens(option.Grammar);

            foreach (var token in tokens)
            {
                if (token.IsLiteral)
                {
                    // Literal binary string - count its bits
                    string literal = token.Value;
                    if (literal.All(ch => ch == '0' || ch == '1'))
                    {
                        totalBits += literal.Length;
                    }
                }
                else
                {
                    string s = token.Value;
                    if (s.Equals("encodedAI", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith("Encoded", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith("Binary", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith("Numeric", StringComparison.OrdinalIgnoreCase))
                    {
                        // stop counting - these tokens represent variable-length fields
                        break;
                    }

                    // Find the field in the option's field list
                    var field = option.Field?.FirstOrDefault(f => f.Name?.Equals(s, StringComparison.OrdinalIgnoreCase) == true);
                    if (field?.BitLength != null)
                    {
                        totalBits += field.BitLength.Value;
                    }
                }
            }

            return totalBits;
        }

        #endregion

        #region Helper Methods - Output Formatting

        private string FormatAsAiJson(Dictionary<string, string> parameterDictionary, Option outputOption)
        {
            var aiSequence = outputOption.AiSequence ?? new List<string>();
            var jsonObject = new Dictionary<string, string>();

            // Map field names to AI codes
            var aiToFieldMapping = new Dictionary<string, string>
            {
                { "01", "gtin" },
                { "21", "serial" },
                { "10", "batchlot" },
                { "17", "expirydate" },
                { "22", "cpv" },
                { "00", "sscc" },
                { "414", "gln" },
                { "254", "glnextension" },
                { "8003", "grai" },
                { "8004", "giai" },
                { "8017", "gsrnp" },
                { "8018", "gsrn" },
                { "253", "gdti" },
                { "255", "gcn" },
                { "8006", "itip" },
                { "35", "generalmanager" },
                { "36", "objectclass" },
                { "37", "serialnumber" }
            };

            foreach (var ai in aiSequence)
            {
                if (aiToFieldMapping.TryGetValue(ai, out string? fieldName))
                {
                    if (parameterDictionary.TryGetValue(fieldName!, out string? fieldValue))
                    {
                        jsonObject[ai] = fieldValue;
                    }
                }
            }

            // include AIDC entries
            var aidcEntries = CollectAidcEntries(parameterDictionary);
            foreach (var entry in aidcEntries)
            {
                jsonObject[entry.AI] = entry.Value;
            }

            return JsonSerializer.Serialize(jsonObject, TdtJsonContext.Default.DictionaryStringString);
        }

        /// <summary>
        /// Collects aidc_* parameters from the dictionary into AidcEntry objects.
        /// </summary>
        private static List<Models.AidcEntry> CollectAidcEntries(Dictionary<string, string> parameterDictionary)
        {
            var entries = new List<Models.AidcEntry>();
            foreach (var kvp in parameterDictionary)
            {
                if (kvp.Key.StartsWith("aidc_", StringComparison.Ordinal) && kvp.Key.Length > 5)
                {
                    entries.Add(new Models.AidcEntry
                    {
                        AI = kvp.Key.Substring(5),
                        Value = kvp.Value
                    });
                }
            }
            return entries;
        }

        #endregion

        #region Table Access

        /// <summary>
        /// Gets Table F for AI encoding formats.
        /// </summary>
        public TableF GetTableF() => tableF;

        /// <summary>
        /// Gets Table K for AI key lengths.
        /// </summary>
        public TableK GetTableK() => tableK;

        /// <summary>
        /// Gets Table E for encoding methods.
        /// </summary>
        public TableE GetTableE() => tableE;

        /// <summary>
        /// Gets Table B for bit length mappings.
        /// </summary>
        public TableB GetTableB() => tableB;

        #endregion
    }
}
