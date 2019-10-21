using System;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;

using TagDataTranslation;

namespace TagDataTranslationUnitTest
{
    [TestFixture()]
    public class Custom
    {
        [Test()]
        public void TestSSCC96()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"sscc=012345678901234560";
            string parameterList = @"filter=0;gs1companyprefixlength=8;tagLength=96";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"31105E30A7055F2CC0000000");
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:sscc-96:0.12345678.090123456";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:sscc:12345678.090123456";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestSGLN96()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"gln=1234567890128;serial=1234567890";
            string parameterList = @"filter=1;gs1companyprefixlength=8;tagLength=96";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"32305E30A7466800499602D2");
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:sgln-96:1.12345678.9012.1234567890";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:sgln:12345678.9012.1234567890";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestSGLN195()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"gln=1234567890128;serial=ABCDEF!&1=2";
            string parameterList = @"filter=1;gs1companyprefixlength=8;tagLength=195";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"39305E30A746690614389163214CC5EB20000000000000000000").Substring(0, 195);
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:sgln-195:1.12345678.9012.ABCDEF!%261=2";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:sgln:12345678.9012.ABCDEF!%261=2";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestGRAI96()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"grai=012345678901281";
            string parameterList = @"filter=0;gs1companyprefixlength=9;tagLength=96";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"330C75BCD150030000000001");
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:grai-96:0.123456789.012.1";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:grai:123456789.012.1";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestGRAI170()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"grai=01234567890128ABcdE!GGH-;&*a%";
            string parameterList = @"filter=7;gs1companyprefixlength=11;tagLength=170";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"37E45BFB8386A0A0C2C7922A18F1E42D76995614A000").Substring(0, 170);
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:grai-170:7.12345678901.2.ABcdE!GGH-;%26*a%25";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:grai:12345678901.2.ABcdE!GGH-;%26*a%25";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestGIAI96()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"giai=12345671";
            string parameterList = @"filter=1;gs1companyprefixlength=7;tagLength=96";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"34344B5A1C00000000000001");
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:giai-96:1.1234567.1";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:giai:1234567.1";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestGIAI202()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"giai=12345671AaBbKkZz!?%2225%%''%";
            string parameterList = @"filter=1;gs1companyprefixlength=7;tagLength=202";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"38344B5A1D8C1C30B14BD76BD217E9593264D52A54E9D2800000").Substring(0, 202);
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:giai-202:1.1234567.1AaBbKkZz!%3F%252225%25%25''%25";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:giai:1234567.1AaBbKkZz!%3F%252225%25%25''%25";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestGSRN96()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"gsrn=012345678901234560";
            string parameterList = @"filter=0;gs1companyprefixlength=10;tagLength=96";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"2D08075BCD1501E240000000");
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:gsrn-96:0.0123456789.0123456";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:gsrn:0123456789.0123456";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestGDTI96()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"gdti=01234567890123445678";
            string parameterList = @"filter=1;gs1companyprefixlength=10;tagLength=96";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"2C28075BCD150200003493AE");
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:gdti-96:1.0123456789.01.3445678";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:gdti:0123456789.01.3445678";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestGDTI174()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"gdti=01234567890123445678&;/d";
            string parameterList = @"filter=2;gs1companyprefixlength=11;tagLength=174";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = @"3e440932c05a42cda346ad9bb84ced7e400000000000";
            Assert.AreEqual(expect, engine.BinaryToHex(result1));

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:gdti-174:2.01234567890.1.3445678%26;%2Fd";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:gdti:01234567890.1.3445678%26;%2Fd";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestGID96()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"generalmanager=1234;objectclass=1234;serial=1234";
            string parameterList = @"tagLength=96";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"3500004D20004D20000004D2");
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:gid-96:1234.1234.1234";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:gid:1234.1234.1234";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestDOD96()
        {
            TDTEngine engine = new TDTEngine();
            string epcIdentifier = @"cageordodaac=99ABH;serial=123";
            string parameterList = @"filter=0;tagLength=96";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"2F020393941424800000007B");
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:usdod-96:0.99ABH.123";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:usdod:99ABH.123";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestADIvar()
        {
            TDTEngine engine = new TDTEngine();
            string epcIdentifier = @"ADI CAG 99AH2/PNO 123/SEQ 145";
            string parameterList = @"filter=1";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"3B060E79048CB1CB3031D3500000").Substring(0, 98);
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:adi-var:1.99AH2.123.145";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:adi:99AH2.123.145";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"TEI");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"TEI");
            Assert.AreEqual(epcIdentifier, result5);
        }


        [Test()]
        public void TestSGTIN96()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"gtin=08710966610350;serial=1606";
            string parameterList = @"filter=1;gs1companyprefixlength=7;tagLength=96";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"303613ACD83B9AC000000646");
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:sgtin-96:1.8710966.061035.1606";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:sgtin:8710966.061035.1606";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }

        [Test()]
        public void TestSGTIN198()
        {
            TDTEngine engine = new TDTEngine();

            string epcIdentifier = @"gtin=08710966610350;serial=%2522";
            string parameterList = @"filter=1;gs1companyprefixlength=7;tagLength=198";

            string result1 = engine.Translate(epcIdentifier, parameterList, @"BINARY");
            string expect = engine.HexToBinary(@"363613ACD83B9AD2B26AC9900000000000000000000000000000").Substring(0, 198);
            Assert.AreEqual(expect, result1);

            string result2 = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
            expect = @"urn:epc:tag:sgtin-198:1.8710966.061035.%252522";
            Assert.AreEqual(expect, result2);

            string result3 = engine.Translate(result2, parameterList, @"PURE_IDENTITY");
            expect = @"urn:epc:id:sgtin:8710966.061035.%252522";
            Assert.AreEqual(expect, result3);

            string result4 = engine.Translate(result3, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result4);

            string result5 = engine.Translate(result1, parameterList, @"LEGACY");
            Assert.AreEqual(epcIdentifier, result5);
        }
    }
}

