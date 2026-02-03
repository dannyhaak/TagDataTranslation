using System;
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
    /// </summary>
    public class TDTEngine
    {
        // TDT 2.2 JSON scheme data
        private readonly List<EpcTagDataTranslation2> epcTagDataTranslations2 = new List<EpcTagDataTranslation2>();

        // GCP prefix length lookup
        private readonly Dictionary<string, int> gcpPrefixLengths = new Dictionary<string, int>();

        // Filter value tables
        private readonly Dictionary<string, Dictionary<int, string>> filterValueTables = new Dictionary<string, Dictionary<int, string>>();

        // TDT 2.2 Tables
        private TableF tableF;
        private TableK tableK;
        private TableE tableE;
        private TableB tableB;

        // JSON serialization options
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

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
        /// Creates a new TDTEngine instance and loads all scheme files.
        /// </summary>
        public TDTEngine()
        {
            Console.WriteLine("[TagDataTranslation] This library is free for non-commercial use only. Please contact tdt@mimasu.nl for licensing information.");

            var assembly = typeof(TDTEngine).GetTypeInfo().Assembly;
            var schemeFilenameStart = "TagDataTranslation.Schemes2.";
            var tableFilenameStart = "TagDataTranslation.Tables.";
            var filterFilenameStart = "TagDataTranslation.FilterValueTables.";

            foreach (string filename in assembly.GetManifestResourceNames())
            {
                // Load TDT 2.2 JSON schemes from Schemes2 folder
                if (filename.EndsWith(".json", StringComparison.CurrentCulture) && filename.StartsWith(schemeFilenameStart, StringComparison.CurrentCulture))
                {
                    using (var stream = assembly.GetManifestResourceStream(filename))
                    {
                        try
                        {
                            var root = JsonSerializer.Deserialize<TdtRoot>(stream, JsonOptions);
                            if (root?.EpcTagDataTranslation?.Scheme != null)
                            {
                                epcTagDataTranslations2.Add(root.EpcTagDataTranslation);
                            }
                        }
                        catch (JsonException ex)
                        {
                            Console.WriteLine($"[TagDataTranslation] Failed to load scheme {filename}: {ex.Message}");
                        }
                    }
                }

                // Load Tables (F, K, E, B)
                if (filename.EndsWith(".json", StringComparison.CurrentCulture) && filename.StartsWith(tableFilenameStart, StringComparison.CurrentCulture))
                {
                    using (var stream = assembly.GetManifestResourceStream(filename))
                    {
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
                        using (StreamReader sr = new StreamReader(stream))
                        {
                            string scheme = filename.Split('.')[2].Split('-')[1];

                            filterValueTables.Add(scheme, new Dictionary<int, string>());

                            while (sr.Peek() >= 0)
                            {
                                string line = sr.ReadLine();
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
                        var xdoc = XDocument.Load(stream);
                        gcpPrefixLengths = xdoc.Root.Descendants().ToDictionary(k => (string)k.FirstAttribute.Value, k => int.Parse(k.LastAttribute.Value));
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
        public string Translate(string epcIdentifier, string parameterList, string outputFormat)
        {
            return TranslateDetails(epcIdentifier, parameterList, outputFormat)?.Output;
        }

        /// <summary>
        /// Translates an EPC identifier and returns detailed results.
        /// </summary>
        /// <param name="epcIdentifier">The input EPC identifier.</param>
        /// <param name="parameterList">Semicolon-separated list of key=value parameters.</param>
        /// <param name="outputFormat">The desired output format.</param>
        /// <returns>Translation result with output and parameter dictionary, or null if translation fails.</returns>
        public TranslateResult TranslateDetails(string epcIdentifier, string parameterList, string outputFormat)
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
                Output = outputResult  // May be null if requested format isn't supported
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
        public Dictionary<string, string> ProcessInput(string epcIdentifier, string parameterList)
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
            var inputLevelsSchemes = new Dictionary<Level2, Scheme2>();

            foreach (var e in epcTagDataTranslations2)
            {
                var s = e.Scheme;
                if (s?.Level == null) continue;

                foreach (var l in s.Level)
                {
                    if (l.PrefixMatch == null) continue;

                    if (epcIdentifier.StartsWith(l.PrefixMatch, StringComparison.CurrentCulture))
                    {
                        // Check taglength parameter matches if specified
                        if (parameterDictionary.TryGetValue("taglength", out string taglength))
                        {
                            bool isVarLength = taglength.Equals("var", StringComparison.OrdinalIgnoreCase);
                            bool schemeHasFixedLength = s.TagLength.HasValue && s.TagLength.Value > 0;

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
                                if (!taglength.Equals(s.TagLength.Value.ToString()))
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

                        inputLevelsSchemes.Add(l, s);
                    }
                }
            }

            if (inputLevelsSchemes.Count == 0)
            {
                throw new TDTTranslationException("TDTSchemeNotFound");
            }

            // 3. DETERMINE THE OPTION THAT MATCHES THE INPUT VALUE
            Level2 inputLevel = null;
            Scheme2 inputScheme = null;
            Option2 inputOption = null;

            // Sort by longest prefix matches
            inputLevelsSchemes = inputLevelsSchemes.OrderByDescending(i => i.Key.PrefixMatch?.Length ?? 0).ToDictionary(x => x.Key, y => y.Value);

            foreach (var kvp in inputLevelsSchemes)
            {
                Level2 l = kvp.Key;
                Scheme2 s = kvp.Value;

                foreach (var o in l.Option ?? Enumerable.Empty<Option2>())
                {
                    // Check optionKey if specified
                    if (s.OptionKey != null)
                    {
                        string value;

                        if (int.TryParse(s.OptionKey, out _))
                        {
                            value = s.OptionKey;
                        }
                        else
                        {
                            parameterDictionary.TryGetValue(s.OptionKey, out value);
                        }

                        if (value != null && o.OptionKey != value)
                        {
                            continue;
                        }
                    }

                    // match against the original input (patterns expect percent-encoded chars)
                    var pattern = PrepareRegexPattern(o.Pattern);
                    Regex regex = new Regex(pattern);
                    var isMatch = regex.IsMatch(epcIdentifier);
                    if (isMatch)
                    {
                        inputScheme = s;
                        inputLevel = l;
                        inputOption = o;
                        break;
                    }
                }

                if (inputOption != null)
                {
                    break;
                }
            }

            if (inputOption == null)
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
                foreach (string s in inputLevel.RequiredParsingParameters.Split(','))
                {
                    if (!parameterDictionary.ContainsKey(s))
                    {
                        throw new TDTTranslationException("TDTUndefinedField");
                    }
                }
            }

            // 4. PARSE THE INPUT VALUE TO EXTRACT VALUES FOR EACH FIELD
            var pattern2 = PrepareRegexPattern(inputOption.Pattern);
            Regex r = new Regex(pattern2);

            Match m = r.Match(epcIdentifier);

            if (!m.Success)
            {
                throw new TDTTranslationException("TDTOptionNotFound");
            }

            // Sort fields by seq
            var fields = inputOption.Field ?? new List<Field2>();
            var fieldsSorted = fields.OrderBy(c => c.Seq).ToList();
            var inputLevelType = ParseLevelType(inputLevel.Type);

            for (int i = 1; i <= fieldsSorted.Count; i++)
            {
                var inputField = fieldsSorted[i - 1];
                string name = inputField.Name ?? "";
                string variableElement = m.Groups[i].Value;

                // Validate character set
                if (inputField.CharacterSet != null)
                {
                    if (!ValidateCharacterset(variableElement, inputField.CharacterSet))
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
                            Int64 integer = Convert.ToInt64(variableElement, 2);
                            variableElement = Convert.ToString(integer);
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
                            Int64 integer = Convert.ToInt64(variableElement, 2);
                            variableElement = Convert.ToString(integer);
                        }
                    }
                    else
                    {
                        Int64 integer = Convert.ToInt64(variableElement, 2);
                        variableElement = Convert.ToString(integer);
                    }

                    // Handle padding from TAG_ENCODING level
                    var tagEncodingField = FindCorrespondingField(inputScheme, "TAG_ENCODING", inputOption.OptionKey, name);
                    variableElement = HandlePaddingOnDecode(variableElement, inputField, tagEncodingField);
                }

                // Validate minimum/maximum
                if (inputField.DecimalMinimum != null && variableElement.Length > 0)
                {
                    try
                    {
                        BigInteger integer = BigInteger.Parse(variableElement);
                        if (ValidateMinimum(integer, inputField.DecimalMinimum))
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
                        if (ValidateMaximum(integer, inputField.DecimalMaximum))
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
            if (inputLevelType == LevelType.BINARY && inputOption.EncodedAI != null && inputOption.EncodedAI.Count > 0)
            {
                // Calculate the bit position where encodedAI data starts
                // The pattern matched the fixed fields, so we need to find where they end
                int fixedBitsLength = CalculateFixedBitsLength(inputOption);

                if (epcIdentifier.Length > fixedBitsLength)
                {
                    string encodedAIBinary = epcIdentifier.Substring(fixedBitsLength);
                    DecodeEncodedAI(encodedAIBinary, inputOption.EncodedAI, parameterDictionary);
                }
            }

            // 4c. DECODE VARIABLE-LENGTH FIELDS (for "++" schemes with BINARY input, TDS 2.3)
            // Order matches the grammar: delimited numeric → variable-length alphanumeric/numeric → hostname
            if (inputLevelType == LevelType.BINARY)
            {
                int fixedBitsLength = CalculateFixedBitsLength(inputOption);
                int bitPosition = fixedBitsLength;

                // Decode delimited numeric field first (e.g., giai, cpi) - comes before other variable fields
                if (inputOption.DelimitedNumericField != null && epcIdentifier.Length > bitPosition)
                {
                    string remainingBinary = epcIdentifier.Substring(bitPosition);
                    var (value, bitsConsumed) = DecodeDelimitedNumericField(remainingBinary, inputOption.DelimitedNumericField);
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
                    var (value, bitsConsumed) = DecodeVariableLengthField(remainingBinary, inputOption.VariableLengthField);
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
                    var (value, bitsConsumed) = DecodeVariableLengthNumericField(remainingBinary, inputOption.VariableLengthNumericField);
                    if (value != null)
                    {
                        parameterDictionary[inputOption.VariableLengthNumericField.Name ?? "serialNumber"] = value;
                        bitPosition += bitsConsumed;
                    }
                }

                // Decode hostname field (for ++ schemes) - always last
                if (inputOption.HostnameField != null && epcIdentifier.Length > bitPosition)
                {
                    string remainingBinary = epcIdentifier.Substring(bitPosition);
                    var hostname = DecodeHostnameField(remainingBinary);
                    if (hostname != null)
                    {
                        parameterDictionary[inputOption.HostnameField.Name ?? "hostname"] = hostname;
                    }
                }
            }

            // 5. PERFORM EXTRACT RULES
            if (inputLevel.Rule != null)
            {
                var extractRules = inputLevel.Rule.Where(r2 => r2.Type == "EXTRACT").OrderBy(c => c.Seq).ToList();
                ExecuteRules(extractRules, parameterDictionary);
            }

            // 5.5. Handle scheme-specific field conversions for '++' schemes
            var schemeName = parameterDictionary.GetValueOrDefault("schemeName", "");
            if (schemeName == "DSGTIN++")
            {
                ExtractDateFromDateBinary(parameterDictionary);
            }
            else if (schemeName == "ITIP++")
            {
                ExtractItipFieldsFromItipBinary(parameterDictionary);
            }

            return parameterDictionary;
        }

        /// <summary>
        /// Processes the output format and generates the translated EPC identifier.
        /// </summary>
        private string ProcessOutput(Dictionary<string, string> parameterDictionary, string outputFormat)
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
            Scheme2 outputScheme = null;
            Level2 outputLevel = null;
            Option2 outputOption = null;

            foreach (var e in epcTagDataTranslations2)
            {
                var s = e.Scheme;
                if (s?.Name != parameterDictionary["schemeName"]) continue;

                outputScheme = s;

                foreach (var l in s.Level ?? Enumerable.Empty<Level2>())
                {
                    if (ParseLevelType(l.Type) != outputFormatType) continue;

                    outputLevel = l;

                    foreach (var o in l.Option ?? Enumerable.Empty<Option2>())
                    {
                        if (o.OptionKey == parameterDictionary["optionKey"])
                        {
                            outputOption = o;
                        }
                    }
                }
            }

            if (outputLevel == null || outputOption == null)
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
            if (outputLevel.Rule != null)
            {
                var formatRules = outputLevel.Rule.Where(r2 => r2.Type == "FORMAT").OrderBy(c => c.Seq).ToList();
                ExecuteRules(formatRules, parameterDictionary);
            }

            // 7.5. Handle DSGTIN++/ITIP++ date binary conversion
            if (outputScheme?.Name == "DSGTIN++" && outputFormatType == LevelType.BINARY)
            {
                ComputeDsgtinPlusPlusDateBinary(parameterDictionary);
            }
            else if (outputScheme?.Name == "ITIP++" && outputFormatType == LevelType.BINARY)
            {
                ComputeItipPlusPlusItipBinary(parameterDictionary);
            }

            // 8. BUILD OUTPUT VALUE FROM GRAMMAR STRING
            string grammarstring = outputOption.Grammar ?? "";

            StringBuilder outputString = new StringBuilder();

            Regex abnf = new Regex(@"\'.*?\'|\s*[\w]+\s*");
            MatchCollection collection = abnf.Matches(grammarstring);

            foreach (var c in collection)
            {
                string s = c.ToString();

                if (s[0] == '\'')
                {
                    outputString.Append(s.Substring(1, s.Length - 2));
                }
                else
                {
                    s = s.Trim();

                    // Handle encodedAI token for "+" schemes (SGTIN+, SSCC+, GRAI+, etc.)
                    if (s.Equals("encodedAI", StringComparison.OrdinalIgnoreCase) && outputOption.EncodedAI != null)
                    {
                        var encodedAIBits = ProcessEncodedAI(outputOption.EncodedAI, parameterDictionary);
                        outputString.Append(encodedAIBits);
                        continue;
                    }

                    // Handle serialEncoded token for "++" schemes (TDS 2.3)
                    if (s.Equals("serialEncoded", StringComparison.OrdinalIgnoreCase) && outputOption.VariableLengthField != null)
                    {
                        if (parameterDictionary.TryGetValue(outputOption.VariableLengthField.Name ?? "serial", out var serialValue))
                        {
                            var serialBits = EncodeVariableLengthField(serialValue, outputOption.VariableLengthField);
                            outputString.Append(serialBits);
                        }
                        continue;
                    }

                    // Handle serialNumericEncoded token for "++" schemes with numeric serial (SGCN++, CPI++)
                    if (s.Equals("serialNumericEncoded", StringComparison.OrdinalIgnoreCase) && outputOption.VariableLengthNumericField != null)
                    {
                        if (parameterDictionary.TryGetValue(outputOption.VariableLengthNumericField.Name ?? "serialNumber", out var serialValue))
                        {
                            var serialBits = EncodeVariableLengthNumericField(serialValue, outputOption.VariableLengthNumericField);
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
                                var bits = EncodeVariableLengthField(fieldValue, outputOption.VariableLengthField);
                                outputString.Append(bits);
                            }
                            continue;
                        }
                        else if (outputOption.VariableLengthNumericField != null &&
                                 outputOption.VariableLengthNumericField.Name?.Equals(fieldName, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (parameterDictionary.TryGetValue(fieldName, out var fieldValue))
                            {
                                var bits = EncodeVariableLengthNumericField(fieldValue, outputOption.VariableLengthNumericField);
                                outputString.Append(bits);
                            }
                            continue;
                        }
                        else if (outputOption.DelimitedNumericField != null &&
                                 outputOption.DelimitedNumericField.Name?.Equals(fieldName, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (parameterDictionary.TryGetValue(fieldName, out var fieldValue))
                            {
                                var bits = EncodeDelimitedNumericField(fieldValue, outputOption.DelimitedNumericField);
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
                                var bits = EncodeDelimitedNumericField(fieldValue, outputOption.DelimitedNumericField);
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
                                var bits = EncodeVariableLengthNumericField(fieldValue, outputOption.VariableLengthNumericField);
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

                    string variableElement;
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
                        var tagEncodingField = FindCorrespondingField(outputScheme, "TAG_ENCODING", outputOption.OptionKey, s);
                        var binaryField = outputOption.Field?.FirstOrDefault(f => f.Name == s);

                        variableElement = HandlePaddingOnEncode(variableElement, tagEncodingField, binaryField);

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
                                foreach (char digitChar in variableElement.PadLeft(binaryField.Length.Value, '0'))
                                {
                                    int digit = digitChar - '0';
                                    bcdBuilder.Append(Convert.ToString(digit, 2).PadLeft(4, '0'));
                                }
                                variableElement = bcdBuilder.ToString();
                            }
                            else if (Int64.TryParse(variableElement, out var result))
                            {
                                // Regular binary encoding
                                variableElement = Convert.ToString(result, 2).PadLeft(binaryField.BitLength.Value, '0');
                            }
                            else
                            {
                                variableElement = new string('0', binaryField.BitLength.Value);
                            }
                        }
                        else
                        {
                            Int64 result;
                            if (!Int64.TryParse(variableElement, out result))
                            {
                                result = 0;
                            }
                            variableElement = Convert.ToString(result, 2);
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
                            if (!ValidateCharacterset(variableElement, field.CharacterSet))
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

            // Handle special outputs
            if (outputFormatType == LevelType.GS1_AI_JSON)
            {
                return FormatAsAiJson(parameterDictionary, outputOption);
            }

            return outputString.ToString();
        }

        /// <summary>
        /// Computes dateBinary for DSGTIN++ from date fields.
        /// Format: 4-bit date type indicator + 16-bit packed date (YY*512 + MM*32 + DD)
        /// Date types: 0=prodDate(11), 1=packDate(13), 2=bestBeforeDate(15), 3=sellByDate(16),
        ///             4=expDate(17), 5=firstFreezeDate(7006), 6=harvestDate(7007)
        /// </summary>
        private void ComputeDsgtinPlusPlusDateBinary(Dictionary<string, string> parameterDictionary)
        {
            // Map of date field names to their type indicators
            var dateFields = new Dictionary<string, int>
            {
                { "prodDate", 0 },       // AI 11
                { "packDate", 1 },       // AI 13
                { "bestBeforeDate", 2 }, // AI 15
                { "sellByDate", 3 },     // AI 16
                { "expDate", 4 },        // AI 17
                { "firstFreezeDate", 5 }, // AI 7006
                { "harvestDate", 6 }     // AI 7007
            };

            foreach (var df in dateFields)
            {
                if (parameterDictionary.TryGetValue(df.Key, out var dateValue) && dateValue.Length == 6)
                {
                    // Parse YYMMDD
                    if (int.TryParse(dateValue.Substring(0, 2), out int year) &&
                        int.TryParse(dateValue.Substring(2, 2), out int month) &&
                        int.TryParse(dateValue.Substring(4, 2), out int day))
                    {
                        // Pack date: YY*512 + MM*32 + DD
                        int packedDate = (year * 512) + (month * 32) + day;
                        // Combine type indicator (4 bits) + packed date (16 bits)
                        int dateBinary = (df.Value << 16) | packedDate;
                        // Store as decimal string (will be converted to binary by output processing)
                        parameterDictionary["dateBinary"] = dateBinary.ToString();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Computes itipBinary for ITIP++ from gtin, piece, and total fields.
        /// itipBinary (72 bits) = gtin (14 digits) + piece (2 digits) + total (2 digits) as a combined 18-digit integer.
        /// </summary>
        private void ComputeItipPlusPlusItipBinary(Dictionary<string, string> parameterDictionary)
        {
            if (!parameterDictionary.TryGetValue("gtin", out var gtin) ||
                !parameterDictionary.TryGetValue("piece", out var piece) ||
                !parameterDictionary.TryGetValue("total", out var total))
            {
                return;
            }

            // combine gtin (14 digits) + piece (2 digits) + total (2 digits) = 18 digit string
            var combined = gtin.PadLeft(14, '0') + piece.PadLeft(2, '0') + total.PadLeft(2, '0');

            // parse as decimal and convert to binary string for 72-bit field
            if (BigInteger.TryParse(combined, out var value))
            {
                // store as decimal string - the field will convert to binary
                parameterDictionary["itipBinary"] = value.ToString();
            }
        }

        /// <summary>
        /// Extracts gtin, piece, total fields from itipBinary for ITIP++.
        /// Reverse of ComputeItipPlusPlusItipBinary.
        /// </summary>
        private void ExtractItipFieldsFromItipBinary(Dictionary<string, string> parameterDictionary)
        {
            if (!parameterDictionary.TryGetValue("itipBinary", out var itipBinaryStr))
            {
                return;
            }

            if (string.IsNullOrEmpty(itipBinaryStr))
            {
                return;
            }

            // parse itipBinary to get the 18-digit combined value
            BigInteger itipValue;
            try
            {
                // check if it's a binary string (only 0s and 1s)
                if (itipBinaryStr.All(c => c == '0' || c == '1') && itipBinaryStr.Length > 10)
                {
                    itipValue = 0;
                    foreach (char c in itipBinaryStr)
                    {
                        itipValue = itipValue * 2 + (c - '0');
                    }
                }
                else
                {
                    itipValue = BigInteger.Parse(itipBinaryStr);
                }
            }
            catch
            {
                return;
            }

            // convert to 18-digit string padded with leading zeros
            string combined = itipValue.ToString().PadLeft(18, '0');

            // extract fields: gtin (14 digits) + piece (2 digits) + total (2 digits)
            if (combined.Length >= 18)
            {
                parameterDictionary["gtin"] = combined.Substring(0, 14);
                parameterDictionary["piece"] = combined.Substring(14, 2);
                parameterDictionary["total"] = combined.Substring(16, 2);
            }
        }

        /// <summary>
        /// Extracts date field from dateBinary for DSGTIN++/ITIP++.
        /// Reverse of ComputeDsgtinPlusPlusDateBinary.
        /// </summary>
        private void ExtractDateFromDateBinary(Dictionary<string, string> parameterDictionary)
        {
            if (!parameterDictionary.TryGetValue("dateBinary", out var dateBinaryStr))
            {
                return;
            }

            if (string.IsNullOrEmpty(dateBinaryStr))
            {
                return;
            }

            // Parse the dateBinary value - could be binary string or decimal
            int dateBinary;
            try
            {
                // Check if it's a binary string (only 0s and 1s)
                if (dateBinaryStr.All(c => c == '0' || c == '1') && dateBinaryStr.Length > 10)
                {
                    dateBinary = Convert.ToInt32(dateBinaryStr, 2);
                }
                else
                {
                    // It's a decimal value
                    dateBinary = int.Parse(dateBinaryStr);
                }
            }
            catch
            {
                return;
            }
            int typeIndicator = (dateBinary >> 16) & 0x0F;  // Top 4 bits
            int packedDate = dateBinary & 0xFFFF;          // Bottom 16 bits

            // Unpack date: year = value / 512, month = (value % 512) / 32, day = value % 32
            int year = packedDate / 512;
            int remainder = packedDate % 512;
            int month = remainder / 32;
            int day = remainder % 32;
            string dateValue = $"{year:D2}{month:D2}{day:D2}";

            // Map type indicator to field name
            string? fieldName = typeIndicator switch
            {
                0 => "prodDate",       // AI 11
                1 => "packDate",       // AI 13
                2 => "bestBeforeDate", // AI 15
                3 => "sellByDate",     // AI 16
                4 => "expDate",        // AI 17
                5 => "firstFreezeDate", // AI 7006
                6 => "harvestDate",    // AI 7007
                _ => null
            };

            if (fieldName != null)
            {
                parameterDictionary[fieldName] = dateValue;
            }
        }

        #region Rule Execution

        /// <summary>
        /// Executes transformation rules on the parameter dictionary.
        /// </summary>
        private void ExecuteRules(List<Rule2> rules, Dictionary<string, string> parameterDictionary)
        {
            if (rules == null) return;

            foreach (var r in rules)
            {
                string newFieldName = r.NewFieldName ?? "";

                if (string.IsNullOrEmpty(r.Function)) continue;

                string[] functionSplit = r.Function.Split(new char[] { '(', ',', ')' }, 128);
                string functionName = functionSplit[0];
                string[] functionParameters = new string[functionSplit.Length - 2];
                Array.Copy(functionSplit, 1, functionParameters, 0, functionSplit.Length - 2);
                int l = functionParameters.Length;

                string newFieldValue = null;

                switch (functionName)
                {
                    case "SUBSTR":
                        if (l == 2 || l == 3)
                        {
                            string substrInput = GetValue(functionParameters[0], parameterDictionary);
                            int offset = int.Parse(GetValue(functionParameters[1], parameterDictionary));

                            if (l == 2)
                            {
                                newFieldValue = RuleSUBSTR(substrInput, offset);
                            }
                            else
                            {
                                int length = int.Parse(GetValue(functionParameters[2], parameterDictionary));
                                newFieldValue = RuleSUBSTR(substrInput, offset, length);
                            }
                        }
                        break;

                    case "CONCAT":
                        List<string> concatInput = new List<string>();
                        for (int i = 0; i < l; i++)
                        {
                            string s = GetValue(functionParameters[i], parameterDictionary);
                            concatInput.Add(s);
                        }
                        newFieldValue = RuleCONCAT(concatInput);
                        break;

                    case "GS1CHECKSUM":
                        string checksumValue = GetValue(functionParameters[0], parameterDictionary);
                        newFieldValue = RuleGS1CHECKSUM(checksumValue);
                        break;

                    case "URLENCODE":
                        if (l >= 1)
                        {
                            // Skip if source field doesn't exist in dictionary
                            var urlFieldName = functionParameters[0].Trim();
                            if (!parameterDictionary.ContainsKey(urlFieldName) &&
                                !parameterDictionary.Keys.Any(k => k.Equals(urlFieldName, StringComparison.OrdinalIgnoreCase)))
                            {
                                continue;
                            }
                            string urlInput = GetValue(urlFieldName, parameterDictionary);
                            newFieldValue = UriEncoder.UrlEncode(urlInput);
                        }
                        break;

                    case "URLDECODE":
                        if (l >= 1)
                        {
                            // Skip if source field doesn't exist in dictionary
                            var urlDecFieldName = functionParameters[0].Trim();
                            if (!parameterDictionary.ContainsKey(urlDecFieldName) &&
                                !parameterDictionary.Keys.Any(k => k.Equals(urlDecFieldName, StringComparison.OrdinalIgnoreCase)))
                            {
                                continue;
                            }
                            string urlInput = GetValue(urlDecFieldName, parameterDictionary);
                            newFieldValue = UriEncoder.UrlDecode(urlInput);
                        }
                        break;

                    case "URNENCODE":
                        if (l >= 1)
                        {
                            // Skip if source field doesn't exist in dictionary
                            var urnFieldName = functionParameters[0].Trim();
                            if (!parameterDictionary.ContainsKey(urnFieldName) &&
                                !parameterDictionary.Keys.Any(k => k.Equals(urnFieldName, StringComparison.OrdinalIgnoreCase)))
                            {
                                continue;
                            }
                            string urnInput = GetValue(urnFieldName, parameterDictionary);
                            newFieldValue = UriEncoder.UrnEncode(urnInput);
                        }
                        break;

                    case "URNDECODE":
                        if (l >= 1)
                        {
                            // Skip if source field doesn't exist in dictionary
                            var urnDecFieldName = functionParameters[0].Trim();
                            if (!parameterDictionary.ContainsKey(urnDecFieldName) &&
                                !parameterDictionary.Keys.Any(k => k.Equals(urnDecFieldName, StringComparison.OrdinalIgnoreCase)))
                            {
                                continue;
                            }
                            string urnInput = GetValue(urnDecFieldName, parameterDictionary);
                            newFieldValue = UriEncoder.UrnDecode(urnInput);
                        }
                        break;

                    default:
                        // Unknown function - skip
                        continue;
                }

                if (newFieldValue == null) continue;

                // Validate character set
                if (r.CharacterSet != null)
                {
                    if (!ValidateCharacterset(newFieldValue, r.CharacterSet))
                    {
                        throw new TDTTranslationException("TDTFieldOutsideCharacterSet");
                    }
                }

                // Validate range
                if (r.DecimalMinimum != null)
                {
                    BigInteger integer = BigInteger.Parse(newFieldValue);
                    if (ValidateMinimum(integer, r.DecimalMinimum))
                    {
                        throw new TDTTranslationException("TDTFieldBelowMinimum");
                    }
                }

                if (r.DecimalMaximum != null)
                {
                    BigInteger integer = BigInteger.Parse(newFieldValue);
                    if (ValidateMaximum(integer, r.DecimalMaximum))
                    {
                        throw new TDTTranslationException("TDTFieldAboveMaximum");
                    }
                }

                parameterDictionary[newFieldName] = newFieldValue;
            }
        }

        private string GetValue(string input, Dictionary<string, string> epcIdentifierDictionary)
        {
            // strip quotes from literal strings
            if (input.StartsWith("'") && input.EndsWith("'") && input.Length >= 2)
            {
                return input.Substring(1, input.Length - 2);
            }

            if (int.TryParse(input, out _))
            {
                return input;
            }

            if (epcIdentifierDictionary.TryGetValue(input, out string newInput))
            {
                return newInput;
            }

            // Try case-insensitive lookup
            var key = epcIdentifierDictionary.Keys.FirstOrDefault(k => k.Equals(input, StringComparison.OrdinalIgnoreCase));
            if (key != null)
            {
                return epcIdentifierDictionary[key];
            }

            return input;
        }

        private string RuleSUBSTR(string input, int offset)
        {
            if (offset >= input.Length) return "";
            return input.Substring(offset);
        }

        private string RuleSUBSTR(string input, int offset, int length)
        {
            if (offset >= input.Length) return "";
            if (offset + length > input.Length) length = input.Length - offset;
            return input.Substring(offset, length);
        }

        private string RuleCONCAT(List<string> input)
        {
            return string.Concat(input);
        }

        private string RuleGS1CHECKSUM(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int n = int.Parse(input.Substring(input.Length - 1 - i, 1));
                sum += i % 2 == 0 ? n * 3 : n;
            }

            int result = sum % 10 == 0 ? 0 : 10 - sum % 10;
            return result.ToString();
        }

        #endregion

        #region Hex/Binary Conversion

        /// <summary>
        /// Converts a hexadecimal string to binary.
        /// </summary>
        public string HexToBinary(string hex)
        {
            int length = hex.Length;
            StringBuilder binary = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int integer = Convert.ToInt16(hex.Substring(i, 1), 16);
                binary.Append(Convert.ToString(integer, 2).PadLeft(4, '0'));
            }

            return binary.ToString();
        }

        /// <summary>
        /// Converts a binary string to hexadecimal.
        /// </summary>
        public string BinaryToHex(string binary)
        {
            int length = binary.Length;
            if (length % 16 != 0)
            {
                int toPad = 16 - length % 16;
                binary = binary.PadRight(length + toPad, '0');
                length = binary.Length;
            }

            StringBuilder hex = new StringBuilder();
            for (int i = 0; i < length; i += 4)
            {
                int integer = Convert.ToInt16(binary.Substring(i, 4), 2);
                hex.Append(Convert.ToString(integer, 16));
            }

            return hex.ToString();
        }

        #endregion

        #region Validation

        private bool ValidateCharacterset(string input, string characterSet)
        {
            if (input.Length == 0)
                return true;

            // Remove trailing quantifiers like *, +, or {n,m} but preserve the regex structure
            string pattern = characterSet;
            if (pattern.EndsWith("*") || pattern.EndsWith("+"))
            {
                pattern = pattern.Substring(0, pattern.Length - 1);
                // If removing the quantifier leaves an unbalanced group, remove the outer group too
                if (pattern.EndsWith(")") && pattern.StartsWith("("))
                {
                    // Check if removing outer parens would help
                    int openCount = pattern.Count(c => c == '(');
                    int closeCount = pattern.Count(c => c == ')');
                    if (openCount > closeCount)
                    {
                        // Unbalanced - try wrapping in ^ and $ for full match instead
                        pattern = characterSet;
                    }
                }
            }

            try
            {
                // Use the full pattern and check if the entire input matches
                Regex r = new Regex("^" + characterSet + "$");
                return r.IsMatch(input);
            }
            catch
            {
                // If regex fails, fall back to allowing the input
                return true;
            }
        }

        private bool ValidateMinimum(BigInteger input, string minimum)
        {
            BigInteger.TryParse(minimum, out BigInteger minimumInt);
            return input < minimumInt;
        }

        private bool ValidateMaximum(BigInteger input, string maximum)
        {
            BigInteger.TryParse(maximum, out BigInteger maximumInt);
            return input > maximumInt;
        }

        #endregion

        #region Helper Methods

        private void ParseInput(string input, Dictionary<string, string> parameterDictionary)
        {
            if (input.Length > 0)
            {
                foreach (string s in input.Split(';'))
                {
                    var parts = s.Split('=');
                    if (parts.Length >= 2)
                    {
                        parameterDictionary[parts[0].Trim().ToLower()] = parts[1].Trim().ToLower();
                    }
                }
            }
        }

        /// <summary>
        /// Gets the GCP prefix length for a given input string.
        /// </summary>
        public PrefixLengthResult GetPrefixLength(string input)
        {
            var prefixLength = gcpPrefixLengths.Where(x => input.StartsWith(x.Key, StringComparison.CurrentCulture)).FirstOrDefault();

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

        /// <summary>
        /// Prepares a regex pattern from JSON scheme for use with .NET regex.
        /// Handles differences in JSON escape sequences.
        /// </summary>
        private string PrepareRegexPattern(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return "";

            // JSON escapes backslashes, so \\d in JSON means \d in regex
            // The JSON deserializer should handle this, but in case patterns come through
            // with literal escape sequences, handle common ones
            return pattern;
        }

        private Field2 FindCorrespondingField(Scheme2 scheme, string levelType, string optionKey, string fieldName)
        {
            if (scheme?.Level == null) return null;

            foreach (var l in scheme.Level)
            {
                if (l.Type?.ToUpper() != levelType?.ToUpper()) continue;

                foreach (var o in l.Option ?? Enumerable.Empty<Option2>())
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
        /// Uses GS1 packed objects date encoding: days since January 1, 2000.
        /// </summary>
        /// <param name="yymmdd">Date in YYMMDD format (e.g., "261231" for Dec 31, 2026).</param>
        /// <param name="bitLength">Number of bits for the output (typically 16).</param>
        /// <returns>Binary string representation of the date.</returns>
        private string EncodeDateYYMMDD(string yymmdd, int bitLength)
        {
            if (string.IsNullOrEmpty(yymmdd) || yymmdd.Length != 6)
            {
                return new string('0', bitLength);
            }

            try
            {
                // Parse YYMMDD
                int year = int.Parse(yymmdd.Substring(0, 2));
                int month = int.Parse(yymmdd.Substring(2, 2));
                int day = int.Parse(yymmdd.Substring(4, 2));

                // TDS 2.3 packed date encoding formula: YY * 512 + MM * 32 + DD
                // This uses 9 bits for year (0-511), 5 bits for month (0-31), 5 bits for day (0-31)
                // Total = 16 bits (bit 15-7 for year, 6-2 for month, 1-0 and upper bits of next for day)
                int packedDate = (year * 512) + (month * 32) + day;

                // Convert to binary and pad
                string binary = Convert.ToString(packedDate, 2);
                return binary.PadLeft(bitLength, '0');
            }
            catch
            {
                return new string('0', bitLength);
            }
        }

        /// <summary>
        /// Decodes a binary date representation back to YYMMDD format.
        /// Uses TDS 2.3 packed date encoding: YY * 512 + MM * 32 + DD.
        /// </summary>
        /// <param name="binary">Binary string representation of the date.</param>
        /// <returns>Date in YYMMDD format (e.g., "261231" for Dec 31, 2026).</returns>
        private string DecodeDateYYMMDD(string binary)
        {
            if (string.IsNullOrEmpty(binary))
            {
                return "000000";
            }

            try
            {
                // Convert binary to packed date value
                int packedDate = Convert.ToInt32(binary, 2);

                // TDS 2.3 packed date encoding: YY * 512 + MM * 32 + DD
                int year = packedDate / 512;
                int remainder = packedDate % 512;
                int month = remainder / 32;
                int day = remainder % 32;

                // Format as YYMMDD
                return $"{year:D2}{month:D2}{day:D2}";
            }
            catch
            {
                return "000000";
            }
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

        private string HandlePaddingOnDecode(string value, Field2 inputField, Field2 tagEncodingField)
        {
            bool padCharInBinary = inputField?.PadChar != null;
            bool padCharInTagEncoding = tagEncodingField?.PadChar != null;

            if (padCharInBinary && !padCharInTagEncoding)
            {
                if (inputField.PadDir?.ToUpper() == "LEFT")
                {
                    value = value.TrimStart(inputField.PadChar[0]);
                }
                else
                {
                    value = value.TrimEnd(inputField.PadChar[0]);
                }
            }

            if (!padCharInBinary && padCharInTagEncoding)
            {
                if (tagEncodingField.PadDir?.ToUpper() == "LEFT")
                {
                    value = value.PadLeft(tagEncodingField.Length ?? 0, tagEncodingField.PadChar[0]);
                }
                else
                {
                    value = value.PadRight(tagEncodingField.Length ?? 0, tagEncodingField.PadChar[0]);
                }

                if ((tagEncodingField.Length ?? 0) == 0)
                {
                    value = "";
                }
            }

            return value;
        }

        private string HandlePaddingOnEncode(string value, Field2 tagEncodingField, Field2 binaryField)
        {
            bool padCharInTagEncoding = tagEncodingField?.PadChar != null;
            bool padCharInBinary = binaryField?.PadChar != null;

            if (padCharInTagEncoding && !padCharInBinary)
            {
                if (tagEncodingField.PadDir?.ToUpper() == "LEFT")
                {
                    value = value.TrimStart(tagEncodingField.PadChar[0]);
                }
                else
                {
                    value = value.TrimEnd(tagEncodingField.PadChar[0]);
                }
            }

            if (!padCharInTagEncoding && padCharInBinary)
            {
                if (binaryField.PadDir?.ToUpper() == "LEFT")
                {
                    value = value.PadLeft(binaryField.Length ?? 0, binaryField.PadChar[0]);
                }
                else
                {
                    value = value.PadRight(binaryField.Length ?? 0, binaryField.PadChar[0]);
                }
            }

            return value;
        }

        #endregion

        #region Encoded AI Processing

        /// <summary>
        /// Processes encoded AI data for "+" schemes (SGTIN+, SSCC+, GRAI+, etc.).
        /// Uses Table F for encoding format definitions and Table B for bit counts.
        /// </summary>
        /// <param name="encodedAIs">List of encoded AI definitions from the scheme.</param>
        /// <param name="parameters">Dictionary of field values.</param>
        /// <returns>Binary string representation of the encoded AIs.</returns>
        private string ProcessEncodedAI(List<EncodedAI> encodedAIs, Dictionary<string, string> parameters)
        {
            if (encodedAIs == null || encodedAIs.Count == 0 || tableF == null)
            {
                return "";
            }

            var bits = new StringBuilder();

            foreach (var ai in encodedAIs.OrderBy(a => a.Seq))
            {
                // Get the value from parameters
                if (!parameters.TryGetValue(ai.Name, out var value))
                {
                    // Try case-insensitive lookup
                    var key = parameters.Keys.FirstOrDefault(k => k.Equals(ai.Name, StringComparison.OrdinalIgnoreCase));
                    if (key != null)
                    {
                        value = parameters[key];
                    }
                    else
                    {
                        // Value not found, skip this AI
                        continue;
                    }
                }

                // Get the encoding format from Table F
                var format = tableF.GetEntry(ai.Ai);
                if (format == null)
                {
                    // Unknown AI, cannot encode
                    throw new TDTTranslationException($"Unknown AI '{ai.Ai}' in Table F");
                }

                // Handle AIs with two components (like 8003 GRAI where value is GRAI base + serial)
                if (format.HasSecondComponent && format.Comp1FixedLengthChars.HasValue)
                {
                    // Split the value into component 1 (fixed-length) and component 2 (variable-length)
                    int comp1Length = format.Comp1FixedLengthChars.Value;
                    if (value.Length > comp1Length)
                    {
                        string comp1Value = value.Substring(0, comp1Length);
                        string comp2Value = value.Substring(comp1Length);

                        // Encode component 1 (fixed-length)
                        bits.Append(EncodeAIValue(comp1Value, format, false));
                        // Encode component 2 (variable-length)
                        bits.Append(EncodeAIValue(comp2Value, format, true));
                    }
                    else
                    {
                        // Value is only component 1 (no serial/extension)
                        bits.Append(EncodeAIValue(value, format, false));
                    }
                }
                else
                {
                    // Single component AI - encode normally
                    bits.Append(EncodeAIValue(value, format, false));
                }
            }

            return bits.ToString();
        }

        /// <summary>
        /// Encodes a single AI value according to Table F format.
        /// </summary>
        /// <param name="value">The value to encode.</param>
        /// <param name="format">The Table F entry defining the encoding format.</param>
        /// <param name="isSecondComponent">True if encoding the second component of a two-component AI.</param>
        /// <returns>Binary string representation of the encoded value.</returns>
        private string EncodeAIValue(string value, TableFEntry format, bool isSecondComponent)
        {
            var bits = new StringBuilder();

            // Get the appropriate format parameters
            string formatType;
            int? fixedLengthBits;
            int? encodingIndicatorBits;
            int? lengthIndicatorBits;
            int? maxCharacters;

            if (isSecondComponent)
            {
                formatType = format.Comp2Format ?? "";
                fixedLengthBits = format.Comp2FixedLengthBits;
                encodingIndicatorBits = format.Comp2EncodingIndicatorBits;
                lengthIndicatorBits = format.Comp2LengthIndicatorBits;
                maxCharacters = format.Comp2MaxCharacters;
            }
            else
            {
                formatType = format.Comp1Format ?? "";
                fixedLengthBits = format.Comp1FixedLengthBits;
                encodingIndicatorBits = format.Comp1EncodingIndicatorBits;
                lengthIndicatorBits = format.Comp1LengthIndicatorBits;
                maxCharacters = format.Comp1MaxCharacters;
            }

            // Handle fixed-length encoding
            if (fixedLengthBits.HasValue)
            {
                bits.Append(EncodeFixedLength(value, fixedLengthBits.Value, formatType));
            }
            // Handle variable-length encoding
            else if (encodingIndicatorBits.HasValue || lengthIndicatorBits.HasValue)
            {
                bits.Append(EncodeVariableLength(value, formatType, encodingIndicatorBits ?? 0, lengthIndicatorBits ?? 0));
            }

            return bits.ToString();
        }

        /// <summary>
        /// Encodes a value as fixed-length binary.
        /// </summary>
        /// <param name="value">The value to encode.</param>
        /// <param name="bitLength">The number of bits for the encoded value.</param>
        /// <param name="formatType">The encoding format type from Table F.</param>
        /// <returns>Binary string representation padded to the specified bit length.</returns>
        private string EncodeFixedLength(string value, int bitLength, string formatType)
        {
            if (formatType.Contains("Fixed-length numeric", StringComparison.OrdinalIgnoreCase))
            {
                // BCD encoding: each decimal digit is 4 bits (TDS 2.3 section 14.5.4)
                var sb = new StringBuilder();
                int expectedDigits = bitLength / 4;
                // Pad value to expected length
                var paddedValue = value.PadLeft(expectedDigits, '0');
                foreach (char c in paddedValue)
                {
                    if (char.IsDigit(c))
                    {
                        int digit = c - '0';
                        sb.Append(Convert.ToString(digit, 2).PadLeft(4, '0'));
                    }
                    else
                    {
                        // Non-digit character, encode as 0
                        sb.Append("0000");
                    }
                }
                return sb.ToString();
            }
            else if (formatType.Contains("date", StringComparison.OrdinalIgnoreCase) ||
                formatType.Contains("Fixed-Bit-Length", StringComparison.OrdinalIgnoreCase))
            {
                // Date/integer encoding: convert to integer then to binary
                if (BigInteger.TryParse(value, out var numericValue))
                {
                    var binary = ToBinaryString(numericValue);
                    return binary.PadLeft(bitLength, '0');
                }
                else
                {
                    // If not numeric, try encoding as ASCII
                    return EncodeAsAscii(value, bitLength);
                }
            }
            else if (formatType.Contains("Country code", StringComparison.OrdinalIgnoreCase))
            {
                // ISO 3166-1 alpha-2 country code (2 letters)
                return EncodeCountryCode(value, bitLength);
            }
            else
            {
                // Default to numeric encoding
                if (BigInteger.TryParse(value, out var numericValue))
                {
                    var binary = ToBinaryString(numericValue);
                    return binary.PadLeft(bitLength, '0');
                }
                return new string('0', bitLength);
            }
        }

        /// <summary>
        /// Encodes a value with variable-length encoding.
        /// </summary>
        /// <param name="value">The value to encode.</param>
        /// <param name="formatType">The encoding format type from Table F.</param>
        /// <param name="encodingIndicatorBits">Number of bits for encoding indicator (0 if not used).</param>
        /// <param name="lengthIndicatorBits">Number of bits for length indicator.</param>
        /// <returns>Binary string with encoding indicator, length indicator, and encoded data.</returns>
        private string EncodeVariableLength(string value, string formatType, int encodingIndicatorBits, int lengthIndicatorBits)
        {
            var bits = new StringBuilder();
            int encodingIndicator;
            string dataBits;

            if (formatType.Contains("alphanumeric", StringComparison.OrdinalIgnoreCase))
            {
                // Variable-length alphanumeric - choose optimal encoding
                (encodingIndicator, dataBits) = ChooseOptimalEncoding(value);
            }
            else if (formatType.Contains("numeric string without encoding indicator", StringComparison.OrdinalIgnoreCase))
            {
                // Variable-length numeric string without encoding indicator
                // Uses integer encoding but no indicator is written
                encodingIndicator = 0;
                dataBits = EncodeVariableLengthInteger(value);

                // For this format, write length indicator then data (no encoding indicator)
                bits.Append(Convert.ToString(value.Length, 2).PadLeft(lengthIndicatorBits, '0'));
                bits.Append(dataBits);
                return bits.ToString();
            }
            else if (formatType.Contains("Delimited/terminated numeric", StringComparison.OrdinalIgnoreCase))
            {
                // TDS 2.3 section 14.5.5: Delimited/terminated numeric encoding
                // - Digits 0-9 are encoded as 4-bit BCD (nibble values 0-9)
                // - Mode switch nibbles: 11=uppercase, 12=lowercase, 14=7-bit ASCII
                // - Terminator nibble: 15
                return EncodeDelimitedTerminatedNumeric(value);
            }
            else
            {
                // Default to integer encoding
                encodingIndicator = 0;
                dataBits = EncodeVariableLengthInteger(value);
            }

            // Write encoding indicator if used
            if (encodingIndicatorBits > 0)
            {
                bits.Append(Convert.ToString(encodingIndicator, 2).PadLeft(encodingIndicatorBits, '0'));
            }

            // Write length indicator
            if (lengthIndicatorBits > 0)
            {
                bits.Append(Convert.ToString(value.Length, 2).PadLeft(lengthIndicatorBits, '0'));
            }

            // Write data bits
            bits.Append(dataBits);

            return bits.ToString();
        }

        /// <summary>
        /// Chooses the optimal encoding method for an alphanumeric string.
        /// </summary>
        /// <param name="value">The value to encode.</param>
        /// <returns>Tuple of (encoding indicator, encoded data bits).</returns>
        private (int encodingIndicator, string dataBits) ChooseOptimalEncoding(string value)
        {
            // Try encodings in order of efficiency
            // 0: Variable-length integer (most efficient for numeric strings)
            if (IsNumericOnly(value))
            {
                return (0, EncodeVariableLengthInteger(value));
            }

            // 1: Upper case hexadecimal (4 bits per char)
            if (IsUpperCaseHex(value))
            {
                return (1, EncodeUpperCaseHex(value));
            }

            // 2: Lower case hexadecimal (4 bits per char)
            if (IsLowerCaseHex(value))
            {
                return (2, EncodeLowerCaseHex(value));
            }

            // 3: Base64 (6 bits per char)
            if (IsBase64Safe(value))
            {
                return (3, EncodeBase64(value));
            }

            // 5: URN Code 40 (~5.33 bits per char)
            if (IsUrnCode40(value))
            {
                return (5, EncodeUrnCode40(value));
            }

            // 4: 7-bit ASCII (7 bits per char) - fallback
            return (4, EncodeAscii(value));
        }

        /// <summary>
        /// Encodes a value as variable-length integer (encoding indicator 0).
        /// </summary>
        private string EncodeVariableLengthInteger(string value)
        {
            if (string.IsNullOrEmpty(value) || !BigInteger.TryParse(value, out var numericValue))
            {
                return "";
            }

            // Get bit count from Table B based on length and encoding indicator 0
            int bitCount = tableB?.GetBitCount(value.Length, 0) ?? (int)Math.Ceiling(value.Length * 3.32);
            var binary = ToBinaryString(numericValue);
            return binary.PadLeft(bitCount, '0');
        }

        /// <summary>
        /// Encodes a value as upper case hexadecimal (encoding indicator 1).
        /// </summary>
        private string EncodeUpperCaseHex(string value)
        {
            var bits = new StringBuilder();
            foreach (char c in value.ToUpper())
            {
                int hexValue = c >= '0' && c <= '9' ? c - '0' : c - 'A' + 10;
                bits.Append(Convert.ToString(hexValue, 2).PadLeft(4, '0'));
            }
            return bits.ToString();
        }

        /// <summary>
        /// Encodes a value as lower case hexadecimal (encoding indicator 2).
        /// </summary>
        private string EncodeLowerCaseHex(string value)
        {
            var bits = new StringBuilder();
            foreach (char c in value.ToLower())
            {
                int hexValue = c >= '0' && c <= '9' ? c - '0' : c - 'a' + 10;
                bits.Append(Convert.ToString(hexValue, 2).PadLeft(4, '0'));
            }
            return bits.ToString();
        }

        /// <summary>
        /// Encodes a value as base64 (encoding indicator 3).
        /// </summary>
        private string EncodeBase64(string value)
        {
            var bits = new StringBuilder();
            const string base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
            foreach (char c in value)
            {
                int index = base64Chars.IndexOf(c);
                if (index >= 0)
                {
                    bits.Append(Convert.ToString(index, 2).PadLeft(6, '0'));
                }
            }
            return bits.ToString();
        }

        /// <summary>
        /// Encodes a value as 7-bit ASCII (encoding indicator 4).
        /// </summary>
        private string EncodeAscii(string value)
        {
            var bits = new StringBuilder();
            foreach (char c in value)
            {
                bits.Append(Convert.ToString((int)c, 2).PadLeft(7, '0'));
            }
            return bits.ToString();
        }

        /// <summary>
        /// Encodes a value as URN Code 40 (encoding indicator 5).
        /// 16 bits per 3 characters.
        /// </summary>
        private string EncodeUrnCode40(string value)
        {
            const string code40Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-.:";
            var bits = new StringBuilder();

            // Process in groups of 3 characters
            for (int i = 0; i < value.Length; i += 3)
            {
                int tripletValue = 0;
                for (int j = 0; j < 3 && i + j < value.Length; j++)
                {
                    char c = char.ToUpper(value[i + j]);
                    int charIndex = code40Chars.IndexOf(c);
                    if (charIndex < 0) charIndex = 0;
                    tripletValue = tripletValue * 40 + charIndex;
                }

                // Handle partial triplets
                int remaining = Math.Min(3, value.Length - i);
                if (remaining < 3)
                {
                    // Pad with zeros for incomplete triplets
                    for (int j = remaining; j < 3; j++)
                    {
                        tripletValue = tripletValue * 40;
                    }
                }

                bits.Append(Convert.ToString(tripletValue, 2).PadLeft(16, '0'));
            }

            return bits.ToString();
        }

        /// <summary>
        /// Encodes a value as fixed-length ASCII.
        /// </summary>
        private string EncodeAsAscii(string value, int bitLength)
        {
            var bits = new StringBuilder();
            foreach (char c in value)
            {
                bits.Append(Convert.ToString((int)c, 2).PadLeft(7, '0'));
            }
            // Pad or truncate to fit bit length
            if (bits.Length < bitLength)
            {
                bits.Append(new string('0', bitLength - bits.Length));
            }
            return bits.ToString().Substring(0, Math.Min(bits.Length, bitLength));
        }

        /// <summary>
        /// Encodes a country code (ISO 3166-1 alpha-2) as 12 bits.
        /// </summary>
        private string EncodeCountryCode(string value, int bitLength)
        {
            if (value.Length != 2)
            {
                return new string('0', bitLength);
            }

            // Each letter encoded as A=1, B=2, etc. (5 bits each = 10 bits)
            // Plus 2 padding bits for 12 total
            int first = char.ToUpper(value[0]) - 'A' + 1;
            int second = char.ToUpper(value[1]) - 'A' + 1;
            var binary = Convert.ToString(first, 2).PadLeft(5, '0') + Convert.ToString(second, 2).PadLeft(5, '0');
            return binary.PadLeft(bitLength, '0');
        }

        /// <summary>
        /// Converts a BigInteger to a binary string.
        /// </summary>
        private string ToBinaryString(BigInteger value)
        {
            if (value == 0)
            {
                return "0";
            }

            var bits = new StringBuilder();
            while (value > 0)
            {
                bits.Insert(0, (value % 2).ToString());
                value /= 2;
            }
            return bits.ToString();
        }

        /// <summary>
        /// Encodes a value using TDS 2.3 section 14.5.5 "Delimited/terminated numeric" format.
        /// Format: BCD digits + mode switch (E=7-bit ASCII) + encoding indicator (3 bits) + length (5 bits) + char data
        /// </summary>
        private string EncodeDelimitedTerminatedNumeric(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }

            var bits = new StringBuilder();
            int i = 0;

            // encode leading digits as 4-bit BCD
            while (i < value.Length && char.IsDigit(value[i]))
            {
                int digit = value[i] - '0';
                bits.Append(Convert.ToString(digit, 2).PadLeft(4, '0'));
                i++;
            }

            // if there are remaining non-digit characters, encode them
            if (i < value.Length)
            {
                string remaining = value.Substring(i);

                // mode switch nibble E (1110) = 7-bit ASCII mode
                bits.Append("1110");

                // encoding indicator (3 bits): 100 = 7-bit ASCII
                bits.Append("100");

                // length indicator (5 bits)
                bits.Append(Convert.ToString(remaining.Length, 2).PadLeft(5, '0'));

                // 7-bit ASCII character data
                foreach (char c in remaining)
                {
                    bits.Append(Convert.ToString((int)c, 2).PadLeft(7, '0'));
                }
            }

            return bits.ToString();
        }

        /// <summary>
        /// Gets the 6-bit code for uppercase alphanumeric encoding (mode 11).
        /// Character set: 0-9=0-9, A-Z=10-35, special chars after.
        /// </summary>
        private int GetUppercaseAlphanumericCode(char c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            if (c >= 'A' && c <= 'Z') return c - 'A' + 10;
            // special characters
            return c switch
            {
                '-' => 36,
                '.' => 37,
                '/' => 38,
                ':' => 39,
                _ => 0
            };
        }

        /// <summary>
        /// Gets the 6-bit code for lowercase alphanumeric encoding (mode 12).
        /// Character set: 0-9=0-9, a-z=10-35, special chars after.
        /// </summary>
        private int GetLowercaseAlphanumericCode(char c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            if (c >= 'a' && c <= 'z') return c - 'a' + 10;
            // special characters
            return c switch
            {
                '-' => 36,
                '.' => 37,
                '/' => 38,
                ':' => 39,
                _ => 0
            };
        }

        /// <summary>
        /// Decodes a value encoded using TDS 2.3 section 14.5.5 "Delimited/terminated numeric" format.
        /// Format: BCD digits + mode switch (E=7-bit ASCII) + encoding indicator (3 bits) + length (5 bits) + char data
        /// </summary>
        private (string? value, int bitsConsumed) DecodeDelimitedTerminatedNumeric(string binaryData)
        {
            if (string.IsNullOrEmpty(binaryData) || binaryData.Length < 4)
            {
                return (null, 0);
            }

            var result = new StringBuilder();
            int bitPosition = 0;

            // read 4-bit nibbles for BCD digits
            while (bitPosition + 4 <= binaryData.Length)
            {
                int nibble = Convert.ToInt32(binaryData.Substring(bitPosition, 4), 2);

                if (nibble >= 0 && nibble <= 9)
                {
                    // BCD digit
                    result.Append((char)('0' + nibble));
                    bitPosition += 4;
                }
                else if (nibble == 14)
                {
                    // mode switch to 7-bit ASCII with encoding indicator + length
                    bitPosition += 4;

                    // read encoding indicator (3 bits) - should be 100 (7-bit ASCII)
                    if (bitPosition + 3 > binaryData.Length) break;
                    bitPosition += 3;

                    // read length indicator (5 bits)
                    if (bitPosition + 5 > binaryData.Length) break;
                    int length = Convert.ToInt32(binaryData.Substring(bitPosition, 5), 2);
                    bitPosition += 5;

                    // read 7-bit ASCII characters
                    for (int i = 0; i < length && bitPosition + 7 <= binaryData.Length; i++)
                    {
                        int code = Convert.ToInt32(binaryData.Substring(bitPosition, 7), 2);
                        bitPosition += 7;
                        result.Append((char)code);
                    }
                    break;
                }
                else if (nibble == 15)
                {
                    // terminator
                    bitPosition += 4;
                    break;
                }
                else
                {
                    // unknown nibble, stop
                    break;
                }
            }

            return (result.ToString(), bitPosition);
        }

        /// <summary>
        /// Decodes a 6-bit code to uppercase alphanumeric character (mode 11).
        /// </summary>
        private char DecodeUppercaseAlphanumericCode(int code)
        {
            if (code >= 0 && code <= 9) return (char)('0' + code);
            if (code >= 10 && code <= 35) return (char)('A' + code - 10);
            return code switch
            {
                36 => '-',
                37 => '.',
                38 => '/',
                39 => ':',
                _ => '\0'
            };
        }

        /// <summary>
        /// Decodes a 6-bit code to lowercase alphanumeric character (mode 12).
        /// </summary>
        private char DecodeLowercaseAlphanumericCode(int code)
        {
            if (code >= 0 && code <= 9) return (char)('0' + code);
            if (code >= 10 && code <= 35) return (char)('a' + code - 10);
            return code switch
            {
                36 => '-',
                37 => '.',
                38 => '/',
                39 => ':',
                _ => '\0'
            };
        }

        /// <summary>
        /// Decodes a 6-bit Base64 code to character.
        /// </summary>
        private char DecodeBase64Char(int code)
        {
            const string base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
            if (code >= 0 && code < base64Chars.Length) return base64Chars[code];
            return '\0';
        }

        #region Character Set Validation for Encoding

        private bool IsNumericOnly(string value) =>
            !string.IsNullOrEmpty(value) && value.All(c => c >= '0' && c <= '9');

        private bool IsUpperCaseHex(string value) =>
            !string.IsNullOrEmpty(value) && value.All(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F'));

        private bool IsLowerCaseHex(string value) =>
            !string.IsNullOrEmpty(value) && value.All(c => (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f'));

        private bool IsBase64Safe(string value) =>
            !string.IsNullOrEmpty(value) && value.All(c =>
                (c >= '0' && c <= '9') ||
                (c >= 'A' && c <= 'Z') ||
                (c >= 'a' && c <= 'z') ||
                c == '-' || c == '_');

        private bool IsUrnCode40(string value) =>
            !string.IsNullOrEmpty(value) && value.All(c =>
                (c >= '0' && c <= '9') ||
                (c >= 'A' && c <= 'Z') ||
                (c >= 'a' && c <= 'z') ||  // Will be converted to upper case
                c == '-' || c == '.' || c == ':');

        #endregion

        #region Encoded AI Decoding

        /// <summary>
        /// Decodes encoded AI data from binary for "+" schemes (SGTIN+, SSCC+, GRAI+, DSGTIN+, etc.).
        /// This is the reverse of ProcessEncodedAI.
        /// </summary>
        /// <param name="binaryData">The binary string containing the encoded AI data.</param>
        /// <param name="encodedAIs">List of encoded AI definitions from the scheme.</param>
        /// <param name="parameters">Dictionary to populate with decoded field values.</param>
        /// <returns>The number of bits consumed from the binary data.</returns>
        private int DecodeEncodedAI(string binaryData, List<EncodedAI> encodedAIs, Dictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(binaryData) || encodedAIs == null || encodedAIs.Count == 0 || tableF == null)
            {
                return 0;
            }

            int bitPosition = 0;

            foreach (var ai in encodedAIs.OrderBy(a => a.Seq))
            {
                // Get the encoding format from Table F
                var format = tableF.GetEntry(ai.Ai);
                if (format == null)
                {
                    continue;
                }

                // Handle AIs with two components (like 8003 GRAI where value is GRAI base + serial)
                if (format.HasSecondComponent)
                {
                    // Decode component 1 (fixed-length)
                    var (comp1Value, comp1Bits) = DecodeAIValue(binaryData.Substring(bitPosition), format, false);
                    bitPosition += comp1Bits;

                    // Decode component 2 (variable-length) if there's more data
                    string combinedValue = comp1Value ?? "";
                    if (bitPosition < binaryData.Length)
                    {
                        var (comp2Value, comp2Bits) = DecodeAIValue(binaryData.Substring(bitPosition), format, true);
                        bitPosition += comp2Bits;
                        if (comp2Value != null)
                        {
                            combinedValue += comp2Value;
                        }
                    }

                    if (!string.IsNullOrEmpty(combinedValue))
                    {
                        parameters[ai.Name] = combinedValue;
                    }
                }
                else
                {
                    // Single component AI - decode normally
                    var (value, bitsConsumed) = DecodeAIValue(binaryData.Substring(bitPosition), format, false);
                    if (value != null)
                    {
                        parameters[ai.Name] = value;
                    }
                    bitPosition += bitsConsumed;
                }

                if (bitPosition >= binaryData.Length)
                {
                    break;
                }
            }

            return bitPosition;
        }

        /// <summary>
        /// Decodes a single AI value according to Table F format.
        /// </summary>
        /// <param name="binaryData">The binary string to decode from.</param>
        /// <param name="format">The Table F entry defining the encoding format.</param>
        /// <param name="isSecondComponent">True if decoding the second component of a two-component AI.</param>
        /// <returns>Tuple of (decoded value, bits consumed).</returns>
        private (string? value, int bitsConsumed) DecodeAIValue(string binaryData, TableFEntry format, bool isSecondComponent)
        {
            if (string.IsNullOrEmpty(binaryData))
            {
                return (null, 0);
            }

            // Get the appropriate format parameters
            string formatType;
            int? fixedLengthBits;
            int? encodingIndicatorBits;
            int? lengthIndicatorBits;

            if (isSecondComponent)
            {
                formatType = format.Comp2Format ?? "";
                fixedLengthBits = format.Comp2FixedLengthBits;
                encodingIndicatorBits = format.Comp2EncodingIndicatorBits;
                lengthIndicatorBits = format.Comp2LengthIndicatorBits;
            }
            else
            {
                formatType = format.Comp1Format ?? "";
                fixedLengthBits = format.Comp1FixedLengthBits;
                encodingIndicatorBits = format.Comp1EncodingIndicatorBits;
                lengthIndicatorBits = format.Comp1LengthIndicatorBits;
            }

            // Handle fixed-length decoding
            if (fixedLengthBits.HasValue)
            {
                return DecodeFixedLength(binaryData, fixedLengthBits.Value, formatType);
            }
            // Handle variable-length decoding
            else if (encodingIndicatorBits.HasValue || lengthIndicatorBits.HasValue)
            {
                return DecodeVariableLength(binaryData, formatType, encodingIndicatorBits ?? 0, lengthIndicatorBits ?? 0);
            }

            return (null, 0);
        }

        /// <summary>
        /// Decodes a fixed-length binary value.
        /// </summary>
        private (string? value, int bitsConsumed) DecodeFixedLength(string binaryData, int bitLength, string formatType)
        {
            if (binaryData.Length < bitLength)
            {
                return (null, 0);
            }

            string bits = binaryData.Substring(0, bitLength);

            if (formatType.Contains("Fixed-length numeric", StringComparison.OrdinalIgnoreCase))
            {
                // BCD decoding: each decimal digit is 4 bits (TDS 2.3 section 14.5.4)
                var sb = new StringBuilder();
                for (int i = 0; i < bits.Length; i += 4)
                {
                    if (i + 4 <= bits.Length)
                    {
                        int digit = Convert.ToInt32(bits.Substring(i, 4), 2);
                        sb.Append(digit);
                    }
                }
                return (sb.ToString(), bitLength);
            }
            else if (formatType.Contains("date", StringComparison.OrdinalIgnoreCase) ||
                formatType.Contains("Fixed-Bit-Length", StringComparison.OrdinalIgnoreCase))
            {
                // Date/integer decoding: convert from binary to decimal
                var numericValue = BinaryStringToBigInteger(bits);
                return (numericValue.ToString(), bitLength);
            }
            else if (formatType.Contains("Country code", StringComparison.OrdinalIgnoreCase))
            {
                // ISO 3166-1 alpha-2 country code
                return (DecodeCountryCode(bits), bitLength);
            }
            else
            {
                // Default to numeric decoding
                var numericValue = BinaryStringToBigInteger(bits);
                return (numericValue.ToString(), bitLength);
            }
        }

        /// <summary>
        /// Decodes a variable-length binary value.
        /// </summary>
        private (string? value, int bitsConsumed) DecodeVariableLength(string binaryData, string formatType, int encodingIndicatorBits, int lengthIndicatorBits)
        {
            // special handling for "Delimited/terminated numeric" format (TDS 2.3 section 14.5.5)
            if (formatType.Contains("Delimited/terminated numeric", StringComparison.OrdinalIgnoreCase))
            {
                return DecodeDelimitedTerminatedNumeric(binaryData);
            }

            int bitPosition = 0;
            int encodingIndicator = 0;
            int length = 0;

            // Read encoding indicator if present
            if (encodingIndicatorBits > 0)
            {
                if (binaryData.Length < bitPosition + encodingIndicatorBits)
                {
                    return (null, 0);
                }
                encodingIndicator = Convert.ToInt32(binaryData.Substring(bitPosition, encodingIndicatorBits), 2);
                bitPosition += encodingIndicatorBits;
            }

            // Read length indicator
            if (lengthIndicatorBits > 0)
            {
                if (binaryData.Length < bitPosition + lengthIndicatorBits)
                {
                    return (null, 0);
                }
                length = Convert.ToInt32(binaryData.Substring(bitPosition, lengthIndicatorBits), 2);
                bitPosition += lengthIndicatorBits;
            }

            if (length <= 0)
            {
                return ("", bitPosition);
            }

            // Get bit count for the data from Table B
            int dataBits = tableB?.GetBitCount(length, encodingIndicator) ?? 0;
            if (dataBits == 0)
            {
                // Fallback: estimate bits based on encoding type
                dataBits = encodingIndicator switch
                {
                    0 => (int)Math.Ceiling(length * 3.32), // Variable-length integer
                    1 => length * 4, // Upper case hex
                    2 => length * 4, // Lower case hex
                    3 => length * 6, // Base64
                    4 => length * 7, // 7-bit ASCII
                    5 => ((length + 2) / 3) * 16, // URN Code 40
                    _ => length * 7
                };
            }

            if (binaryData.Length < bitPosition + dataBits)
            {
                // Not enough bits, try to decode what we have
                dataBits = binaryData.Length - bitPosition;
            }

            string dataBitsStr = binaryData.Substring(bitPosition, dataBits);
            string? value = DecodeByEncodingIndicator(dataBitsStr, length, encodingIndicator);

            return (value, bitPosition + dataBits);
        }

        /// <summary>
        /// Decodes data bits according to the encoding indicator.
        /// </summary>
        private string? DecodeByEncodingIndicator(string dataBits, int length, int encodingIndicator)
        {
            return encodingIndicator switch
            {
                0 => DecodeVariableLengthInteger(dataBits, length),
                1 => DecodeUpperCaseHex(dataBits, length),
                2 => DecodeLowerCaseHex(dataBits, length),
                3 => DecodeBase64(dataBits, length),
                4 => Decode7BitAscii(dataBits, length),
                5 => DecodeUrnCode40(dataBits, length),
                _ => Decode7BitAscii(dataBits, length) // Default to ASCII
            };
        }

        /// <summary>
        /// Decodes a variable-length integer (encoding indicator 0).
        /// </summary>
        private string DecodeVariableLengthInteger(string dataBits, int length)
        {
            var value = BinaryStringToBigInteger(dataBits);
            return value.ToString().PadLeft(length, '0');
        }

        /// <summary>
        /// Decodes upper case hexadecimal (encoding indicator 1).
        /// </summary>
        private string DecodeUpperCaseHex(string dataBits, int length)
        {
            var result = new StringBuilder();
            for (int i = 0; i < dataBits.Length && result.Length < length; i += 4)
            {
                if (i + 4 <= dataBits.Length)
                {
                    int hexValue = Convert.ToInt32(dataBits.Substring(i, 4), 2);
                    result.Append(hexValue < 10 ? (char)('0' + hexValue) : (char)('A' + hexValue - 10));
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Decodes lower case hexadecimal (encoding indicator 2).
        /// </summary>
        private string DecodeLowerCaseHex(string dataBits, int length)
        {
            var result = new StringBuilder();
            for (int i = 0; i < dataBits.Length && result.Length < length; i += 4)
            {
                if (i + 4 <= dataBits.Length)
                {
                    int hexValue = Convert.ToInt32(dataBits.Substring(i, 4), 2);
                    result.Append(hexValue < 10 ? (char)('0' + hexValue) : (char)('a' + hexValue - 10));
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Decodes base64 (encoding indicator 3).
        /// </summary>
        private string DecodeBase64(string dataBits, int length)
        {
            const string base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
            var result = new StringBuilder();
            for (int i = 0; i < dataBits.Length && result.Length < length; i += 6)
            {
                if (i + 6 <= dataBits.Length)
                {
                    int index = Convert.ToInt32(dataBits.Substring(i, 6), 2);
                    if (index < base64Chars.Length)
                    {
                        result.Append(base64Chars[index]);
                    }
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Decodes 7-bit ASCII (encoding indicator 4).
        /// </summary>
        private string Decode7BitAscii(string dataBits, int length)
        {
            var result = new StringBuilder();
            for (int i = 0; i < dataBits.Length && result.Length < length; i += 7)
            {
                if (i + 7 <= dataBits.Length)
                {
                    int asciiValue = Convert.ToInt32(dataBits.Substring(i, 7), 2);
                    if (asciiValue >= 32 && asciiValue < 127)
                    {
                        result.Append((char)asciiValue);
                    }
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Decodes URN Code 40 (encoding indicator 5).
        /// </summary>
        private string DecodeUrnCode40(string dataBits, int length)
        {
            const string code40Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-.:";
            var result = new StringBuilder();

            // Process in groups of 16 bits (3 characters each)
            for (int i = 0; i < dataBits.Length && result.Length < length; i += 16)
            {
                if (i + 16 <= dataBits.Length)
                {
                    int tripletValue = Convert.ToInt32(dataBits.Substring(i, 16), 2);

                    // Extract 3 characters from the triplet
                    int c3 = tripletValue % 40;
                    tripletValue /= 40;
                    int c2 = tripletValue % 40;
                    tripletValue /= 40;
                    int c1 = tripletValue % 40;

                    if (result.Length < length && c1 < code40Chars.Length) result.Append(code40Chars[c1]);
                    if (result.Length < length && c2 < code40Chars.Length) result.Append(code40Chars[c2]);
                    if (result.Length < length && c3 < code40Chars.Length) result.Append(code40Chars[c3]);
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Decodes a country code from binary.
        /// </summary>
        private string DecodeCountryCode(string bits)
        {
            if (bits.Length < 10)
            {
                return "";
            }

            // Each letter encoded as A=1, B=2, etc. (5 bits each)
            int first = Convert.ToInt32(bits.Substring(0, 5), 2);
            int second = Convert.ToInt32(bits.Substring(5, 5), 2);

            if (first >= 1 && first <= 26 && second >= 1 && second <= 26)
            {
                return $"{(char)('A' + first - 1)}{(char)('A' + second - 1)}";
            }
            return "";
        }

        /// <summary>
        /// Converts a binary string to BigInteger.
        /// </summary>
        private BigInteger BinaryStringToBigInteger(string binary)
        {
            if (string.IsNullOrEmpty(binary))
            {
                return 0;
            }

            BigInteger result = 0;
            foreach (char c in binary)
            {
                result = result * 2 + (c == '1' ? 1 : 0);
            }
            return result;
        }

        /// <summary>
        /// Calculates the total bit length of fixed fields in a BINARY option.
        /// This is used to find where the encodedAI data starts.
        /// </summary>
        private int CalculateFixedBitsLength(Option2 option)
        {
            if (option?.Grammar == null)
            {
                return 0;
            }

            // Parse the grammar to count fixed bits
            // Grammar format: "'11111011' dataToggle filter '0100' expDate encodedAI"
            int totalBits = 0;
            Regex abnf = new Regex(@"\'.*?\'|\s*[\w]+\s*");
            MatchCollection collection = abnf.Matches(option.Grammar);

            foreach (var c in collection)
            {
                string s = c.ToString();

                if (s[0] == '\'')
                {
                    // Literal binary string - count its bits
                    string literal = s.Substring(1, s.Length - 2);
                    if (literal.All(ch => ch == '0' || ch == '1'))
                    {
                        totalBits += literal.Length;
                    }
                }
                else
                {
                    s = s.Trim();
                    if (s.Equals("encodedAI", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith("Encoded", StringComparison.OrdinalIgnoreCase))
                    {
                        // Stop counting - encodedAI, serialEncoded, hostnameEncoded are variable length
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

        #region TDS 2.3 Variable-Length Field Encoding/Decoding

        /// <summary>
        /// Decodes a variable-length alphanumeric field (TDS 2.3).
        /// Format: encoding indicator (3 bits) + length (5 bits) + data (variable)
        /// Uses TDS 2.3 Table B.1 encoding indicators:
        ///   0 = numeric as variable-length integer
        ///   1 = upper-case hex (4 bits/char)
        ///   2 = lower-case hex (4 bits/char)
        ///   3 = Base64URL (6 bits/char)
        ///   4 = 7-bit ASCII
        ///   5 = URN Code 40 (16 bits per 3 chars)
        /// </summary>
        private (string? value, int bitsConsumed) DecodeVariableLengthField(string binaryData, VariableLengthFieldDefinition fieldDef)
        {
            if (string.IsNullOrEmpty(binaryData) || fieldDef == null)
            {
                return (null, 0);
            }

            int encodingIndicatorBits = fieldDef.EncodingIndicatorBits ?? 3;
            int lengthIndicatorBits = fieldDef.LengthIndicatorBits ?? 5;
            int headerBits = encodingIndicatorBits + lengthIndicatorBits;

            if (binaryData.Length < headerBits)
            {
                return (null, 0);
            }

            // Read encoding indicator
            int encodingIndicator = Convert.ToInt32(binaryData.Substring(0, encodingIndicatorBits), 2);

            // Read length (number of characters)
            int charCount = Convert.ToInt32(binaryData.Substring(encodingIndicatorBits, lengthIndicatorBits), 2);

            // Calculate data bit length based on encoding indicator
            int dataBitLength = encodingIndicator switch
            {
                0 => tableB?.GetBitCount(charCount, 0) ?? (int)Math.Ceiling(charCount * 3.32), // Variable-length integer
                1 => charCount * 4, // Upper hex
                2 => charCount * 4, // Lower hex
                3 => charCount * 6, // Base64
                4 => charCount * 7, // 7-bit ASCII
                5 => ((charCount + 2) / 3) * 16, // URN Code 40: 16 bits per 3 chars
                _ => charCount * 7 // Default to ASCII
            };

            int totalBits = headerBits + dataBitLength;
            if (binaryData.Length < totalBits)
            {
                // Fall back to available bits
                dataBitLength = binaryData.Length - headerBits;
            }

            // Extract data bits
            string dataBits = binaryData.Substring(headerBits, dataBitLength);

            // Decode using the correct decoder for the encoding indicator
            string? value = DecodeByEncodingIndicator(dataBits, charCount, encodingIndicator);

            return (value, headerBits + dataBitLength);
        }

        /// <summary>
        /// Decodes a variable-length numeric field (TDS 2.3).
        /// Format: length indicator (bits) + numeric data
        /// </summary>
        private (string? value, int bitsConsumed) DecodeVariableLengthNumericField(string binaryData, VariableLengthFieldDefinition fieldDef)
        {
            if (string.IsNullOrEmpty(binaryData) || fieldDef == null)
            {
                return (null, 0);
            }

            int lengthIndicatorBits = fieldDef.LengthIndicatorBits ?? 5;

            if (binaryData.Length < lengthIndicatorBits)
            {
                return (null, 0);
            }

            // Read length (number of characters)
            int length = Convert.ToInt32(binaryData.Substring(0, lengthIndicatorBits), 2);
            int bitsConsumed = lengthIndicatorBits;

            // Numeric fields use 4 bits per digit (BCD-like)
            var sb = new StringBuilder();
            for (int i = 0; i < length && bitsConsumed + 4 <= binaryData.Length; i++)
            {
                int digit = Convert.ToInt32(binaryData.Substring(bitsConsumed, 4), 2);
                sb.Append(digit);
                bitsConsumed += 4;
            }

            return (sb.ToString(), bitsConsumed);
        }

        /// <summary>
        /// Decodes a delimited numeric field (TDS 2.3 section 14.5.5).
        /// Format: BCD digits + optional mode switch + alphanumeric + terminator
        /// Uses DecodeDelimitedTerminatedNumeric for full support of the encoding.
        /// </summary>
        private (string? value, int bitsConsumed) DecodeDelimitedNumericField(string binaryData, VariableLengthFieldDefinition fieldDef)
        {
            // use the full TDS 2.3 section 14.5.5 decoder for proper mode switching support
            return DecodeDelimitedTerminatedNumeric(binaryData);
        }

        /// <summary>
        /// Decodes a hostname field using HostnameEncoder (TDS 2.3).
        /// </summary>
        private string? DecodeHostnameField(string binaryData)
        {
            if (string.IsNullOrEmpty(binaryData) || binaryData.Length < 7)
            {
                return null;
            }

            try
            {
                return HostnameEncoder.Decode(binaryData);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Encodes a variable-length alphanumeric field (TDS 2.3).
        /// Format: encoding indicator (3 bits) + length (5 bits) + data (variable)
        /// Uses TDS 2.3 Table B.1 encoding indicators:
        ///   0 = numeric as variable-length integer
        ///   1 = upper-case hex (4 bits/char)
        ///   2 = lower-case hex (4 bits/char)
        ///   3 = Base64URL (6 bits/char)
        ///   4 = 7-bit ASCII
        ///   5 = URN Code 40 (~5.33 bits/char)
        /// </summary>
        private string EncodeVariableLengthField(string value, VariableLengthFieldDefinition fieldDef)
        {
            if (string.IsNullOrEmpty(value) || fieldDef == null)
            {
                return "";
            }

            var sb = new StringBuilder();
            int encodingIndicatorBits = fieldDef.EncodingIndicatorBits ?? 3;
            int lengthIndicatorBits = fieldDef.LengthIndicatorBits ?? 5;

            // Use ChooseOptimalEncoding which implements TDS 2.3 Table B.1
            var (encodingIndicator, dataBits) = ChooseOptimalEncoding(value);

            // Write encoding indicator
            sb.Append(Convert.ToString(encodingIndicator, 2).PadLeft(encodingIndicatorBits, '0'));

            // Write length (number of characters)
            sb.Append(Convert.ToString(value.Length, 2).PadLeft(lengthIndicatorBits, '0'));

            // Write data bits from ChooseOptimalEncoding
            sb.Append(dataBits);

            return sb.ToString();
        }

        /// <summary>
        /// Encodes a variable-length numeric field (TDS 2.3).
        /// Format: length indicator (bits) + 4-bit BCD digits
        /// </summary>
        private string EncodeVariableLengthNumericField(string value, VariableLengthFieldDefinition fieldDef)
        {
            if (string.IsNullOrEmpty(value) || fieldDef == null)
            {
                return "";
            }

            var sb = new StringBuilder();
            int lengthIndicatorBits = fieldDef.LengthIndicatorBits ?? 5;

            // Write length
            sb.Append(Convert.ToString(value.Length, 2).PadLeft(lengthIndicatorBits, '0'));

            // Write 4-bit BCD digits
            foreach (char c in value)
            {
                if (char.IsDigit(c))
                {
                    int digit = c - '0';
                    sb.Append(Convert.ToString(digit, 2).PadLeft(4, '0'));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Encodes a delimited numeric field (TDS 2.3 section 14.5.5).
        /// Format: BCD digits + optional mode switch + alphanumeric
        /// NOTE: No terminator is added - the next field boundary defines the end.
        /// Uses EncodeDelimitedTerminatedNumeric for full support of the encoding.
        /// </summary>
        private string EncodeDelimitedNumericField(string value, VariableLengthFieldDefinition fieldDef)
        {
            if (string.IsNullOrEmpty(value))
            {
                return ""; // empty field
            }

            // use the full TDS 2.3 section 14.5.5 encoder for proper mode switching support
            // no terminator - the next field (hostname, etc.) defines the boundary
            return EncodeDelimitedTerminatedNumeric(value);
        }

        /// <summary>
        /// Checks if a string can be encoded using 6-bit alphanumeric encoding.
        /// </summary>
        private bool CanUse6BitAlphanumeric(string value)
        {
            // 6-bit alphanumeric supports: 0-9, A-Z, and some special characters
            foreach (char c in value)
            {
                if (!char.IsDigit(c) && !char.IsUpper(c) &&
                    c != '-' && c != '.' && c != '/' && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Encodes a single character using 6-bit alphanumeric encoding.
        /// Character set: space (0), 0-9 (1-10), A-Z (11-36), special chars
        /// </summary>
        private int Encode6BitAlphanumeric(char c)
        {
            if (c == ' ') return 0;
            if (c >= '0' && c <= '9') return 1 + (c - '0');
            if (c >= 'A' && c <= 'Z') return 11 + (c - 'A');
            if (c == '-') return 37;
            if (c == '.') return 38;
            if (c == '/') return 39;
            return 0; // Default to space
        }

        /// <summary>
        /// Decodes a 6-bit alphanumeric value to a character.
        /// </summary>
        private char Decode6BitAlphanumeric(int value)
        {
            if (value == 0) return ' ';
            if (value >= 1 && value <= 10) return (char)('0' + value - 1);
            if (value >= 11 && value <= 36) return (char)('A' + value - 11);
            if (value == 37) return '-';
            if (value == 38) return '.';
            if (value == 39) return '/';
            return '\0';
        }

        #endregion

        #endregion

        #region Helper Methods - Output Formatting

        private string FormatAsAiJson(Dictionary<string, string> parameterDictionary, Option2 outputOption)
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
                if (aiToFieldMapping.TryGetValue(ai, out string fieldName))
                {
                    if (parameterDictionary.TryGetValue(fieldName, out string fieldValue))
                    {
                        jsonObject[ai] = fieldValue;
                    }
                }
            }

            return JsonSerializer.Serialize(jsonObject);
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
