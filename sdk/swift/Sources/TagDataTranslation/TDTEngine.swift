import Foundation

/// GS1 EPC Tag Data Translation engine.
///
/// Licensed under BSL 1.1 -- production use requires a commercial license from tdt@mimasu.nl.
///
/// Example:
/// ```swift
/// let engine = TDTEngine()
/// let binary = TDTEngine.hexToBinary("30340242201d8840009efdf7")
/// let uri = try engine.translate(binary, to: "PURE_IDENTITY", params: "tagLength=96")
/// ```
public class TDTEngine {

    public enum TranslationError: Error, LocalizedError {
        case translationFailed(String)
        case nullResult

        public var errorDescription: String? {
            switch self {
            case .translationFailed(let message): return message
            case .nullResult: return "Translation returned null"
            }
        }
    }

    public init() {}

    /// Translate an EPC identifier between encoding levels.
    /// - Parameters:
    ///   - input: The EPC to convert (binary, hex, URI, or legacy)
    ///   - outputFormat: Target format (BINARY, LEGACY, TAG_ENCODING, PURE_IDENTITY)
    ///   - params: Semicolon-delimited key=value pairs
    /// - Returns: The translated EPC string
    /// - Throws: `TranslationError` if translation fails
    public func translate(_ input: String, to outputFormat: String, params: String = "") throws -> String {
        let resultPtr = input.withCString { inputPtr in
            params.withCString { paramsPtr in
                outputFormat.withCString { formatPtr in
                    tdt_translate(inputPtr, paramsPtr, formatPtr)
                }
            }
        }

        guard let resultPtr = resultPtr else {
            throw TranslationError.nullResult
        }

        let result = String(cString: resultPtr)
        tdt_free_string(resultPtr)

        if result.hasPrefix("ERROR:") {
            throw TranslationError.translationFailed(String(result.dropFirst(6)))
        }

        return result
    }

    /// Translate without throwing. Returns nil on failure.
    public func tryTranslate(_ input: String, to outputFormat: String, params: String = "") -> String? {
        let resultPtr = input.withCString { inputPtr in
            params.withCString { paramsPtr in
                outputFormat.withCString { formatPtr in
                    tdt_try_translate(inputPtr, paramsPtr, formatPtr)
                }
            }
        }

        guard let resultPtr = resultPtr else { return nil }
        let result = String(cString: resultPtr)
        tdt_free_string(resultPtr)
        return result
    }

    /// Convert hexadecimal string to binary string.
    public static func hexToBinary(_ hex: String) -> String {
        let resultPtr = hex.withCString { tdt_hex_to_binary($0) }!
        let result = String(cString: resultPtr)
        tdt_free_string(resultPtr)
        return result
    }

    /// Convert binary string to hexadecimal string.
    public static func binaryToHex(_ binary: String) -> String {
        let resultPtr = binary.withCString { tdt_binary_to_hex($0) }!
        let result = String(cString: resultPtr)
        tdt_free_string(resultPtr)
        return result
    }
}
