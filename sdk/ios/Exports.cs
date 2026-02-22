using System.Runtime.InteropServices;
using TagDataTranslation;

namespace TagDataTranslation.iOS;

/// <summary>
/// C-callable exports for the TDT engine.
/// These are exposed as native symbols in the compiled static library,
/// callable from Swift/Objective-C via the C FFI.
/// </summary>
public static class Exports
{
    private static TDTEngine? _engine;
    private static TDTEngine Engine => _engine ??= new TDTEngine();

    [UnmanagedCallersOnly(EntryPoint = "tdt_translate")]
    public static IntPtr Translate(IntPtr epcIdentifierPtr, IntPtr parameterListPtr, IntPtr outputFormatPtr)
    {
        try
        {
            var epcIdentifier = Marshal.PtrToStringUTF8(epcIdentifierPtr) ?? "";
            var parameterList = Marshal.PtrToStringUTF8(parameterListPtr) ?? "";
            var outputFormat = Marshal.PtrToStringUTF8(outputFormatPtr) ?? "";
            var result = Engine.Translate(epcIdentifier, parameterList, outputFormat);
            return Marshal.StringToCoTaskMemUTF8(result);
        }
        catch (Exception ex)
        {
            return Marshal.StringToCoTaskMemUTF8($"ERROR:{ex.Message}");
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "tdt_try_translate")]
    public static IntPtr TryTranslate(IntPtr epcIdentifierPtr, IntPtr parameterListPtr, IntPtr outputFormatPtr)
    {
        var epcIdentifier = Marshal.PtrToStringUTF8(epcIdentifierPtr) ?? "";
        var parameterList = Marshal.PtrToStringUTF8(parameterListPtr) ?? "";
        var outputFormat = Marshal.PtrToStringUTF8(outputFormatPtr) ?? "";

        if (Engine.TryTranslate(epcIdentifier, parameterList, outputFormat, out var result, out _))
            return Marshal.StringToCoTaskMemUTF8(result ?? "");
        return IntPtr.Zero;
    }

    [UnmanagedCallersOnly(EntryPoint = "tdt_hex_to_binary")]
    public static IntPtr HexToBinary(IntPtr hexPtr)
    {
        var hex = Marshal.PtrToStringUTF8(hexPtr) ?? "";
        var result = Engine.HexToBinary(hex);
        return Marshal.StringToCoTaskMemUTF8(result);
    }

    [UnmanagedCallersOnly(EntryPoint = "tdt_binary_to_hex")]
    public static IntPtr BinaryToHex(IntPtr binaryPtr)
    {
        var binary = Marshal.PtrToStringUTF8(binaryPtr) ?? "";
        var result = Engine.BinaryToHex(binary);
        return Marshal.StringToCoTaskMemUTF8(result);
    }

    [UnmanagedCallersOnly(EntryPoint = "tdt_free_string")]
    public static void FreeString(IntPtr ptr)
    {
        if (ptr != IntPtr.Zero)
            Marshal.FreeCoTaskMem(ptr);
    }
}
