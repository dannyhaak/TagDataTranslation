using TagDataTranslation;
using Xunit;

namespace TagDataTranslationUnitTest;

public class Exceptions
{
    [Fact]
    public void TestCaseExceptionTDTFieldAboveMaximum()
    {
        var epcIdentifier = "gtin=00037000302414;serial=274877906944";
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var outputFormat = "PURE_IDENTITY";
        var engine = new TDTEngine();

        var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
        Assert.Equal("TDTFieldAboveMaximum", ex.Message);
    }

    [Fact]
    public void TestCaseExceptionTDTUndefinedField()
    {
        var epcIdentifier = "gtin=00037000302414;serial=1";
        var parameterList = "gs1companyprefixlength=7;tagLength=96";
        var outputFormat = "BINARY";
        var engine = new TDTEngine();

        var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
        Assert.Equal("TDTUndefinedField", ex.Message);
    }

    [Fact]
    public void TestCaseExceptionTDTSchemeNotFound()
    {
        var epcIdentifier = "glin=00037000302414;serial=-1";
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var outputFormat = "PURE_IDENTITY";
        var engine = new TDTEngine();

        var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
        Assert.Equal("TDTSchemeNotFound", ex.Message);
    }

    [Fact]
    public void TestCaseExceptionTDTOptionNotFound()
    {
        var epcIdentifier = "gtin=00037000302414;serial=-1";
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var outputFormat = "PURE_IDENTITY";
        var engine = new TDTEngine();

        var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
        Assert.Equal("TDTOptionNotFound", ex.Message);
    }

    [Fact]
    public void TestCaseExceptionTDTTDTOptionNotFound_2()
    {
        var epcIdentifier = "gtin=00037000302414;serial=$$";
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var outputFormat = "PURE_IDENTITY";
        var engine = new TDTEngine();

        var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
        Assert.Equal("TDTOptionNotFound", ex.Message);
    }

    [Fact]
    public void TestCaseExceptionParameterList()
    {
        var epcIdentifier = "string";
        var parameterList = "string";
        var outputFormat = "string";
        var engine = new TDTEngine();

        var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
        Assert.Equal("TDTParameterErrorException", ex.Message);
    }

    [Fact]
    public void TestCaseExceptionOutputFormat()
    {
        var epcIdentifier = "gtin=00037000302414;serial=1041970";
        var parameterList = "filter=3;gs1companyprefixlength=7;tagLength=96";
        var outputFormat = "string";
        var engine = new TDTEngine();

        var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
        Assert.Equal("TDTOutputFormatUnknownException", ex.Message);
    }

    [Fact]
    public void TestCaseExceptionFilterValueNull()
    {
        var epcIdentifier = "gtin=00037000302414;serial=1041970";
        var parameterList = "filter=null;gs1companyprefixlength=7;tagLength=96";
        var outputFormat = "TAG_ENCODING";
        var engine = new TDTEngine();

        var ex = Assert.Throws<TDTTranslationException>(() => engine.Translate(epcIdentifier, parameterList, outputFormat));
        Assert.Equal("TDTFieldOutsideCharacterSet", ex.Message);
    }

    /*
    Untested exceptions:
    1. TDTFileNotFound – Reports if the engine could not locate the configured definition file to compile.
    2. TDTFieldBelowMinimum - Reports a (numeric) Field that fell below the decimalMinimum value allowed by the TDT markup
    7. TDTLevelNotFound - Reported if no matching Level can be found via prefixMatch
    9. TDTLookupFailed - Reported if lookup in an external table failed to provide a value – reports table URI and path expression.
    10. TDTNumericOverflow – Reported when a numeric overflow occurs when handling numeric values such as serial number.
    */
}
