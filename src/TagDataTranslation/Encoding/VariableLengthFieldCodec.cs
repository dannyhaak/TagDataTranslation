using System;
using System.Linq;
using System.Text;
using TagDataTranslation.Models;
using TagDataTranslation.Tables;

namespace TagDataTranslation.Encoding
{
    /// <summary>
    /// Encodes and decodes TDS 2.3 variable-length fields for '++' schemes.
    /// Handles alphanumeric, numeric, delimited numeric, and hostname fields.
    /// </summary>
    internal class VariableLengthFieldCodec
    {
        private readonly TableB? tableB;

        public VariableLengthFieldCodec(TableB? tableB)
        {
            this.tableB = tableB;
        }

        /// <summary>
        /// Decodes a variable-length alphanumeric field (TDS 2.3).
        /// Format: encoding indicator (3 bits) + length (5 bits) + data (variable)
        /// </summary>
        public (string? value, int bitsConsumed) DecodeVariableLengthField(string binaryData, VariableLengthFieldDefinition fieldDef)
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

            int encodingIndicator = Convert.ToInt32(binaryData.Substring(0, encodingIndicatorBits), 2);
            int charCount = Convert.ToInt32(binaryData.Substring(encodingIndicatorBits, lengthIndicatorBits), 2);

            int dataBitLength = CalculateDataBitLength(charCount, encodingIndicator);

            int totalBits = headerBits + dataBitLength;
            if (binaryData.Length < totalBits)
            {
                dataBitLength = binaryData.Length - headerBits;
            }

            string dataBits = binaryData.Substring(headerBits, dataBitLength);
            string? value = EncodedAICodec.DecodeByEncodingIndicator(dataBits, charCount, encodingIndicator);

            return (value, headerBits + dataBitLength);
        }

        /// <summary>
        /// Decodes a variable-length numeric field (TDS 2.3).
        /// Format: length indicator (bits) + 4-bit BCD digits
        /// </summary>
        public (string? value, int bitsConsumed) DecodeVariableLengthNumericField(string binaryData, VariableLengthFieldDefinition fieldDef)
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

            int length = Convert.ToInt32(binaryData.Substring(0, lengthIndicatorBits), 2);
            int bitsConsumed = lengthIndicatorBits;

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
        /// </summary>
        public (string? value, int bitsConsumed) DecodeDelimitedNumericField(string binaryData, VariableLengthFieldDefinition fieldDef)
        {
            return DecodeDelimitedTerminatedNumeric(binaryData);
        }

        /// <summary>
        /// Encodes a variable-length alphanumeric field (TDS 2.3).
        /// Format: encoding indicator (3 bits) + length (5 bits) + data (variable)
        /// </summary>
        public string EncodeVariableLengthField(string value, VariableLengthFieldDefinition fieldDef)
        {
            if (string.IsNullOrEmpty(value) || fieldDef == null)
            {
                return "";
            }

            var sb = new StringBuilder();
            int encodingIndicatorBits = fieldDef.EncodingIndicatorBits ?? 3;
            int lengthIndicatorBits = fieldDef.LengthIndicatorBits ?? 5;

            var (encodingIndicator, dataBits) = EncodedAICodec.ChooseOptimalEncoding(value, tableB);

            sb.Append(Convert.ToString(encodingIndicator, 2).PadLeft(encodingIndicatorBits, '0'));
            sb.Append(Convert.ToString(value.Length, 2).PadLeft(lengthIndicatorBits, '0'));
            sb.Append(dataBits);

            return sb.ToString();
        }

        /// <summary>
        /// Encodes a variable-length numeric field (TDS 2.3).
        /// Format: length indicator (bits) + 4-bit BCD digits
        /// </summary>
        public string EncodeVariableLengthNumericField(string value, VariableLengthFieldDefinition fieldDef)
        {
            if (string.IsNullOrEmpty(value) || fieldDef == null)
            {
                return "";
            }

            var sb = new StringBuilder();
            int lengthIndicatorBits = fieldDef.LengthIndicatorBits ?? 5;

            sb.Append(Convert.ToString(value.Length, 2).PadLeft(lengthIndicatorBits, '0'));

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
        /// </summary>
        public string EncodeDelimitedNumericField(string value, VariableLengthFieldDefinition fieldDef)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }

            return EncodeDelimitedTerminatedNumeric(value);
        }

        /// <summary>
        /// Decodes a hostname field using HostnameEncoder (TDS 2.3).
        /// </summary>
        public static string? DecodeHostnameField(string binaryData)
        {
            if (string.IsNullOrEmpty(binaryData) || binaryData.Length < 7)
            {
                return null;
            }

            try
            {
                return HostnameEncoder.Decode(binaryData);
            }
            catch (FormatException)
            {
                return null;
            }
            catch (OverflowException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        internal int CalculateDataBitLength(int charCount, int encodingIndicator)
        {
            return encodingIndicator switch
            {
                0 => tableB?.GetBitCount(charCount, 0) ?? (int)Math.Ceiling(charCount * 3.32),
                1 => charCount * 4,
                2 => charCount * 4,
                3 => charCount * 6,
                4 => charCount * 7,
                5 => ((charCount + 2) / 3) * 16,
                _ => charCount * 7
            };
        }

        /// <summary>
        /// Encodes a value using TDS 2.3 section 14.5.5 "Delimited/terminated numeric" format.
        /// </summary>
        internal static string EncodeDelimitedTerminatedNumeric(string value)
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
        /// Decodes a value encoded using TDS 2.3 section 14.5.5 "Delimited/terminated numeric" format.
        /// </summary>
        internal static (string? value, int bitsConsumed) DecodeDelimitedTerminatedNumeric(string binaryData)
        {
            if (string.IsNullOrEmpty(binaryData) || binaryData.Length < 4)
            {
                return (null, 0);
            }

            var result = new StringBuilder();
            int bitPosition = 0;

            while (bitPosition + 4 <= binaryData.Length)
            {
                int nibble = Convert.ToInt32(binaryData.Substring(bitPosition, 4), 2);

                if (nibble >= 0 && nibble <= 9)
                {
                    result.Append((char)('0' + nibble));
                    bitPosition += 4;
                }
                else if (nibble == 14)
                {
                    bitPosition += 4;

                    if (bitPosition + 3 > binaryData.Length) break;
                    bitPosition += 3;

                    if (bitPosition + 5 > binaryData.Length) break;
                    int length = Convert.ToInt32(binaryData.Substring(bitPosition, 5), 2);
                    bitPosition += 5;

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
                    bitPosition += 4;
                    break;
                }
                else
                {
                    break;
                }
            }

            return (result.ToString(), bitPosition);
        }
    }
}
