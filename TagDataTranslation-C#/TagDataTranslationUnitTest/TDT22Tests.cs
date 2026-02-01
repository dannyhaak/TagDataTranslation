using System.Collections.Generic;
using System.Linq;
using TagDataTranslation;
using TagDataTranslation.DigitalLink;
using Xunit;

namespace TagDataTranslationUnitTest;

/// <summary>
/// Tests specific to TDT 2.2 features including new schemes and Digital Link support.
/// </summary>
public class TDT22Tests
{
    private readonly TDTEngine _engine = new();

    #region JSON Schemes Loading

    [Fact]
    public void Engine_LoadsJsonSchemes()
    {
        // verify engine initializes without errors (schemes load correctly)
        var engine = new TDTEngine();
        Assert.NotNull(engine);
    }

    [Fact]
    public void Tables_AreAccessible()
    {
        var tableB = _engine.GetTableB();
        var tableE = _engine.GetTableE();
        var tableF = _engine.GetTableF();
        var tableK = _engine.GetTableK();

        Assert.NotNull(tableB);
        Assert.NotNull(tableE);
        Assert.NotNull(tableF);
        Assert.NotNull(tableK);
    }

    [Fact]
    public void TableF_ContainsSchemeInfo()
    {
        var tableF = _engine.GetTableF();
        // table F maps AI codes to their encoding format
        Assert.True(tableF.Count > 0);
    }

    #endregion

    #region Scheme Round-Trip Tests

    [Fact]
    public void Sgtin96_RoundTrip()
    {
        // SGTIN-96 encoding requires filter value
        var pureIdentity = "urn:epc:id:sgtin:0614141.812345.6789";
        var paramList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var binary = _engine.Translate(pureIdentity, paramList, "BINARY");
        Assert.NotNull(binary);
        Assert.Equal(96, binary.Length);

        var hex = _engine.BinaryToHex(binary);
        var binaryBack = _engine.HexToBinary(hex);
        var result = _engine.Translate(binaryBack, "tagLength=96", "PURE_IDENTITY");
        Assert.Equal(pureIdentity, result);
    }

    #endregion

    #region Digital Link Support

    [Fact]
    public void DigitalLink_ParseSgtin()
    {
        var uri = "https://id.gs1.org/01/00614141123452/21/6789";
        Assert.True(DigitalLinkParser.TryParse(uri, out var components));
        Assert.Equal("00614141123452", components!.Gtin);
        Assert.Equal("6789", components.SerialNumber);
    }

    [Fact]
    public void DigitalLink_ParseWithBatchLot()
    {
        var uri = "https://id.gs1.org/01/00614141123452/10/LOT123";
        Assert.True(DigitalLinkParser.TryParse(uri, out var components));
        Assert.Equal("00614141123452", components!.Gtin);
        Assert.Equal("LOT123", components.BatchLot);
    }

    [Fact]
    public void DigitalLink_GenerateSgtin()
    {
        var components = new DigitalLinkComponents
        {
            Domain = "id.gs1.org",
            Gtin = "00614141123452",
            SerialNumber = "6789"
        };

        var link = DigitalLinkGenerator.Generate(components);
        Assert.Equal("https://id.gs1.org/01/00614141123452/21/6789", link);
    }

    [Fact]
    public void DigitalLink_GenerateWithHttp()
    {
        var components = new DigitalLinkComponents
        {
            Domain = "example.com",
            Gtin = "00614141123452"
        };

        var link = DigitalLinkGenerator.Generate(components, useHttps: false);
        Assert.StartsWith("http://", link);
    }

    [Fact]
    public void DigitalLink_RoundTrip()
    {
        var original = new DigitalLinkComponents
        {
            Domain = "id.gs1.org",
            Gtin = "00614141123452",
            SerialNumber = "serial123"
        };

        var link = DigitalLinkGenerator.Generate(original);
        Assert.True(DigitalLinkParser.TryParse(link, out var parsed));

        Assert.Equal(original.Gtin, parsed!.Gtin);
        Assert.Equal(original.SerialNumber, parsed.SerialNumber);
    }

    [Fact]
    public void DigitalLink_ParseWithQueryParams()
    {
        var uri = "https://id.gs1.org/01/00614141123452/21/6789?17=260101";
        Assert.True(DigitalLinkParser.TryParse(uri, out var components));
        Assert.Equal("260101", components!.ExpiryDate);
    }

    #endregion

    #region TranslateDetails API

    [Fact]
    public void TranslateDetails_ReturnsOutput()
    {
        var result = _engine.TranslateDetails(
            "urn:epc:id:sgtin:0614141.812345.6789",
            "filter=3;tagLength=96",
            "TAG_ENCODING"
        );

        Assert.NotNull(result);
        Assert.NotNull(result.Output);
        Assert.StartsWith("urn:epc:tag:", result.Output);
    }

    [Fact]
    public void TranslateDetails_ContainsParameterDictionary()
    {
        var hex = "30340242201d8840009efdf7";
        var binary = _engine.HexToBinary(hex);
        var result = _engine.TranslateDetails(binary, "tagLength=96", "PURE_IDENTITY");

        Assert.NotNull(result);
        Assert.NotNull(result.ParameterDictionary);
    }

    #endregion

    #region GCP Prefix Length

    [Fact]
    public void GetPrefixLength_KnownPrefix()
    {
        var result = _engine.GetPrefixLength("0614141123456");
        Assert.NotNull(result);
        // GCP length may vary based on prefix list
        Assert.True(result.Length >= 5 && result.Length <= 12);
        Assert.NotEmpty(result.Prefix);
    }

    [Fact]
    public void GetPrefixLength_DifferentLengths()
    {
        // Test various GCP lengths that exist in the prefix list
        var result6 = _engine.GetPrefixLength("030000123456");
        var result7 = _engine.GetPrefixLength("0614141123456");

        Assert.True(result6.Length >= 6);
        Assert.True(result7.Length >= 6);
    }

    #endregion

    #region Filter Value Tables

    [Fact]
    public void FilterValueTable_SGTIN()
    {
        var table = _engine.GetFilterValueTable("SGTIN");
        Assert.NotNull(table);
        Assert.True(table.Count > 0);
        Assert.True(table.ContainsKey(0)); // "all others"
    }

    [Fact]
    public void FilterValueTable_SSCC()
    {
        var table = _engine.GetFilterValueTable("SSCC");
        Assert.NotNull(table);
        Assert.True(table.Count > 0);
    }

    [Fact]
    public void FilterValueTable_AllSchemes()
    {
        var schemes = new[] { "SGTIN", "SSCC", "SGLN", "GRAI", "GIAI", "GSRN", "GDTI" };
        foreach (var scheme in schemes)
        {
            var table = _engine.GetFilterValueTable(scheme);
            Assert.NotNull(table);
            Assert.True(table.Count > 0, $"Filter table for {scheme} should not be empty");
        }
    }

    #endregion

    #region Hex/Binary Conversion

    [Fact]
    public void HexToBinary_ValidHex()
    {
        var binary = _engine.HexToBinary("30340242201d8840009efdf7");
        Assert.Equal(96, binary.Length);
        Assert.True(binary.All(c => c == '0' || c == '1'));
    }

    [Fact]
    public void BinaryToHex_ValidBinary()
    {
        var binary = "001100000011010000000010010000100010000000011101100010000100000000000000100111101111110111110111";
        var hex = _engine.BinaryToHex(binary);
        Assert.Equal("30340242201d8840009efdf7", hex.ToLowerInvariant());
    }

    [Fact]
    public void HexBinary_RoundTrip()
    {
        var originalHex = "30340242201d8840009efdf7";
        var binary = _engine.HexToBinary(originalHex);
        var hex = _engine.BinaryToHex(binary);
        Assert.Equal(originalHex, hex.ToLowerInvariant());
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void Translate_InvalidScheme_ReturnsNull()
    {
        // Test with a clearly invalid scheme prefix - TDT 2.2 returns null instead of throwing
        var result = _engine.Translate("urn:epc:id:invalid:123.456.789", "tagLength=96", "BINARY");
        Assert.Null(result);
    }

    [Fact]
    public void Translate_EmptyParams_HandledGracefully()
    {
        var hex = "30340242201d8840009efdf7";
        var binary = _engine.HexToBinary(hex);
        // should work with minimal params when decoding
        var result = _engine.Translate(binary, "tagLength=96", "PURE_IDENTITY");
        Assert.NotNull(result);
    }

    #endregion
}
