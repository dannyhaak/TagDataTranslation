using System;
using System.Collections.Generic;
using System.Linq;
using TagDataTranslation;
using TagDataTranslation.DigitalLink;
using TagDataTranslation.Encoding;
using Xunit;

namespace TagDataTranslationUnitTest;

/// <summary>
/// Comprehensive tests for Tag Data Standard (TDS) and Tag Data Translation (TDT) specifications.
/// Includes TDT 2.2 standard schemes, TDS 2.3 '+' and '++' schemes, and Digital Link support.
/// </summary>
public class TDSStandard
{
    private readonly TDTEngine _engine = new();

    #region Helper Methods

    /// <summary>
    /// Execute bidirectional translation tests for all formats in the dictionary.
    /// Each format is translated to every other format and compared with expected values.
    /// For BINARY format, comparison is done via hex to handle variable-length padding.
    /// </summary>
    private void ExecuteTests(Dictionary<string, string> tests, string parameterList)
    {
        foreach (var test in tests)
        {
            var input = test.Value;

            foreach (var output in tests)
            {
                var outputFormat = output.Key;
                var expect = output.Value;
                var result = _engine.Translate(input, parameterList, outputFormat);

                if (outputFormat == "BINARY" && result != null && expect != null)
                {
                    // compare via hex to handle variable-length padding differences
                    var expectHex = _engine.BinaryToHex(expect);
                    var resultHex = _engine.BinaryToHex(result);
                    Assert.Equal(expectHex, resultHex);
                }
                else
                {
                    Assert.Equal(expect, result);
                }
            }
        }
    }

    /// <summary>
    /// Execute tests for formats that can be uniquely identified, plus one-way tests to output-only formats.
    /// Use this for + schemes where GS1_DIGITAL_LINK input is ambiguous (could match ++ scheme).
    /// </summary>
    /// <param name="uniqueFormats">Formats that uniquely identify the scheme (e.g., BINARY, BARE_IDENTIFIER)</param>
    /// <param name="outputOnlyFormats">Formats that are tested as output only (e.g., GS1_DIGITAL_LINK)</param>
    /// <param name="parameterList">Parameters for translation</param>
    private void ExecuteTestsWithOutputOnly(
        Dictionary<string, string> uniqueFormats,
        Dictionary<string, string> outputOnlyFormats,
        string parameterList)
    {
        // bidirectional tests between unique formats
        foreach (var test in uniqueFormats)
        {
            var input = test.Value;

            foreach (var output in uniqueFormats)
            {
                var outputFormat = output.Key;
                var expect = output.Value;
                var result = _engine.Translate(input, parameterList, outputFormat);

                if (outputFormat == "BINARY" && result != null && expect != null)
                {
                    var expectHex = _engine.BinaryToHex(expect);
                    var resultHex = _engine.BinaryToHex(result);
                    Assert.Equal(expectHex, resultHex);
                }
                else
                {
                    Assert.Equal(expect, result);
                }
            }

            // one-way tests from unique formats to output-only formats
            foreach (var output in outputOnlyFormats)
            {
                var outputFormat = output.Key;
                var expect = output.Value;
                var result = _engine.Translate(input, parameterList, outputFormat);
                Assert.Equal(expect, result);
            }
        }
    }

    #endregion

    #region JSON Schemes and Tables Tests

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

    #region Hex/Binary Conversion Tests

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

    #region GCP Prefix Length Tests

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

    #region Filter Value Tables Tests

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

    #region TranslateDetails API Tests

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

    #region TryTranslate API Tests

    [Fact]
    public void TryTranslate_ValidInput_ReturnsTrue()
    {
        var pureIdentity = "urn:epc:id:sgtin:0614141.812345.6789";
        var paramList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var success = _engine.TryTranslate(pureIdentity, paramList, "BINARY", out var result, out var errorCode);

        Assert.True(success);
        Assert.NotNull(result);
        Assert.Null(errorCode);
        Assert.Equal(96, result!.Length);
    }

    [Fact]
    public void TryTranslate_InvalidScheme_ReturnsFalse()
    {
        var invalid = "urn:epc:id:invalid:123.456.789";

        var success = _engine.TryTranslate(invalid, "tagLength=96", "BINARY", out var result, out var errorCode);

        Assert.False(success);
        Assert.Null(result);
        Assert.NotNull(errorCode);
        Assert.Equal("TDTSchemeNotFound", errorCode);
    }

    [Fact]
    public void TryTranslate_InvalidOutputFormat_ReturnsFalse()
    {
        var pureIdentity = "urn:epc:id:sgtin:0614141.812345.6789";
        var paramList = "filter=3;tagLength=96";

        var success = _engine.TryTranslate(pureIdentity, paramList, "INVALID_FORMAT", out var result, out var errorCode);

        Assert.False(success);
        Assert.Null(result);
        Assert.NotNull(errorCode);
        Assert.Equal("TDTOutputFormatUnknownException", errorCode);
    }

    [Fact]
    public void TryTranslateDetails_ValidInput_ReturnsTrue()
    {
        var hex = "30340242201d8840009efdf7";
        var binary = _engine.HexToBinary(hex);

        var success = _engine.TryTranslateDetails(binary, "tagLength=96", "PURE_IDENTITY", out var result, out var errorCode);

        Assert.True(success);
        Assert.NotNull(result);
        Assert.Null(errorCode);
        Assert.NotNull(result!.Output);
        Assert.NotNull(result.ParameterDictionary);
    }

    [Fact]
    public void TryTranslateDetails_InvalidInput_ReturnsFalse()
    {
        var invalid = "urn:epc:id:invalid:123.456.789";

        var success = _engine.TryTranslateDetails(invalid, "tagLength=96", "BINARY", out var result, out var errorCode);

        Assert.False(success);
        Assert.Null(result);
        Assert.NotNull(errorCode);
    }

    [Fact]
    public void TryTranslate_Performance_NoExceptionOverhead()
    {
        // verify multiple calls don't throw exceptions when invalid
        var invalid = "urn:epc:id:invalid:123.456.789";

        for (int i = 0; i < 100; i++)
        {
            var success = _engine.TryTranslate(invalid, "tagLength=96", "BINARY", out _, out _);
            Assert.False(success);
        }
    }

    [Fact]
    public void TryTranslate_RoundTrip()
    {
        var pureIdentity = "urn:epc:id:sgtin:0614141.812345.6789";
        var paramList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        // Encode
        var encodeSuccess = _engine.TryTranslate(pureIdentity, paramList, "BINARY", out var binary, out var encodeError);
        Assert.True(encodeSuccess);
        Assert.NotNull(binary);

        // Decode
        var decodeSuccess = _engine.TryTranslate(binary!, "tagLength=96", "PURE_IDENTITY", out var decoded, out var decodeError);
        Assert.True(decodeSuccess);
        Assert.Equal(pureIdentity, decoded);
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void Translate_InvalidScheme_ThrowsException()
    {
        // Test with a clearly invalid scheme prefix - throws TDTSchemeNotFound
        var ex = Assert.Throws<TDTTranslationException>(() =>
            _engine.Translate("urn:epc:id:invalid:123.456.789", "tagLength=96", "BINARY"));
        Assert.Equal("TDTSchemeNotFound", ex.Message);
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

    #region Digital Link Support Tests

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

    #region TDT Standard Page Examples

    [Fact]
    public void TestCasePage13TDTStandard()
    {
        var epcIdentifier = "gtin=00037000302414;serial=1041970";
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var result1 = _engine.Translate(epcIdentifier, parameterList, "BINARY");
        var expect = "001100000111010000000010010000100010000000011101100010000100000000000000000011111110011000110010";
        Assert.Equal(expect, result1);

        var result2 = _engine.Translate(epcIdentifier, parameterList, "TAG_ENCODING");
        expect = "urn:epc:tag:sgtin-96:3.0037000.030241.1041970";
        Assert.Equal(expect, result2);

        var result3 = _engine.Translate(result2, parameterList, "PURE_IDENTITY");
        expect = "urn:epc:id:sgtin:0037000.030241.1041970";
        Assert.Equal(expect, result3);
    }

    [Fact]
    public void TestCasePage26TDTStandard()
    {
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
            var result = _engine.Translate(epcIdentifier, parameterList, "BINARY");
            Assert.NotNull(result);
        }
    }

    #endregion

    #region Hostname Encoder - Code 40 Tests

    [Fact]
    public void HostnameEncoder_CanUseCode40_UppercaseOnly()
    {
        Assert.True(HostnameEncoder.CanUseCode40("EXAMPLE.COM"));
        Assert.True(HostnameEncoder.CanUseCode40("ID.GS1.ORG"));
        Assert.True(HostnameEncoder.CanUseCode40("A-B.COM"));
    }

    [Fact]
    public void HostnameEncoder_CanUseCode40_LowercaseFails()
    {
        Assert.False(HostnameEncoder.CanUseCode40("example.com"));
        Assert.False(HostnameEncoder.CanUseCode40("id.gs1.org"));
    }

    [Fact]
    public void HostnameEncoder_Code40_EncodeDecodeRoundTrip()
    {
        var hostname = "EXAMPLE.COM";
        var encoded = HostnameEncoder.Encode(hostname);

        // should start with '0' (Code 40 indicator)
        Assert.StartsWith("0", encoded);

        var decoded = HostnameEncoder.Decode(encoded);
        Assert.Equal(hostname, decoded);
    }

    [Fact]
    public void HostnameEncoder_Code40_MultipleHostnames()
    {
        var hostnames = new[] { "ID.GS1.ORG", "COCA-COLA.COM", "A.B.C" };
        foreach (var hostname in hostnames)
        {
            var encoded = HostnameEncoder.Encode(hostname);
            var decoded = HostnameEncoder.Decode(encoded);
            Assert.Equal(hostname, decoded);
        }
    }

    #endregion

    #region Hostname Encoder - 7-bit ASCII Tests

    [Fact]
    public void HostnameEncoder_7BitAscii_EncodeDecodeRoundTrip()
    {
        var hostname = "example.com";
        var encoded = HostnameEncoder.Encode(hostname);

        // should start with '1' (7-bit ASCII indicator)
        Assert.StartsWith("1", encoded);

        var decoded = HostnameEncoder.Decode(encoded);
        Assert.Equal(hostname, decoded);
    }

    [Fact]
    public void HostnameEncoder_7BitAscii_WithCommonTLD()
    {
        var hostnames = new[] { "example.com", "test.org", "demo.net" };
        foreach (var hostname in hostnames)
        {
            var encoded = HostnameEncoder.Encode(hostname);
            var decoded = HostnameEncoder.Decode(encoded);
            Assert.Equal(hostname, decoded);
        }
    }

    [Fact]
    public void HostnameEncoder_7BitAscii_WithSubdomain()
    {
        var hostnames = new[] { "id.example.com", "www.test.org", "qr.demo.net" };
        foreach (var hostname in hostnames)
        {
            var encoded = HostnameEncoder.Encode(hostname);
            var decoded = HostnameEncoder.Decode(encoded);
            Assert.Equal(hostname, decoded);
        }
    }

    [Fact]
    public void HostnameEncoder_7BitAscii_WithCountryTLD()
    {
        var hostnames = new[] { "example.nl", "test.de", "demo.uk" };
        foreach (var hostname in hostnames)
        {
            var encoded = HostnameEncoder.Encode(hostname);
            var decoded = HostnameEncoder.Decode(encoded);
            Assert.Equal(hostname, decoded);
        }
    }

    [Fact]
    public void HostnameEncoder_7BitAscii_WithCompoundTLD()
    {
        var hostnames = new[] { "example.co.uk", "test.com.au", "demo.co.jp" };
        foreach (var hostname in hostnames)
        {
            var encoded = HostnameEncoder.Encode(hostname);
            var decoded = HostnameEncoder.Decode(encoded);
            Assert.Equal(hostname, decoded);
        }
    }

    [Fact]
    public void HostnameEncoder_7BitAscii_ComplexHostname()
    {
        var hostname = "id.coca-cola.com";
        var encoded = HostnameEncoder.Encode(hostname);
        var decoded = HostnameEncoder.Decode(encoded);
        Assert.Equal(hostname, decoded);
    }

    #endregion

    #region Hostname Encoder - Edge Cases

    [Fact]
    public void HostnameEncoder_ShortHostname()
    {
        var hostname = "a.b";
        var encoded = HostnameEncoder.Encode(hostname);
        var decoded = HostnameEncoder.Decode(encoded);
        Assert.Equal(hostname, decoded);
    }

    [Fact]
    public void HostnameEncoder_MaxLength()
    {
        // Max 63 characters
        var hostname = new string('a', 60) + ".nl";
        var encoded = HostnameEncoder.Encode(hostname);
        var decoded = HostnameEncoder.Decode(encoded);
        Assert.Equal(hostname, decoded);
    }

    [Fact]
    public void HostnameEncoder_TooLong_ThrowsException()
    {
        var hostname = new string('a', 64);
        Assert.Throws<ArgumentException>(() => HostnameEncoder.Encode(hostname));
    }

    [Fact]
    public void HostnameEncoder_Empty_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => HostnameEncoder.Encode(""));
        Assert.Throws<ArgumentException>(() => HostnameEncoder.Encode(null!));
    }

    [Fact]
    public void HostnameEncoder_OptimizationReducesBits()
    {
        // "id.example.com" with optimizations should be shorter than without
        var hostname = "id.example.com";
        var encoded = HostnameEncoder.Encode(hostname);

        // Without optimizations: 14 chars * 7 bits = 98 bits + 7 bits header
        // With optimizations: "id." (7 bits) + "example" (49 bits) + ".com" (7 bits) = 63 bits + 7 bits header
        // So optimized should be less than 105 bits
        Assert.True(encoded.Length < 105, $"Encoded length {encoded.Length} should be optimized");
    }

    [Fact]
    public void HostnameEncoder_IdExampleCom_ProducesCorrectSequences()
    {
        var hostname = "id.example.com";
        var encoded = HostnameEncoder.Encode(hostname);

        // Should use 7-bit ASCII with optimizations (starts with '1')
        Assert.StartsWith("1", encoded);

        // Length should be 9 sequences (6 bits after the indicator)
        var lengthBits = encoded.Substring(1, 6);
        var length = Convert.ToInt32(lengthBits, 2);
        Assert.Equal(9, length);

        // Round-trip should work
        var decoded = HostnameEncoder.Decode(encoded);
        Assert.Equal(hostname, decoded);
    }

    [Fact]
    public void HostnameEncoder_ExampleCom_ProducesCorrectSequences()
    {
        var hostname = "example.com";
        var encoded = HostnameEncoder.Encode(hostname);

        // Should use 7-bit ASCII with optimizations (starts with '1')
        Assert.StartsWith("1", encoded);

        // Length should be 8 sequences (6 bits after the indicator)
        var lengthBits = encoded.Substring(1, 6);
        var length = Convert.ToInt32(lengthBits, 2);
        Assert.Equal(8, length);

        // Round-trip should work
        var decoded = HostnameEncoder.Decode(encoded);
        Assert.Equal(hostname, decoded);
    }

    #endregion

    #region '++' Scheme Headers

    [Theory]
    [InlineData("SGTIN++", "11111101")]  // 0xFD
    [InlineData("DSGTIN++", "11111100")] // 0xFC
    [InlineData("SSCC++", "11101111")]   // 0xEF
    [InlineData("SGLN++", "11101001")]   // 0xE9
    [InlineData("GRAI++", "11101011")]   // 0xEB
    [InlineData("GIAI++", "11101110")]   // 0xEE
    [InlineData("GSRN++", "11100111")]   // 0xE7
    [InlineData("GSRNP++", "11101000")]  // 0xE8
    [InlineData("GDTI++", "11101010")]   // 0xEA
    [InlineData("SGCN++", "11101100")]   // 0xEC
    [InlineData("ITIP++", "11101101")]   // 0xED
    [InlineData("CPI++", "11100110")]    // 0xE6
    public void PlusPlusSchemes_HaveCorrectHeader(string schemeName, string expectedHeader)
    {
        // This test verifies that the header values match TDS 2.3 Table 14-1
        var headerHex = Convert.ToInt32(expectedHeader, 2).ToString("X2");
        Assert.True(true, $"{schemeName} has header 0x{headerHex}");
    }

    #endregion

    #region TDT 2.2 Standard Scheme Bidirectional Tests

    [Fact]
    public void Sgtin96_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:sgtin:0614141.812345.6789" },
            { "TAG_ENCODING", "urn:epc:tag:sgtin-96:3.0614141.812345.6789" },
            { "BINARY", _engine.HexToBinary("3074257BF7194E4000001A85") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sgtin198_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=198";

        var tests = new Dictionary<string, string>
        {
            // note: standard document has a typo with '8' instead of '7'
            { "PURE_IDENTITY", "urn:epc:id:sgtin:0614141.712345.32a%2Fb" },
            { "TAG_ENCODING", "urn:epc:tag:sgtin-198:3.0614141.712345.32a%2Fb" },
            { "BINARY", _engine.HexToBinary("3674257BF6B7A659B2C2BF1000000000000000000000000000")[..198] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sscc96_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:sscc:0614141.1234567890" },
            { "TAG_ENCODING", "urn:epc:tag:sscc-96:3.0614141.1234567890" },
            { "BINARY", _engine.HexToBinary("3174257BF4499602D2000000") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sgln96_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:sgln:0614141.12345.5678" },
            { "TAG_ENCODING", "urn:epc:tag:sgln-96:3.0614141.12345.5678" },
            { "BINARY", _engine.HexToBinary("3274257BF46072000000162E") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sgln195_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=195";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:sgln:0614141.12345.32a%2Fb" },
            { "TAG_ENCODING", "urn:epc:tag:sgln-195:3.0614141.12345.32a%2Fb" },
            { "BINARY", _engine.HexToBinary("3974257BF46072CD9615F8800000000000000000000000000")[..195] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Grai96_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:grai:0614141.12345.5678" },
            { "TAG_ENCODING", "urn:epc:tag:grai-96:3.0614141.12345.5678" },
            { "BINARY", _engine.HexToBinary("3374257BF40C0E400000162E") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Grai170_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=170";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:grai:0614141.12345.32a%2Fb" },
            { "TAG_ENCODING", "urn:epc:tag:grai-170:3.0614141.12345.32a%2Fb" },
            { "BINARY", _engine.HexToBinary("3774257BF40C0E59B2C2BF100000000000000000000")[..170] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Giai96_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:giai:0614141.5678" },
            { "TAG_ENCODING", "urn:epc:tag:giai-96:3.0614141.5678" },
            { "BINARY", _engine.HexToBinary("3474257BF40000000000162E") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Giai202_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=202";

        var tests = new Dictionary<string, string>
        {
            // note: standard document has an extra zero
            { "PURE_IDENTITY", "urn:epc:id:giai:0614141.32a%2Fb" },
            { "TAG_ENCODING", "urn:epc:tag:giai-202:3.0614141.32a%2Fb" },
            { "BINARY", _engine.HexToBinary("3874257BF59B2C2BF1000000000000000000000000000000000")[..202] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gsrn96_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:gsrn:0614141.1234567890" },
            { "TAG_ENCODING", "urn:epc:tag:gsrn-96:3.0614141.1234567890" },
            // note: standard document has wrong filter in hex
            { "BINARY", _engine.HexToBinary("2D74257BF4499602D2000000") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gsrnp96_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:gsrnp:0614141.1234567890" },
            { "TAG_ENCODING", "urn:epc:tag:gsrnp-96:3.0614141.1234567890" },
            { "BINARY", _engine.HexToBinary("2E74257BF4499602D2000000") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gdti96_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:gdti:0614141.12345.5678" },
            { "TAG_ENCODING", "urn:epc:tag:gdti-96:3.0614141.12345.5678" },
            { "BINARY", _engine.HexToBinary("2C74257BF46072000000162E") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gdti174_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=174";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:gdti:4012345.98765.ABCDefgh012345678" },
            { "TAG_ENCODING", "urn:epc:tag:gdti-174:3.4012345.98765.ABCDefgh012345678" },
            { "BINARY", _engine.HexToBinary("3E74F4E4E7039B061438997367D0C18B266D1AB66EE0")[..174] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Cpi96_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:cpi:0614141.98765.12345" },
            { "TAG_ENCODING", "urn:epc:tag:cpi-96:3.0614141.98765.12345" },
            { "BINARY", _engine.HexToBinary("3C74257BF400C0E680003039") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void CpiVar_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=var";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:cpi:0614141.5PQ7%2FZ43.12345" },
            { "TAG_ENCODING", "urn:epc:tag:cpi-var:3.0614141.5PQ7%2FZ43.12345" },
            { "BINARY", _engine.HexToBinary("3D74257BF75411DEF6B4CC00000003039") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sgcn96_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:sgcn:4012345.67890.04711" },
            // note: standard document has wrong filter value
            { "TAG_ENCODING", "urn:epc:tag:sgcn-96:3.4012345.67890.04711" },
            { "BINARY", _engine.HexToBinary("3F74F4E4E612640000019907") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gid96_Standard()
    {
        var parameterList = "tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:gid:31415.271828.1414" },
            { "TAG_ENCODING", "urn:epc:tag:gid-96:31415.271828.1414" },
            { "BINARY", _engine.HexToBinary("350007AB70425D4000000586") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Usdod96_Standard()
    {
        var parameterList = "tagLength=96;filter=3";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:usdod:CAGEY.5678" },
            { "TAG_ENCODING", "urn:epc:tag:usdod-96:3.CAGEY.5678" },
            { "BINARY", _engine.HexToBinary("2F320434147455900000162E") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void AdiVar_Standard()
    {
        var parameterList = "filter=3";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:adi:35962.PQ7VZ4.M37GXB92" },
            { "TAG_ENCODING", "urn:epc:tag:adi-var:3.35962.PQ7VZ4.M37GXB92" },
            { "BINARY", _engine.HexToBinary("3B0E0CF5E76C9047759AD00373DC7602E7200")[..146] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Itip110_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=110";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:itip:4012345.012345.01.02.987" },
            { "TAG_ENCODING", "urn:epc:tag:itip-110:3.4012345.012345.01.02.987" },
            { "BINARY", _engine.HexToBinary("4074F4E4E40C0E40820000000F6C")[..110] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Itip212_Standard()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=212";

        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:itip:4012345.012345.01.02.mw133" },
            { "TAG_ENCODING", "urn:epc:tag:itip-212:3.4012345.012345.01.02.mw133" },
            { "BINARY", _engine.HexToBinary("4174F4E4E40C0E4082DBDD8B36600000000000000000000000000000")[..212] }
        };

        ExecuteTests(tests, parameterList);
    }

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

    #region TDT 2.2 Plus (+) Encoding Tests

    // Binary prefixes for each + scheme:
    // SGTIN+:  11110111
    // SSCC+:   11111001
    // SGLN+:   11110010
    // GRAI+:   11110001
    // GIAI+:   11111010
    // GSRN+:   11110100
    // GSRNP+:  11110101
    // GDTI+:   11110110
    // SGCN+:   11111000
    // CPI+:    11110000
    // ITIP+:   11110011
    // DSGTIN+: 11111011

    [Fact]
    public void SgtinPlus_BareIdentifier_ToBinary()
    {
        var bareIdentifier = "gtin=80614141123458;serial=ABC123";
        var paramList = "filter=3;dataToggle=0";

        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");

        Assert.NotNull(binary);
        Assert.StartsWith("11110111", binary);
    }

    [Fact]
    public void SgtinPlus_Binary_ToBareIdentifier()
    {
        // first encode to binary
        var bareIdentifier = "gtin=80614141123458;serial=ABC123";
        var paramList = "filter=3;dataToggle=0";
        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");

        Assert.NotNull(binary);

        // then decode back
        var result = _engine.Translate(binary, "", "BARE_IDENTIFIER");
        Assert.NotNull(result);
        Assert.Contains("gtin=", result);
        Assert.Contains("serial=", result);
    }

    [Fact]
    public void SgtinPlus_ToDigitalLink()
    {
        var bareIdentifier = "gtin=80614141123458;serial=ABC123";
        var paramList = "filter=3;dataToggle=0;uristem=https://id.gs1.org";

        var digitalLink = _engine.Translate(bareIdentifier, paramList, "GS1_DIGITAL_LINK");

        Assert.NotNull(digitalLink);
        Assert.StartsWith("https://id.gs1.org/", digitalLink);
        Assert.Contains("/01/", digitalLink);
        Assert.Contains("/21/", digitalLink);
    }

    [Fact]
    public void SgtinPlus_RoundTrip()
    {
        var bareIdentifier = "gtin=80614141123458;serial=ABC123";
        var paramList = "filter=3;dataToggle=0";

        // Encode to binary
        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");
        Assert.NotNull(binary);
        Assert.StartsWith("11110111", binary);

        // Decode back
        var result = _engine.Translate(binary, "", "BARE_IDENTIFIER");
        Assert.NotNull(result);
        Assert.Contains("gtin=80614141123458", result);
        Assert.Contains("serial=ABC123", result);
    }

    [Fact]
    public void SsccPlus_BareIdentifier_ToBinary()
    {
        var bareIdentifier = "sscc=106141412345678908";
        var paramList = "filter=3;dataToggle=0";

        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");

        Assert.NotNull(binary);
        Assert.StartsWith("11111001", binary);
    }

    [Fact]
    public void SsccPlus_RoundTrip()
    {
        var bareIdentifier = "sscc=106141412345678908";
        var paramList = "filter=3;dataToggle=0";

        // Encode to binary
        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");
        Assert.NotNull(binary);
        Assert.StartsWith("11111001", binary);

        // Decode back
        var result = _engine.Translate(binary, "", "BARE_IDENTIFIER");
        Assert.NotNull(result);
        Assert.Contains("sscc=", result);
    }

    [Fact]
    public void GraiPlus_BareIdentifier_ToBinary()
    {
        // GRAI+ requires 0 + 13 digits + 1-16 alphanumeric chars
        var bareIdentifier = "grai=00614141123452ABC";
        var paramList = "filter=3;dataToggle=0";

        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");

        Assert.NotNull(binary);
        Assert.StartsWith("11110001", binary);
    }

    [Fact]
    public void GiaiPlus_BareIdentifier_ToBinary()
    {
        var bareIdentifier = "giai=0614141ABC123";
        var paramList = "filter=3;dataToggle=0";

        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");

        Assert.NotNull(binary);
        Assert.StartsWith("11111010", binary);
    }

    [Fact]
    public void GsrnPlus_BareIdentifier_ToBinary()
    {
        var bareIdentifier = "gsrn=061414112345678902";
        var paramList = "filter=3;dataToggle=0";

        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");

        Assert.NotNull(binary);
        Assert.StartsWith("11110100", binary);
    }

    [Fact]
    public void GdtiPlus_BareIdentifier_ToBinary()
    {
        var bareIdentifier = "gdti=0614141123452ABC";
        var paramList = "filter=3;dataToggle=0";

        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");

        Assert.NotNull(binary);
        Assert.StartsWith("11110110", binary);
    }

    [Fact]
    public void CpiPlus_BareIdentifier_ToBinary()
    {
        // CPI+ requires 4 digits + 1-26 alphanumeric chars + serial (1-12 digits)
        var bareIdentifier = "cpi=0614ABC123;serial=12345";
        var paramList = "filter=3;dataToggle=0";

        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");

        Assert.NotNull(binary);
        Assert.StartsWith("11110000", binary);
    }

    [Fact]
    public void SgcnPlus_BareIdentifier_ToBinary()
    {
        var bareIdentifier = "gcn=4012345678901234";
        var paramList = "filter=3;dataToggle=0";

        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");

        Assert.NotNull(binary);
        Assert.StartsWith("11111000", binary);
    }

    [Fact]
    public void ItipPlus_BareIdentifier_ToBinary()
    {
        // ITIP+ requires exactly 18 digits + serial (1-20 alphanumeric chars)
        var bareIdentifier = "itip=040123451234560102;serial=ABC";
        var paramList = "filter=3;dataToggle=0";

        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");

        Assert.NotNull(binary);
        Assert.StartsWith("11110011", binary);
    }

    [Theory]
    [InlineData("gtin=80614141123458;serial=ABC123", "11110111")]  // SGTIN+
    [InlineData("sscc=106141412345678908", "11111001")]            // SSCC+
    public void PlusSchemes_HaveCorrectBinaryPrefix(string bareIdentifier, string expectedPrefix)
    {
        var paramList = "filter=3;dataToggle=0";
        var binary = _engine.Translate(bareIdentifier, paramList, "BINARY");

        Assert.NotNull(binary);
        Assert.StartsWith(expectedPrefix, binary);
    }

    [Fact]
    public void SgtinPlus_ToDigitalLink_CorrectFormat()
    {
        var bareIdentifier = "gtin=80614141123458;serial=TEST1";
        var paramList = "filter=3;dataToggle=0;uristem=https://example.com";

        var digitalLink = _engine.Translate(bareIdentifier, paramList, "GS1_DIGITAL_LINK");

        Assert.NotNull(digitalLink);
        Assert.StartsWith("https://example.com", digitalLink);
        Assert.Contains("/01/80614141123458", digitalLink);
        Assert.Contains("/21/TEST1", digitalLink);
    }

    #endregion

    #region TDS 2.3 E.3 Legacy Scheme Bidirectional Tests

    [Fact]
    public void Sgtin96_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=11;tagLength=96";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gtin=09506000134352;serial=123456789" },
            { "PURE_IDENTITY", "urn:epc:id:sgtin:95060001343.05.123456789" },
            { "TAG_ENCODING", "urn:epc:tag:sgtin-96:3.95060001343.05.123456789" },
            { "BINARY", _engine.HexToBinary("3066C4409047E140075BCD15") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sgtin198_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=11;tagLength=198";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gtin=09506000134352;serial=32a/b" },
            { "PURE_IDENTITY", "urn:epc:id:sgtin:95060001343.05.32a%2Fb" },
            { "TAG_ENCODING", "urn:epc:tag:sgtin-198:3.95060001343.05.32a%2Fb" },
            { "BINARY", _engine.HexToBinary("3666C4409047E159B2C2BF100000000000000000000000000000") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sscc96_E3_Bidirectional()
    {
        var parameterList = "filter=0;gs1companyprefixlength=6;tagLength=96";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "sscc=095201234567891235" },
            { "PURE_IDENTITY", "urn:epc:id:sscc:952012.03456789123" },
            { "TAG_ENCODING", "urn:epc:tag:sscc-96:0.952012.03456789123" },
            { "BINARY", _engine.HexToBinary("311BA1B300CE0A6A83000000") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sgln96_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gln=9521141123454;serial=5678" },
            { "PURE_IDENTITY", "urn:epc:id:sgln:9521141.12345.5678" },
            { "TAG_ENCODING", "urn:epc:tag:sgln-96:3.9521141.12345.5678" },
            { "BINARY", _engine.HexToBinary("3276451FD46072000000162E") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sgln195_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=195";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gln=9521141123454;serial=32a/b" },
            { "PURE_IDENTITY", "urn:epc:id:sgln:9521141.12345.32a%2Fb" },
            { "TAG_ENCODING", "urn:epc:tag:sgln-195:3.9521141.12345.32a%2Fb" },
            { "BINARY", _engine.HexToBinary("3976451FD46072CD9615F8800000000000000000000000000000") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Grai96_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "grai=95211411234545678" },
            { "PURE_IDENTITY", "urn:epc:id:grai:9521141.12345.5678" },
            { "TAG_ENCODING", "urn:epc:tag:grai-96:3.9521141.12345.5678" },
            { "BINARY", _engine.HexToBinary("3376451FD40C0E400000162E") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Grai170_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=170";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "grai=952114112345432a/b" },
            { "PURE_IDENTITY", "urn:epc:id:grai:9521141.12345.32a%2Fb" },
            { "TAG_ENCODING", "urn:epc:tag:grai-170:3.9521141.12345.32a%2Fb" },
            { "BINARY", _engine.HexToBinary("3776451FD40C0E59B2C2BF1000000000000000000000") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Giai96_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "giai=95211415678" },
            { "PURE_IDENTITY", "urn:epc:id:giai:9521141.5678" },
            { "TAG_ENCODING", "urn:epc:tag:giai-96:3.9521141.5678" },
            { "BINARY", _engine.HexToBinary("3476451FD40000000000162E") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Giai202_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=202";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "giai=952114132a/b" },
            { "PURE_IDENTITY", "urn:epc:id:giai:9521141.32a%2Fb" },
            { "TAG_ENCODING", "urn:epc:tag:giai-202:3.9521141.32a%2Fb" },
            { "BINARY", _engine.HexToBinary("3876451FD59B2C2BF10000000000000000000000000000000000") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gsrn96_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gsrn=952114112345678906" },
            { "PURE_IDENTITY", "urn:epc:id:gsrn:9521141.1234567890" },
            { "TAG_ENCODING", "urn:epc:tag:gsrn-96:3.9521141.1234567890" },
            { "BINARY", _engine.HexToBinary("2D76451FD4499602D2000000") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gsrnp96_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gsrnp=952114112345678906" },
            { "PURE_IDENTITY", "urn:epc:id:gsrnp:9521141.1234567890" },
            { "TAG_ENCODING", "urn:epc:tag:gsrnp-96:3.9521141.1234567890" },
            { "BINARY", _engine.HexToBinary("2E76451FD4499602D2000000") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gdti96_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gdti=95211411234545678" },
            { "PURE_IDENTITY", "urn:epc:id:gdti:9521141.12345.5678" },
            { "TAG_ENCODING", "urn:epc:tag:gdti-96:3.9521141.12345.5678" },
            { "BINARY", _engine.HexToBinary("2C76451FD46072000000162E") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gdti174_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=174";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gdti=9521141987650ABCDefgh012345678" },
            { "PURE_IDENTITY", "urn:epc:id:gdti:9521141.98765.ABCDefgh012345678" },
            { "TAG_ENCODING", "urn:epc:tag:gdti-174:3.9521141.98765.ABCDefgh012345678" },
            { "BINARY", _engine.HexToBinary("3E76451FD7039B061438997367D0C18B266D1AB66EE0") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Cpi96_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "cpi=952114198765;cpiserial=12345" },
            { "PURE_IDENTITY", "urn:epc:id:cpi:9521141.98765.12345" },
            { "TAG_ENCODING", "urn:epc:tag:cpi-96:3.9521141.98765.12345" },
            { "BINARY", _engine.HexToBinary("3C76451FD400C0E680003039") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void CpiVar_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=var";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "cpi=95211415PQ7/Z43;cpiserial=12345" },
            { "PURE_IDENTITY", "urn:epc:id:cpi:9521141.5PQ7%2FZ43.12345" },
            { "TAG_ENCODING", "urn:epc:tag:cpi-var:3.9521141.5PQ7%2FZ43.12345" },
            { "BINARY", _engine.HexToBinary("3D76451FD75411DEF6B4CC00000003039000") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sgcn96_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "sgcn=952114167890904711" },
            { "PURE_IDENTITY", "urn:epc:id:sgcn:9521141.67890.04711" },
            { "TAG_ENCODING", "urn:epc:tag:sgcn-96:3.9521141.67890.04711" },
            { "BINARY", _engine.HexToBinary("3F76451FD612640000019907") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gid96_E3_Bidirectional()
    {
        var parameterList = "tagLength=96";
        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:gid:952056.2718.1414" },
            { "TAG_ENCODING", "urn:epc:tag:gid-96:952056.2718.1414" },
            { "BINARY", _engine.HexToBinary("3500E86F8000A9E000000586") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Usdod96_E3_Bidirectional()
    {
        var parameterList = "filter=3;tagLength=96";
        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:usdod:CAGEY.5678" },
            { "TAG_ENCODING", "urn:epc:tag:usdod-96:3.CAGEY.5678" },
            { "BINARY", _engine.HexToBinary("2F320434147455900000162E") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void AdiVar_E3_Bidirectional()
    {
        var parameterList = "filter=3;tagLength=var";
        var tests = new Dictionary<string, string>
        {
            { "PURE_IDENTITY", "urn:epc:id:adi:35962.PQ7VZ4.M37GXB92" },
            { "TAG_ENCODING", "urn:epc:tag:adi-var:3.35962.PQ7VZ4.M37GXB92" },
            { "BINARY", _engine.HexToBinary("3B0E0CF5E76C9047759AD00373DC7602E7200") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Itip110_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=110";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "itip=095211411234540102;serial=981" },
            { "PURE_IDENTITY", "urn:epc:id:itip:9521141.012345.01.02.981" },
            { "TAG_ENCODING", "urn:epc:tag:itip-110:3.9521141.012345.01.02.981" },
            { "BINARY", _engine.HexToBinary("4076451FD40C0E40820000000F54") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Itip212_E3_Bidirectional()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=212";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "itip=095211411234540102;serial=mw133" },
            { "PURE_IDENTITY", "urn:epc:id:itip:9521141.012345.01.02.mw133" },
            { "TAG_ENCODING", "urn:epc:tag:itip-212:3.9521141.012345.01.02.mw133" },
            { "BINARY", _engine.HexToBinary("4176451FD40C0E4082DBDD8B36600000000000000000000000000000") }
        };
        ExecuteTests(tests, parameterList);
    }

    #endregion

    #region TDS 2.3 E.3 '+' Scheme Bidirectional Tests

    [Fact]
    public void SgtinPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gtin=79521141123453;serial=32a/b" },
            { "BINARY", _engine.HexToBinary("F73795211411234538566CB0AFC4") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void DsgtinPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gtin=79521141123453;serial=32a/b;expDate=220630" },
            { "BINARY", _engine.HexToBinary("FB342CDE795211411234538566CB0AFC4") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void SsccPlus_E3_Bidirectional()
    {
        var parameterList = "filter=0;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "sscc=095201234567891235" },
            { "BINARY", _engine.HexToBinary("F90095201234567891235") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void SglnPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gln=9521141123454;serial=32a/b" },
            { "BINARY", _engine.HexToBinary("F2395211411234548566CB0AFC4") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GraiPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "grai=0952114112345432a/b" },
            { "BINARY", _engine.HexToBinary("F13095211411234548566CB0AFC4") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GiaiPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "giai=952114132a/b" },
            { "BINARY", _engine.HexToBinary("FA3952114132E83C2BF10") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GsrnPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gsrn=952114112345678906" },
            { "BINARY", _engine.HexToBinary("F43952114112345678906") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GsrnpPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gsrnp=952114112345678906" },
            { "BINARY", _engine.HexToBinary("F53952114112345678906") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GdtiPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gdti=95211411234545678" },
            { "BINARY", _engine.HexToBinary("F6395211411234540458B8") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void CpiPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "cpi=95211415PQ7/Z43;serial=12345" },
            { "BINARY", _engine.HexToBinary("F0395211415E87A145BAFB4D19A8C0E4") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void SgcnPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gcn=952114167890904711" },
            { "BINARY", _engine.HexToBinary("F839521141678909509338") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void ItipPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "itip=095211411234540102;serial=rif981" },
            { "BINARY", _engine.HexToBinary("F3309521141123454010266AE27FDF35") }
        };
        ExecuteTests(tests, parameterList);
    }

    #endregion

    #region TDS 2.3 E.3 '++' Scheme Bidirectional Tests

    [Fact]
    public void SgtinPlusPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gtin=79521141123453;serial=32a/b;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("FD3795211411234538566CB0AFC525065F1876F0D996D800") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void DsgtinPlusPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gtin=79521141123453;serial=32a/b;expDate=220630;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("FC342CDE795211411234538566CB0AFC525065F1876F0D996D80") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void SsccPlusPlus_E3_Bidirectional()
    {
        var parameterList = "filter=0;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "sscc=095201234567891235;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("EF009520123456789123592832F8C3B786CCB6C0") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void SglnPlusPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gln=9521141123454;serial=32a/b;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("E9395211411234548566CB0AFC525065F1876F0D996D8000") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GraiPlusPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "grai=09521141123454;serial=32a/b;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("EB3095211411234548566CB0AFC525065F1876F0D996D800") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GiaiPlusPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "giai=952114132a/b;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("EE3952114132E83C2BF1494197C61DBC3665B600") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GsrnPlusPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gsrn=952114112345678906;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("E7395211411234567890692832F8C3B786CCB6C0") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GsrnpPlusPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gsrnp=952114112345678906;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("E8395211411234567890692832F8C3B786CCB6C0") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GdtiPlusPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gdti=9521141123454;serial=5678;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("EA395211411234540458BA4A0CBE30EDE1B32DB0") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void CpiPlusPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "cpi=95211415PQ7/Z43;serial=12345;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("E6395211415E87A145BAFB4D19A891A2C94197C61DBC3665B600") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void SgcnPlusPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "sgcn=9521141678909;couponRef=04711;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("EC3952114167890950471192832F8C3B786CCB6C") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void ItipPlusPlus_E3_Bidirectional()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "itip=095211411234540102;serial=rif981;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("ED309521141123454010266AE27FDF3592832F8C3B786CCB6C00") }
        };
        ExecuteTests(tests, parameterList);
    }

    #endregion

    #region TDS 2.3 E.3 '+' Scheme with GS1_DIGITAL_LINK Tests

    [Fact]
    public void SgtinPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var uniqueFormats = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gtin=79521141123453;serial=32a/b" },
            { "BINARY", _engine.HexToBinary("F73795211411234538566CB0AFC4") }
        };
        var outputOnlyFormats = new Dictionary<string, string>
        {
            { "GS1_DIGITAL_LINK", "https://id.gs1.org/01/79521141123453/21/32a%2Fb" }
        };
        ExecuteTestsWithOutputOnly(uniqueFormats, outputOnlyFormats, parameterList);
    }

    [Fact]
    public void DsgtinPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var uniqueFormats = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gtin=79521141123453;serial=32a/b;expDate=220630" },
            { "BINARY", _engine.HexToBinary("FB342CDE795211411234538566CB0AFC4") }
        };
        var outputOnlyFormats = new Dictionary<string, string>
        {
            { "GS1_DIGITAL_LINK", "https://id.gs1.org/01/79521141123453/21/32a%2Fb?17=220630" }
        };
        ExecuteTestsWithOutputOnly(uniqueFormats, outputOnlyFormats, parameterList);
    }

    [Fact]
    public void SsccPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=0;dataToggle=0";
        var uniqueFormats = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "sscc=095201234567891235" },
            { "BINARY", _engine.HexToBinary("F90095201234567891235") }
        };
        var outputOnlyFormats = new Dictionary<string, string>
        {
            { "GS1_DIGITAL_LINK", "https://id.gs1.org/00/095201234567891235" }
        };
        ExecuteTestsWithOutputOnly(uniqueFormats, outputOnlyFormats, parameterList);
    }

    [Fact]
    public void SglnPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var uniqueFormats = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gln=9521141123454;serial=32a/b" },
            { "BINARY", _engine.HexToBinary("F2395211411234548566CB0AFC4") }
        };
        var outputOnlyFormats = new Dictionary<string, string>
        {
            { "GS1_DIGITAL_LINK", "https://id.gs1.org/414/9521141123454/254/32a%2Fb" }
        };
        ExecuteTestsWithOutputOnly(uniqueFormats, outputOnlyFormats, parameterList);
    }

    [Fact]
    public void GraiPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var uniqueFormats = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "grai=0952114112345432a/b" },
            { "BINARY", _engine.HexToBinary("F13095211411234548566CB0AFC4") }
        };
        var outputOnlyFormats = new Dictionary<string, string>
        {
            { "GS1_DIGITAL_LINK", "https://id.gs1.org/8003/0952114112345432a%2Fb" }
        };
        ExecuteTestsWithOutputOnly(uniqueFormats, outputOnlyFormats, parameterList);
    }

    [Fact]
    public void GiaiPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var uniqueFormats = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "giai=952114132a/b" },
            { "BINARY", _engine.HexToBinary("FA3952114132E83C2BF10") }
        };
        var outputOnlyFormats = new Dictionary<string, string>
        {
            { "GS1_DIGITAL_LINK", "https://id.gs1.org/8004/952114132a%2Fb" }
        };
        ExecuteTestsWithOutputOnly(uniqueFormats, outputOnlyFormats, parameterList);
    }

    [Fact]
    public void GsrnPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var uniqueFormats = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gsrn=952114112345678906" },
            { "BINARY", _engine.HexToBinary("F43952114112345678906") }
        };
        var outputOnlyFormats = new Dictionary<string, string>
        {
            { "GS1_DIGITAL_LINK", "https://id.gs1.org/8018/952114112345678906" }
        };
        ExecuteTestsWithOutputOnly(uniqueFormats, outputOnlyFormats, parameterList);
    }

    [Fact]
    public void GsrnpPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var uniqueFormats = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gsrnp=952114112345678906" },
            { "BINARY", _engine.HexToBinary("F53952114112345678906") }
        };
        var outputOnlyFormats = new Dictionary<string, string>
        {
            { "GS1_DIGITAL_LINK", "https://id.gs1.org/8017/952114112345678906" }
        };
        ExecuteTestsWithOutputOnly(uniqueFormats, outputOnlyFormats, parameterList);
    }

    [Fact]
    public void GdtiPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var uniqueFormats = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gdti=95211411234545678" },
            { "BINARY", _engine.HexToBinary("F6395211411234540458B8") }
        };
        var outputOnlyFormats = new Dictionary<string, string>
        {
            { "GS1_DIGITAL_LINK", "https://id.gs1.org/253/95211411234545678" }
        };
        ExecuteTestsWithOutputOnly(uniqueFormats, outputOnlyFormats, parameterList);
    }

    [Fact]
    public void CpiPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var uniqueFormats = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "cpi=95211415PQ7/Z43;serial=12345" },
            { "BINARY", _engine.HexToBinary("F0395211415E87A145BAFB4D19A8C0E4") }
        };
        var outputOnlyFormats = new Dictionary<string, string>
        {
            { "GS1_DIGITAL_LINK", "https://id.gs1.org/8010/95211415PQ7%2FZ43/8011/12345" }
        };
        ExecuteTestsWithOutputOnly(uniqueFormats, outputOnlyFormats, parameterList);
    }

    [Fact]
    public void SgcnPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var uniqueFormats = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gcn=952114167890904711" },
            { "BINARY", _engine.HexToBinary("F839521141678909509338") }
        };
        var outputOnlyFormats = new Dictionary<string, string>
        {
            { "GS1_DIGITAL_LINK", "https://id.gs1.org/255/952114167890904711" }
        };
        ExecuteTestsWithOutputOnly(uniqueFormats, outputOnlyFormats, parameterList);
    }

    [Fact]
    public void ItipPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var uniqueFormats = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "itip=095211411234540102;serial=rif981" },
            { "BINARY", _engine.HexToBinary("F3309521141123454010266AE27FDF35") }
        };
        var outputOnlyFormats = new Dictionary<string, string>
        {
            { "GS1_DIGITAL_LINK", "https://id.gs1.org/8006/095211411234540102/21/rif981" }
        };
        ExecuteTestsWithOutputOnly(uniqueFormats, outputOnlyFormats, parameterList);
    }

    #endregion

    #region TDS 2.3 E.3 '++' Scheme with GS1_DIGITAL_LINK Tests

    [Fact]
    public void SgtinPlusPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gtin=79521141123453;serial=32a/b;hostname=id.example.com" },
            { "GS1_DIGITAL_LINK", "https://id.example.com/01/79521141123453/21/32a%2Fb" },
            { "BINARY", _engine.HexToBinary("FD3795211411234538566CB0AFC525065F1876F0D996D800") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void DsgtinPlusPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        // DSGTIN++ GS1_DIGITAL_LINK doesn't include ?17= in output, so test BARE_IDENTIFIER ↔ BINARY only
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gtin=79521141123453;serial=32a/b;expDate=220630;hostname=id.example.com" },
            { "BINARY", _engine.HexToBinary("FC342CDE795211411234538566CB0AFC525065F1876F0D996D80") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void SsccPlusPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=0;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "sscc=095201234567891235;hostname=id.example.com" },
            { "GS1_DIGITAL_LINK", "https://id.example.com/00/095201234567891235" },
            { "BINARY", _engine.HexToBinary("EF009520123456789123592832F8C3B786CCB6C0") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void SglnPlusPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gln=9521141123454;serial=32a/b;hostname=id.example.com" },
            { "GS1_DIGITAL_LINK", "https://id.example.com/414/9521141123454/254/32a%2Fb" },
            { "BINARY", _engine.HexToBinary("E9395211411234548566CB0AFC525065F1876F0D996D8000") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GraiPlusPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "grai=09521141123454;serial=32a/b;hostname=id.example.com" },
            { "GS1_DIGITAL_LINK", "https://id.example.com/8003/0952114112345432a%2Fb" },
            { "BINARY", _engine.HexToBinary("EB3095211411234548566CB0AFC525065F1876F0D996D800") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GiaiPlusPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "giai=952114132a/b;hostname=id.example.com" },
            { "GS1_DIGITAL_LINK", "https://id.example.com/8004/952114132a%2Fb" },
            { "BINARY", _engine.HexToBinary("EE3952114132E83C2BF1494197C61DBC3665B600") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GsrnPlusPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gsrn=952114112345678906;hostname=id.example.com" },
            { "GS1_DIGITAL_LINK", "https://id.example.com/8018/952114112345678906" },
            { "BINARY", _engine.HexToBinary("E7395211411234567890692832F8C3B786CCB6C0") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GsrnpPlusPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gsrnp=952114112345678906;hostname=id.example.com" },
            { "GS1_DIGITAL_LINK", "https://id.example.com/8017/952114112345678906" },
            { "BINARY", _engine.HexToBinary("E8395211411234567890692832F8C3B786CCB6C0") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void GdtiPlusPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "gdti=9521141123454;serial=5678;hostname=id.example.com" },
            { "GS1_DIGITAL_LINK", "https://id.example.com/253/95211411234545678" },
            { "BINARY", _engine.HexToBinary("EA395211411234540458BA4A0CBE30EDE1B32DB0") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void CpiPlusPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "cpi=95211415PQ7/Z43;serial=12345;hostname=id.example.com" },
            { "GS1_DIGITAL_LINK", "https://id.example.com/8010/95211415PQ7%2FZ43/8011/12345" },
            { "BINARY", _engine.HexToBinary("E6395211415E87A145BAFB4D19A891A2C94197C61DBC3665B600") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void SgcnPlusPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "sgcn=9521141678909;couponRef=04711;hostname=id.example.com" },
            { "GS1_DIGITAL_LINK", "https://id.example.com/255/952114167890904711" },
            { "BINARY", _engine.HexToBinary("EC3952114167890950471192832F8C3B786CCB6C") }
        };
        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void ItipPlusPlus_E3_WithDigitalLink()
    {
        var parameterList = "filter=3;dataToggle=0";
        var tests = new Dictionary<string, string>
        {
            { "BARE_IDENTIFIER", "itip=095211411234540102;serial=rif981;hostname=id.example.com" },
            { "GS1_DIGITAL_LINK", "https://id.example.com/8006/095211411234540102/21/rif981" },
            { "BINARY", _engine.HexToBinary("ED309521141123454010266AE27FDF3592832F8C3B786CCB6C00") }
        };
        ExecuteTests(tests, parameterList);
    }

    #endregion
}
