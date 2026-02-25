using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace TagDataTranslation.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(warmupCount: 3, iterationCount: 10)]
public class TranslateBenchmark
{
    private TDTEngine engine = null!;

    // SGTIN-96 test data (from existing tests)
    private const string Sgtin96BareIdentifier = "gtin=00037000302414;serial=1041970";
    private const string Sgtin96Params = "filter=3;gs1companyprefixlength=7;tagLength=96";
    private const string Sgtin96Hex = "30340242201D8840009EFDF7";
    private string Sgtin96Binary = "";

    // SGTIN++ test data (from existing tests)
    private const string SgtinPPBareIdentifier = "gtin=79521141123453;serial=32a/b;hostname=example.com";
    private const string SgtinPPParams = "filter=3;dataToggle=0";
    private string SgtinPPBinary = "";

    // failure case: random hex that doesn't match any scheme
    private const string RandomHex = "DEADBEEFCAFEBABE12345678";
    private string RandomBinary = "";

    [GlobalSetup]
    public void Setup()
    {
        engine = new TDTEngine();
        Sgtin96Binary = BinaryConverter.HexToBinary(Sgtin96Hex);

        // encode SGTIN++ to get its binary representation
        var result = engine.Translate(SgtinPPBareIdentifier, SgtinPPParams, "BINARY");
        SgtinPPBinary = result ?? "";

        RandomBinary = BinaryConverter.HexToBinary(RandomHex);
    }

    [Benchmark]
    public string? Translate_Sgtin96_BareIdentifierToBinary()
    {
        return engine.Translate(Sgtin96BareIdentifier, Sgtin96Params, "BINARY");
    }

    [Benchmark]
    public string? Translate_Sgtin96_BinaryToBareIdentifier()
    {
        return engine.Translate(Sgtin96Binary, "tagLength=96", "BARE_IDENTIFIER");
    }

    [Benchmark]
    public string? Translate_SgtinPlusPlus_BareIdentifierToBinary()
    {
        return engine.Translate(SgtinPPBareIdentifier, SgtinPPParams, "BINARY");
    }

    [Benchmark]
    public string? Translate_SgtinPlusPlus_BinaryToBareIdentifier()
    {
        return engine.Translate(SgtinPPBinary, "tagLength=var", "BARE_IDENTIFIER");
    }

    [Benchmark]
    public string HexToBinary_Sgtin96()
    {
        return BinaryConverter.HexToBinary(Sgtin96Hex);
    }

    [Benchmark]
    public string BinaryToHex_Sgtin96()
    {
        return BinaryConverter.BinaryToHex(Sgtin96Binary);
    }

    [Benchmark]
    public bool TryTranslate_Failure_RandomHex()
    {
        return engine.TryTranslate(RandomHex, "", "BARE_IDENTIFIER", out _, out _);
    }

    [Benchmark]
    public bool TryTranslate_Failure_RandomBinary()
    {
        return engine.TryTranslate(RandomBinary, "tagLength=96", "BARE_IDENTIFIER", out _, out _);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<TranslateBenchmark>(args: args);
    }
}
