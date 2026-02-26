using System;
using System.Collections.Generic;
using System.Text;
using TagDataTranslation.Models;
using TagDataTranslation.Tables;

namespace TagDataTranslation.Encoding
{
    /// <summary>
    /// Encodes and decodes +AIDC data following new EPC schemes (TDS 2.3, Section 15.3).
    /// Discovers AI codes dynamically from binary headers using Table K,
    /// then decodes/encodes values using Table F via EncodedAICodec.
    /// </summary>
    internal class AidcDataCodec
    {
        private readonly TableF tableF;
        private readonly TableK tableK;
        private readonly EncodedAICodec encodedAICodec;

        public AidcDataCodec(TableF tableF, TableK tableK, EncodedAICodec encodedAICodec)
        {
            this.tableF = tableF;
            this.tableK = tableK;
            this.encodedAICodec = encodedAICodec;
        }

        /// <summary>
        /// Decodes +AIDC binary data into a list of AI entries.
        /// Follows the algorithm in TDS 2.3 Section 15.3.
        /// </summary>
        /// <param name="binaryData">Binary string following the EPC data.</param>
        /// <returns>List of decoded AIDC entries.</returns>
        public List<AidcEntry> Decode(string binaryData)
        {
            var entries = new List<AidcEntry>();

            if (string.IsNullOrEmpty(binaryData))
            {
                return entries;
            }

            int pos = 0;

            while (pos + 8 <= binaryData.Length)
            {
                // read 8 bits as two BCD digits (4 bits each)
                int nibble1 = Convert.ToInt32(binaryData.Substring(pos, 4), 2);
                int nibble2 = Convert.ToInt32(binaryData.Substring(pos + 4, 4), 2);

                // if either digit > 9 (A-F), stop: reserved header
                if (nibble1 > 9 || nibble2 > 9)
                {
                    break;
                }

                string firstTwoDigits = $"{nibble1}{nibble2}";

                // special case: "00"
                if (firstTwoDigits == "00")
                {
                    int remainingBits = binaryData.Length - pos - 8;
                    if (remainingBits >= 72)
                    {
                        // decode as SSCC (AI 00) - 18-digit fixed-length numeric = 72 bits BCD
                        pos += 8;
                        var ssccEntry = DecodeAIValue("00", binaryData.Substring(pos));
                        if (ssccEntry != null)
                        {
                            entries.Add(ssccEntry.Value.entry);
                            pos += ssccEntry.Value.bitsConsumed;
                        }
                        continue;
                    }
                    else
                    {
                        // terminator: 00 with < 72 data bits remaining
                        break;
                    }
                }

                pos += 8;

                // look up Table K to determine AI key length and additional bits
                int aiKeyLength = tableK.GetKeyLength(firstTwoDigits);
                int additionalBits = tableK.GetAdditionalBits(firstTwoDigits);

                string aiCode = firstTwoDigits;

                // read additional bits for 3 or 4-digit AI codes
                if (additionalBits > 0 && pos + additionalBits <= binaryData.Length)
                {
                    string additionalBinary = binaryData.Substring(pos, additionalBits);
                    pos += additionalBits;

                    // decode additional BCD digits
                    var additionalDigits = new StringBuilder();
                    for (int i = 0; i < additionalBinary.Length; i += 4)
                    {
                        if (i + 4 <= additionalBinary.Length)
                        {
                            int digit = Convert.ToInt32(additionalBinary.Substring(i, 4), 2);
                            additionalDigits.Append(digit);
                        }
                    }
                    aiCode += additionalDigits.ToString();
                }

                // look up Table F for this AI and decode value
                var decoded = DecodeAIValue(aiCode, binaryData.Substring(pos));
                if (decoded != null)
                {
                    entries.Add(decoded.Value.entry);
                    pos += decoded.Value.bitsConsumed;
                }
                else
                {
                    // unknown AI, cannot continue decoding
                    break;
                }
            }

            return entries;
        }

        /// <summary>
        /// Encodes a list of AIDC entries into binary.
        /// Pads to 16-bit word boundary with zeros.
        /// </summary>
        /// <param name="entries">AIDC entries to encode.</param>
        /// <returns>Binary string of encoded AIDC data (padded to 16-bit boundary).</returns>
        public string Encode(List<AidcEntry> entries)
        {
            if (entries == null || entries.Count == 0)
            {
                return "";
            }

            var bits = new StringBuilder();

            foreach (var entry in entries)
            {
                // encode AI code as BCD (4 bits per digit)
                foreach (char c in entry.AI)
                {
                    int digit = c - '0';
                    bits.Append(Convert.ToString(digit, 2).PadLeft(4, '0'));
                }

                // encode value using Table F
                var format = tableF.GetEntry(entry.AI);
                if (format == null)
                {
                    throw new TDTTranslationException($"Unknown AI '{entry.AI}' in Table F for AIDC encoding");
                }

                if (format.HasSecondComponent && format.Comp1FixedLengthChars.HasValue)
                {
                    int comp1Length = format.Comp1FixedLengthChars.Value;
                    if (entry.Value.Length > comp1Length)
                    {
                        string comp1Value = entry.Value.Substring(0, comp1Length);
                        string comp2Value = entry.Value.Substring(comp1Length);
                        bits.Append(encodedAICodec.EncodeAIValue(comp1Value, format, false));
                        bits.Append(encodedAICodec.EncodeAIValue(comp2Value, format, true));
                    }
                    else
                    {
                        bits.Append(encodedAICodec.EncodeAIValue(entry.Value, format, false));
                    }
                }
                else
                {
                    bits.Append(encodedAICodec.EncodeAIValue(entry.Value, format, false));
                }
            }

            // pad to 16-bit word boundary
            int remainder = bits.Length % 16;
            if (remainder != 0)
            {
                bits.Append(new string('0', 16 - remainder));
            }

            return bits.ToString();
        }

        /// <summary>
        /// Decodes the value for a single AI using Table F.
        /// </summary>
        private (AidcEntry entry, int bitsConsumed)? DecodeAIValue(string aiCode, string remainingBinary)
        {
            var format = tableF.GetEntry(aiCode);
            if (format == null)
            {
                return null;
            }

            int totalBitsConsumed = 0;
            string decodedValue;

            if (format.HasSecondComponent)
            {
                // decode first component
                var (comp1Value, comp1Bits) = encodedAICodec.DecodeAIValue(remainingBinary, format, false);
                totalBitsConsumed += comp1Bits;

                string combinedValue = comp1Value ?? "";

                // decode second component
                if (totalBitsConsumed < remainingBinary.Length)
                {
                    var (comp2Value, comp2Bits) = encodedAICodec.DecodeAIValue(
                        remainingBinary.Substring(totalBitsConsumed), format, true);
                    totalBitsConsumed += comp2Bits;

                    if (comp2Value != null)
                    {
                        combinedValue += comp2Value;
                    }
                }

                decodedValue = combinedValue;
            }
            else
            {
                var (value, bitsConsumed) = encodedAICodec.DecodeAIValue(remainingBinary, format, false);
                totalBitsConsumed = bitsConsumed;
                decodedValue = value ?? "";
            }

            return (new AidcEntry { AI = aiCode, Value = decodedValue }, totalBitsConsumed);
        }
    }
}
