using System;
using System.Numerics;
using System.Text;

namespace TagDataTranslation
{
    /// <summary>
    /// Utility class for converting between hex, binary, and BigInteger representations.
    /// </summary>
    public static class BinaryConverter
    {
        // lookup table: hex char (by ASCII index) → 4-char binary string
        private static readonly string[] HexToBinaryTable = new string[128];

        // lookup table: 4-bit value (0–15) → hex char
        private static readonly char[] BinaryToHexTable = "0123456789abcdef".ToCharArray();

        static BinaryConverter()
        {
            for (int i = 0; i < 16; i++)
            {
                string bits = Convert.ToString(i, 2).PadLeft(4, '0');
                char lower = "0123456789abcdef"[i];
                char upper = "0123456789ABCDEF"[i];
                HexToBinaryTable[lower] = bits;
                HexToBinaryTable[upper] = bits;
            }
        }

        /// <summary>
        /// Converts a hexadecimal string to binary.
        /// </summary>
        public static string HexToBinary(string hex)
        {
            int length = hex.Length;
            StringBuilder binary = new StringBuilder(length * 4);

            for (int i = 0; i < length; i++)
            {
                char c = hex[i];
                if (c >= HexToBinaryTable.Length || HexToBinaryTable[c] == null)
                    throw new ArgumentException($"Invalid hex character '{c}' at position {i}");
                binary.Append(HexToBinaryTable[c]);
            }

            return binary.ToString();
        }

        /// <summary>
        /// Converts a binary string to hexadecimal.
        /// </summary>
        public static string BinaryToHex(string binary)
        {
            int length = binary.Length;

            for (int i = 0; i < length; i++)
            {
                if (binary[i] != '0' && binary[i] != '1')
                    throw new ArgumentException($"Invalid binary character '{binary[i]}' at position {i}");
            }

            if (length % 16 != 0)
            {
                int toPad = 16 - length % 16;
                binary = binary.PadRight(length + toPad, '0');
                length = binary.Length;
            }

            StringBuilder hex = new StringBuilder(length / 4);
            for (int i = 0; i < length; i += 4)
            {
                int value = (binary[i] - '0') * 8
                          + (binary[i + 1] - '0') * 4
                          + (binary[i + 2] - '0') * 2
                          + (binary[i + 3] - '0');
                hex.Append(BinaryToHexTable[value]);
            }

            return hex.ToString();
        }

        /// <summary>
        /// Converts a binary string to BigInteger.
        /// </summary>
        public static BigInteger BinaryStringToBigInteger(string binary)
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
    }
}
