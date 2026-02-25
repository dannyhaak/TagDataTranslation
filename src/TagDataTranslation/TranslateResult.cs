using System.Collections.Generic;

namespace TagDataTranslation
{
    public class TranslateResult
    {
        public Dictionary<string, string> ParameterDictionary { get; set; } = new();

        public string Output { get; set; } = string.Empty;
    }
}