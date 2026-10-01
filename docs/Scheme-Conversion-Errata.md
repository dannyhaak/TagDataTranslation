# Scheme Conversion Errata

This document lists errors found in the JSON scheme files (`Schemes2/`) when comparing to the original XML scheme definitions.

## GRAI-96.json - BARE_IDENTIFIER Pattern (withdrawn)

An earlier version of this document changed the BARE_IDENTIFIER pattern from `^grai=([0-9]{14,25})$` to `^grai=([0-9]{15,26})$`. That change was wrong and has been reverted.

The GRAI-96 bare identifier excludes the pad digit that precedes the GRAI in AI (8003): the grammar has no literal '0', the rules use `SUBSTR(grai,0,12)` and `SUBSTR(grai,13)`, and GS1_AI_JSON and GS1_DIGITAL_LINK capture `0([0-9]{14,25})`. So the value is 13 digits (company prefix, asset type, check digit) plus a serial of 1-12 digits: `{14,25}`. The `{15,26}` pattern rejected single-digit serials and split 26-digit inputs one position off. The TDT 2.3 public review artefacts (2026-09-15) also use `{14,25}`.

---

## ADI-var.json - PURE_IDENTITY Rule CharacterSet

**Location:** `Schemes2/ADI-var.json`, PURE_IDENTITY level, rule seq 2

**JSON (incorrect):**
```json
"characterSet": "[A-Z0-9/#-]]*"
```

**Issue:**
Extra closing bracket `]` in the character set regex, making it invalid.

**Fixed:** Changed to `"[A-Z0-9/#-]*"`

---

*Last updated: 2026-10-01*
