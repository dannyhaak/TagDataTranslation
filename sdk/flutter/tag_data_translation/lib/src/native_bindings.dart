import 'dart:ffi';
import 'dart:io' show Platform;

import 'package:ffi/ffi.dart';

// C function signatures (as defined in tdt.h)
typedef TdtTranslateNative = Pointer<Utf8> Function(
    Pointer<Utf8> epcIdentifier,
    Pointer<Utf8> parameterList,
    Pointer<Utf8> outputFormat);

typedef TdtTryTranslateNative = Pointer<Utf8> Function(
    Pointer<Utf8> epcIdentifier,
    Pointer<Utf8> parameterList,
    Pointer<Utf8> outputFormat);

typedef TdtHexToBinaryNative = Pointer<Utf8> Function(Pointer<Utf8> hex);
typedef TdtBinaryToHexNative = Pointer<Utf8> Function(Pointer<Utf8> binary);
typedef TdtFreeStringNative = Void Function(Pointer<Utf8> ptr);

// dart versions of C function signatures
typedef TdtTranslateDart = Pointer<Utf8> Function(
    Pointer<Utf8> epcIdentifier,
    Pointer<Utf8> parameterList,
    Pointer<Utf8> outputFormat);

typedef TdtTryTranslateDart = Pointer<Utf8> Function(
    Pointer<Utf8> epcIdentifier,
    Pointer<Utf8> parameterList,
    Pointer<Utf8> outputFormat);

typedef TdtHexToBinaryDart = Pointer<Utf8> Function(Pointer<Utf8> hex);
typedef TdtBinaryToHexDart = Pointer<Utf8> Function(Pointer<Utf8> binary);
typedef TdtFreeStringDart = void Function(Pointer<Utf8> ptr);

/// Low-level FFI bindings to the NativeAOT TagDataTranslation library.
///
/// On iOS, the static library is linked at build time and symbols are
/// available in the process. On Android, the shared library is loaded
/// from jniLibs.
class NativeBindings {
  static NativeBindings? _instance;

  final TdtTranslateDart translate;
  final TdtTryTranslateDart tryTranslate;
  final TdtHexToBinaryDart hexToBinary;
  final TdtBinaryToHexDart binaryToHex;
  final TdtFreeStringDart freeString;

  NativeBindings._({
    required this.translate,
    required this.tryTranslate,
    required this.hexToBinary,
    required this.binaryToHex,
    required this.freeString,
  });

  /// Get the singleton instance, loading the native library on first access.
  static NativeBindings get instance {
    _instance ??= _load();
    return _instance!;
  }

  static NativeBindings _load() {
    final DynamicLibrary lib;

    if (Platform.isIOS) {
      // on iOS the static library is linked into the app binary
      lib = DynamicLibrary.process();
    } else if (Platform.isAndroid) {
      lib = DynamicLibrary.open('libtagdatatranslation.so');
    } else {
      throw UnsupportedError(
          'TagDataTranslation is only supported on iOS and Android');
    }

    return NativeBindings._(
      translate: lib
          .lookupFunction<TdtTranslateNative, TdtTranslateDart>('tdt_translate'),
      tryTranslate: lib
          .lookupFunction<TdtTryTranslateNative, TdtTryTranslateDart>(
              'tdt_try_translate'),
      hexToBinary: lib
          .lookupFunction<TdtHexToBinaryNative, TdtHexToBinaryDart>(
              'tdt_hex_to_binary'),
      binaryToHex: lib
          .lookupFunction<TdtBinaryToHexNative, TdtBinaryToHexDart>(
              'tdt_binary_to_hex'),
      freeString: lib
          .lookupFunction<TdtFreeStringNative, TdtFreeStringDart>(
              'tdt_free_string'),
    );
  }
}
