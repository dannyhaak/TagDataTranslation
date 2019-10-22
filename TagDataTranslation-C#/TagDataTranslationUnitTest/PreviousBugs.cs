using System;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;

using TagDataTranslation;

namespace TagDataTranslationUnitTest
{
    [TestFixture()]
    public class PreviousBugs
    {
        [Test()]
        public void LongCompanyPrefix()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"urn:epc:id:sgtin:0867360217.005.0";
            string parameterList = @"filter=1;gs1companyprefixlength=10;tagLength=96";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"302833B2DDD9014000000000");
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:sgtin-96:1.0867360217.005.0";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"LEGACY");
            expect = @"gtin=00867360217055;serial=0";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"PURE_IDENTITY");
            Assert.AreEqual(epcIdentifier, result4);
        }

        [Test()]
        public void EmptyParameterListSGTIN96PureIdentityToLegacy()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"urn:epc:id:sgtin:0037000.030241.1041970";
            string parameterList = @"";

            string result = engine.Translate(epcIdentifier, parameterList, @"LEGACY");
            string expect = @"gtin=00037000302414;serial=1041970";
            Assert.AreEqual(expect, result);
        }

        [Test()]
        public void EmptyParameterListSGTIN96TagURIToLegacy()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"urn:epc:tag:sgtin-96:1.0037000.030241.1041970";
            string parameterList = @"";

            string result = engine.Translate(epcIdentifier, parameterList, @"LEGACY");
            string expect = @"gtin=00037000302414;serial=1041970";
            Assert.AreEqual(expect, result);

        }

        [Test()]
        public void EmptyParameterListSGTIN96TagURIToPureIdentity()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"urn:epc:tag:sgtin-96:1.0037000.030241.1041970";
            string parameterList = @"";

            string result = engine.Translate(epcIdentifier, parameterList, @"PURE_IDENTITY");
            string expect = @"urn:epc:id:sgtin:0037000.030241.1041970";
            Assert.AreEqual(expect, result);

        }

        [Test()]
        public void EmptyParameterListSGTIN198PureIdentityToLegacy()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"urn:epc:id:sgtin:0037000.030241.ABCD";
            string parameterList = @"";

            string result = engine.Translate(epcIdentifier, parameterList, @"LEGACY");
            string expect = @"gtin=00037000302414;serial=ABCD";
            Assert.AreEqual(expect, result);
        }

        [Test()]
        public void AdiVarBrendan()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = engine.HexToBinary(@"3B0204C8D72C001CC5F1C79CB4D35000");
            string parameterList = @"";

            string result = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            string expect = @"urn:epc:tag:adi-var:0.SH520..GLW1192445";
            Assert.AreEqual(expect, result);

            string result2 = engine.Translate(result, parameterList, @"BINARY");

            var length = epcIdentifier.Length;
            var result2Padded = result2.PadRight(length, '0');

            Assert.AreEqual(epcIdentifier, result2Padded);
        }
    }
}

