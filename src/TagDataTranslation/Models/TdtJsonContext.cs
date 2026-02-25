using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TagDataTranslation.Models;

[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(TdtRoot))]
[JsonSerializable(typeof(Dictionary<string, string>))]
internal partial class TdtJsonContext : JsonSerializerContext
{
}
