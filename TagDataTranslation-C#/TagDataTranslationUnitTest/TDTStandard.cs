using System.Collections.Generic;
using TagDataTranslation;
using Xunit;

namespace TagDataTranslationUnitTest;

public class TDTStandard
{
    [Fact]
    public void TestCasePage13TDTStandard()
    {
        var engine = new TDTEngine();

        var epcIdentifier = "gtin=00037000302414;serial=1041970";
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var result1 = engine.Translate(epcIdentifier, parameterList, "BINARY");
        var expect = "001100000111010000000010010000100010000000011101100010000100000000000000000011111110011000110010";
        Assert.Equal(expect, result1);

        var result2 = engine.Translate(epcIdentifier, parameterList, "TAG_ENCODING");
        expect = "urn:epc:tag:sgtin-96:3.0037000.030241.1041970";
        Assert.Equal(expect, result2);

        var result3 = engine.Translate(result2, parameterList, "PURE_IDENTITY");
        expect = "urn:epc:id:sgtin:0037000.030241.1041970";
        Assert.Equal(expect, result3);

        var result4 = engine.Translate(result3, parameterList, "LEGACY");
        Assert.Equal(epcIdentifier, result4);
    }

    [Fact]
    public void TestCasePage26TDTStandard()
    {
        var engine = new TDTEngine();

        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var epcIdentifiers = new List<string>
        {
            "gtin=00037000302414;serial=10419703",
            "gln=0003700030247;serial=1041970",
            "grai=00037000302414274877906943",
            "giai=00370003024149267890123",
            "generalmanager=5;objectclass=17;serial=23",
            "cageordodaac=AB123;serial=3789156"
        };

        foreach (var epcIdentifier in epcIdentifiers)
        {
            var result = engine.Translate(epcIdentifier, parameterList, "BINARY");
            var result2 = engine.Translate(result, parameterList, "LEGACY");
            Assert.Equal(epcIdentifier, result2);
        }
    }
}
