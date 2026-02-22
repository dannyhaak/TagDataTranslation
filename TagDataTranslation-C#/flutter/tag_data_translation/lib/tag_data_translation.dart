/// GS1 EPC Tag Data Translation for Flutter.
///
/// Licensed under BSL 1.1 -- production use requires a commercial license
/// from tdt@mimasu.nl.
///
/// Example:
/// ```dart
/// final binary = TDTEngine.hexToBinary('30340242201d8840009efdf7');
/// final uri = await TDTEngine.translate(binary, 'PURE_IDENTITY', params: 'tagLength=96');
/// ```
library tag_data_translation;

import 'tag_data_translation_platform_interface.dart';

/// GS1 EPC Tag Data Translation engine.
class TDTEngine {
  /// Translate an EPC identifier between encoding levels.
  ///
  /// [epcIdentifier] is the EPC to convert (binary, hex, URI, or legacy).
  /// [outputFormat] is the target format (BINARY, LEGACY, TAG_ENCODING, PURE_IDENTITY).
  /// [params] is an optional semicolon-delimited key=value string.
  ///
  /// Throws [PlatformException] if translation fails.
  static Future<String> translate(
    String epcIdentifier,
    String outputFormat, {
    String params = '',
  }) {
    return TagDataTranslationPlatform.instance
        .translate(epcIdentifier, params, outputFormat);
  }

  /// Translate without throwing. Returns null on failure.
  static Future<String?> tryTranslate(
    String epcIdentifier,
    String outputFormat, {
    String params = '',
  }) {
    return TagDataTranslationPlatform.instance
        .tryTranslate(epcIdentifier, params, outputFormat);
  }

  /// Convert hexadecimal string to binary string.
  ///
  /// This is a pure Dart implementation -- no platform channel needed.
  static String hexToBinary(String hex) {
    final buffer = StringBuffer();
    for (var i = 0; i < hex.length; i++) {
      final value = int.parse(hex[i], radix: 16);
      buffer.write(value.toRadixString(2).padLeft(4, '0'));
    }
    return buffer.toString();
  }

  /// Convert binary string to hexadecimal string.
  ///
  /// This is a pure Dart implementation -- no platform channel needed.
  static String binaryToHex(String binary) {
    // pad to multiple of 4
    final padded = binary.padLeft(((binary.length + 3) ~/ 4) * 4, '0');
    final buffer = StringBuffer();
    for (var i = 0; i < padded.length; i += 4) {
      final nibble = int.parse(padded.substring(i, i + 4), radix: 2);
      buffer.write(nibble.toRadixString(16));
    }
    return buffer.toString();
  }
}
