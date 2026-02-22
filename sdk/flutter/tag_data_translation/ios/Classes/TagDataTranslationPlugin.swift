import Flutter

/**
 * Flutter plugin wrapping the TagDataTranslation iOS SDK.
 *
 * This plugin delegates to the NativeAOT-compiled static library
 * via the C FFI exports (tdt_translate, tdt_try_translate, etc.).
 */
public class TagDataTranslationPlugin: NSObject, FlutterPlugin {

    public static func register(with registrar: FlutterPluginRegistrar) {
        let channel = FlutterMethodChannel(
            name: "nl.mimasu.tdt/engine",
            binaryMessenger: registrar.messenger()
        )
        let instance = TagDataTranslationPlugin()
        registrar.addMethodCallDelegate(instance, channel: channel)
    }

    public func handle(_ call: FlutterMethodCall, result: @escaping FlutterResult) {
        guard let args = call.arguments as? [String: String] else {
            result(FlutterError(code: "INVALID_ARGS", message: "Expected string map", details: nil))
            return
        }

        let epcIdentifier = args["epcIdentifier"] ?? ""
        let parameterList = args["parameterList"] ?? ""
        let outputFormat = args["outputFormat"] ?? ""

        switch call.method {
        case "translate":
            // TODO: Call tdt_translate via FFI when XCFramework is linked
            result(FlutterError(code: "NOT_IMPLEMENTED", message: "iOS SDK not yet linked", details: nil))

        case "tryTranslate":
            // TODO: Call tdt_try_translate via FFI when XCFramework is linked
            result(FlutterError(code: "NOT_IMPLEMENTED", message: "iOS SDK not yet linked", details: nil))

        default:
            result(FlutterMethodNotImplemented)
        }
    }
}
