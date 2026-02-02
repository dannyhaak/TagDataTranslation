# TagDataTranslation Library - Claude Code Context

## Project Overview

TagDataTranslation is a C# library implementing GS1's Tag Data Translation (TDT) specification for encoding and decoding EPC (Electronic Product Code) identifiers used in RFID tags.

## Supported Standards

- **TDT 2.2** - Full support for all standard EPC schemes
- **TDS 2.3** - Support for '+' and '++' schemes with hostname encoding

## Tech Stack

- .NET 8.0 / 9.0 / 10.0 (multi-targeting)
- xUnit for testing
- JSON-based scheme definitions (in `Schemes2/` folder)

## Key Components

### TDTEngine.cs
The main translation engine. Key methods:
- `Translate(input, inputFormat, parameterList)` - Main translation method
- `ProcessInput()` - Parses input and extracts fields
- `ProcessOutput()` - Formats output to requested level

### Scheme Files (Schemes2/*.json)
JSON definitions for each EPC scheme containing:
- Level definitions (BINARY, BARE_IDENTIFIER, GS1_DIGITAL_LINK, etc.)
- Field patterns and extraction rules
- Encoding/decoding rules

### Encoding/ folder
Helper classes for specific encoding methods:
- `HostnameEncoder.cs` - TDS 2.3 hostname encoding with optimizations

## TDS 2.3 Implementation Details

### '+' Schemes (Plus schemes)
Single-plus schemes like SGTIN+, SSCC+, etc. that:
- Use variable-length serial encoding
- Support GS1 Digital Link URIs with id.gs1.org hostname
- Do NOT encode custom hostnames

### '++' Schemes (Plus-plus schemes)
Double-plus schemes like SGTIN++, SSCC++, etc. that:
- Include all features of '+' schemes
- Additionally encode a custom hostname in binary
- Support branded GS1 Digital Link URIs (e.g., https://coca-cola.com/01/...)

### Hostname Encoding (Section 14.5.16)

Two methods supported:
1. **Code 40** (indicator bit 0): For uppercase-only hostnames
   - 16 bits per 3 characters
   - Character set: 0-9, A-Z, -, .

2. **7-bit ASCII with optimizations** (indicator bit 1): For mixed-case hostnames
   - Uses optimization tables for common TLDs and subdomains
   - `.com`, `.org`, `.net` etc. encoded as single 7-bit sequence
   - `id.`, `www.`, `qr.` encoded as single 7-bit sequence
   - Country TLDs encoded as 14-bit sequences

**Important:** The hostname length field indicates number of 7-bit sequences, NOT number of output characters.

### Variable-Length Alphanumeric Encoding (Section 14.5.6)

Format: 3-bit encoding indicator + 5-bit length + variable data

| Indicator | Method | Bits per char |
|-----------|--------|---------------|
| 0 | Numeric | ~3.32 bits/digit |
| 1 | Upper hex | 4 bits |
| 2 | Lower hex | 4 bits |
| 3 | Base64 URI-safe | 6 bits |
| 4 | 7-bit ASCII | 7 bits |
| 5 | URN Code 40 | ~5.33 bits |

### '++' Scheme BINARY Pattern

All '++' schemes require trailing `([01]*)` in their BINARY pattern to capture variable-length serial and hostname data after the fixed fields.

Example for SGTIN++:
```
"pattern": "^11111101([01])([01]{3})([01]{56})([01]*)"
```

### '++' Scheme Structure

Most '++' schemes follow this structure:
- Header (8 bits) - unique per scheme
- DataToggle (1 bit) - +AIDC data indicator
- Filter (3 bits)
- Fixed fields (scheme-specific, BCD encoded)
- Serial (variable-length alphanumeric)
- Hostname (1-bit encoding + 6-bit length + data)

## Known Issues

### TDS 2.3 Standard Errata
See `docs/TDS-2.3-Errata.md` for documented errors in the TDS 2.3 specification, including:
- SGTIN++/DSGTIN++ hostname errors in E.3
- SSCC++/ITIP++ header errors in E.3

### Pre-existing Test Failures
Some tests in `TDSStandard.cs` and `Exceptions.cs` fail. These are pre-existing issues unrelated to TDS 2.3 implementation.

## Build Commands

```bash
# Build all targets
dotnet build TagDataTranslation/TagDataTranslation.csproj

# Run tests
dotnet test TagDataTranslationUnitTest/TagDataTranslationUnitTest.csproj

# Run specific test categories
dotnet test --filter "FullyQualifiedName~TDS23"
dotnet test --filter "FullyQualifiedName~TDT22"
```

## File Locations

| Path | Description |
|------|-------------|
| `TagDataTranslation/` | Main library |
| `TagDataTranslation/Schemes2/` | JSON scheme definitions |
| `TagDataTranslation/Encoding/` | Encoding helper classes |
| `TagDataTranslation/Tables/` | Lookup tables (Table F, K, E, B) |
| `TagDataTranslationUnitTest/` | Unit tests |
| `docs/` | Documentation and standards |

## Adding New Schemes

1. Create JSON scheme file in `Schemes2/`
2. Define all levels (BINARY, BARE_IDENTIFIER, etc.)
3. Add BINARY pattern with appropriate capture groups
4. For '++' schemes, add `variableLengthField` and `hostnameField` definitions
5. Add tests in appropriate test file

## Debugging Tips

- Use `TryTranslateDetails()` for detailed translation information
- Binary patterns must match exactly - check bit counts
- For '++' schemes, hostname length is in sequences, not characters
- Check `docs/TDS-2.3-Standard.md` for specification details

## License

AGPL-3.0 - See LICENSE file
