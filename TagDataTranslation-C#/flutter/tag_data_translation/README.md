# tag_data_translation

GS1 EPC Tag Data Translation for Flutter. Encode and decode all EPC schemes on Android and iOS.

## Status

This plugin is a scaffold. The native Android and iOS SDKs need to be built and linked
before the platform channel calls will work. The pure Dart `hexToBinary` and `binaryToHex`
methods work immediately.

## Installation

```yaml
dependencies:
  tag_data_translation: ^3.0.0
```

## Usage

```dart
import 'package:tag_data_translation/tag_data_translation.dart';

// pure Dart -- works immediately
final binary = TDTEngine.hexToBinary('30340242201d8840009efdf7');
final hex = TDTEngine.binaryToHex(binary);

// platform channel -- requires native SDK
final uri = await TDTEngine.translate(binary, 'PURE_IDENTITY', params: 'tagLength=96');
```

## License

Business Source License 1.1. Production use requires a commercial license -- contact tdt@mimasu.nl.
