using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable enable

namespace TagDataTranslation.Models;

/// <summary>
/// Root container for TDT 2.2 JSON scheme files.
/// </summary>
public class TdtRoot
{
    [JsonPropertyName("tdt:epcTagDataTranslation")]
    public EpcTagDataTranslation2? EpcTagDataTranslation { get; set; }
}

/// <summary>
/// EPC Tag Data Translation document metadata and scheme definition.
/// </summary>
public class EpcTagDataTranslation2
{
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("epcTDSVersion")]
    public string? EpcTDSVersion { get; set; }

    [JsonPropertyName("scheme")]
    public Scheme2? Scheme { get; set; }
}

/// <summary>
/// Defines an EPC scheme (e.g., SGTIN-96, SSCC-96).
/// </summary>
public class Scheme2
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("optionKey")]
    public string? OptionKey { get; set; }

    [JsonPropertyName("tagLength")]
    public int? TagLength { get; set; }

    /// <summary>
    /// TDS 2.3: Indicates this is a '++' scheme that supports custom hostname encoding.
    /// </summary>
    [JsonPropertyName("supportsHostname")]
    public bool SupportsHostname { get; set; }

    [JsonPropertyName("level")]
    public List<Level2>? Level { get; set; }
}

/// <summary>
/// Represents an encoding level (BINARY, TAG_ENCODING, PURE_IDENTITY, etc.).
/// </summary>
public class Level2
{
    /// <summary>
    /// Level type: BINARY, TAG_ENCODING, PURE_IDENTITY, ELEMENT_STRING,
    /// GS1_AI_JSON, GS1_DIGITAL_LINK, TEI, BARE_IDENTIFIER, BARE_IDENTIFIER_ALT
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("prefixMatch")]
    public string? PrefixMatch { get; set; }

    [JsonPropertyName("requiredParsingParameters")]
    public string? RequiredParsingParameters { get; set; }

    [JsonPropertyName("requiredFormattingParameters")]
    public string? RequiredFormattingParameters { get; set; }

    /// <summary>
    /// GS1 Digital Link key qualifiers (e.g., ["22", "10", "21"]).
    /// </summary>
    [JsonPropertyName("gs1DigitalLinkKeyQualifiers")]
    public List<string>? Gs1DigitalLinkKeyQualifiers { get; set; }

    /// <summary>
    /// Alternative property name for Digital Link key qualifiers used in some scheme files.
    /// </summary>
    [JsonPropertyName("dlpKeyQualifiers")]
    public List<string>? DlpKeyQualifiers { get; set; }

    [JsonPropertyName("option")]
    public List<Option2>? Option { get; set; }

    [JsonPropertyName("rule")]
    public List<Rule2>? Rule { get; set; }
}

/// <summary>
/// Represents an option within a level, defining pattern matching and field extraction.
/// </summary>
public class Option2
{
    [JsonPropertyName("optionKey")]
    public string? OptionKey { get; set; }

    [JsonPropertyName("pattern")]
    public string? Pattern { get; set; }

    [JsonPropertyName("grammar")]
    public string? Grammar { get; set; }

    /// <summary>
    /// AI sequence for GS1_AI_JSON and GS1_DIGITAL_LINK formats (e.g., ["01", "21"]).
    /// </summary>
    [JsonPropertyName("aiSequence")]
    public List<string>? AiSequence { get; set; }

    [JsonPropertyName("field")]
    public List<Field2>? Field { get; set; }

    /// <summary>
    /// Encoded AI definitions for BINARY level options.
    /// </summary>
    [JsonPropertyName("encodedAI")]
    public List<EncodedAI>? EncodedAI { get; set; }

    /// <summary>
    /// TDS 2.3: Variable-length alphanumeric field definition (for serial, extension, etc.).
    /// </summary>
    [JsonPropertyName("variableLengthField")]
    public VariableLengthFieldDefinition? VariableLengthField { get; set; }

    /// <summary>
    /// TDS 2.3: Variable-length numeric field definition (for CPI serial, SGCN serial, etc.).
    /// </summary>
    [JsonPropertyName("variableLengthNumericField")]
    public VariableLengthFieldDefinition? VariableLengthNumericField { get; set; }

    /// <summary>
    /// TDS 2.3: Delimited/terminated numeric field definition (for GIAI, CPI, etc.).
    /// </summary>
    [JsonPropertyName("delimitedNumericField")]
    public VariableLengthFieldDefinition? DelimitedNumericField { get; set; }

    /// <summary>
    /// TDS 2.3: Hostname field definition for '++' schemes.
    /// </summary>
    [JsonPropertyName("hostnameField")]
    public HostnameFieldDefinition? HostnameField { get; set; }
}

/// <summary>
/// TDS 2.3: Defines a variable-length field for '++' schemes.
/// </summary>
public class VariableLengthFieldDefinition
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("encodingMethod")]
    public string? EncodingMethod { get; set; }

    [JsonPropertyName("encodingIndicatorBits")]
    public int? EncodingIndicatorBits { get; set; }

    [JsonPropertyName("lengthIndicatorBits")]
    public int? LengthIndicatorBits { get; set; }

    [JsonPropertyName("maxBits")]
    public int? MaxBits { get; set; }

    [JsonPropertyName("maxChars")]
    public int? MaxChars { get; set; }
}

/// <summary>
/// TDS 2.3: Defines a hostname field for '++' schemes.
/// </summary>
public class HostnameFieldDefinition
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("encodingMethod")]
    public string? EncodingMethod { get; set; }

    [JsonPropertyName("encodingIndicatorBits")]
    public int? EncodingIndicatorBits { get; set; }

    [JsonPropertyName("lengthIndicatorBits")]
    public int? LengthIndicatorBits { get; set; }

    [JsonPropertyName("maxChars")]
    public int? MaxChars { get; set; }
}

/// <summary>
/// Defines a field within an option for data extraction and formatting.
/// </summary>
public class Field2
{
    [JsonPropertyName("seq")]
    public int Seq { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("characterSet")]
    public string? CharacterSet { get; set; }

    [JsonPropertyName("decimalMinimum")]
    public string? DecimalMinimum { get; set; }

    [JsonPropertyName("decimalMaximum")]
    public string? DecimalMaximum { get; set; }

    [JsonPropertyName("bitPadDir")]
    public string? BitPadDir { get; set; }

    [JsonPropertyName("bitLength")]
    public int? BitLength { get; set; }

    [JsonPropertyName("length")]
    public int? Length { get; set; }

    [JsonPropertyName("padChar")]
    public string? PadChar { get; set; }

    [JsonPropertyName("padDir")]
    public string? PadDir { get; set; }

    /// <summary>
    /// Compaction type for variable-length fields.
    /// </summary>
    [JsonPropertyName("compaction")]
    public string? Compaction { get; set; }

    /// <summary>
    /// Compression type for variable-length fields.
    /// </summary>
    [JsonPropertyName("compression")]
    public string? Compression { get; set; }

    /// <summary>
    /// GCP offset for GTIN-based fields (0 or 1).
    /// </summary>
    [JsonPropertyName("gcpOffset")]
    public int? GcpOffset { get; set; }

    /// <summary>
    /// Special encoding type for the field (e.g., "dateYYMMDD" for date fields in DSGTIN+).
    /// </summary>
    [JsonPropertyName("encoding")]
    public string? Encoding { get; set; }
}

/// <summary>
/// Defines an encoded AI reference for BINARY level options.
/// </summary>
public class EncodedAI
{
    [JsonPropertyName("ai")]
    public string? Ai { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("seq")]
    public int Seq { get; set; }
}

/// <summary>
/// Defines a transformation rule for EXTRACT or FORMAT operations.
/// </summary>
public class Rule2
{
    /// <summary>
    /// Rule type: EXTRACT or FORMAT.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Input format: STRING or BINARY.
    /// </summary>
    [JsonPropertyName("inputFormat")]
    public string? InputFormat { get; set; }

    [JsonPropertyName("seq")]
    public int Seq { get; set; }

    [JsonPropertyName("newFieldName")]
    public string? NewFieldName { get; set; }

    [JsonPropertyName("characterSet")]
    public string? CharacterSet { get; set; }

    [JsonPropertyName("length")]
    public int? Length { get; set; }

    [JsonPropertyName("function")]
    public string? Function { get; set; }

    [JsonPropertyName("decimalMinimum")]
    public string? DecimalMinimum { get; set; }

    [JsonPropertyName("decimalMaximum")]
    public string? DecimalMaximum { get; set; }

    [JsonPropertyName("padChar")]
    public string? PadChar { get; set; }

    [JsonPropertyName("padDir")]
    public string? PadDir { get; set; }

    [JsonPropertyName("bitPadDir")]
    public string? BitPadDir { get; set; }
}
