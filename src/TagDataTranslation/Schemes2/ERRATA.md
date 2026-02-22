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

## Table F AI Encoding Issues

### Issue: "Delimited/terminated numeric" encoding for alphanumeric AIs

**Affected AIs**: 8004 (GIAI), 8010 (CPI), and potentially others

**Problem**: Table F lists these AIs as using "Delimited/terminated numeric" encoding (section 14.5.5), but the AI values can contain alphanumeric characters:
- GIAI (8004): Can contain characters from `[!%-?A-Z_a-z\x22]` for the asset reference portion
- CPI (8010): Can contain characters from `[#-/0-9A-Z]` for the component/part reference portion

**Impact**: The current implementation encodes these values as numeric-only, which produces incorrect binary output when the value contains non-numeric characters.

**Potential Fix**: Either:
1. Table F should indicate these AIs use "Delimited/terminated alphanumeric" encoding
2. The encoder should detect alphanumeric content and switch to appropriate encoding method
3. TDS 2.3 section 14.5.5 may need clarification for mixed-character AIs

---

## Notes

- The `[01]*` character set is appropriate for BINARY level fields (which contain binary data)
- The `[0-9]*` or appropriate character classes should be used for BARE_IDENTIFIER and other text-based levels
- These bugs cause validation failures when parsing BARE_IDENTIFIER inputs with valid date values
- The '+' schemes that use alphanumeric AI values (GIAI+, CPI+, etc.) may require encoder updates to handle mixed character encoding properly
