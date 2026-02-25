using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using TagDataTranslation.Models;
using TagDataTranslation.Tables;

namespace TagDataTranslation.Encoding
{
    /// <summary>
    /// Encodes and decodes AI (Application Identifier) data for '+' schemes.
    /// Uses Table F for encoding format definitions and Table B for bit counts.
    /// </summary>
    internal class EncodedAICodec
    {
        private readonly TableF? tableF;
        private readonly TableB? tableB;

        public EncodedAICodec(TableF? tableF, TableB? tableB)
        {
            this.tableF = tableF;
            this.tableB = tableB;
        }

        /// <summary>
        /// Processes encoded AI data for "+" schemes (SGTIN+, SSCC+, GRAI+, etc.).
        /// </summary>
        public string ProcessEncodedAI(List<EncodedAI> encodedAIs, Dictionary<string, string> parameters)
        {
            if (encodedAIs == null || encodedAIs.Count == 0 || tableF == null)
            {
                return "";
            }

            var bits = new StringBuilder();

            foreach (var ai in encodedAIs.OrderBy(a => a.Seq))
            {
                if (!parameters.TryGetValue(ai.Name ?? "", out var value))
                {
                    var key = parameters.Keys.FirstOrDefault(k => k.Equals(ai.Name, StringComparison.OrdinalIgnoreCase));
                    if (key != null)
                    {
                        value = parameters[key];
                    }
                    else
                    {
                        continue;
                    }
                }

                var format = tableF.GetEntry(ai.Ai ?? "");
                if (format == null)
                {
                    throw new TDTTranslationException($"Unknown AI '{ai.Ai}' in Table F");
                }

                if (format.HasSecondComponent && format.Comp1FixedLengthChars.HasValue)
                {
                    int comp1Length = format.Comp1FixedLengthChars.Value;
                    if (value.Length > comp1Length)
                    {
                        string comp1Value = value.Substring(0, comp1Length);
                        string comp2Value = value.Substring(comp1Length);
                        bits.Append(EncodeAIValue(comp1Value, format, false));
                        bits.Append(EncodeAIValue(comp2Value, format, true));
                    }
                    else
                    {
                        bits.Append(EncodeAIValue(value, format, false));
                    }
                }
                else
                {
                    bits.Append(EncodeAIValue(value, format, false));
                }
            }

            return bits.ToString();
        }

        /// <summary>
        /// Decodes encoded AI data from binary for "+" schemes.
        /// </summary>
        public int DecodeEncodedAI(string binaryData, List<EncodedAI> encodedAIs, Dictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(binaryData) || encodedAIs == null || encodedAIs.Count == 0 || tableF == null)
            {
                return 0;
            }

            int bitPosition = 0;

            foreach (var ai in encodedAIs.OrderBy(a => a.Seq))
            {
                var format = tableF.GetEntry(ai.Ai ?? "");
                if (format == null)
                {
                    continue;
                }

                if (format.HasSecondComponent)
                {
                    var (comp1Value, comp1Bits) = DecodeAIValue(binaryData.Substring(bitPosition), format, false);
                    bitPosition += comp1Bits;

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

                    if (!string.IsNullOrEmpty(combinedValue) && ai.Name != null)
                    {
                        parameters[ai.Name] = combinedValue;
                    }
                }
                else
                {
                    var (value, bitsConsumed) = DecodeAIValue(binaryData.Substring(bitPosition), format, false);
                    if (value != null && ai.Name != null)
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

        private string EncodeAIValue(string value, TableFEntry format, bool isSecondComponent)
        {
            var bits = new StringBuilder();

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

            if (fixedLengthBits.HasValue)
            {
                bits.Append(EncodeFixedLength(value, fixedLengthBits.Value, formatType));
            }
            else if (encodingIndicatorBits.HasValue || lengthIndicatorBits.HasValue)
            {
                bits.Append(EncodeVariableLength(value, formatType, encodingIndicatorBits ?? 0, lengthIndicatorBits ?? 0));
            }

            return bits.ToString();
        }

        private (string? value, int bitsConsumed) DecodeAIValue(string binaryData, TableFEntry format, bool isSecondComponent)
        {
            if (string.IsNullOrEmpty(binaryData))
            {
                return (null, 0);
            }

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

            if (fixedLengthBits.HasValue)
            {
                return DecodeFixedLength(binaryData, fixedLengthBits.Value, formatType);
            }
            else if (encodingIndicatorBits.HasValue || lengthIndicatorBits.HasValue)
            {
                return DecodeVariableLength(binaryData, formatType, encodingIndicatorBits ?? 0, lengthIndicatorBits ?? 0);
            }

            return (null, 0);
        }

        #region Fixed-length encoding/decoding

        private string EncodeFixedLength(string value, int bitLength, string formatType)
        {
            if (formatType.Contains("Fixed-length numeric", StringComparison.OrdinalIgnoreCase))
            {
                var sb = new StringBuilder();
                int expectedDigits = bitLength / 4;
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
                        sb.Append("0000");
                    }
                }
                return sb.ToString();
            }
            else if (formatType.Contains("date", StringComparison.OrdinalIgnoreCase) ||
                formatType.Contains("Fixed-Bit-Length", StringComparison.OrdinalIgnoreCase))
            {
                if (BigInteger.TryParse(value, out var numericValue))
                {
                    var binary = ToBinaryString(numericValue);
                    return binary.PadLeft(bitLength, '0');
                }
                else
                {
                    return EncodeAsAscii(value, bitLength);
                }
            }
            else if (formatType.Contains("Country code", StringComparison.OrdinalIgnoreCase))
            {
                return EncodeCountryCode(value, bitLength);
            }
            else
            {
                if (BigInteger.TryParse(value, out var numericValue))
                {
                    var binary = ToBinaryString(numericValue);
                    return binary.PadLeft(bitLength, '0');
                }
                return new string('0', bitLength);
            }
        }

        private (string? value, int bitsConsumed) DecodeFixedLength(string binaryData, int bitLength, string formatType)
        {
            if (binaryData.Length < bitLength)
            {
                return (null, 0);
            }

            string bits = binaryData.Substring(0, bitLength);

            if (formatType.Contains("Fixed-length numeric", StringComparison.OrdinalIgnoreCase))
            {
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
                var numericValue = BinaryConverter.BinaryStringToBigInteger(bits);
                return (numericValue.ToString(), bitLength);
            }
            else if (formatType.Contains("Country code", StringComparison.OrdinalIgnoreCase))
            {
                return (DecodeCountryCode(bits), bitLength);
            }
            else
            {
                var numericValue = BinaryConverter.BinaryStringToBigInteger(bits);
                return (numericValue.ToString(), bitLength);
            }
        }

        #endregion

        #region Variable-length encoding/decoding

        private string EncodeVariableLength(string value, string formatType, int encodingIndicatorBits, int lengthIndicatorBits)
        {
            var bits = new StringBuilder();
            int encodingIndicator;
            string dataBits;

            if (formatType.Contains("alphanumeric", StringComparison.OrdinalIgnoreCase))
            {
                (encodingIndicator, dataBits) = ChooseOptimalEncoding(value, tableB);
            }
            else if (formatType.Contains("numeric string without encoding indicator", StringComparison.OrdinalIgnoreCase))
            {
                encodingIndicator = 0;
                dataBits = EncodeVariableLengthInteger(value, tableB);

                bits.Append(Convert.ToString(value.Length, 2).PadLeft(lengthIndicatorBits, '0'));
                bits.Append(dataBits);
                return bits.ToString();
            }
            else if (formatType.Contains("Delimited/terminated numeric", StringComparison.OrdinalIgnoreCase))
            {
                return VariableLengthFieldCodec.EncodeDelimitedTerminatedNumeric(value);
            }
            else
            {
                encodingIndicator = 0;
                dataBits = EncodeVariableLengthInteger(value, tableB);
            }

            if (encodingIndicatorBits > 0)
            {
                bits.Append(Convert.ToString(encodingIndicator, 2).PadLeft(encodingIndicatorBits, '0'));
            }

            if (lengthIndicatorBits > 0)
            {
                bits.Append(Convert.ToString(value.Length, 2).PadLeft(lengthIndicatorBits, '0'));
            }

            bits.Append(dataBits);

            return bits.ToString();
        }

        private (string? value, int bitsConsumed) DecodeVariableLength(string binaryData, string formatType, int encodingIndicatorBits, int lengthIndicatorBits)
        {
            if (formatType.Contains("Delimited/terminated numeric", StringComparison.OrdinalIgnoreCase))
            {
                return VariableLengthFieldCodec.DecodeDelimitedTerminatedNumeric(binaryData);
            }

            int bitPosition = 0;
            int encodingIndicator = 0;
            int length = 0;

            if (encodingIndicatorBits > 0)
            {
                if (binaryData.Length < bitPosition + encodingIndicatorBits)
                {
                    return (null, 0);
                }
                encodingIndicator = Convert.ToInt32(binaryData.Substring(bitPosition, encodingIndicatorBits), 2);
                bitPosition += encodingIndicatorBits;
            }

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

            int dataBits = tableB?.GetBitCount(length, encodingIndicator) ?? 0;
            if (dataBits == 0)
            {
                dataBits = encodingIndicator switch
                {
                    0 => (int)Math.Ceiling(length * 3.32),
                    1 => length * 4,
                    2 => length * 4,
                    3 => length * 6,
                    4 => length * 7,
                    5 => ((length + 2) / 3) * 16,
                    _ => length * 7
                };
            }

            if (binaryData.Length < bitPosition + dataBits)
            {
                dataBits = binaryData.Length - bitPosition;
            }

            string dataBitsStr = binaryData.Substring(bitPosition, dataBits);
            string? value = DecodeByEncodingIndicator(dataBitsStr, length, encodingIndicator);

            return (value, bitPosition + dataBits);
        }

        #endregion

        #region Encoding helpers (static, shared with VariableLengthFieldCodec)

        /// <summary>
        /// Chooses the optimal encoding method for an alphanumeric string.
        /// </summary>
        internal static (int encodingIndicator, string dataBits) ChooseOptimalEncoding(string value, TableB? tableB)
        {
            if (IsNumericOnly(value))
            {
                return (0, EncodeVariableLengthInteger(value, tableB));
            }

            if (IsUpperCaseHex(value))
            {
                return (1, EncodeUpperCaseHex(value));
            }

            if (IsLowerCaseHex(value))
            {
                return (2, EncodeLowerCaseHex(value));
            }

            if (IsBase64Safe(value))
            {
                return (3, EncodeBase64(value));
            }

            if (IsUrnCode40(value))
            {
                return (5, EncodeUrnCode40(value));
            }

            return (4, EncodeAscii(value));
        }

        /// <summary>
        /// Decodes data bits according to the encoding indicator.
        /// </summary>
        internal static string? DecodeByEncodingIndicator(string dataBits, int length, int encodingIndicator)
        {
            return encodingIndicator switch
            {
                0 => DecodeVariableLengthInteger(dataBits, length),
                1 => DecodeUpperCaseHex(dataBits, length),
                2 => DecodeLowerCaseHex(dataBits, length),
                3 => DecodeBase64(dataBits, length),
                4 => Decode7BitAscii(dataBits, length),
                5 => DecodeUrnCode40(dataBits, length),
                _ => Decode7BitAscii(dataBits, length)
            };
        }

        internal static string EncodeVariableLengthInteger(string value, TableB? tableB)
        {
            if (string.IsNullOrEmpty(value) || !BigInteger.TryParse(value, out var numericValue))
            {
                return "";
            }

            int bitCount = tableB?.GetBitCount(value.Length, 0) ?? (int)Math.Ceiling(value.Length * 3.32);
            var binary = ToBinaryString(numericValue);
            return binary.PadLeft(bitCount, '0');
        }

        internal static string EncodeUpperCaseHex(string value)
        {
            var bits = new StringBuilder();
            foreach (char c in value.ToUpper())
            {
                int hexValue = c >= '0' && c <= '9' ? c - '0' : c - 'A' + 10;
                bits.Append(Convert.ToString(hexValue, 2).PadLeft(4, '0'));
            }
            return bits.ToString();
        }

        internal static string EncodeLowerCaseHex(string value)
        {
            var bits = new StringBuilder();
            foreach (char c in value.ToLower())
            {
                int hexValue = c >= '0' && c <= '9' ? c - '0' : c - 'a' + 10;
                bits.Append(Convert.ToString(hexValue, 2).PadLeft(4, '0'));
            }
            return bits.ToString();
        }

        internal static string EncodeBase64(string value)
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

        internal static string EncodeAscii(string value)
        {
            var bits = new StringBuilder();
            foreach (char c in value)
            {
                bits.Append(Convert.ToString((int)c, 2).PadLeft(7, '0'));
            }
            return bits.ToString();
        }

        internal static string EncodeUrnCode40(string value)
        {
            const string code40Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-.:";
            var bits = new StringBuilder();

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

                int remaining = Math.Min(3, value.Length - i);
                if (remaining < 3)
                {
                    for (int j = remaining; j < 3; j++)
                    {
                        tripletValue = tripletValue * 40;
                    }
                }

                bits.Append(Convert.ToString(tripletValue, 2).PadLeft(16, '0'));
            }

            return bits.ToString();
        }

        internal static string EncodeAsAscii(string value, int bitLength)
        {
            var bits = new StringBuilder();
            foreach (char c in value)
            {
                bits.Append(Convert.ToString((int)c, 2).PadLeft(7, '0'));
            }
            if (bits.Length < bitLength)
            {
                bits.Append(new string('0', bitLength - bits.Length));
            }
            return bits.ToString().Substring(0, Math.Min(bits.Length, bitLength));
        }

        internal static string EncodeCountryCode(string value, int bitLength)
        {
            if (value.Length != 2)
            {
                return new string('0', bitLength);
            }

            int first = char.ToUpper(value[0]) - 'A' + 1;
            int second = char.ToUpper(value[1]) - 'A' + 1;
            var binary = Convert.ToString(first, 2).PadLeft(5, '0') + Convert.ToString(second, 2).PadLeft(5, '0');
            return binary.PadLeft(bitLength, '0');
        }

        #endregion

        #region Decoding helpers (static)

        internal static string DecodeVariableLengthInteger(string dataBits, int length)
        {
            var value = BinaryConverter.BinaryStringToBigInteger(dataBits);
            return value.ToString().PadLeft(length, '0');
        }

        internal static string DecodeUpperCaseHex(string dataBits, int length)
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

        internal static string DecodeLowerCaseHex(string dataBits, int length)
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

        internal static string DecodeBase64(string dataBits, int length)
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

        internal static string Decode7BitAscii(string dataBits, int length)
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

        internal static string DecodeUrnCode40(string dataBits, int length)
        {
            const string code40Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-.:";
            var result = new StringBuilder();

            for (int i = 0; i < dataBits.Length && result.Length < length; i += 16)
            {
                if (i + 16 <= dataBits.Length)
                {
                    int tripletValue = Convert.ToInt32(dataBits.Substring(i, 16), 2);

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

        internal static string DecodeCountryCode(string bits)
        {
            if (bits.Length < 10)
            {
                return "";
            }

            int first = Convert.ToInt32(bits.Substring(0, 5), 2);
            int second = Convert.ToInt32(bits.Substring(5, 5), 2);

            if (first >= 1 && first <= 26 && second >= 1 && second <= 26)
            {
                return $"{(char)('A' + first - 1)}{(char)('A' + second - 1)}";
            }
            return "";
        }

        #endregion

        #region Character set validation (static)

        internal static bool IsNumericOnly(string value) =>
            !string.IsNullOrEmpty(value) && value.All(c => c >= '0' && c <= '9');

        internal static bool IsUpperCaseHex(string value) =>
            !string.IsNullOrEmpty(value) && value.All(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F'));

        internal static bool IsLowerCaseHex(string value) =>
            !string.IsNullOrEmpty(value) && value.All(c => (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f'));

        internal static bool IsBase64Safe(string value) =>
            !string.IsNullOrEmpty(value) && value.All(c =>
                (c >= '0' && c <= '9') ||
                (c >= 'A' && c <= 'Z') ||
                (c >= 'a' && c <= 'z') ||
                c == '-' || c == '_');

        internal static bool IsUrnCode40(string value) =>
            !string.IsNullOrEmpty(value) && value.All(c =>
                (c >= '0' && c <= '9') ||
                (c >= 'A' && c <= 'Z') ||
                (c >= 'a' && c <= 'z') ||
                c == '-' || c == '.' || c == ':');

        #endregion

        #region Utility

        internal static string ToBinaryString(BigInteger value)
        {
            if (value == 0)
            {
                return "0";
            }

            // stack-based to avoid O(n²) from StringBuilder.Insert(0, ...)
            var digits = new Stack<char>();
            while (value > 0)
            {
                digits.Push((char)('0' + (int)(value % 2)));
                value /= 2;
            }
            return new string(digits.ToArray());
        }

        #endregion
    }
}
