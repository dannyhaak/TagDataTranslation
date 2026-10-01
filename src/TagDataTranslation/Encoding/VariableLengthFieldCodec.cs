using System;
using System.Numerics;
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

            // TDS 2.3 section 14.5.13: the value is an unsigned integer of ceiling(L*log2(10)) bits, left-padded to L digits
            int length = Convert.ToInt32(binaryData.Substring(0, lengthIndicatorBits), 2);
            int valueBits = NumericStringBitLength(length);

            if (binaryData.Length < lengthIndicatorBits + valueBits)
            {
                return (null, 0);
            }

            var value = BinaryConverter.BinaryStringToBigInteger(binaryData.Substring(lengthIndicatorBits, valueBits));
            string digits = value.ToString().PadLeft(length, '0');
            if (digits.Length != length)
            {
                throw new TDTTranslationException("TDTFieldAboveMaximum");
            }

            return (digits, lengthIndicatorBits + valueBits);
        }

        private static int NumericStringBitLength(int digits) => EncodedAICodec.NumericBitLength(digits);

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
        /// Encodes a variable-length numeric string without encoding indicator (TDS 2.3 section 14.5.13).
        /// Format: length indicator (bits) + the digits as an unsigned integer of ceiling(L*log2(10)) bits
        /// </summary>
        public string EncodeVariableLengthNumericField(string value, VariableLengthFieldDefinition fieldDef)
        {
            if (string.IsNullOrEmpty(value) || fieldDef == null)
            {
                return "";
            }

            int lengthIndicatorBits = fieldDef.LengthIndicatorBits ?? 5;
            if (!value.All(c => c >= '0' && c <= '9') || value.Length >= (1 << lengthIndicatorBits))
            {
                throw new TDTTranslationException("TDTFieldOutsideCharacterSet");
            }

            var sb = new StringBuilder();
            sb.Append(Convert.ToString(value.Length, 2).PadLeft(lengthIndicatorBits, '0'));
            sb.Append(EncodedAICodec.ToBinaryString(BigInteger.Parse(value)).PadLeft(NumericStringBitLength(value.Length), '0'));

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
                0 => tableB?.GetBitCount(charCount, 0) ?? EncodedAICodec.NumericBitLength(charCount),
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

            if (i == value.Length)
            {
                // terminator: the string is all-numeric
                bits.Append("1111");
            }
            else
            {
                // delimiter, then the remainder using the variable-length alphanumeric method (3-bit indicator, 5-bit length)
                string remaining = value.Substring(i);
                var (encodingIndicator, dataBits) = EncodedAICodec.ChooseOptimalEncoding(remaining, null);

                bits.Append("1110");
                bits.Append(Convert.ToString(encodingIndicator, 2).PadLeft(3, '0'));
                bits.Append(Convert.ToString(remaining.Length, 2).PadLeft(5, '0'));
                bits.Append(dataBits);
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
                    // delimiter, then a variable-length alphanumeric remainder: 3-bit indicator, 5-bit length, data
                    bitPosition += 4;
                    if (bitPosition + 8 > binaryData.Length) return (null, 0);

                    int encodingIndicator = Convert.ToInt32(binaryData.Substring(bitPosition, 3), 2);
                    int length = Convert.ToInt32(binaryData.Substring(bitPosition + 3, 5), 2);
                    bitPosition += 8;

                    int dataBits = EncodedAICodec.DataBitLength(encodingIndicator, length);
                    if (bitPosition + dataBits > binaryData.Length) return (null, 0);

                    result.Append(EncodedAICodec.DecodeByEncodingIndicator(binaryData.Substring(bitPosition, dataBits), length, encodingIndicator));
                    bitPosition += dataBits;
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
