using TagDataTranslation;

// create the engine and check for load errors
var engine = new TDTEngine();
if (engine.LoadErrors.Count > 0)
{
    Console.WriteLine("Scheme load errors:");
    foreach (var error in engine.LoadErrors)
        Console.WriteLine($"  {error}");
}

Console.WriteLine("=== TagDataTranslation Console Example ===\n");

// encode: GTIN + serial -> binary -> hex
var epcIdentifier = "gtin=00037000302414;serial=10419703";
var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
var binary = engine.Translate(epcIdentifier, parameterList, "BINARY");
var hex = engine.BinaryToHex(binary);
Console.WriteLine($"Encode GTIN to hex:");
Console.WriteLine($"  Input:  {epcIdentifier}");
Console.WriteLine($"  Hex:    {hex}\n");

// decode: hex -> all representations
var decodeBinary = engine.HexToBinary(hex);
var pureIdentity = engine.Translate(decodeBinary, "tagLength=96", "PURE_IDENTITY");
var tagUri = engine.Translate(decodeBinary, "tagLength=96", "TAG_ENCODING");
var legacy = engine.Translate(decodeBinary, "tagLength=96", "LEGACY");

Console.WriteLine($"Decode hex to all formats:");
Console.WriteLine($"  Pure Identity: {pureIdentity}");
Console.WriteLine($"  Tag URI:       {tagUri}");
Console.WriteLine($"  Legacy:        {legacy}\n");

// exception-free translation
if (engine.TryTranslate("invalid-input", "", "BINARY", out var result, out var errorCode))
{
    Console.WriteLine($"  Result: {result}");
}
else
{
    Console.WriteLine($"TryTranslate with invalid input:");
    Console.WriteLine($"  Error code: {errorCode}");
}
