/// GS1 EPC Tag Data Translation for Flutter.
///
/// Licensed under BSL 1.1 -- production use requires a commercial license
/// from tdt@mimasu.nl.
///
/// Example:
/// ```dart
/// final binary = TDTEngine.hexToBinary('30340242201d8840009efdf7');
/// final uri = TDTEngine.translate(binary, 'PURE_IDENTITY', params: 'tagLength=96');
/// ```
library tag_data_translation;

import 'dart:ffi';

import 'package:ffi/ffi.dart';

import 'src/native_bindings.dart';

/// Error thrown when EPC translation fails.
class TranslationError implements Exception {
  final String message;
  const TranslationError(this.message);

  @override
  String toString() => 'TranslationError: $message';
}

/// GS1 EPC Tag Data Translation engine.
///
/// Uses dart:ffi to call the NativeAOT-compiled TagDataTranslation library
/// directly, without platform channels.
class TDTEngine {
  /// Translate an EPC identifier between encoding levels.
  ///
  /// [epcIdentifier] is the EPC to convert (binary, hex, URI, or legacy).
  /// [outputFormat] is the target format (BINARY, LEGACY, TAG_ENCODING, PURE_IDENTITY).
  /// [params] is an optional semicolon-delimited key=value string.
  ///
  /// Throws [TranslationError] if translation fails.
  static String translate(
    String epcIdentifier,
    String outputFormat, {
    String params = '',
  }) {
    final bindings = NativeBindings.instance;
    final epcPtr = epcIdentifier.toNativeUtf8();
    final paramsPtr = params.toNativeUtf8();
    final formatPtr = outputFormat.toNativeUtf8();

    try {
      final resultPtr = bindings.translate(epcPtr, paramsPtr, formatPtr);
      final result = resultPtr.toDartString();
      bindings.freeString(resultPtr);

      if (result.startsWith('ERROR:')) {
        throw TranslationError(result.substring(6));
      }
      return result;
    } finally {
      malloc.free(epcPtr);
      malloc.free(paramsPtr);
      malloc.free(formatPtr);
    }
  }

  /// Translate without throwing. Returns null on failure.
  static String? tryTranslate(
    String epcIdentifier,
    String outputFormat, {
    String params = '',
  }) {
    final bindings = NativeBindings.instance;
    final epcPtr = epcIdentifier.toNativeUtf8();
    final paramsPtr = params.toNativeUtf8();
    final formatPtr = outputFormat.toNativeUtf8();

    try {
      final resultPtr = bindings.tryTranslate(epcPtr, paramsPtr, formatPtr);
      if (resultPtr == nullptr) return null;
      final result = resultPtr.toDartString();
      bindings.freeString(resultPtr);
      return result;
    } finally {
      malloc.free(epcPtr);
      malloc.free(paramsPtr);
      malloc.free(formatPtr);
    }
  }

  /// Convert hexadecimal string to binary string.
  ///
  /// This is a pure Dart implementation -- no native call needed.
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
  /// This is a pure Dart implementation -- no native call needed.
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
