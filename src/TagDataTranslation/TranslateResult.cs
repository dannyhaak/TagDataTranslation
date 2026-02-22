using System.Collections.Generic;
using System.Xml.Serialization;

namespace TagDataTranslation
{
    public class TranslateResult
    {
        [XmlIgnore]
        public Dictionary<string, string> ParameterDictionary { get; set; } = new();

        public string Output { get; set; } = string.Empty;
    }
}