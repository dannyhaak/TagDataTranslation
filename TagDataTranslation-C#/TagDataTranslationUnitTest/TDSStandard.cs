using System.Collections.Generic;
using TagDataTranslation;
using Xunit;

namespace TagDataTranslationUnitTest;

/// <summary>
/// Tests based on TDS (Tag Data Standard) specification examples.
/// </summary>
public class TDSStandard
{
    private readonly TDTEngine _engine = new();

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
                Assert.Equal(expect, result);
            }
        }
    }

    [Fact]
    public void Sgtin96()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(01)80614141123458(21)6789" },
            { "PURE_IDENTITY", "urn:epc:id:sgtin:0614141.812345.6789" },
            { "TAG_ENCODING", "urn:epc:tag:sgtin-96:3.0614141.812345.6789" },
            { "BINARY", _engine.HexToBinary("3074257BF7194E4000001A85") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sgtin198()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=198";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(01)70614141123451(21)32a/b" },
            // note: standard document has a typo with '8' instead of '7'
            { "PURE_IDENTITY", "urn:epc:id:sgtin:0614141.712345.32a%2Fb" },
            { "TAG_ENCODING", "urn:epc:tag:sgtin-198:3.0614141.712345.32a%2Fb" },
            { "BINARY", _engine.HexToBinary("3674257BF6B7A659B2C2BF1000000000000000000000000000")[..198] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sscc96()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(00)106141412345678908" },
            { "PURE_IDENTITY", "urn:epc:id:sscc:0614141.1234567890" },
            { "TAG_ENCODING", "urn:epc:tag:sscc-96:3.0614141.1234567890" },
            { "BINARY", _engine.HexToBinary("3174257BF4499602D2000000") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sgln96()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(414)0614141123452(254)5678" },
            { "PURE_IDENTITY", "urn:epc:id:sgln:0614141.12345.5678" },
            { "TAG_ENCODING", "urn:epc:tag:sgln-96:3.0614141.12345.5678" },
            { "BINARY", _engine.HexToBinary("3274257BF46072000000162E") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sgln195()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=195";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(414)0614141123452(254)32a/b" },
            { "PURE_IDENTITY", "urn:epc:id:sgln:0614141.12345.32a%2Fb" },
            { "TAG_ENCODING", "urn:epc:tag:sgln-195:3.0614141.12345.32a%2Fb" },
            { "BINARY", _engine.HexToBinary("3974257BF46072CD9615F8800000000000000000000000000")[..195] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Grai96()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(8003)006141411234525678" },
            { "PURE_IDENTITY", "urn:epc:id:grai:0614141.12345.5678" },
            { "TAG_ENCODING", "urn:epc:tag:grai-96:3.0614141.12345.5678" },
            { "BINARY", _engine.HexToBinary("3374257BF40C0E400000162E") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Grai170()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=170";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(8003)0061414112345232a/b" },
            { "PURE_IDENTITY", "urn:epc:id:grai:0614141.12345.32a%2Fb" },
            { "TAG_ENCODING", "urn:epc:tag:grai-170:3.0614141.12345.32a%2Fb" },
            { "BINARY", _engine.HexToBinary("3774257BF40C0E59B2C2BF100000000000000000000")[..170] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Giai96()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(8004)06141415678" },
            { "PURE_IDENTITY", "urn:epc:id:giai:0614141.5678" },
            { "TAG_ENCODING", "urn:epc:tag:giai-96:3.0614141.5678" },
            { "BINARY", _engine.HexToBinary("3474257BF40000000000162E") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Giai202()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=202";

        var tests = new Dictionary<string, string>
        {
            // note: standard document has an extra zero
            { "LEGACY_AI", "(8004)061414132a/b" },
            { "PURE_IDENTITY", "urn:epc:id:giai:0614141.32a%2Fb" },
            { "TAG_ENCODING", "urn:epc:tag:giai-202:3.0614141.32a%2Fb" },
            { "BINARY", _engine.HexToBinary("3874257BF59B2C2BF1000000000000000000000000000000000")[..202] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gsrn96()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(8018)061414112345678902" },
            { "PURE_IDENTITY", "urn:epc:id:gsrn:0614141.1234567890" },
            { "TAG_ENCODING", "urn:epc:tag:gsrn-96:3.0614141.1234567890" },
            // note: standard document has wrong filter in hex
            { "BINARY", _engine.HexToBinary("2D74257BF4499602D2000000") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gsrnp96()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(8017)061414112345678902" },
            { "PURE_IDENTITY", "urn:epc:id:gsrnp:0614141.1234567890" },
            { "TAG_ENCODING", "urn:epc:tag:gsrnp-96:3.0614141.1234567890" },
            { "BINARY", _engine.HexToBinary("2E74257BF4499602D2000000") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gdti96()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(253)06141411234525678" },
            { "PURE_IDENTITY", "urn:epc:id:gdti:0614141.12345.5678" },
            { "TAG_ENCODING", "urn:epc:tag:gdti-96:3.0614141.12345.5678" },
            { "BINARY", _engine.HexToBinary("2C74257BF46072000000162E") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gdti174()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=174";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(253)4012345987652ABCDefgh012345678" },
            { "PURE_IDENTITY", "urn:epc:id:gdti:4012345.98765.ABCDefgh012345678" },
            { "TAG_ENCODING", "urn:epc:tag:gdti-174:3.4012345.98765.ABCDefgh012345678" },
            { "BINARY", _engine.HexToBinary("3E74F4E4E7039B061438997367D0C18B266D1AB66EE0")[..174] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Cpi96()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(8010)061414198765(8011)12345" },
            { "PURE_IDENTITY", "urn:epc:id:cpi:0614141.98765.12345" },
            { "TAG_ENCODING", "urn:epc:tag:cpi-96:3.0614141.98765.12345" },
            { "BINARY", _engine.HexToBinary("3C74257BF400C0E680003039") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void CpiVar()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=var";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(8010)06141415PQ7/Z43(8011)12345" },
            { "PURE_IDENTITY", "urn:epc:id:cpi:0614141.5PQ7%2FZ43.12345" },
            { "TAG_ENCODING", "urn:epc:tag:cpi-var:3.0614141.5PQ7%2FZ43.12345" },
            { "BINARY", _engine.HexToBinary("3D74257BF75411DEF6B4CC00000003039") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Sgcn96()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(255)401234567890104711" },
            { "PURE_IDENTITY", "urn:epc:id:sgcn:4012345.67890.04711" },
            // note: standard document has wrong filter value
            { "TAG_ENCODING", "urn:epc:tag:sgcn-96:3.4012345.67890.04711" },
            { "BINARY", _engine.HexToBinary("3F74F4E4E612640000019907") }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Gid96()
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
    public void Usdod96()
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
    public void AdiVar()
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
    public void Itip110()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=110";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(8006)040123451234560102(21)987" },
            { "PURE_IDENTITY", "urn:epc:id:itip:4012345.012345.01.02.987" },
            { "TAG_ENCODING", "urn:epc:tag:itip-110:3.4012345.012345.01.02.987" },
            { "BINARY", _engine.HexToBinary("4074F4E4E40C0E40820000000F6C")[..110] }
        };

        ExecuteTests(tests, parameterList);
    }

    [Fact]
    public void Itip212()
    {
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=212";

        var tests = new Dictionary<string, string>
        {
            { "LEGACY_AI", "(8006)040123451234560102(21)mw133" },
            { "PURE_IDENTITY", "urn:epc:id:itip:4012345.012345.01.02.mw133" },
            { "TAG_ENCODING", "urn:epc:tag:itip-212:3.4012345.012345.01.02.mw133" },
            { "BINARY", _engine.HexToBinary("4174F4E4E40C0E4082DBDD8B36600000000000000000000000000000")[..212] }
        };

        ExecuteTests(tests, parameterList);
    }
}
