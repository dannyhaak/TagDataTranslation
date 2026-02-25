# Changelog

All notable changes to TagDataTranslation will be documented in this file.

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
