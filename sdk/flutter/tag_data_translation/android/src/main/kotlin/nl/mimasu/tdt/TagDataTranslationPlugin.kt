package nl.mimasu.tdt

import io.flutter.embedding.engine.plugins.FlutterPlugin
import io.flutter.plugin.common.MethodCall
import io.flutter.plugin.common.MethodChannel
import io.flutter.plugin.common.MethodChannel.MethodCallHandler
import io.flutter.plugin.common.MethodChannel.Result

/**
 * Flutter plugin wrapping the TagDataTranslation Android SDK.
 *
 * This plugin delegates to the .NET Android class library (TagDataTranslation.Android)
 * which provides Java-callable wrappers for the TDT engine.
 */
class TagDataTranslationPlugin : FlutterPlugin, MethodCallHandler {

    private lateinit var channel: MethodChannel
    // TODO: Initialize from TagDataTranslation.Android .aar
    // private lateinit var engine: nl.mimasu.tdt.TDTEngine

    override fun onAttachedToEngine(binding: FlutterPlugin.FlutterPluginBinding) {
        channel = MethodChannel(binding.binaryMessenger, "nl.mimasu.tdt/engine")
        channel.setMethodCallHandler(this)
        // engine = nl.mimasu.tdt.TDTEngine()
    }

    override fun onMethodCall(call: MethodCall, result: Result) {
        val epcIdentifier = call.argument<String>("epcIdentifier") ?: ""
        val parameterList = call.argument<String>("parameterList") ?: ""
        val outputFormat = call.argument<String>("outputFormat") ?: ""

        when (call.method) {
            "translate" -> {
                try {
                    // TODO: val translated = engine.translate(epcIdentifier, parameterList, outputFormat)
                    // result.success(translated)
                    result.error("NOT_IMPLEMENTED", "Android SDK not yet linked", null)
                } catch (e: Exception) {
                    result.error("TRANSLATE_ERROR", e.message, null)
                }
            }
            "tryTranslate" -> {
                // TODO: val translated = engine.tryTranslate(epcIdentifier, parameterList, outputFormat)
                // result.success(translated)
                result.error("NOT_IMPLEMENTED", "Android SDK not yet linked", null)
            }
            else -> result.notImplemented()
        }
    }

    override fun onDetachedFromEngine(binding: FlutterPlugin.FlutterPluginBinding) {
        channel.setMethodCallHandler(null)
    }
}
