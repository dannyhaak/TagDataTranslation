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

            Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat), "TDTFieldAboveMaximum");
        }

        [Test ()]
        public void TestCaseExceptionTDTFieldOutsideCharacterSet ()
        {
            string epcIdentifier = @"gtin=00037000302414;serial=$$";
            string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";
            string outputFormat = @"PURE_IDENTITY";
            TDTEngine engine = new TDTEngine();

            Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat), "TDTFieldOutsideCharacterSet");
        }

        [Test ()]
        public void TestCaseExceptionTDTUndefinedField ()
        {
            string epcIdentifier = @"gtin=00037000302414;serial=1";
            string parameterList = @"filter=3;tagLength=96";
            string outputFormat = @"PURE_IDENTITY";
            TDTEngine engine = new TDTEngine();

            Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat), "TDTUndefinedField");
        }

        [Test ()]
        public void TestCaseExceptionTDTSchemeNotFound ()
        {
            string epcIdentifier = @"glin=00037000302414;serial=-1";
            string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";
            string outputFormat = @"PURE_IDENTITY";
            TDTEngine engine = new TDTEngine();

            Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat), "TDTSchemeNotFound");
        }

        [Test ()]
        public void TestCaseExceptionTDTOptionNotFound ()
        {
            string epcIdentifier = @"gtin=00037000302414;serial=-1";
            string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";
            string outputFormat = @"PURE_IDENTITY";
            TDTEngine engine = new TDTEngine();

            Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat), "TDTOptionNotFound");
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

