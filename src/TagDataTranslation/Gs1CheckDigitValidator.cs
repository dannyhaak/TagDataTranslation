using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace TagDataTranslation
{
    /// <summary>
    /// Validates the GS1 check digit of GS1 identification keys supplied in the input value.
    /// The translation recalculates check digits for output, so a wrong check digit in the input
    /// would otherwise be replaced silently with a different, valid key.
    /// </summary>
    internal static class Gs1CheckDigitValidator
    {
        // offset of the first digit of the key within the AI value, and the length of the key including its check digit
        private static readonly Dictionary<string, (int Offset, int Length)> KeyLayout = new()
        {
            { "00", (0, 18) },
            { "01", (0, 14) },
            { "253", (0, 13) },
            { "255", (0, 13) },
            { "414", (0, 13) },
            { "8003", (1, 13) },
            { "8006", (0, 14) },
            { "8017", (0, 18) },
            { "8018", (0, 18) }
        };

        private static readonly Dictionary<string, string> BareKeyToAi = new()
        {
            { "gtin", "01" },
            { "sscc", "00" },
            { "gln", "414" },
            { "grai", "8003" },
            { "gdti", "253" },
            { "gsrn", "8018" },
            { "gsrnp", "8017" },
            { "sgcn", "255" },
            { "gcn", "255" },
            { "itip", "8006" }
        };

        private static readonly Regex DigitalLinkKey = new(@"/(00|01|253|255|414|8003|8006|8017|8018)/([^/?#]+)", RegexOptions.Compiled);
        private static readonly Regex BareKey = new(@"(?:^|;)(gtin|sscc|gln|grai|gdti|gsrn|gsrnp|sgcn|gcn|itip)=([0-9]+)", RegexOptions.Compiled);

        /// <summary>
        /// Validates the check digits in the input value. Throws TDTInvalidCheckDigit if one is wrong.
        /// </summary>
        public static void Validate(string input, TDTEngine.LevelType levelType, string schemeName, Dictionary<string, string> parameterDictionary)
        {
            switch (levelType)
            {
                case TDTEngine.LevelType.GS1_DIGITAL_LINK:
                    foreach (Match m in DigitalLinkKey.Matches(input))
                    {
                        ValidateAiValue(m.Groups[1].Value, Uri.UnescapeDataString(m.Groups[2].Value));
                    }
                    break;

                case TDTEngine.LevelType.GS1_AI_JSON:
                    ValidateAiJson(input);
                    break;

                case TDTEngine.LevelType.BARE_IDENTIFIER:
                case TDTEngine.LevelType.BARE_IDENTIFIER_ALT:
                    foreach (Match m in BareKey.Matches(input))
                    {
                        string key = m.Groups[1].Value;
                        string value = m.Groups[2].Value;
                        // the bare identifier of GRAI-96 and GRAI-170 excludes the pad digit that precedes the GRAI in AI (8003)
                        if (key == "grai" && schemeName.StartsWith("GRAI-", StringComparison.Ordinal))
                        {
                            value = "0" + value;
                        }
                        ValidateAiValue(BareKeyToAi[key], value);
                    }
                    break;

                case TDTEngine.LevelType.BINARY:
                    // older schemes do not encode the check digit, the '+' and '++' schemes encode the key intact
                    if (!schemeName.Contains('+')) break;
                    foreach (var (name, ai) in BareKeyToAi)
                    {
                        if (parameterDictionary.TryGetValue(name, out var value))
                        {
                            ValidateAiValue(ai, value);
                        }
                    }
                    if (parameterDictionary.TryGetValue("valueOf8003", out var valueOf8003))
                    {
                        ValidateAiValue("8003", valueOf8003);
                    }
                    break;
            }
        }

        private static void ValidateAiJson(string input)
        {
            try
            {
                using var doc = JsonDocument.Parse(input);
                if (doc.RootElement.ValueKind != JsonValueKind.Object) return;
                foreach (var property in doc.RootElement.EnumerateObject())
                {
                    if (property.Value.ValueKind == JsonValueKind.String)
                    {
                        ValidateAiValue(property.Name, property.Value.GetString()!);
                    }
                }
            }
            catch (JsonException)
            {
                throw new TDTTranslationException("TDTOptionNotFound");
            }
        }

        internal static void ValidateAiValue(string ai, string value)
        {
            if (!KeyLayout.TryGetValue(ai, out var layout)) return;
            if (value.Length < layout.Offset + layout.Length) return;

            string key = value.Substring(layout.Offset, layout.Length);
            if (!key.All(c => c >= '0' && c <= '9')) return;

            string expected = RuleExecutor.ApplyGs1Checksum(key.Substring(0, key.Length - 1));
            if (key[key.Length - 1].ToString() != expected)
            {
                throw new TDTTranslationException("TDTInvalidCheckDigit");
            }
        }
    }
}
