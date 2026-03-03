# TagDataTranslation

**Encode and decode GS1 EPC identifiers for RAIN (UHF) RFID tags.** Convert between GTIN, SSCC, SGLN, and 50+ other formats — from barcode to EPC hex and back.

Implements the **GS1 EPC Tag Data Standard (TDS) 2.3** and **Tag Data Translation (TDT) 2.2** specifications. Used in production for RFID tag programming, inventory systems, and supply chain applications.

[![NuGet](https://img.shields.io/nuget/v/TagDataTranslation)](https://www.nuget.org/packages/TagDataTranslation)
[![npm](https://img.shields.io/npm/v/@mimasu/tdt)](https://www.npmjs.com/package/@mimasu/tdt)
[![PyPI](https://img.shields.io/pypi/v/tag-data-translation)](https://pypi.org/project/tag-data-translation/)
[![pub.dev](https://img.shields.io/pub/v/tag_data_translation)](https://pub.dev/packages/tag_data_translation)
[![Swift](https://img.shields.io/badge/Swift_Package_Manager-compatible-orange)](https://github.com/dannyhaak/TagDataTranslation)
[![Android](https://img.shields.io/badge/Android-GitHub_Packages-green)](https://github.com/dannyhaak/TagDataTranslation/packages)
[![License](https://img.shields.io/badge/license-BSL--1.1-blue)](LICENSING.md)

**Try it online**: https://www.mimasu.nl/tag-data-translation/try-online

## Why This Library

- **Spec-complete**: All 50 EPC schemes including TDS 2.3 '+' and '++' variants with Digital Link URIs
- **Deterministic**: Every encode/decode is provably correct against the GS1 specification — no approximations, no guessing
- **Fast**: SGTIN-96 encode in 7.8 us, decode in 7.7 us (benchmarked on Apple M1 Pro)
- **Cross-platform**: .NET, JavaScript/TypeScript (WASM), Python, Swift, Kotlin, Flutter
- **Production-ready**: Exception-free `TryTranslate` API for high-throughput tag programming and reading

## Features

- GTIN to EPC encoding (SGTIN-96, SGTIN-198) and decoding
- SSCC, SGLN, GRAI, GIAI, GSRN, GDTI, SGCN, ITIP, GID, CPI, ADI, USDOD encoding
- GS1 Digital Link URI generation and parsing
- '++' schemes with custom hostname encoding for branded Digital Link URIs
- GS1 Company Prefix lookup
- Filter Value tables
- Hex to binary and binary to hex conversion

## Platform Support

| Platform | Package | Status |
|----------|---------|--------|
| .NET 8/9/10 | [NuGet](https://www.nuget.org/packages/TagDataTranslation) | Available |
| .NET MAUI (Android) | NuGet | Available (3.0.0+) |
| .NET MAUI (iOS) | NuGet | Available (3.0.0+) |
| .NET MAUI (macCatalyst) | NuGet | Available (3.0.0+) |
| JavaScript/TypeScript | [npm](https://www.npmjs.com/package/@mimasu/tdt) | Available (3.0.0+) |
| Python | [PyPI](https://pypi.org/project/tag-data-translation/) | Available (3.0.0+) |
| iOS (Swift) | Swift Package Manager | Available (3.0.0+) |
| Android (Kotlin/Java) | GitHub Packages | Available (3.0.0+) |
| Flutter (Dart) | pub.dev | Available (3.0.0+) |

## Supported Schemes

| Scheme | Formats |
|--------|---------|
| SGTIN | SGTIN-96, SGTIN-198, SGTIN+, **SGTIN++** |
| SSCC | SSCC-96, SSCC+, **SSCC++** |
| SGLN | SGLN-96, SGLN-195, SGLN+, **SGLN++** |
| GRAI | GRAI-96, GRAI-170, GRAI+, **GRAI++** |
| GIAI | GIAI-96, GIAI-202, GIAI+, **GIAI++** |
| GSRN | GSRN-96, GSRN+, **GSRN++** |
| GSRNP | GSRNP-96, GSRNP+, **GSRNP++** |
| GDTI | GDTI-96, GDTI-113, GDTI-174, GDTI+, **GDTI++** |
| SGCN | SGCN-96, SGCN+, **SGCN++** |
| ITIP | ITIP-110, ITIP-212, ITIP+, **ITIP++** |
| GID | GID-96 |
| CPI | CPI-96, CPI-var, CPI+, **CPI++** |
| ADI | ADI-var |
| USDOD | USDOD-96 |
| DSGTIN | DSGTIN+, **DSGTIN++** |

**'++' schemes** (TDS 2.3) support lossless encoding of custom hostnames in EPC binary, enabling round-trip translation with branded Digital Link URIs like `https://coca-cola.com/01/...` instead of `https://id.gs1.org/01/...`.

## Installation

### NuGet (.NET and .NET MAUI)

```bash
dotnet add package TagDataTranslation
```

Or via Package Manager:
```
Install-Package TagDataTranslation
```

The NuGet package includes targets for .NET 8.0/9.0/10.0, Android, iOS, and macCatalyst. .NET MAUI projects will automatically resolve the correct platform target.

### From Source

```bash
git clone https://github.com/dannyhaak/TagDataTranslation.git
cd TagDataTranslation
dotnet build src/TagDataTranslation/TagDataTranslation.csproj
```

## Requirements

- .NET 8.0 or later (supports .NET 8.0, 9.0, and 10.0)
- For mobile targets: .NET MAUI workload (`dotnet workload install maui`)

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
string legacy = engine.Translate(binary, "", "LEGACY");
// legacy = "gtin=00037000302414;serial=10419703"
```

### Get All Representations

```csharp
var engine = new TDTEngine();
var result = engine.TranslateDetails("30340242201d8840009efdf7", "", "TAG_ENCODING");

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

### Debugging Scheme Loading

```csharp
var engine = new TDTEngine();
if (engine.LoadErrors.Count > 0)
{
    foreach (var error in engine.LoadErrors)
    {
        Console.WriteLine(error);
    }
}
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

#### LoadErrors

```csharp
public IReadOnlyList<string> LoadErrors { get; }
```

Contains any errors encountered while loading scheme files. Inspect this after construction to debug missing or malformed schemes.

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

## Performance

Benchmarked on Apple M1 Pro, .NET 8.0 (BenchmarkDotNet):

| Operation | Mean | Allocated |
|-----------|------|-----------|
| SGTIN-96 encode (GTIN → binary) | 7.8 us | 9.9 KB |
| SGTIN-96 decode (binary → GTIN) | 7.7 us | 9.2 KB |
| SGTIN++ encode (with hostname) | 24.3 us | 75.3 KB |
| SGTIN++ decode (with hostname) | 5.0 us | 7.8 KB |
| HexToBinary (96-bit) | 99 ns | 480 B |
| BinaryToHex (96-bit) | 54 ns | 192 B |

The engine uses compiled regex caching, pre-sorted scheme data, and lookup tables for hex/binary conversion. The `TDTEngine` constructor loads all schemes once; subsequent `Translate()` calls benefit from cached patterns and pre-computed data structures.

Run benchmarks yourself:

```bash
dotnet run -c Release --project test/TagDataTranslation.Benchmarks
```

## Examples

See the `examples/` directory for platform-specific sample projects:

- `examples/ConsoleApp/` -- .NET console application
- `examples/MauiApp/` -- .NET MAUI cross-platform app (Android, iOS, macCatalyst)
- `examples/NodeApp/` -- Node.js application (via WebAssembly)

## Building

```bash
dotnet build src/TagDataTranslation/TagDataTranslation.csproj
dotnet test test/TagDataTranslation.Tests/TagDataTranslation.Tests.csproj
```

## Creating a NuGet Package

```bash
dotnet pack src/TagDataTranslation/TagDataTranslation.csproj -c Release -o ./artifacts
```

To publish to NuGet.org:
```bash
dotnet nuget push ./artifacts/TagDataTranslation.*.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
```

## Version History

| Version | Changes |
|---------|---------|
| 3.0.0 | Cross-platform SDKs: npm (WASM), Python (pythonnet), Swift (NativeAOT), Android (NativeAOT), Flutter (dart:ffi), .NET MAUI (Android, iOS, macCatalyst); performance optimizations (regex caching, lookup tables, pre-sorted fields); BSL 1.1 licensing |
| 2.3.0 | TDS 2.3 support with 12 new '++' schemes for custom hostname encoding in Digital Link URIs |
| 2.1.0 | Added TryTranslate/TryTranslateDetails for exception-free high-throughput translation |
| 2.0.1 | Multi-targeting support for .NET 8.0, 9.0, and 10.0 |
| 2.0.0 | TDT 2.2 with JSON schemes, Digital Link support, new schemes (DSGTIN+, GDTI-113, etc.) |
| 1.1.5 | Updated GCP prefix file, ITIP encoding fixes |
| 1.0.0 | Initial release with TDT 1.6/1.11 support |

## License

This library is licensed under the **Business Source License 1.1** (BSL 1.1).

- **Non-production use** (development, testing, evaluation) is free
- **Production use** requires a commercial license -- contact tdt@mimasu.nl
- Each version converts to **Apache 2.0** four years after release

See [LICENSING.md](LICENSING.md) for full details.

The included JSON and XSD artifacts are (c) GS1 (https://www.gs1.org/standards/epc-rfid/tdt).

## Use Cases

- **Tag programming**: Encode GTINs and SSCCs to EPC hex for writing to RAIN RFID tags
- **Tag reading**: Decode EPC hex from RFID readers back to human-readable identifiers
- **Inventory systems**: Translate between barcode and RFID representations
- **Supply chain**: Convert between GS1 Digital Link URIs and EPC binary
- **Label printing**: Generate EPC hex for RFID-enabled label printers (Zebra, SATO, etc.)
- **Mobile RFID apps**: Encode/decode on iOS and Android via native SDKs

## Resources

- [GS1 TDT Standard](https://www.gs1.org/standards/epc-rfid/tdt)
- [GS1 Tag Data Standard (TDS)](https://www.gs1.org/standards/tds)
- [GS1 Digital Link](https://www.gs1.org/standards/gs1-digital-link)
- [Online Demo](https://www.mimasu.nl/tag-data-translation/try-online)
- [RAIN RFID Training Academy](https://www.mimasu.nl/intro)
