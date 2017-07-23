using System;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;

using TagDataTranslation;

namespace TagDataTranslationUnitTest
{
    [TestFixture ()]
    public class TDTStandard
    {
        [Test ()]
        public void TestCasePage13TDTStandard ()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"gtin=00037000302414;serial=1041970";
            string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = @"001100000111010000000010010000100010000000011101100010000100000000000000000011111110011000110010";
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:sgtin-96:3.0037000.030241.1041970";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:sgtin:0037000.030241.1041970";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);
        }

        [Test ()]
        public void TestCasePage26TDTStandard ()
        {
            TDTEngine engine = new TDTEngine ();

            String parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";

            List<String> epcIdentifiers = new List<String> ();
            epcIdentifiers.Add (@"gtin=00037000302414;serial=10419703");
            epcIdentifiers.Add (@"gln=0003700030247;serial=1041970");
            epcIdentifiers.Add (@"grai=00037000302414274877906943");
            epcIdentifiers.Add (@"giai=00370003024149267890123");
            epcIdentifiers.Add (@"generalmanager=5;objectclass=17;serial=23");
            epcIdentifiers.Add (@"cageordodaac=AB123;serial=3789156");

            foreach (String epcIdentifier in epcIdentifiers) {
                String result = engine.Translate(epcIdentifier, parameterList, @"BINARY");
                String result2 = engine.Translate(result, parameterList, @"LEGACY");
                Assert.AreEqual(epcIdentifier, result2);
            }
        }
    }
}

