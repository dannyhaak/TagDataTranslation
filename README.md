## Synopsis

Tag Data Translation implemented according to the GS1 EPC Tag Data Translation 1.6 specification (http://www.gs1.org/epc/tag-data-translation-standard) for RAIN RFID, and updated for Tag Data Standard 1.11. Comes with unit tests and a demonstration application.

The following schemes are supported:
- ADI-var
- CPI-96, CPI-var
- GTDI-96, GDTI-174
- GIAI-96, GIAI-202
- GID-96
- GRAI-96, GRAI-170
- GSRN-96
- GSRNP-96
- ITIP-110, ITIP-212
- SGCN-96
- SGLN-96, SGLN-195
- SGTIN-96, SGTIN-198
- SSCC-96
- USDOD-96

The following programming languages are supported:
- C# .NET Framework 4.0  (Microsoft and Xamarin Mono runtime)
- C# .NET Standard 1.4

## Example

The following code is an example on how to use the library, to go from a GTIN and serial to hexadecimal.

```
TDTEngine engine = new TDTEngine ();
string epcIdentifier = @"gtin=00037000302414;serial=10419703"
string parameterList = @"filter=3;gs1companyprefixlength=7;tagLength=96";
string binary = engine.Translate(epcIdentifier, parameterList, @"BINARY");
string binaryHex = engine.BinaryToHex(binary);
```

Or the other way around.

```
TDTEngine engine = new TDTEngine ();
string epcIdentifier = engine.HexToBinary(@"30340242201d8840009efdf7");
string parameterList = @"tagLength=96";
string legacy = engine.Translate(epcIdentifier, parameterList, @"LEGACY");
```

## API

The library follows the client API as defined in the standard and there are some additional helper functions.

### Translate

```
public String translate(String epcIdentifier, String parameterList, String outputFormat)
```

Translates epcIdentifier from one representation into another within the same coding scheme.

#### Parameters

| Parameter     | Description |
| ------------- | ----------- |
| epcIdentifier | The epcIdentifier to be converted. This should be expressed as a string, in accordance with one of the grammars or patterns in the TDT markup files, i.e. a binary string consisting of characters '0' and '1', a URI (either tag-encoding or pure-identity formats), or a serialized identifier expressed as in Table 3. |
| parameterList | This is a parameter string containing key value pairs, using the semicolon [';'] as delimiter between key=value pairs. For example, to convert a GTIN code the parameter string would look like the following: `filter=3;companyprefixlength=7;tagLength=96` |
| outputFormat  | The output format into which the epcIdentifier SHALL be converted. The following are the formats supported: `BINARY`, `LEGACY`, `LEGACY_AI`, `TAG_ENCODING`,  `PURE_IDENTITY` |

#### Returns

The converted value into one of the above formats as String.

#### Throws

**TDTTranslationException** – Throws exceptions due to the following reason:

1. `TDTFileNotFound` Reports if the engine could not locate the configured definition file to compile.
2. `TDTFieldBelowMinimum` Reports a (numeric) Field that fell below the decimalMinimum value allowed by the TDT markup
3. `TDTFieldAboveMaximum` Reports a (numeric) Field that exceeded the decimalMaximum value allowed by the TDT markup
4. `TDTFieldOutsideCharacterSet` Reports a Field containing characters outside the characterSet range allowed by the TDT markup
5. `TDTUndefinedField` Reports a Field required for the output or an intermediate rule, whose value is undefined
6. `TDTSchemeNotFound` Reported if no matching Scheme can be found via prefixMatch
7. `TDTLevelNotFound` Reported if no matching Level can be found via prefixMatch
8. `TDTOptionNotFound` Reported if no matching Option can be found via the optionKey or via matching the pattern
9. `TDTLookupFailed` Reported if lookup in an external table failed to provide a value – reports table URI and path expression.
10. `TDTNumericOverflow` Reported when a numeric overflow occurs when handling numeric values such as serial number.

### GetPrefixLength

```
public PrefixLengthResult GetPrefixLength(string input)
```

Gets the GS1 Prefix Length for the given identifier. Based on the gcpprefixformatlist.xml file from GS1 (GCP Length Table, https://www.gs1.org/standards/bc-epc-interop).

#### Parameters

| Parameter     | Description |
| ------------- | ----------- |
| input | Identifier for which to find the GS1 Prefix Length. Input as string. |

#### Returns

An object with the following properties.

| Property     | Description |
| ------------- | ----------- |
| Prefix | The full GS1 Prefix as a string. |
| Length | The length of the GS1 Prefix as integer. |

### GetFilterValueTable

```
public Dictionary<int, string> GetFilterValueTable(string scheme)
```

Gets the Filter Value table for the provided scheme. 

#### Parameters

| Parameter     | Description |
| ------------- | ----------- |
| scheme | The GS1 EPC scheme for which to retrieve the Filter Value Table. Input as string. |

#### Returns

A dictionary with an integer as key (Filter Value) and a string as value (description).

## License

This library is dual-licensed:
- GNU Affero General Public License version 3
- Commercial license, contact tdt@dannyhaak.nl for more details

The included XML and XSD artifacts are (c) by GS1 (https://www.gs1.org/epc/tag-data-translation-standard).
