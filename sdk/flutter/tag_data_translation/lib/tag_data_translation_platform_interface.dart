import 'package:flutter/services.dart';
import 'tag_data_translation_method_channel.dart';

/// Platform interface for TagDataTranslation plugin.
abstract class TagDataTranslationPlatform {
  static TagDataTranslationPlatform instance = MethodChannelTagDataTranslation();

  Future<String> translate(String epcIdentifier, String parameterList, String outputFormat);
  Future<String?> tryTranslate(String epcIdentifier, String parameterList, String outputFormat);
}
