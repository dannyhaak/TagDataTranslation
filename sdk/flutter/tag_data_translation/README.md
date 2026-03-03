# tag_data_translation

GS1 EPC Tag Data Translation for Flutter. Encode and decode all EPC schemes on Android and iOS.

## Features

- Translate between all EPC encoding levels: Binary, Hex, Tag URI, Pure Identity URI, GS1 Digital Link
- All standard schemes: SGTIN-96, SGTIN-198, SSCC-96, SGLN, GRAI, GIAI, GSRN, GDTI, SGCN
- TDS 2.3 '+' and '++' scheme support with GS1 Digital Link URIs
- Pure Dart hex/binary conversion utilities
- Synchronous API via dart:ffi (no async overhead)

## Installation

```yaml
dependencies:
  tag_data_translation: ^3.0.0
```

## Usage

```dart
import 'package:tag_data_translation/tag_data_translation.dart';

// convert hex EPC to binary
final binary = TDTEngine.hexToBinary('30340242201d8840009efdf7');

// translate to Pure Identity URI
final uri = TDTEngine.translate(
  binary,
  'PURE_IDENTITY',
);
// => urn:epc:id:sgtin:0037000.030241.10419703

// encode a GTIN to EPC hex
final hex = TDTEngine.translate(
  'urn:epc:id:sgtin:0037000.030241.10419703',
  'TAG_ENCODING',
  params: 'filter=3;tagLength=96',
);

// safe translation (returns null on failure)
final result = TDTEngine.tryTranslate(binary, 'PURE_IDENTITY');
```

## Error handling

`translate()` throws `TranslationError` on invalid input. Use `tryTranslate()` for a null-safe alternative.

```dart
try {
  final uri = TDTEngine.translate(input, 'PURE_IDENTITY');
} on TranslationError catch (e) {
  print('Translation failed: $e');
}
```

## Platform support

| Platform | Architecture | Status |
|----------|-------------|--------|
| iOS | arm64 | Supported |
| iOS Simulator | arm64 | Supported |
| Android | arm64-v8a | Supported |
| Android | x86_64 | Supported |

## How it works

This plugin uses dart:ffi to call a NativeAOT-compiled .NET library directly. There is no platform channel overhead -- translation calls are synchronous and fast.

## Performance

Translation calls go directly through dart:ffi to the NativeAOT-compiled .NET engine -- no platform channel serialization. The core engine translates a typical SGTIN-96 in ~8 us on ARM64.

| Operation | .NET native |
|-----------|-------------|
| SGTIN-96 encode | 7.8 us |
| SGTIN-96 decode | 7.7 us |
| HexToBinary (96-bit) | 99 ns |
| BinaryToHex (96-bit) | 54 ns |

## License

Business Source License 1.1. Production use requires a commercial license -- contact tdt@mimasu.nl.
