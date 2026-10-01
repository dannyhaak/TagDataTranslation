# TDS 2.2/2.3 Scheme JSON Errata

This document lists bugs found in the GS1 standard TDT 2.2 scheme JSON files from the 2025-02-13 artifacts.

## DSGTIN+.json

### Bug 1: Incorrect character set for date fields in BARE_IDENTIFIER level

**Location**: BARE_IDENTIFIER level, optionKey 0-6 (all date options)

**Problem**: All date fields (`prodDate`, `packDate`, `bestBeforeDate`, `sellByDate`, `expDate`, `firstFreezeDate`, `harvestDate`) have `characterSet: "[01]*"` which only allows binary 0/1 characters.

**Expected**: Date fields in BARE_IDENTIFIER should have `characterSet: "[0-9]*"` since they contain YYMMDD date strings like "220630".

**Fix Applied**: Changed all date fields in BARE_IDENTIFIER level from `[01]*` to `[0-9]*`.

---

## CPI+.json

### Bug 2: Missing encoding format documentation

The CPI+ scheme uses AI 8010 which has a "Delimited/terminated numeric" encoding for the CPI value. The test cases in TDS 2.3 E.3 may require verification against actual encoder output.

---

## GIAI+.json

### Bug 3: Pattern verification needed

The GIAI+ BARE_IDENTIFIER uses pattern `^giai=([0-9]{4}[!%-?A-Z_a-z\\x22]{1,26})$` which expects:
- 4 leading digits (minimum company prefix)
- 1-26 alphanumeric characters for asset reference

The TDS 2.3 E.3 test vectors should be verified against this pattern.

---

---

## Table F AI Encoding Issues (withdrawn)

An earlier version listed "Delimited/terminated numeric" for AIs (8004) and (8010) as a Table F error. It is not: TDS 2.3 section 14.5.5 encodes the initial digits, then a `1110` delimiter followed by the variable-length alphanumeric method for the rest of the value. The encoder handles this.

---

## Errors found in the TDT 2.3 public review artefacts (2026-09-15)

These were present in our copies as well and are fixed here. They are reported to GS1 in `docs/TDT-2.3-Public-Review-Comments.md` in the Mimasu repository.

| File | Location | Was | Now |
|------|----------|-----|-----|
| ITIP-110, ITIP-212 | `itip` decimalMaximum, non-binary levels | 14 nines | 18 nines |
| DSGTIN+ | BARE_IDENTIFIER date fields | `[01]*` | `[0-9]*` |
| ADI-var | PURE_IDENTITY rule seq 2 | `[A-Z0-9/#-]]*` | `[A-Z0-9/#-]*` |
| ADI-var | TEI option 7 grammar | `'/SER='` | `'/SER '` |
| ADI-var | BINARY CAGE/DoDAAC sub-pattern | `(?:11[01]{4})\|(?:111--[01])` | `(?:110[01]{3})\|(?:11100[01])` |
| ADI-var | `urnEncodedSerial`, `urnEncodedOriginalPartNumber` character sets | decoded set `[0-9A-Z/-]+` | escaped set `(?:[0-9A-Z-]\|%2F)*` (with `%23` prefix for '#' serials) |
| CPI-var | BARE_IDENTIFIER option 12 `cpi` | `[A-Z0-9/#-]]*` | `[A-Z0-9/#-]*` |
| CPI-var | PURE_IDENTITY serial | `{1,10}` | `{1,12}` |
| CPI-var | GS1_AI_JSON grammar | `serial` (undefined) | `cpiserial` |
| CPI-96, CPI-var | PURE_IDENTITY option 6 field seq | 1, 3, 3 | 1, 2, 3 |
| CPI-96 | `cpiserial` maximum in BARE/AI JSON/Digital Link | 9999999999 | 2147483647 (31-bit field) |
| GDTI-113 | BINARY serial | plain integer | TDS 14.3.6 numeric string (`prependedserial`) |
| GIAI-202 | GS1_DIGITAL_LINK FORMAT rule character set | URN set | URL set |
| USDOD-96 | TAG_ENCODING filter | `([0-9])` | `(1[0-5]\|[0-9])` |
| SGLN-96, SGLN-195, SGLN+ | extension (254) | always emitted | `valueIfNull: "0"` with `[...]` conditional grammar; optional in GS1_AI_JSON |
| 21 files with Digital Link URL character classes | `[A-Za-z0-9"._-]` | raw `"` | `%22` |

---

## Notes

- The `[01]*` character set is appropriate for BINARY level fields (which contain binary data)
- The `[0-9]*` or appropriate character classes should be used for BARE_IDENTIFIER and other text-based levels
- These bugs cause validation failures when parsing BARE_IDENTIFIER inputs with valid date values
- The '+' schemes that use alphanumeric AI values (GIAI+, CPI+, etc.) may require encoder updates to handle mixed character encoding properly
