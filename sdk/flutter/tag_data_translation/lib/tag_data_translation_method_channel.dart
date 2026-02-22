import 'package:flutter/services.dart';
import 'tag_data_translation_platform_interface.dart';

/// MethodChannel implementation of [TagDataTranslationPlatform].
class MethodChannelTagDataTranslation extends TagDataTranslationPlatform {
  static const _channel = MethodChannel('nl.mimasu.tdt/engine');

  @override
  Future<String> translate(
      String epcIdentifier, String parameterList, String outputFormat) async {
    final result = await _channel.invokeMethod<String>('translate', {
      'epcIdentifier': epcIdentifier,
      'parameterList': parameterList,
      'outputFormat': outputFormat,
    });
    return result!;
  }

  @override
  Future<String?> tryTranslate(
      String epcIdentifier, String parameterList, String outputFormat) async {
    return await _channel.invokeMethod<String>('tryTranslate', {
      'epcIdentifier': epcIdentifier,
      'parameterList': parameterList,
      'outputFormat': outputFormat,
    });
  }
}
