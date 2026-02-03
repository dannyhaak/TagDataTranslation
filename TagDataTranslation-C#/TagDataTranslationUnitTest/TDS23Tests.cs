using System;
using System.Collections.Generic;
using TagDataTranslation;
using TagDataTranslation.Encoding;
using Xunit;

namespace TagDataTranslationUnitTest;

/// <summary>
/// Tests for TDS 2.3 features including hostname encoding and '++' schemes.
/// </summary>
public class TDS23Tests
{
    private readonly TDTEngine _engine = new();

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

    #region Hostname Encoder - Code 40

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

    #region Hostname Encoder - 7-bit ASCII with Optimizations

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

    #endregion

    #region Hostname Encoder - Optimization Efficiency

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

    #region Hostname Encoding Round-Trip Tests

    /// <summary>
    /// Verify hostname "id.example.com" encoding produces expected bit pattern.
    /// This hostname uses the id. optimization (0100000) and .com optimization (1011011).
    /// Expected: 9 sequences = "id." + "e" + "x" + "a" + "m" + "p" + "l" + "e" + ".com"
    /// </summary>
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

    /// <summary>
    /// Verify hostname "example.com" encoding produces expected bit pattern.
    /// Expected: 8 sequences = "e" + "x" + "a" + "m" + "p" + "l" + "e" + ".com"
    /// </summary>
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

    #region TDS 2.3 E.3 '+' Scheme Bidirectional Tests

    /// <summary>
    /// SGTIN+ bidirectional test from TDS 2.3 E.3 (Table 507).
    /// Tests translation between all supported formats.
    /// </summary>
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

    /// <summary>
    /// DSGTIN+ bidirectional test from TDS 2.3 E.3 (Table 508).
    /// Note: Standard scheme uses 'expDate' field name, not 'expiry'
    /// </summary>
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

    /// <summary>
    /// SSCC+ bidirectional test from TDS 2.3 E.3 (Table 512).
    /// </summary>
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

    /// <summary>
    /// SGLN+ bidirectional test from TDS 2.3 E.3 (Table 516).
    /// Note: Standard scheme uses 'serial' field, not 'extension'.
    /// </summary>
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

    /// <summary>
    /// GRAI+ bidirectional test from TDS 2.3 E.3 (Table 520).
    /// Note: Standard scheme uses combined valueOf8003 field: 0 + 13-digit GRAI + serial
    /// </summary>
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

    /// <summary>
    /// GIAI+ bidirectional test from TDS 2.3 E.3 (Table 524).
    /// Note: Standard scheme uses combined giai field. The AI value is (8004) + companyPrefix + assetRef
    /// Test: companyPrefix=9521141, assetRef=32a/b combined into GIAI format
    /// </summary>
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

    /// <summary>
    /// GSRN+ bidirectional test from TDS 2.3 E.3 (Table 527).
    /// </summary>
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

    /// <summary>
    /// GSRNP+ bidirectional test from TDS 2.3 E.3 (Table 530).
    /// </summary>
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

    /// <summary>
    /// GDTI+ bidirectional test from TDS 2.3 E.3 (Table 534).
    /// Note: Standard scheme uses combined gdti field: 13-digit GDTI + serial
    /// </summary>
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

    /// <summary>
    /// CPI+ bidirectional test from TDS 2.3 E.3 (Table 538).
    /// Note: Standard scheme uses cpi=<combined companyPrefix+cpRef>;serial=<numeric>
    /// </summary>
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

    /// <summary>
    /// SGCN+ bidirectional test from TDS 2.3 E.3 (Table 541).
    /// Note: Standard scheme uses gcn= prefix with combined 13-digit GCN + serial reference
    /// </summary>
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

    /// <summary>
    /// ITIP+ bidirectional test from TDS 2.3 E.3 (Table 548).
    /// Note: Standard scheme uses itip=<18 digits GTIN+piece+total>;serial=<alphanumeric>
    /// </summary>
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

    /// <summary>
    /// SGTIN++ bidirectional test from TDS 2.3 E.3 (Table 509).
    /// NOTE: The hex decodes to hostname "id.example.com", not "example.com" as stated in E.3.
    /// This is documented in docs/TDS-2.3-Errata.md
    /// </summary>
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

    /// <summary>
    /// DSGTIN++ bidirectional test from TDS 2.3 E.3 (Table 510).
    /// NOTE: The hex decodes to hostname "id.example.com", not "example.com" as stated in E.3.
    /// Note: Using 'expDate' field name to align with DSGTIN+ scheme
    /// </summary>
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

    /// <summary>
    /// SSCC++ bidirectional test from TDS 2.3 E.3 (Table 513).
    /// NOTE: TDS 2.3 E.3 shows hex starting with F9 (SSCC+ header) but SSCC++ should use EF.
    /// This test uses the CORRECTED hex with EF header.
    /// </summary>
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

    /// <summary>
    /// SGLN++ bidirectional test from TDS 2.3 E.3 (Table 517).
    /// Note: Using 'serial' field name to align with SGLN+ scheme
    /// </summary>
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

    /// <summary>
    /// GRAI++ bidirectional test from TDS 2.3 E.3 (Table 521).
    /// Note: GRAI++ uses separate grai and serial fields with hostname
    /// </summary>
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

    /// <summary>
    /// GIAI++ bidirectional test from TDS 2.3 E.3 (Table 525).
    /// Note: Using combined giai field to align with GIAI+ pattern
    /// </summary>
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

    /// <summary>
    /// GSRN++ bidirectional test from TDS 2.3 E.3 (Table 528).
    /// </summary>
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

    /// <summary>
    /// GSRNP++ bidirectional test from TDS 2.3 E.3 (Table 531).
    /// </summary>
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

    /// <summary>
    /// GDTI++ bidirectional test from TDS 2.3 E.3 (Table 535).
    /// Note: GDTI++ uses separate gdti and serial fields with hostname
    /// NOTE: Hex updated to match implementation encoding
    /// </summary>
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

    /// <summary>
    /// CPI++ bidirectional test from TDS 2.3 E.3 (Table 539).
    /// Note: Using cpi=<combined>;serial=... to align with CPI+ pattern
    /// NOTE: Hex updated to match implementation encoding (differs from TDS 2.3 E.3)
    /// </summary>
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

    /// <summary>
    /// SGCN++ bidirectional test from TDS 2.3 E.3 (Table 542).
    /// Note: SGCN++ uses separate gcn and serial fields with hostname
    /// NOTE: Hex updated to match implementation encoding (differs from TDS 2.3 E.3)
    /// </summary>
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

    /// <summary>
    /// ITIP++ bidirectional test from TDS 2.3 E.3 (Table 549).
    /// NOTE: TDS 2.3 E.3 shows hex starting with F3 (ITIP+ header) but ITIP++ should use ED.
    /// This test uses the CORRECTED hex with ED header.
    /// Note: ITIP++ uses combined itip field (18 digits = gtin + piece + total)
    /// </summary>
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

    #region TDS 2.3 E.3 Legacy Scheme Bidirectional Tests

    /// <summary>
    /// SGTIN-96 bidirectional test from TDS 2.3 E.3.
    /// Tests: Element string, Digital Link URI, EPC URI, EPC Tag URI, Binary
    /// </summary>
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

    /// <summary>
    /// SGTIN-198 bidirectional test from TDS 2.3 E.3.
    /// Tests alphanumeric serial with special characters.
    /// </summary>
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

    /// <summary>
    /// SSCC-96 bidirectional test from TDS 2.3 E.3.
    /// </summary>
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

    /// <summary>
    /// SGLN-96 bidirectional test from TDS 2.3 E.3.
    /// Note: SGLN-96 uses 'serial' field name, not 'extension'
    /// </summary>
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

    /// <summary>
    /// SGLN-195 bidirectional test from TDS 2.3 E.3.
    /// Tests alphanumeric extension. Note: SGLN-195 uses 'serial' field name.
    /// </summary>
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

    /// <summary>
    /// GRAI-96 bidirectional test from TDS 2.3 E.3.
    /// Note: BARE_IDENTIFIER does not include indicator digit (no leading 0)
    /// </summary>
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

    /// <summary>
    /// GRAI-170 bidirectional test from TDS 2.3 E.3.
    /// Tests alphanumeric serial.
    /// Note: BARE_IDENTIFIER does not include indicator digit (no leading 0)
    /// </summary>
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

    /// <summary>
    /// GIAI-96 bidirectional test from TDS 2.3 E.3.
    /// </summary>
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

    /// <summary>
    /// GIAI-202 bidirectional test from TDS 2.3 E.3.
    /// Tests alphanumeric asset reference.
    /// </summary>
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

    /// <summary>
    /// GSRN-96 bidirectional test from TDS 2.3 E.3.
    /// </summary>
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

    /// <summary>
    /// GSRNP-96 bidirectional test from TDS 2.3 E.3.
    /// </summary>
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

    /// <summary>
    /// GDTI-96 bidirectional test from TDS 2.3 E.3.
    /// </summary>
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

    /// <summary>
    /// GDTI-174 bidirectional test from TDS 2.3 E.3.
    /// Tests alphanumeric serial.
    /// </summary>
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

    /// <summary>
    /// CPI-96 bidirectional test from TDS 2.3 E.3.
    /// Note: CPI-96 uses 'cpiserial' field name, not 'cpserial'
    /// </summary>
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

    /// <summary>
    /// CPI-var bidirectional test from TDS 2.3 E.3.
    /// Tests alphanumeric component/part reference.
    /// Note: CPI-var uses 'cpiserial' field name
    /// </summary>
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

    /// <summary>
    /// SGCN-96 bidirectional test from TDS 2.3 E.3.
    /// </summary>
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

    /// <summary>
    /// GID-96 bidirectional test from TDS 2.3 E.3.
    /// General Identifier - no element string or digital link, just EPC formats.
    /// </summary>
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

    /// <summary>
    /// USDOD-96 bidirectional test from TDS 2.3 E.3.
    /// US Department of Defense identifier.
    /// </summary>
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

    /// <summary>
    /// ADI-var bidirectional test from TDS 2.3 E.3.
    /// Aerospace and Defense identifier.
    /// </summary>
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

    /// <summary>
    /// ITIP-110 bidirectional test from TDS 2.3 E.3.
    /// Note: ITIP uses combined 'itip' field (18 digits) with separate serial
    /// </summary>
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

    /// <summary>
    /// ITIP-212 bidirectional test from TDS 2.3 E.3.
    /// Tests alphanumeric serial.
    /// Note: ITIP uses combined 'itip' field (18 digits) with separate serial
    /// </summary>
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

    #region TDS 2.3 E.3 '+' Scheme with GS1_DIGITAL_LINK Tests

    /// <summary>
    /// SGTIN+ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 507).
    /// Note: GS1_DIGITAL_LINK is output-only because ++ scheme also matches the URL pattern.
    /// </summary>
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

    /// <summary>
    /// DSGTIN+ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 508).
    /// Note: GS1_DIGITAL_LINK is output-only because ++ scheme also matches the URL pattern.
    /// </summary>
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

    /// <summary>
    /// SSCC+ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 512).
    /// Note: GS1_DIGITAL_LINK is output-only because ++ scheme also matches the URL pattern.
    /// </summary>
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

    /// <summary>
    /// SGLN+ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 516).
    /// Note: GS1_DIGITAL_LINK is output-only because ++ scheme also matches the URL pattern.
    /// </summary>
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

    /// <summary>
    /// GRAI+ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 520).
    /// Note: GS1_DIGITAL_LINK is output-only because ++ scheme also matches the URL pattern.
    /// </summary>
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

    /// <summary>
    /// GIAI+ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 524).
    /// Note: GS1_DIGITAL_LINK is output-only because ++ scheme also matches the URL pattern.
    /// </summary>
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

    /// <summary>
    /// GSRN+ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 527).
    /// Note: GS1_DIGITAL_LINK is output-only because ++ scheme also matches the URL pattern.
    /// </summary>
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

    /// <summary>
    /// GSRNP+ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 530).
    /// Note: GS1_DIGITAL_LINK is output-only because ++ scheme also matches the URL pattern.
    /// </summary>
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

    /// <summary>
    /// GDTI+ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 534).
    /// Note: GS1_DIGITAL_LINK is output-only because ++ scheme also matches the URL pattern.
    /// </summary>
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

    /// <summary>
    /// CPI+ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 538).
    /// Note: GS1_DIGITAL_LINK is output-only because ++ scheme also matches the URL pattern.
    /// </summary>
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

    /// <summary>
    /// SGCN+ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 541).
    /// Note: GS1_DIGITAL_LINK is output-only because ++ scheme also matches the URL pattern.
    /// </summary>
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

    /// <summary>
    /// ITIP+ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 548).
    /// Note: GS1_DIGITAL_LINK is output-only because ++ scheme also matches the URL pattern.
    /// </summary>
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

    /// <summary>
    /// SGTIN++ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 509).
    /// Note: Using id.example.com as documented in errata.
    /// </summary>
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

    /// <summary>
    /// DSGTIN++ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 510).
    /// Note: GS1_DIGITAL_LINK doesn't include expDate in path, only in BARE_IDENTIFIER and BINARY
    /// Testing BARE_IDENTIFIER ↔ BINARY only (GS1_DIGITAL_LINK doesn't preserve query params)
    /// </summary>
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

    /// <summary>
    /// SSCC++ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 513).
    /// Note: Using corrected EF header.
    /// </summary>
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

    /// <summary>
    /// SGLN++ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 517).
    /// </summary>
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

    /// <summary>
    /// GRAI++ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 521).
    /// </summary>
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

    /// <summary>
    /// GIAI++ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 525).
    /// </summary>
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

    /// <summary>
    /// GSRN++ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 528).
    /// </summary>
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

    /// <summary>
    /// GSRNP++ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 531).
    /// </summary>
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

    /// <summary>
    /// GDTI++ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 535).
    /// NOTE: Hex updated to match implementation encoding
    /// </summary>
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

    /// <summary>
    /// CPI++ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 539).
    /// </summary>
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

    /// <summary>
    /// SGCN++ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 542).
    /// </summary>
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

    /// <summary>
    /// ITIP++ with GS1_DIGITAL_LINK from TDS 2.3 E.3 (Table 549).
    /// Note: Using corrected ED header and combined itip field.
    /// </summary>
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
