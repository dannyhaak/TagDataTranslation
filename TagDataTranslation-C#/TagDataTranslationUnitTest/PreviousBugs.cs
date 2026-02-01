using TagDataTranslation;
using Xunit;

namespace TagDataTranslationUnitTest;

public class PreviousBugs
{
    [Fact]
    public void LongCompanyPrefix()
    {
        var engine = new TDTEngine();

        var epcIdentifier = "urn:epc:id:sgtin:0867360217.005.0";
        var parameterList = "filter=1;gs1companyprefixlength=10;tagLength=96";

        var result1 = engine.Translate(epcIdentifier, parameterList, "BINARY");
        var expect = engine.HexToBinary("302833B2DDD9014000000000");
        Assert.Equal(expect, result1);

        var result2 = engine.Translate(epcIdentifier, parameterList, "TAG_ENCODING");
        expect = "urn:epc:tag:sgtin-96:1.0867360217.005.0";
        Assert.Equal(expect, result2);

        var result3 = engine.Translate(result2, parameterList, "LEGACY");
        expect = "gtin=00867360217055;serial=0";
        Assert.Equal(expect, result3);

        var result4 = engine.Translate(result3, parameterList, "PURE_IDENTITY");
        Assert.Equal(epcIdentifier, result4);
    }

    [Fact]
    public void EmptyParameterListSGTIN96PureIdentityToLegacy()
    {
        var engine = new TDTEngine();

        var epcIdentifier = "urn:epc:id:sgtin:0037000.030241.1041970";
        var parameterList = "";

        var result = engine.Translate(epcIdentifier, parameterList, "LEGACY");
        var expect = "gtin=00037000302414;serial=1041970";
        Assert.Equal(expect, result);
    }

    [Fact]
    public void EmptyParameterListSGTIN96TagURIToLegacy()
    {
        var engine = new TDTEngine();

        var epcIdentifier = "urn:epc:tag:sgtin-96:1.0037000.030241.1041970";
        var parameterList = "";

        var result = engine.Translate(epcIdentifier, parameterList, "LEGACY");
        var expect = "gtin=00037000302414;serial=1041970";
        Assert.Equal(expect, result);
    }

    [Fact]
    public void EmptyParameterListSGTIN96TagURIToPureIdentity()
    {
        var engine = new TDTEngine();

        var epcIdentifier = "urn:epc:tag:sgtin-96:1.0037000.030241.1041970";
        var parameterList = "";

        var result = engine.Translate(epcIdentifier, parameterList, "PURE_IDENTITY");
        var expect = "urn:epc:id:sgtin:0037000.030241.1041970";
        Assert.Equal(expect, result);
    }

    [Fact]
    public void EmptyParameterListSGTIN198PureIdentityToLegacy()
    {
        var engine = new TDTEngine();

        var epcIdentifier = "urn:epc:id:sgtin:0037000.030241.ABCD";
        var parameterList = "";

        var result = engine.Translate(epcIdentifier, parameterList, "LEGACY");
        var expect = "gtin=00037000302414;serial=ABCD";
        Assert.Equal(expect, result);
    }

    [Fact]
    public void BitPaddingInNonDivisibleByFourLengthEpcs()
    {
        var engine = new TDTEngine();

        var epcIdentifier = engine.HexToBinary("4074F4E4E40C0E40820000000F6C");
        var parameterList = "";

        var result = engine.Translate(epcIdentifier, parameterList, "TAG_ENCODING");
        var expect = "urn:epc:tag:itip-110:3.4012345.012345.01.02.987";
        Assert.Equal(expect, result);
    }

    [Fact]
    public void AdiVarBrendan()
    {
        var engine = new TDTEngine();

        var epcIdentifier = engine.HexToBinary("3B0204C8D72C001CC5F1C79CB4D35000");
        var parameterList = "";

        var result = engine.Translate(epcIdentifier, parameterList, "TAG_ENCODING");
        var expect = "urn:epc:tag:adi-var:0.SH520..GLW1192445";
        Assert.Equal(expect, result);

        var result2 = engine.Translate(result, parameterList, "BINARY");

        var length = epcIdentifier.Length;
        var result2Padded = result2.PadRight(length, '0');

        Assert.Equal(epcIdentifier, result2Padded);
    }
}
