using System.Linq;
using Android.Runtime;
using Java.Interop;
using TagDataTranslation;

namespace TagDataTranslation.Android;

/// <summary>
/// Android-specific wrapper for the TDT engine.
/// This class is automatically exposed to Java/Kotlin via .NET for Android
/// Java-callable wrappers.
/// </summary>
[Register("nl.mimasu.tdt.TDTEngine")]
public class TDTEngineAndroid : Java.Lang.Object
{
    private readonly TDTEngine _engine;

    public TDTEngineAndroid()
    {
        _engine = new TDTEngine();
    }

    /// <summary>
    /// Translate an EPC identifier between encoding levels.
    /// </summary>
    [Export("translate")]
    public string Translate(string epcIdentifier, string parameterList, string outputFormat)
    {
        return _engine.Translate(epcIdentifier, parameterList, outputFormat);
    }

    /// <summary>
    /// Translate without throwing exceptions. Returns null on failure.
    /// </summary>
    [Export("tryTranslate")]
    public string? TryTranslate(string epcIdentifier, string parameterList, string outputFormat)
    {
        if (_engine.TryTranslate(epcIdentifier, parameterList, outputFormat, out var result, out _))
            return result;
        return null;
    }

    /// <summary>
    /// Convert hexadecimal string to binary string.
    /// </summary>
    [Export("hexToBinary")]
    public string HexToBinary(string hex)
    {
        return _engine.HexToBinary(hex);
    }

    /// <summary>
    /// Convert binary string to hexadecimal string.
    /// </summary>
    [Export("binaryToHex")]
    public string BinaryToHex(string binary)
    {
        return _engine.BinaryToHex(binary);
    }

    /// <summary>
    /// Get any errors encountered while loading scheme files.
    /// </summary>
    [Export("getLoadErrors")]
    public string[] GetLoadErrors()
    {
        return _engine.LoadErrors.ToArray();
    }
}
