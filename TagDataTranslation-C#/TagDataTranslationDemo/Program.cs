using TagDataTranslation;
using TagDataTranslation.DigitalLink;

Console.WriteLine("=".PadRight(60, '='));
Console.WriteLine("  TagDataTranslation 2.0 Demo - TDT 2.2 Implementation");
Console.WriteLine("=".PadRight(60, '='));
Console.WriteLine();

var engine = new TDTEngine();

// ============================================================
// 1. Basic SGTIN-96 Encoding/Decoding
// ============================================================
Console.WriteLine("1. SGTIN-96 Encoding/Decoding");
Console.WriteLine("-".PadRight(60, '-'));

var gtin = "gtin=00037000302414;serial=10419703";
var paramList = "filter=3;gs1companyprefixlength=7;tagLength=96";

var binary = engine.Translate(gtin, paramList, "BINARY");
var hex = engine.BinaryToHex(binary);
var pureIdentity = engine.Translate(binary, paramList, "PURE_IDENTITY");
var tagUri = engine.Translate(binary, paramList, "TAG_ENCODING");

Console.WriteLine($"  Input:         {gtin}");
Console.WriteLine($"  Hex:           {hex}");
Console.WriteLine($"  Pure Identity: {pureIdentity}");
Console.WriteLine($"  Tag URI:       {tagUri}");
Console.WriteLine();

// ============================================================
// 2. Decode from Hex
// ============================================================
Console.WriteLine("2. Decode from Hex");
Console.WriteLine("-".PadRight(60, '-'));

var inputHex = "3074257BF7194E4000001A85";
var inputBinary = engine.HexToBinary(inputHex);
var decodedPureIdentity = engine.Translate(inputBinary, "tagLength=96", "PURE_IDENTITY");
var decodedLegacy = engine.Translate(inputBinary, "tagLength=96", "LEGACY");

Console.WriteLine($"  Input Hex:     {inputHex}");
Console.WriteLine($"  Pure Identity: {decodedPureIdentity}");
Console.WriteLine($"  Legacy:        {decodedLegacy}");
Console.WriteLine();

// ============================================================
// 3. Multiple Scheme Examples
// ============================================================
Console.WriteLine("3. Multiple Scheme Examples");
Console.WriteLine("-".PadRight(60, '-'));

var schemes = new (string name, string input, string parameters)[]
{
    ("SGTIN-96", "urn:epc:id:sgtin:0614141.812345.6789", "filter=3;gs1companyprefixlength=7;tagLength=96"),
    ("SSCC-96", "urn:epc:id:sscc:0614141.1234567890", "filter=3;gs1companyprefixlength=7;tagLength=96"),
    ("SGLN-96", "urn:epc:id:sgln:0614141.12345.5678", "filter=3;gs1companyprefixlength=7;tagLength=96"),
    ("GRAI-96", "urn:epc:id:grai:0614141.12345.5678", "filter=3;gs1companyprefixlength=7;tagLength=96"),
    ("GID-96", "urn:epc:id:gid:31415.271828.1414", "tagLength=96"),
};

foreach (var (name, input, parameters) in schemes)
{
    var schemeBinary = engine.Translate(input, parameters, "BINARY");
    var schemeHex = schemeBinary != null ? engine.BinaryToHex(schemeBinary) : "N/A";
    Console.WriteLine($"  {name,-10} {input}");
    Console.WriteLine($"             -> {schemeHex}");
}
Console.WriteLine();

// ============================================================
// 4. TDT 2.2 Plus (+) Encodings
// ============================================================
Console.WriteLine("4. TDT 2.2 Plus (+) Encodings (Variable-Length)");
Console.WriteLine("-".PadRight(60, '-'));

var plusSchemes = new (string name, string bareIdentifier, string prefix)[]
{
    ("SGTIN+", "gtin=80614141123458;serial=ABC123", "11110111"),
    ("SSCC+", "sscc=106141412345678908", "11111001"),
    ("GIAI+", "giai=0614141ABC123", "11111010"),
};

foreach (var (name, bareIdentifier, prefix) in plusSchemes)
{
    var plusBinary = engine.Translate(bareIdentifier, "filter=3;dataToggle=0", "BINARY");
    if (plusBinary != null)
    {
        var plusHex = engine.BinaryToHex(plusBinary);
        Console.WriteLine($"  {name,-10} {bareIdentifier}");
        Console.WriteLine($"             -> Hex: {plusHex}");
        Console.WriteLine($"             -> Binary prefix: {plusBinary[..8]} (expected: {prefix})");
    }
}
Console.WriteLine();

// ============================================================
// 5. Digital Link Generation
// ============================================================
Console.WriteLine("5. GS1 Digital Link Generation");
Console.WriteLine("-".PadRight(60, '-'));

var dlComponents = new DigitalLinkComponents
{
    Domain = "id.gs1.org",
    Gtin = "00614141123452",
    SerialNumber = "ABC123"
};
var digitalLink = DigitalLinkGenerator.Generate(dlComponents);
Console.WriteLine($"  GTIN:          {dlComponents.Gtin}");
Console.WriteLine($"  Serial:        {dlComponents.SerialNumber}");
Console.WriteLine($"  Digital Link:  {digitalLink}");
Console.WriteLine();

// ============================================================
// 6. Digital Link Parsing
// ============================================================
Console.WriteLine("6. GS1 Digital Link Parsing");
Console.WriteLine("-".PadRight(60, '-'));

var dlUri = "https://id.gs1.org/01/00614141123452/21/XYZ789/10/LOT001?17=261231";
if (DigitalLinkParser.TryParse(dlUri, out var parsed))
{
    Console.WriteLine($"  URI:           {dlUri}");
    Console.WriteLine($"  Domain:        {parsed.Domain}");
    Console.WriteLine($"  GTIN (01):     {parsed.Gtin}");
    Console.WriteLine($"  Serial (21):   {parsed.SerialNumber}");
    Console.WriteLine($"  Batch (10):    {parsed.BatchLot}");
    Console.WriteLine($"  Expiry (17):   {parsed.ExpiryDate}");
}
Console.WriteLine();

// ============================================================
// 7. GS1 Company Prefix Lookup
// ============================================================
Console.WriteLine("7. GS1 Company Prefix Lookup");
Console.WriteLine("-".PadRight(60, '-'));

var prefixInputs = new[] { "0614141123456", "4012345678901", "0037000302414" };
foreach (var prefixInput in prefixInputs)
{
    var prefixResult = engine.GetPrefixLength(prefixInput);
    Console.WriteLine($"  {prefixInput} -> Prefix: {prefixResult.Prefix}, Length: {prefixResult.Length}");
}
Console.WriteLine();

// ============================================================
// 8. Filter Value Tables
// ============================================================
Console.WriteLine("8. Filter Value Tables");
Console.WriteLine("-".PadRight(60, '-'));

var sgtinFilters = engine.GetFilterValueTable("SGTIN");
Console.WriteLine("  SGTIN Filter Values:");
foreach (var (key, value) in sgtinFilters.OrderBy(x => x.Key))
{
    Console.WriteLine($"    {key}: {value}");
}
Console.WriteLine();

// ============================================================
// 9. TDT Tables
// ============================================================
Console.WriteLine("9. TDT 2.2 Tables");
Console.WriteLine("-".PadRight(60, '-'));

var tableB = engine.GetTableB();
var tableE = engine.GetTableE();
var tableF = engine.GetTableF();
var tableK = engine.GetTableK();

Console.WriteLine($"  Table B (Base 40 chars):    Loaded");
Console.WriteLine($"  Table E (Character sets):   Loaded");
Console.WriteLine($"  Table F (AI formats):       {tableF.Count} entries");
Console.WriteLine($"  Table K (Key qualifiers):   Loaded");
Console.WriteLine();

// ============================================================
// 10. Translate to GS1 Digital Link
// ============================================================
Console.WriteLine("10. Translate to GS1 Digital Link (via TDT Engine)");
Console.WriteLine("-".PadRight(60, '-'));

var sgtinPlusInput = "gtin=80614141123458;serial=TEST123";
var dlOutput = engine.Translate(sgtinPlusInput, "filter=3;dataToggle=0;uristem=https://example.com", "GS1_DIGITAL_LINK");
Console.WriteLine($"  Input:         {sgtinPlusInput}");
Console.WriteLine($"  Digital Link:  {dlOutput}");
Console.WriteLine();

Console.WriteLine("=".PadRight(60, '='));
Console.WriteLine("  Demo Complete");
Console.WriteLine("=".PadRight(60, '='));
