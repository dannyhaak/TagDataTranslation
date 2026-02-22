using System.Runtime.InteropServices.JavaScript;
using TagDataTranslation;

namespace TagDataTranslation.Wasm;

/// <summary>
/// JavaScript interop exports for the TagDataTranslation engine.
/// These methods are callable from JavaScript after the WASM module loads.
/// </summary>
public partial class JsInterop
{
    private static TDTEngine? _engine;

    private static TDTEngine Engine => _engine ??= new TDTEngine();

    [JSExport]
    public static string Translate(string epcIdentifier, string parameterList, string outputFormat)
    {
        return Engine.Translate(epcIdentifier, parameterList, outputFormat);
    }

    [JSExport]
    public static string? TryTranslate(string epcIdentifier, string parameterList, string outputFormat)
    {
        if (Engine.TryTranslate(epcIdentifier, parameterList, outputFormat, out var result, out _))
            return result;
        return null;
    }

    [JSExport]
    public static string HexToBinary(string hex)
    {
        return Engine.HexToBinary(hex);
    }

    [JSExport]
    public static string BinaryToHex(string binary)
    {
        return Engine.BinaryToHex(binary);
    }

    [JSExport]
    public static string GetLoadErrors()
    {
        return string.Join("\n", Engine.LoadErrors);
    }
}
