import Flutter

/// Flutter plugin registration for TagDataTranslation.
///
/// The actual translation is handled via dart:ffi calling the NativeAOT
/// static library directly. This class only exists to satisfy Flutter's
/// plugin registration requirements.
public class TagDataTranslationPlugin: NSObject, FlutterPlugin {
    public static func register(with registrar: FlutterPluginRegistrar) {
        // no-op: dart:ffi handles all native calls directly
    }
}
