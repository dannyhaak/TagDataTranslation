# TagDataTranslation

Tag Data Translation implemented according to the **GS1 EPC Tag Data Translation 2.2** specification for RAIN RFID.

**Online demo**: https://www.mimasu.nl/tdt

## Features

- Full TDT 2.2 support with JSON-based scheme definitions
- Digital Link URI generation and parsing
- GS1 Company Prefix lookup
- Filter Value tables

## Supported Schemes

| Scheme | Formats |
|--------|---------|
| SGTIN | SGTIN-96, SGTIN-198, SGTIN+ (Digital Link) |
| SSCC | SSCC-96, SSCC+ |
| SGLN | SGLN-96, SGLN-195, SGLN+ |
| GRAI | GRAI-96, GRAI-170, GRAI+ |
| GIAI | GIAI-96, GIAI-202, GIAI+ |
| GSRN | GSRN-96, GSRN+ |
| GSRNP | GSRNP-96, GSRNP+ |
| GDTI | GDTI-96, GDTI-113, GDTI-174, GDTI+ |
| SGCN | SGCN-96, SGCN+ |
| ITIP | ITIP-110, ITIP-212, ITIP+ |
| GID | GID-96 |
| CPI | CPI-96, CPI-var, CPI+ |
| ADI | ADI-var |
| USDOD | USDOD-96 |
| DSGTIN | DSGTIN+ (Digital Link only) |

## Installation

### NuGet

```bash
dotnet add package TagDataTranslation
```

Or via Package Manager:
```
Install-Package TagDataTranslation
```

### From Source

```bash
git clone https://github.com/dannyhaak/TagDataTranslation.git
cd TagDataTranslation/TagDataTranslation-C#/TagDataTranslation
dotnet build
```

## Requirements

- .NET 8.0 or later (supports .NET 8.0, 9.0, and 10.0)

## Quick Start

### Encode GTIN to Hex

```csharp
using TagDataTranslation;

var engine = new TDTEngine();
string epcIdentifier = "gtin=00037000302414;serial=10419703";
string parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
string binary = engine.Translate(epcIdentifier, parameterList, "BINARY");
string hex = engine.BinaryToHex(binary);
// hex = "30340242201d8840009efdf7"
```

### Decode Hex to GTIN

```csharp
var engine = new TDTEngine();
string binary = engine.HexToBinary("30340242201d8840009efdf7");
string parameterList = "tagLength=96";
string legacy = engine.Translate(binary, parameterList, "LEGACY");
// legacy = "gtin=00037000302414;serial=10419703"
```

### Get All Representations

```csharp
var engine = new TDTEngine();
var result = engine.TranslateDetails("30340242201d8840009efdf7", "tagLength=96", "TAG_ENCODING");

Console.WriteLine($"Pure Identity: {result.Fields["pureIdentityURI"]}");
Console.WriteLine($"Tag URI: {result.Fields["tagURI"]}");
Console.WriteLine($"GTIN: {result.Fields["gtin"]}");
Console.WriteLine($"Serial: {result.Fields["serial"]}");
```

### Digital Link Generation

```csharp
using TagDataTranslation.DigitalLink;

var components = new DigitalLinkComponents
{
    Domain = "id.gs1.org",
    PrimaryKey = ("01", "00037000302414"),  // AI 01 = GTIN
    KeyQualifiers = new List<(string, string)>
    {
        ("21", "10419703")  // AI 21 = Serial
    }
};

string digitalLink = DigitalLinkGenerator.Generate(components);
// https://id.gs1.org/01/00037000302414/21/10419703
```

### Digital Link Parsing

```csharp
if (DigitalLinkParser.TryParse("https://id.gs1.org/01/00037000302414/21/10419703", out var components))
{
    Console.WriteLine($"GTIN: {components.PrimaryKey.Value}");
    // GTIN: 00037000302414
}
```

### GS1 Company Prefix Lookup

```csharp
var engine = new TDTEngine();
var result = engine.GetPrefixLength("0037000302414");
Console.WriteLine($"Prefix: {result.Prefix}, Length: {result.Length}");
// Prefix: 0037000, Length: 7
```

## API Reference

### TDTEngine

#### Translate

```csharp
public string Translate(string epcIdentifier, string parameterList, string outputFormat)
```

Translates an EPC identifier from one representation to another.

| Parameter | Description |
|-----------|-------------|
| `epcIdentifier` | The EPC to convert (binary string, hex, URI, or legacy format) |
| `parameterList` | Semicolon-delimited key=value pairs (e.g., `filter=3;gs1companyprefixlength=7;tagLength=96`) |
| `outputFormat` | Target format: `BINARY`, `LEGACY`, `LEGACY_AI`, `TAG_ENCODING`, `PURE_IDENTITY` |

**Returns**: The converted EPC as a string.

#### TranslateDetails

```csharp
public TranslateResult TranslateDetails(string epcIdentifier, string parameterList, string outputFormat)
```

Same as `Translate`, but returns a `TranslateResult` object containing all extracted fields.

#### TryTranslate (Exception-Free)

```csharp
public bool TryTranslate(string epcIdentifier, string parameterList, string outputFormat, out string? result, out string? errorCode)
```

Translates an EPC identifier without throwing exceptions. Ideal for high-throughput scenarios.

```csharp
if (engine.TryTranslate(epcIdentifier, parameterList, "BINARY", out var result, out var errorCode))
{
    Console.WriteLine($"Success: {result}");
}
else
{
    Console.WriteLine($"Failed: {errorCode}");
}
```

#### TryTranslateDetails (Exception-Free)

```csharp
public bool TryTranslateDetails(string epcIdentifier, string parameterList, string outputFormat, out TranslateResult? result, out string? errorCode)
```

Same as `TryTranslate`, but returns a `TranslateResult` object on success.

#### GetPrefixLength

```csharp
public PrefixLengthResult GetPrefixLength(string input)
```

Looks up the GS1 Company Prefix length for a given identifier.

#### GetFilterValueTable

```csharp
public Dictionary<int, string> GetFilterValueTable(string scheme)
```

Returns the filter value descriptions for a scheme (e.g., "SGTIN" returns `{0: "All Others", 1: "POS Item", ...}`).

#### Helper Methods

```csharp
public string HexToBinary(string hex)      // Convert hex to binary string
public string BinaryToHex(string binary)   // Convert binary string to hex
```

### Exceptions

`TDTTranslationException` is thrown with one of these codes:

| Code | Description |
|------|-------------|
| `TDTFileNotFound` | Scheme definition file not found |
| `TDTFieldBelowMinimum` | Numeric field below minimum value |
| `TDTFieldAboveMaximum` | Numeric field above maximum value |
| `TDTFieldOutsideCharacterSet` | Field contains invalid characters |
| `TDTUndefinedField` | Required field is missing |
| `TDTSchemeNotFound` | No matching scheme found |
| `TDTLevelNotFound` | No matching level found |
| `TDTOptionNotFound` | No matching option found |
| `TDTLookupFailed` | External table lookup failed |
| `TDTNumericOverflow` | Numeric overflow occurred |

## Building

```bash
cd TagDataTranslation-C#/TagDataTranslation
dotnet build
dotnet test ../TagDataTranslationUnitTest
```

## Creating a NuGet Package

```bash
cd TagDataTranslation-C#/TagDataTranslation
dotnet pack -c Release
```

The package will be created in `bin/Release/`.

To publish to NuGet.org:
```bash
dotnet nuget push bin/Release/TagDataTranslation.*.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
```

## Version History

| Version | Changes |
|---------|---------|
| 2.1.0 | Added TryTranslate/TryTranslateDetails for exception-free high-throughput translation |
| 2.0.1 | Multi-targeting support for .NET 8.0, 9.0, and 10.0 |
| 2.0.0 | TDT 2.2 with JSON schemes, Digital Link support, new schemes (DSGTIN+, GDTI-113, etc.) |
| 1.1.5 | Updated GCP prefix file, ITIP encoding fixes |
| 1.0.0 | Initial release with TDT 1.6/1.11 support |

## License

This library is dual-licensed:
- **GNU Affero General Public License version 3** (AGPL-3.0)
- **Commercial license** - contact tdt@dannyhaak.nl for details

The included JSON and XSD artifacts are (c) GS1 (https://www.gs1.org/standards/epc-rfid/tdt).

## Resources

- [GS1 TDT Standard](https://www.gs1.org/standards/epc-rfid/tdt)
- [GS1 Digital Link](https://www.gs1.org/standards/gs1-digital-link)
- [Online Demo](https://www.mimasu.nl/tdt)
