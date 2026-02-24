package nl.mimasu.tdt

import io.flutter.embedding.engine.plugins.FlutterPlugin

/**
 * Flutter plugin registration for TagDataTranslation.
 *
 * The actual translation is handled via dart:ffi calling the NativeAOT
 * shared library directly. This class only exists to satisfy Flutter's
 * plugin registration requirements.
 */
class TagDataTranslationPlugin : FlutterPlugin {
    override fun onAttachedToEngine(binding: FlutterPlugin.FlutterPluginBinding) {
        // no-op: dart:ffi handles all native calls directly
    }

    override fun onDetachedFromEngine(binding: FlutterPlugin.FlutterPluginBinding) {
        // no-op
    }
}
