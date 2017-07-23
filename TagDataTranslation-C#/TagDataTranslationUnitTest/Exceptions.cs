using System;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;

using TagDataTranslation;

namespace TagDataTranslationUnitTest
{
    [TestFixture ()]
    public class Exceptions
    {
        [Test ()]
        public void TestCaseExceptionTDTFieldAboveMaximum ()
        {
            string epcIdentifier = @"gtin=00037000302414;serial=274877906944";
            string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";
            string outputFormat = @"PURE_IDENTITY";
            TDTEngine engine = new TDTEngine();

            var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
            Assert.That(ex.Message, Is.EqualTo("TDTFieldAboveMaximum"));
        }

        [Test ()]
        public void TestCaseExceptionTDTUndefinedField ()
        {
            string epcIdentifier = @"gtin=00037000302414;serial=1";
            string parameterList = @"gs1companyprefixlength=7;tagLength=96";
            string outputFormat = @"BINARY";
            TDTEngine engine = new TDTEngine();

            var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
            Assert.That(ex.Message, Is.EqualTo("TDTUndefinedField"));
        }

        [Test ()]
        public void TestCaseExceptionTDTSchemeNotFound ()
        {
            string epcIdentifier = @"glin=00037000302414;serial=-1";
            string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";
            string outputFormat = @"PURE_IDENTITY";
            TDTEngine engine = new TDTEngine();

            var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
            Assert.That(ex.Message, Is.EqualTo("TDTSchemeNotFound"));
        }

        [Test ()]
        public void TestCaseExceptionTDTOptionNotFound ()
        {
            string epcIdentifier = @"gtin=00037000302414;serial=-1";
            string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";
            string outputFormat = @"PURE_IDENTITY";
            TDTEngine engine = new TDTEngine();

            var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
            Assert.That(ex.Message, Is.EqualTo("TDTOptionNotFound"));
        }
        
        [Test ()]
        public void TestCaseExceptionTDTTDTOptionNotFound_2 ()
        {
            string epcIdentifier = @"gtin=00037000302414;serial=$$";
            string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";
            string outputFormat = @"PURE_IDENTITY";
            TDTEngine engine = new TDTEngine();

            var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
            Assert.That(ex.Message, Is.EqualTo("TDTOptionNotFound"));
        }
        
        [Test ()]
        public void TestCaseExceptionParameterList ()
        {
            string epcIdentifier = @"string";
            string parameterList = @"string";
            string outputFormat = @"string";
            TDTEngine engine = new TDTEngine();

            var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
            Assert.That(ex.Message, Is.EqualTo("TDTParameterErrorException"));
        }
        
        [Test ()]
        public void TestCaseExceptionOutputFormat ()
        {
            string epcIdentifier = @"gtin=00037000302414;serial=1041970";
            string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";
            string outputFormat = @"string";
            TDTEngine engine = new TDTEngine();

            var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
            Assert.That(ex.Message, Is.EqualTo("TDTOutputFormatUnknownException"));
        }

        [Test ()]
        public void TestCaseExceptionFilterValueNull ()
        {
			string epcIdentifier = @"gtin=00037000302414;serial=1041970";
			string parameterList = @"filter=null;gs1companyprefixlength=7;tagLength=96";
			string outputFormat = @"TAG_ENCODING";
			TDTEngine engine = new TDTEngine();

            var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
			Assert.That(ex.Message, Is.EqualTo("TDTFieldOutsideCharacterSet"));
        }

        /*
        1. TDTFileNotFound – Reports if the engine could not locate the configured definition file to compile.
        2. TDTFieldBelowMinimum - Reports a (numeric) Field that fell below the decimalMinimum value allowed by the TDT markup
        7. TDTLevelNotFound - Reported if no matching Level can be found via prefixMatch
        9. TDTLookupFailed - Reported if lookup in an external table failed to provide a value – reports table URI and path expression.
        10. TDTNumericOverflow – Reported when a numeric overflow occurs when handling numeric values such as serial number.
        */
    }
}

