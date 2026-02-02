using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TagDataTranslation.Encoding
{
    /// <summary>
    /// TDS 2.3 hostname encoder/decoder for '++' EPC schemes.
    /// Supports URN Code 40 and 7-bit ASCII with optimizations.
    /// </summary>
    public class HostnameEncoder
    {
        // URN Code 40 character set (same as Table B-1)
        private static readonly string Code40Chars = "#-./0123456789:ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // 7-bit optimization table A - maps binary to string
        private static readonly Dictionary<string, string> OptTableA = new()
        {
            { "0011110", "qr." },
            { "0011111", "www." },
            { "0100000", "id." },
            { "0100001", "!" },
            { "0100010", "\"" },
            { "0100011", "#" },
            { "0100101", "%" },
            { "0100110", "&" },
            { "0100111", "'" },
            { "0101000", "(" },
            { "0101001", ")" },
            { "0101010", "*" },
            { "0101011", "+" },
            { "0101100", "," },
            { "0101101", "-" },
            { "0101110", "." },
            { "0101111", "/" },
            { "0110000", "0" },
            { "0110001", "1" },
            { "0110010", "2" },
            { "0110011", "3" },
            { "0110100", "4" },
            { "0110101", "5" },
            { "0110110", "6" },
            { "0110111", "7" },
            { "0111000", "8" },
            { "0111001", "9" },
            { "0111010", ":" },
            { "0111011", ";" },
            { "0111100", "<" },
            { "0111101", "=" },
            { "0111110", ">" },
            { "0111111", "?" },
            { "1000001", "A" },
            { "1000010", "B" },
            { "1000011", "C" },
            { "1000100", "D" },
            { "1000101", "E" },
            { "1000110", "F" },
            { "1000111", "G" },
            { "1001000", "H" },
            { "1001001", "I" },
            { "1001010", "J" },
            { "1001011", "K" },
            { "1001100", "L" },
            { "1001101", "M" },
            { "1001110", "N" },
            { "1001111", "O" },
            { "1010000", "P" },
            { "1010001", "Q" },
            { "1010010", "R" },
            { "1010011", "S" },
            { "1010100", "T" },
            { "1010101", "U" },
            { "1010110", "V" },
            { "1010111", "W" },
            { "1011000", "X" },
            { "1011001", "Y" },
            { "1011010", "Z" },
            { "1011011", ".com" },
            { "1011100", ".org" },
            { "1011101", ".net" },
            { "1011110", ".int" },
            { "1011111", "_" },
            { "1100000", ".edu" },
            { "1100001", "a" },
            { "1100010", "b" },
            { "1100011", "c" },
            { "1100100", "d" },
            { "1100101", "e" },
            { "1100110", "f" },
            { "1100111", "g" },
            { "1101000", "h" },
            { "1101001", "i" },
            { "1101010", "j" },
            { "1101011", "k" },
            { "1101100", "l" },
            { "1101101", "m" },
            { "1101110", "n" },
            { "1101111", "o" },
            { "1110000", "p" },
            { "1110001", "q" },
            { "1110010", "r" },
            { "1110011", "s" },
            { "1110100", "t" },
            { "1110101", "u" },
            { "1110110", "v" },
            { "1110111", "w" },
            { "1111000", "x" },
            { "1111001", "y" },
            { "1111010", "z" },
            { "1111011", ".gov" },
            { "1111100", ".mil" },
            { "1111101", ".biz" },
            { "1111110", ".eco" },
            { "1111111", ".med" }
        };

        // Reverse lookup for encoding
        private static readonly Dictionary<string, string> OptTableAReverse;

        // Country TLDs .ac to .li (Table B1)
        private static readonly string[] TableB1 = {
            ".ac", ".ad", ".ae", ".af", ".ag", ".ai", ".al", ".am",
            ".ao", ".aq", ".ar", ".as", ".at", ".au", ".aw", ".ax",
            ".az", ".ba", ".bb", ".bd", ".be", ".bf", ".bg", ".bh",
            ".bi", ".bj", ".bm", ".bn", ".bo", ".bq", ".br", ".bs",
            ".bt", ".bw", ".by", ".bz", ".ca", ".cc", ".cd", ".cf",
            ".cg", ".ch", ".ci", ".ck", ".cl", ".cm", ".cn", ".co",
            ".cr", ".cu", ".cv", ".cw", ".cx", ".cy", ".cz", ".de",
            ".dj", ".dk", ".dm", ".do", ".dz", ".ec", ".ee", ".eg",
            ".eh", ".er", ".es", ".et", ".eu", ".fi", ".fj", ".fk",
            ".fm", ".fo", ".fr", ".ga", ".gd", ".ge", ".gf", ".gg",
            ".gh", ".gi", ".gl", ".gm", ".gn", ".gp", ".gq", ".gr",
            ".gs", ".gt", ".gu", ".gw", ".gy", ".hk", ".hm", ".hn",
            ".hr", ".ht", ".hu", ".id", ".ie", ".il", ".im", ".in",
            ".io", ".iq", ".ir", ".is", ".it", ".je", ".jm", ".jo",
            ".jp", ".ke", ".kg", ".kh", ".ki", ".km", ".kn", ".kp",
            ".kr", ".kw", ".ky", ".kz", ".la", ".lb", ".lc", ".li"
        };

        // Country TLDs .lk to .zw (Table B2)
        private static readonly string[] TableB2 = {
            ".lk", ".lr", ".ls", ".lt", ".lu", ".lv", ".ly", ".ma",
            ".mc", ".md", ".me", ".mg", ".mh", ".mk", ".ml", ".mm",
            ".mn", ".mo", ".mp", ".mq", ".mr", ".ms", ".mt", ".mu",
            ".mv", ".mw", ".mx", ".my", ".mz", ".na", ".nc", ".ne",
            ".nf", ".ng", ".ni", ".nl", ".no", ".np", ".nr", ".nu",
            ".nz", ".om", ".pa", ".pe", ".pf", ".pg", ".ph", ".pk",
            ".pl", ".pm", ".pn", ".pr", ".ps", ".pt", ".pw", ".py",
            ".qa", ".re", ".ro", ".rs", ".ru", ".rw", ".sa", ".sb",
            ".sc", ".sd", ".se", ".sg", ".sh", ".si", ".sk", ".sl",
            ".sm", ".sn", ".sr", ".ss", ".st", ".su", ".sv", ".sx",
            ".sy", ".sz", ".tc", ".td", ".tf", ".tg", ".th", ".tj",
            ".tk", ".tl", ".tm", ".tn", ".to", ".tr", ".tt", ".tv",
            ".tw", ".tz", ".ua", ".ug", ".us", ".uy", ".uz", ".va",
            ".vc", ".ve", ".vg", ".vi", ".vn", ".vu", ".wf", ".ws",
            ".ye", ".yt", ".za", ".zm", ".zw"
        };

        // Compound TLDs (Table B3)
        private static readonly string[] TableB3 = {
            ".com.au", ".net.au", ".org.au", ".co.at", ".com.bd", ".co.bd", ".com.br", ".net.br",
            ".co.nz", ".com.ng", ".com.pk", ".co.in", ".com.in", ".co.il", ".co.jp", ".co.za",
            ".co.kr", ".com.es", ".com.lk", ".co.th", ".co.tt", ".com.tt", ".com.tr", ".biz.tr",
            ".com.ua", ".co.uk", ".co.zm", ".com.zm", ".com.cn", ".org.cn", ".net.cn", ".gov.cn"
        };

        // Less common gTLDs (Table B4)
        private static readonly string[] TableB4 = {
            ".tech"
        };

        // Combined optimization sequences for encoding (longest first for greedy matching)
        private static readonly List<(string sequence, string binary, int bitCount)> AllOptimizations;

        static HostnameEncoder()
        {
            // Build reverse lookup for Table A
            OptTableAReverse = new Dictionary<string, string>();
            foreach (var kvp in OptTableA)
            {
                if (!OptTableAReverse.ContainsKey(kvp.Value))
                {
                    OptTableAReverse[kvp.Value] = kvp.Key;
                }
            }

            // Build combined optimizations list (sorted by sequence length descending for greedy matching)
            AllOptimizations = new List<(string, string, int)>();

            // Add 14-bit optimizations (Tables B1-B4)
            for (int i = 0; i < TableB1.Length; i++)
            {
                var binary = "0000000" + Convert.ToString(i, 2).PadLeft(7, '0');
                AllOptimizations.Add((TableB1[i], binary, 14));
            }
            for (int i = 0; i < TableB2.Length; i++)
            {
                var binary = "0000001" + Convert.ToString(i, 2).PadLeft(7, '0');
                AllOptimizations.Add((TableB2[i], binary, 14));
            }
            for (int i = 0; i < TableB3.Length; i++)
            {
                var binary = "0000010" + Convert.ToString(i, 2).PadLeft(7, '0');
                AllOptimizations.Add((TableB3[i], binary, 14));
            }
            for (int i = 0; i < TableB4.Length; i++)
            {
                var binary = "0000011" + Convert.ToString(i, 2).PadLeft(7, '0');
                AllOptimizations.Add((TableB4[i], binary, 14));
            }

            // Add 7-bit optimizations from Table A (multi-char sequences only)
            foreach (var kvp in OptTableA.Where(x => x.Value.Length > 1))
            {
                AllOptimizations.Add((kvp.Value, kvp.Key, 7));
            }

            // Sort by sequence length descending for greedy matching
            AllOptimizations = AllOptimizations.OrderByDescending(x => x.sequence.Length).ToList();
        }

        /// <summary>
        /// Checks if a hostname can be encoded using URN Code 40 (uppercase only).
        /// </summary>
        public static bool CanUseCode40(string hostname)
        {
            return hostname.All(c => Code40Chars.Contains(c));
        }

        /// <summary>
        /// Encodes a hostname to binary using the appropriate method.
        /// </summary>
        /// <param name="hostname">The hostname to encode (without https://)</param>
        /// <returns>Binary string</returns>
        public static string Encode(string hostname)
        {
            if (string.IsNullOrEmpty(hostname))
                throw new ArgumentException("Hostname cannot be null or empty");

            if (hostname.Length > 63)
                throw new ArgumentException("Hostname cannot exceed 63 characters");

            // Try URN Code 40 first (more efficient for uppercase-only hostnames)
            if (CanUseCode40(hostname))
            {
                return EncodeCode40(hostname);
            }

            // Fall back to 7-bit ASCII with optimizations
            return Encode7BitAscii(hostname);
        }

        /// <summary>
        /// Encodes a hostname using URN Code 40.
        /// </summary>
        private static string EncodeCode40(string hostname)
        {
            var sb = new StringBuilder();

            // Encoding indicator: 0 for Code 40
            sb.Append('0');

            // Length indicator (6 bits)
            var lengthBinary = Convert.ToString(hostname.Length, 2).PadLeft(6, '0');
            sb.Append(lengthBinary);

            // Pad hostname to multiple of 3
            var padded = hostname;
            while (padded.Length % 3 != 0)
            {
                padded += "#"; // Pad character (index 0)
            }

            // Encode each triplet
            for (int i = 0; i < padded.Length; i += 3)
            {
                int i1 = Code40Chars.IndexOf(padded[i]);
                int i2 = Code40Chars.IndexOf(padded[i + 1]);
                int i3 = Code40Chars.IndexOf(padded[i + 2]);

                int r = 1600 * i1 + 40 * i2 + i3 + 1;
                var tripletBinary = Convert.ToString(r, 2).PadLeft(16, '0');
                sb.Append(tripletBinary);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Encodes a hostname using 7-bit ASCII with optimizations.
        /// </summary>
        private static string Encode7BitAscii(string hostname)
        {
            var sb = new StringBuilder();

            // Encoding indicator: 1 for 7-bit ASCII
            sb.Append('1');

            // Find all optimization sequences that can be used
            var encodingPlan = BuildEncodingPlan(hostname);

            // Calculate optimized length
            int optimizedLength = 0;
            foreach (var (_, _, bitCount) in encodingPlan)
            {
                optimizedLength += bitCount == 14 ? 2 : 1;
            }

            // Length indicator (6 bits)
            var lengthBinary = Convert.ToString(optimizedLength, 2).PadLeft(6, '0');
            sb.Append(lengthBinary);

            // Encode each element
            foreach (var (_, binary, _) in encodingPlan)
            {
                sb.Append(binary);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Builds an encoding plan for a hostname, using optimizations where possible.
        /// </summary>
        private static List<(string sequence, string binary, int bitCount)> BuildEncodingPlan(string hostname)
        {
            var plan = new List<(string, string, int)>();
            int pos = 0;

            while (pos < hostname.Length)
            {
                bool found = false;

                // Try to find the longest matching optimization
                foreach (var (sequence, binary, bitCount) in AllOptimizations)
                {
                    if (pos + sequence.Length <= hostname.Length &&
                        hostname.Substring(pos, sequence.Length) == sequence)
                    {
                        plan.Add((sequence, binary, bitCount));
                        pos += sequence.Length;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    // Encode single character using Table A or standard 7-bit ASCII
                    char c = hostname[pos];
                    string charStr = c.ToString();

                    if (OptTableAReverse.TryGetValue(charStr, out string? binary))
                    {
                        plan.Add((charStr, binary, 7));
                    }
                    else
                    {
                        // Use standard 7-bit ASCII (truncated from 8-bit)
                        int asciiValue = (int)c;
                        if (asciiValue > 127)
                            throw new ArgumentException($"Character '{c}' is not in the supported character set");

                        var charBinary = Convert.ToString(asciiValue, 2).PadLeft(7, '0');
                        plan.Add((charStr, charBinary, 7));
                    }
                    pos++;
                }
            }

            return plan;
        }

        /// <summary>
        /// Decodes a binary string to a hostname.
        /// </summary>
        /// <param name="binary">The binary string to decode</param>
        /// <returns>The decoded hostname</returns>
        public static string Decode(string binary)
        {
            if (string.IsNullOrEmpty(binary) || binary.Length < 7)
                throw new ArgumentException("Binary string too short");

            // Check encoding indicator
            if (binary[0] == '0')
            {
                return DecodeCode40(binary);
            }
            else
            {
                return Decode7BitAscii(binary);
            }
        }

        /// <summary>
        /// Decodes a hostname using URN Code 40.
        /// </summary>
        private static string DecodeCode40(string binary)
        {
            int pos = 1; // Skip encoding indicator

            // Read length indicator (6 bits)
            var lengthBinary = binary.Substring(pos, 6);
            int length = Convert.ToInt32(lengthBinary, 2);
            pos += 6;

            // Calculate number of triplets
            int triplets = (length + 2) / 3;

            var sb = new StringBuilder();

            for (int t = 0; t < triplets; t++)
            {
                if (pos + 16 > binary.Length)
                    throw new ArgumentException("Binary string too short for Code 40 decoding");

                var tripletBinary = binary.Substring(pos, 16);
                int r = Convert.ToInt32(tripletBinary, 2);
                pos += 16;

                int i3 = (r - 1) % 40;
                int i2 = ((r - 1 - i3) / 40) % 40;
                int i1 = (r - 1 - i3 - 40 * i2) / 1600;

                sb.Append(Code40Chars[i1]);
                if (i2 > 0 || sb.Length < length)
                    sb.Append(Code40Chars[i2]);
                if (i3 > 0 || sb.Length < length)
                    sb.Append(Code40Chars[i3]);
            }

            // Trim to actual length (remove padding)
            return sb.ToString().Substring(0, length);
        }

        /// <summary>
        /// Decodes a hostname using 7-bit ASCII with optimizations.
        /// </summary>
        private static string Decode7BitAscii(string binary)
        {
            int pos = 1; // Skip encoding indicator

            // Read length indicator (6 bits)
            var lengthBinary = binary.Substring(pos, 6);
            int length = Convert.ToInt32(lengthBinary, 2);
            pos += 6;

            var sb = new StringBuilder();
            int unitsRead = 0;

            while (unitsRead < length && pos < binary.Length)
            {
                if (pos + 7 > binary.Length)
                    break;

                var sevenBits = binary.Substring(pos, 7);

                // Check for 14-bit sequences (prefixes 0000000, 0000001, 0000010, 0000011)
                if (sevenBits == "0000000" || sevenBits == "0000001" ||
                    sevenBits == "0000010" || sevenBits == "0000011")
                {
                    if (pos + 14 > binary.Length)
                        throw new ArgumentException("Binary string too short for 14-bit sequence");

                    var nextSevenBits = binary.Substring(pos + 7, 7);
                    int index = Convert.ToInt32(nextSevenBits, 2);

                    string? decoded = sevenBits switch
                    {
                        "0000000" when index < TableB1.Length => TableB1[index],
                        "0000001" when index < TableB2.Length => TableB2[index],
                        "0000010" when index < TableB3.Length => TableB3[index],
                        "0000011" when index < TableB4.Length => TableB4[index],
                        _ => null
                    };

                    if (decoded != null)
                    {
                        sb.Append(decoded);
                        pos += 14;
                        unitsRead += 2; // 14-bit counts as 2 units
                        continue;
                    }
                }

                // Try 7-bit optimization from Table A
                if (OptTableA.TryGetValue(sevenBits, out string? tableAValue))
                {
                    sb.Append(tableAValue);
                }
                else
                {
                    // Decode as standard 7-bit ASCII
                    int asciiValue = Convert.ToInt32(sevenBits, 2);
                    sb.Append((char)asciiValue);
                }

                pos += 7;
                unitsRead++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets the bit length of an encoded hostname.
        /// </summary>
        public static int GetEncodedBitLength(string binary)
        {
            return binary.Length;
        }
    }
}
