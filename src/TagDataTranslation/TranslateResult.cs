using System.Collections.Generic;
using System.Linq;
using TagDataTranslation.Models;

namespace TagDataTranslation
{
    public class TranslateResult
    {
        public Dictionary<string, string> ParameterDictionary { get; set; } = new();

        public string Output { get; set; } = string.Empty;

        /// <summary>
        /// Decoded +AIDC data entries (populated when dataToggle=1).
        /// </summary>
        public List<AidcEntry> AidcData
        {
            get
            {
                return ParameterDictionary
                    .Where(kvp => kvp.Key.StartsWith("aidc_") && kvp.Key.Length > 5)
                    .Select(kvp => new AidcEntry { AI = kvp.Key.Substring(5), Value = kvp.Value })
                    .ToList();
            }
        }
    }
}