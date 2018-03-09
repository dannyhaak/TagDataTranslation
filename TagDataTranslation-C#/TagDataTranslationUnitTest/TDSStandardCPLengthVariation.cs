using System;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;

using TagDataTranslation;

namespace TagDataTranslationUnitTest
{
    [TestFixture()]
    public class TDSStandardCPLengthVariation
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
					try {
						var result = engine.Translate(input, parameterList, outputFormat);
						Assert.AreEqual(expect, result, $"Testing translating {input} to {outputFormat} expect {expect} is {result}");
					} catch (Exception e) {
                        Assert.Fail($"Failing translating {input} to {outputFormat} expect {expect} with params {parameterList}: " + e.Message);
					}
				}
			}
		}

        [Test()]
		public void Sgtin96()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(01)80614141123458(21)6789";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };

			for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=96";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}


		[Test()]
		public void Sgtin198()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(01)70614141123451(21)32a/b";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };

			for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=198";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

		[Test()]
		public void Sscc96()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(00)106141412345678908";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };

			for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=96";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

		[Test()]
		public void Sgln96()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(414)0614141123452(254)5678";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };

			for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=96";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

		[Test()]
		public void Sgln195()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(414)0614141123452(254)32a/b";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };


            for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=195";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

		[Test()]
		public void Grai96()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(8003)006141411234525678";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };


            for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=96";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

		[Test()]
		public void Grai170()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(8003)0061414112345232a/b";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };

			for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=170";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

		[Test()]
		public void Giai96()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(8004)0614141567833";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };


            for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=96";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

		[Test()]
		public void Giai202()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(8004)061414112332a/b";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };


            for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=202";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

		[Test()]
		public void Gsrn96()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(8018)061414112345678902";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };


            for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=96";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

		[Test()]
		public void Gsrnp96()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(8017)061414112345678902";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };


            for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=96";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}


		[Test()]
        public void Gdti96()
        {
            TDTEngine engine = new TDTEngine();

			var input = @"(253)06141411234525678";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };

			for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=96";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

        [Test()]
        public void Gdti174()
        {
            TDTEngine engine = new TDTEngine();

			var input = @"(253)4012345987652ABCDefgh012345678";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };


            for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=174";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
        }

        [Test()]
		public void Cpi96()
		{
			TDTEngine engine = new TDTEngine();

            var input = @"(8010)0614141987651(8011)12345";
            var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };

            for (int i = 6; i < 13; i++) {
                var tests = new Dictionary<string, string>();
                tests.Add(@"LEGACY_AI", input);

                string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=96";

                foreach (var outputFormat in outputFormats) {
                    try {
                        tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
                    } catch (Exception e) {
                        Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
                    }
                }

			    ExecuteTests(tests, parameterList);	
            }
		}

		[Test()]
		public void CpiVar()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(8010)0614141987651(8011)12345";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };

			for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=var";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

		[Test()]
		public void Sgcn96()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(255)401234567890104711";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };

			for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=96";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

		[Test()]
		public void Itip110()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(8006)040123451234560102(21)987";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };


            for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=110";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}

		[Test()]
		public void Itip212()
		{
			TDTEngine engine = new TDTEngine();

			var input = @"(8006)040123451234560102(21)mw133";
			var outputFormats = new string[] { @"PURE_IDENTITY", @"TAG_ENCODING", @"BINARY", @"ELEMENT_STRING", @"LEGACY" };


            for (int i = 6; i < 13; i++)
			{
				var tests = new Dictionary<string, string>();
				tests.Add(@"LEGACY_AI", input);

				string parameterList = $"filter=3;gs1companyprefixlength={i};tagLength=212";

				foreach (var outputFormat in outputFormats)
				{
					try
					{
						tests.Add(outputFormat, engine.Translate(input, parameterList, outputFormat));
					}
					catch (Exception e)
					{
						Assert.Fail($"Failing translating {input} to {outputFormat} with params {parameterList}: " + e.Message);
					}
				}

				ExecuteTests(tests, parameterList);
			}
		}
    }
}
