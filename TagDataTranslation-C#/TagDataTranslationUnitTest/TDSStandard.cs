using System;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;

using TagDataTranslation;

namespace TagDataTranslationUnitTest
{
    [TestFixture ()]
    public class TDSStandard
    {
        public void ExecuteTests(Dictionary<string, string> tests, string parameterList) 
        {
			foreach (var test in tests)
			{
                var input = test.Value;

				foreach (var output in tests)
				{
                    TDTEngine engine = new TDTEngine();
					var outputFormat = output.Key;
					var expect = output.Value;
                    try
                    {
                        var result = engine.Translate(input, parameterList, outputFormat);
                        Assert.AreEqual(expect, result, $"Testing translating {input} to {outputFormat} expect {expect} is {result}");
                    }
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} expect {expect}: " + e.Message);
					}
				}
			}
        }

        [Test ()]
        public void Sgtin96()
        {
            TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

			var tests = new Dictionary<string, string>();
            tests.Add(@"LEGACY_AI", @"(01)80614141123458(21)6789");
            tests.Add(@"PURE_IDENTITY", @"urn:epc:id:sgtin:0614141.812345.6789");
            tests.Add(@"TAG_ENCODING", @"urn:epc:tag:sgtin-96:3.0614141.812345.6789");
            tests.Add(@"BINARY", engine.HexToBinary(@"3074257BF7194E4000001A85"));

            ExecuteTests(tests, parameterList);
        }

		[Test()]
		public void Sgtin198()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=198";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(01)70614141123451(21)32a/b");
			// there is a bug in the standard document here, which says urn:epc:id:sgtin:0614141.812345.32a%2Fb - but the '8' is obviously wrong here
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:sgtin:0614141.712345.32a%2Fb");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:sgtin-198:3.0614141.712345.32a%2Fb");
			tests.Add(@"BINARY", engine.HexToBinary(@"3674257BF6B7A659B2C2BF1000000000000000000000000000").Substring(0, 198));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Sscc96()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(00)106141412345678908");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:sscc:0614141.1234567890");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:sscc-96:3.0614141.1234567890");
			tests.Add(@"BINARY", engine.HexToBinary(@"3174257BF4499602D2000000"));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Sgln96()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(414)0614141123452(254)5678");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:sgln:0614141.12345.5678");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:sgln-96:3.0614141.12345.5678");
			tests.Add(@"BINARY", engine.HexToBinary(@"3274257BF46072000000162E"));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Sgln195()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=195";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(414)0614141123452(254)32a/b");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:sgln:0614141.12345.32a%2Fb");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:sgln-195:3.0614141.12345.32a%2Fb");
			tests.Add(@"BINARY", engine.HexToBinary(@"3974257BF46072CD9615F8800000000000000000000000000").Substring(0, 195));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Grai96()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(8003)006141411234525678");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:grai:0614141.12345.5678");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:grai-96:3.0614141.12345.5678");
			tests.Add(@"BINARY", engine.HexToBinary(@"3374257BF40C0E400000162E"));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Grai170()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=170";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(8003)0061414112345232a/b");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:grai:0614141.12345.32a%2Fb");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:grai-170:3.0614141.12345.32a%2Fb");
			tests.Add(@"BINARY", engine.HexToBinary(@"3774257BF40C0E59B2C2BF100000000000000000000").Substring(0, 170));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Giai96()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(8004)06141415678");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:giai:0614141.5678");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:giai-96:3.0614141.5678");
			tests.Add(@"BINARY", engine.HexToBinary(@"3474257BF40000000000162E"));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Giai202()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=202";

			var tests = new Dictionary<string, string>();
			// there is a bug in the standard document here, (8004)0061414132a/b there is a zero too much
			tests.Add(@"LEGACY_AI", @"(8004)061414132a/b");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:giai:0614141.32a%2Fb");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:giai-202:3.0614141.32a%2Fb");
			tests.Add(@"BINARY", engine.HexToBinary(@"3874257BF59B2C2BF1000000000000000000000000000000000").Substring(0, 202));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Gsrn96()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(8018)061414112345678902");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:gsrn:0614141.1234567890");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:gsrn-96:3.0614141.1234567890");
            // there is a bug in the standard document here, which says 2D14257BF4499602D2000000 - but the first '1' is obviously wrong here; different filter
			tests.Add(@"BINARY", engine.HexToBinary(@"2D74257BF4499602D2000000"));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Gsrnp96()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(8017)061414112345678902");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:gsrnp:0614141.1234567890");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:gsrnp-96:3.0614141.1234567890");
			tests.Add(@"BINARY", engine.HexToBinary(@"2E74257BF4499602D2000000"));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Gdti96()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(253)06141411234525678");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:gdti:0614141.12345.5678");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:gdti-96:3.0614141.12345.5678");
			tests.Add(@"BINARY", engine.HexToBinary(@"2C74257BF46072000000162E"));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Gdti174()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=174";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(253)4012345987652ABCDefgh012345678");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:gdti:4012345.98765.ABCDefgh012345678");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:gdti-174:3.4012345.98765.ABCDefgh012345678");
			tests.Add(@"BINARY", engine.HexToBinary(@"3E74F4E4E7039B061438997367D0C18B266D1AB66EE0").Substring(0, 174));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Cpi96()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(8010)061414198765(8011)12345");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:cpi:0614141.98765.12345");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:cpi-96:3.0614141.98765.12345");
			tests.Add(@"BINARY", engine.HexToBinary(@"3C74257BF400C0E680003039"));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void CpiVar()
		{
			TDTEngine engine = new TDTEngine();

            string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=var";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(8010)06141415PQ7/Z43(8011)12345");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:cpi:0614141.5PQ7%2FZ43.12345");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:cpi-var:3.0614141.5PQ7%2FZ43.12345");
			tests.Add(@"BINARY", engine.HexToBinary(@"3D74257BF75411DEF6B4CC00000003039"));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Sgcn96()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(255)401234567890104711");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:sgcn:4012345.67890.04711");
			// there is a bug in the standard document here, the filter value should be 3
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:sgcn-96:3.4012345.67890.04711");
			tests.Add(@"BINARY", engine.HexToBinary(@"3F74F4E4E612640000019907"));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Gid96()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"tagLength=96";

			var tests = new Dictionary<string, string>();
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:gid:31415.271828.1414");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:gid-96:31415.271828.1414");
			tests.Add(@"BINARY", engine.HexToBinary(@"350007AB70425D4000000586"));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Usdod96()
		{
			TDTEngine engine = new TDTEngine();

            string parameterList = @"tagLength=96;filter=3";

			var tests = new Dictionary<string, string>();
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:usdod:CAGEY.5678");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:usdod-96:3.CAGEY.5678");
			tests.Add(@"BINARY", engine.HexToBinary(@"2F320434147455900000162E"));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void AdiVar()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3";

			var tests = new Dictionary<string, string>();
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:adi:35962.PQ7VZ4.M37GXB92");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:adi-var:3.35962.PQ7VZ4.M37GXB92");
			tests.Add(@"BINARY", engine.HexToBinary(@"3B0E0CF5E76C9047759AD00373DC7602E7200").Substring(0, 146));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Itip110()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=110";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(8006)040123451234560102(21)987");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:itip:4012345.012345.01.02.987");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:itip-110:3.4012345.012345.01.02.987");
			tests.Add(@"BINARY", engine.HexToBinary(@"4074F4E4E40C0E40820000000F6C").Substring(0, 110));

			ExecuteTests(tests, parameterList);
		}

		[Test()]
		public void Itip212()
		{
			TDTEngine engine = new TDTEngine();

			string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=212";

			var tests = new Dictionary<string, string>();
			tests.Add(@"LEGACY_AI", @"(8006)040123451234560102(21)mw133");
			tests.Add(@"PURE_IDENTITY", @"urn:epc:id:itip:4012345.012345.01.02.mw133");
			tests.Add(@"TAG_ENCODING", @"urn:epc:tag:itip-212:3.4012345.012345.01.02.mw133");
			tests.Add(@"BINARY", engine.HexToBinary(@"4174F4E4E40C0E4082DBDD8B36600000000000000000000000000000").Substring(0, 212));

			ExecuteTests(tests, parameterList);
		}
	}
}
