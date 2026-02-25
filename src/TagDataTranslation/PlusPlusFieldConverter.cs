using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace TagDataTranslation
{
    /// <summary>
    /// Handles field conversions specific to '++' schemes (DSGTIN++, ITIP++).
    /// Converts between composite binary fields and their component parts.
    /// </summary>
    internal static class PlusPlusFieldConverter
    {
        // map of date field names to their type indicators
        private static readonly Dictionary<string, int> DateFields = new Dictionary<string, int>
        {
            { "prodDate", 0 },       // AI 11
            { "packDate", 1 },       // AI 13
            { "bestBeforeDate", 2 }, // AI 15
            { "sellByDate", 3 },     // AI 16
            { "expDate", 4 },        // AI 17
            { "firstFreezeDate", 5 }, // AI 7006
            { "harvestDate", 6 }     // AI 7007
        };

        // reverse map of type indicator to field name
        private static readonly Dictionary<int, string> DateFieldsByIndicator = new Dictionary<int, string>
        {
            { 0, "prodDate" },
            { 1, "packDate" },
            { 2, "bestBeforeDate" },
            { 3, "sellByDate" },
            { 4, "expDate" },
            { 5, "firstFreezeDate" },
            { 6, "harvestDate" }
        };

        /// <summary>
        /// Computes dateBinary for DSGTIN++ from date fields.
        /// Format: 4-bit date type indicator + 16-bit packed date (YY*512 + MM*32 + DD)
        /// </summary>
        public static void ComputeDsgtinPlusPlusDateBinary(Dictionary<string, string> parameterDictionary)
        {
            foreach (var df in DateFields)
            {
                if (parameterDictionary.TryGetValue(df.Key, out var dateValue) && dateValue.Length == 6)
                {
                    if (int.TryParse(dateValue.Substring(0, 2), out int year) &&
                        int.TryParse(dateValue.Substring(2, 2), out int month) &&
                        int.TryParse(dateValue.Substring(4, 2), out int day))
                    {
                        int packedDate = (year * 512) + (month * 32) + day;
                        int dateBinary = (df.Value << 16) | packedDate;
                        parameterDictionary["dateBinary"] = dateBinary.ToString();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Computes itipBinary for ITIP++ from gtin, piece, and total fields.
        /// itipBinary (72 bits) = gtin (14 digits) + piece (2 digits) + total (2 digits).
        /// </summary>
        public static void ComputeItipPlusPlusItipBinary(Dictionary<string, string> parameterDictionary)
        {
            if (!parameterDictionary.TryGetValue("gtin", out var gtin) ||
                !parameterDictionary.TryGetValue("piece", out var piece) ||
                !parameterDictionary.TryGetValue("total", out var total))
            {
                return;
            }

            var combined = gtin.PadLeft(14, '0') + piece.PadLeft(2, '0') + total.PadLeft(2, '0');

            if (BigInteger.TryParse(combined, out var value))
            {
                parameterDictionary["itipBinary"] = value.ToString();
            }
        }

        /// <summary>
        /// Extracts gtin, piece, total fields from itipBinary for ITIP++.
        /// Reverse of ComputeItipPlusPlusItipBinary.
        /// </summary>
        public static void ExtractItipFieldsFromItipBinary(Dictionary<string, string> parameterDictionary)
        {
            if (!parameterDictionary.TryGetValue("itipBinary", out var itipBinaryStr))
            {
                return;
            }

            if (string.IsNullOrEmpty(itipBinaryStr))
            {
                return;
            }

            BigInteger itipValue;
            try
            {
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
            catch (FormatException)
            {
                return;
            }
            catch (OverflowException)
            {
                return;
            }

            string combined = itipValue.ToString().PadLeft(18, '0');

            if (combined.Length >= 18)
            {
                parameterDictionary["gtin"] = combined.Substring(0, 14);
                parameterDictionary["piece"] = combined.Substring(14, 2);
                parameterDictionary["total"] = combined.Substring(16, 2);
            }
        }

        /// <summary>
        /// Extracts date field from dateBinary for DSGTIN++.
        /// Reverse of ComputeDsgtinPlusPlusDateBinary.
        /// </summary>
        public static void ExtractDateFromDateBinary(Dictionary<string, string> parameterDictionary)
        {
            if (!parameterDictionary.TryGetValue("dateBinary", out var dateBinaryStr))
            {
                return;
            }

            if (string.IsNullOrEmpty(dateBinaryStr))
            {
                return;
            }

            int dateBinary;
            try
            {
                if (dateBinaryStr.All(c => c == '0' || c == '1') && dateBinaryStr.Length > 10)
                {
                    dateBinary = System.Convert.ToInt32(dateBinaryStr, 2);
                }
                else
                {
                    dateBinary = int.Parse(dateBinaryStr);
                }
            }
            catch (FormatException)
            {
                return;
            }
            catch (OverflowException)
            {
                return;
            }

            int typeIndicator = (dateBinary >> 16) & 0x0F;
            int packedDate = dateBinary & 0xFFFF;

            int year = packedDate / 512;
            int remainder = packedDate % 512;
            int month = remainder / 32;
            int day = remainder % 32;
            string dateValue = $"{year:D2}{month:D2}{day:D2}";

            if (DateFieldsByIndicator.TryGetValue(typeIndicator, out string? fieldName))
            {
                parameterDictionary[fieldName] = dateValue;
            }
        }
    }
}
