# Changelog

All notable changes to TagDataTranslation will be documented in this file.

## [Unreleased]

Fixes found while reviewing the TDT 2.3 public review draft (September 2026). Several of these change binary output; the old output was wrong.

### Fixed
- URN Code 40 now follows TDS 2.3 table 14-8 (PAD, A-Z, `-`, `.`, `:`, 0-9) and the `+1` offset, for both variable-length alphanumeric values and '++' hostnames. Lowercase values are no longer upper-cased (which was lossy). **Changes binary output.**
- CPI++ and SGCN++ encode the serial as a TDS 14.5.13 numeric string (unsigned integer of ceil(L·log2 10) bits) instead of BCD, and now match the TDS 2.3 E.3 vectors. **Changes binary output.**
- GDTI-113 encodes the serial with the TDS 14.3.6 "Numeric String" method, preserving leading zeros. **Changes binary output.**
- Delimited/terminated numeric (TDS 14.5.5): all-numeric values end with the `1111` terminator, and the decoder honours the encoding indicator after the `1110` delimiter.
- Variable-length integer bit counts are exact; `3.32 bits/digit` was wrong for 25, 28, 50 and more digits.
- GRAI-96 BARE_IDENTIFIER pattern reverted to `{14,25}`; the `{15,26}` change rejected 1-digit serials and split 26-digit inputs one position off.
- A GS1 Digital Link on `id.gs1.org` selects the '+' scheme instead of the '++' scheme, so '+' binary round-trips through Digital Link.
- Digital Link query-string AIs and extra GS1_AI_JSON members are encoded as +AIDC data; the data toggle follows the data, and `dataToggle=1` without +AIDC data is rejected.
- GS1_AI_JSON output is built from the scheme grammar (with JSON escaping and +AIDC members) instead of a hard-coded AI map that dropped AIs for SGTIN-96, SGLN, GRAI, GDTI, CPI, DSGTIN+ and others. '++' schemes now have a GS1_AI_JSON level.
- SGLN schemes support `valueIfNull` and conditional `[...]` grammar (TDT 3.2/3.9): a missing GLN extension encodes as `0`, and `0` is omitted from bare identifier, GS1_AI_JSON and Digital Link output.
- A raw `"` is no longer accepted in Digital Link URIs; `%22` is (RFC 3986).
- Scheme fixes: CPI-var (`]]` character set, 12-digit pure-identity serial, GS1_AI_JSON grammar field), CPI-96/CPI-var duplicate field `seq`, CPI-96 serial maximum, ADI-var (TEI `/SER ` grammar, URN-escaped character sets, CAGE sub-pattern), GIAI-202 Digital Link encode rule, USDOD-96 two-digit filter, unbalanced character-set regexes in 8 '+'/'++' files.

### Changed
- Stricter validation at the trust boundary. The engine now throws instead of continuing silently when:
  - a GS1 check digit is wrong (`TDTInvalidCheckDigit`);
  - a scheme character set is an invalid regex or a rule function is unknown (`TDTInvalidSchemeDefinition`);
  - a grammar field has no value, including a missing '++' hostname or serial (`TDTUndefinedField`);
  - a value does not fit its binary field (`TDTNumericOverflow`);
  - a value is not numeric, or a pre-TDS 2.0 integer serial has leading zeros (`TDTFieldOutsideCharacterSet`).

## [3.0.7] - 2026-03-03

### Fixed
- Input validation for `BinaryConverter` and `Code40` decoder

### Changed
- README: added platform badges, removed `tagLength` from decode examples, improved discoverability

## [3.0.6] - 2026-03-03

### Changed
- README improvements for NuGet and npm discoverability

## [3.0.5] - 2026-02-26

### Fixed
- Exclude `.js.symbols` file from npm package to prevent MONO_WASM warning

## [3.0.4] - 2026-02-26

### Added
- +AIDC data encoding/decoding support (TDS 2.3 §15.3)

### Fixed
- Decode +AIDC data when `dataToggle=1` (case-sensitivity bug)
- WASM trimmer for `RuntimeInformation`

## [3.0.3] - 2026-02-25

### Fixed
- npm smoke test and iOS commit step in CI

## [3.0.2] - 2026-02-25

### Fixed
- npm and iOS CI workflow failures

## [3.0.1] - 2026-02-25

### Fixed
- CI workflow fixes and AOT-safe JSON serialization

## [3.0.0] - 2026-02-25

### Added
- **Cross-platform SDKs**: npm (WASM), Python (pythonnet), Swift (NativeAOT), Android (NativeAOT), Flutter (dart:ffi)
- .NET MAUI target frameworks: Android, iOS, macCatalyst
- `LoadErrors` property for debugging scheme loading failures
- `InternalsVisibleTo` for test project access
- Performance benchmarks project (BenchmarkDotNet)
- Python example app
- Node.js example app
- PyPI publish workflow
- pub.dev publish workflow

### Changed
- License changed to Business Source License 1.1 (BSL 1.1)
- Performance optimizations: regex caching, grammar token caching, pre-sorted fields/rules, BinaryConverter lookup tables
- README updated with all platform availability and benchmark results

### Fixed
- WASM build error (missing `using System`, `SupportedOSPlatform` attribute)
- Android managed publish pipeline (DLLs not copied to output directory)
- Android native build script (NDK lld linker auto-detection)
- Nullable warnings in Android and WASM wrappers
- npm release workflow using .NET 8.0 instead of 10.0

## [2.3.0]

### Added
- TDS 2.3 support with 12 new '++' schemes for custom hostname encoding in Digital Link URIs
- SGTIN++, SSCC++, SGLN++, GRAI++, GIAI++, GSRN++, GSRNP++, GDTI++, SGCN++, ITIP++, CPI++, DSGTIN++
- Hostname encoding with Code 40 and 7-bit ASCII optimization tables
- Variable-length alphanumeric encoding (Section 14.5.6)

## [2.1.0]

### Added
- `TryTranslate` and `TryTranslateDetails` for exception-free high-throughput translation

## [2.0.1]

### Changed
- Multi-targeting support for .NET 8.0, 9.0, and 10.0

## [2.0.0]

### Added
- TDT 2.2 with JSON-based scheme definitions
- GS1 Digital Link URI generation and parsing
- New schemes: DSGTIN+, GDTI-113, and more
- GS1 Company Prefix lookup
- Filter Value tables

### Changed
- Scheme definitions migrated from XML to JSON

## [1.1.5]

### Fixed
- Updated GCP prefix file
- ITIP encoding fixes

## [1.0.0]

### Added
- Initial release with TDT 1.6/1.11 support
- Core translation engine
- SGTIN-96, SSCC-96, SGLN, GRAI, GIAI, GSRN, GDTI, SGCN schemes
