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
        /// <summary>
        /// Converts a hexadecimal string to binary.
        /// </summary>
        public static string HexToBinary(string hex)
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
        public static string BinaryToHex(string binary)
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
