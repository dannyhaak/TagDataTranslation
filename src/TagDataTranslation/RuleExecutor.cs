using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TagDataTranslation.DigitalLink;
using TagDataTranslation.Encoding;
using TagDataTranslation.Models;

namespace TagDataTranslation
{
    /// <summary>
    /// Executes EXTRACT and FORMAT transformation rules on parameter dictionaries.
    /// </summary>
    internal static class RuleExecutor
    {
        /// <summary>
        /// Executes transformation rules on the parameter dictionary.
        /// </summary>
        public static void ExecuteRules(List<Rule> rules, Dictionary<string, string> parameterDictionary)
        {
            if (rules == null) return;

            foreach (var rule in rules)
            {
                string newFieldName = rule.NewFieldName ?? "";

                if (string.IsNullOrEmpty(rule.Function)) continue;

                string[] functionSplit = rule.Function.Split(new char[] { '(', ',', ')' }, 128);
                string functionName = functionSplit[0];
                string[] functionParameters = new string[functionSplit.Length - 2];
                Array.Copy(functionSplit, 1, functionParameters, 0, functionSplit.Length - 2);
                int paramCount = functionParameters.Length;

                string? newFieldValue = null;

                switch (functionName)
                {
                    case "SUBSTR":
                        if (paramCount == 2 || paramCount == 3)
                        {
                            string substrInput = GetValue(functionParameters[0], parameterDictionary);
                            int offset = int.Parse(GetValue(functionParameters[1], parameterDictionary));

                            if (paramCount == 2)
                            {
                                newFieldValue = ApplySubstr(substrInput, offset);
                            }
                            else
                            {
                                int length = int.Parse(GetValue(functionParameters[2], parameterDictionary));
                                newFieldValue = ApplySubstr(substrInput, offset, length);
                            }
                        }
                        break;

                    case "CONCAT":
                        List<string> concatInput = new List<string>();
                        for (int i = 0; i < paramCount; i++)
                        {
                            string val = GetValue(functionParameters[i], parameterDictionary);
                            concatInput.Add(val);
                        }
                        newFieldValue = ApplyConcat(concatInput);
                        break;

                    case "GS1CHECKSUM":
                        string checksumValue = GetValue(functionParameters[0], parameterDictionary);
                        newFieldValue = ApplyGs1Checksum(checksumValue);
                        break;

                    case "URLENCODE":
                        if (paramCount >= 1)
                        {
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
                        if (paramCount >= 1)
                        {
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
                        if (paramCount >= 1)
                        {
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
                        if (paramCount >= 1)
                        {
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
                        continue;
                }

                if (newFieldValue == null) continue;

                // validate character set
                if (rule.CharacterSet != null)
                {
                    if (!ValidateCharacterset(newFieldValue, rule.CharacterSet))
                    {
                        throw new TDTTranslationException("TDTFieldOutsideCharacterSet");
                    }
                }

                // validate range
                if (rule.DecimalMinimum != null)
                {
                    BigInteger integer = BigInteger.Parse(newFieldValue);
                    if (IsBelowMinimum(integer, rule.DecimalMinimum))
                    {
                        throw new TDTTranslationException("TDTFieldBelowMinimum");
                    }
                }

                if (rule.DecimalMaximum != null)
                {
                    BigInteger integer = BigInteger.Parse(newFieldValue);
                    if (IsAboveMaximum(integer, rule.DecimalMaximum))
                    {
                        throw new TDTTranslationException("TDTFieldAboveMaximum");
                    }
                }

                parameterDictionary[newFieldName] = newFieldValue;
            }
        }

        internal static string GetValue(string input, Dictionary<string, string> epcIdentifierDictionary)
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

            if (epcIdentifierDictionary.TryGetValue(input, out string? newInput))
            {
                return newInput;
            }

            // try case-insensitive lookup
            var key = epcIdentifierDictionary.Keys.FirstOrDefault(k => k.Equals(input, StringComparison.OrdinalIgnoreCase));
            if (key != null)
            {
                return epcIdentifierDictionary[key];
            }

            return input;
        }

        private static string ApplySubstr(string input, int offset)
        {
            if (offset >= input.Length) return "";
            return input.Substring(offset);
        }

        private static string ApplySubstr(string input, int offset, int length)
        {
            if (offset >= input.Length) return "";
            if (offset + length > input.Length) length = input.Length - offset;
            return input.Substring(offset, length);
        }

        private static string ApplyConcat(List<string> input)
        {
            return string.Concat(input);
        }

        internal static string ApplyGs1Checksum(string input)
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

        internal static bool ValidateCharacterset(string input, string characterSet)
        {
            if (input.Length == 0)
                return true;

            try
            {
                System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^" + characterSet + "$");
                return r.IsMatch(input);
            }
            catch
            {
                // invalid regex in character set pattern — allow input through
                // rather than silently rejecting or crashing
                return true;
            }
        }

        private static bool IsBelowMinimum(BigInteger input, string minimum)
        {
            BigInteger.TryParse(minimum, out BigInteger minimumInt);
            return input < minimumInt;
        }

        private static bool IsAboveMaximum(BigInteger input, string maximum)
        {
            BigInteger.TryParse(maximum, out BigInteger maximumInt);
            return input > maximumInt;
        }
    }
}
