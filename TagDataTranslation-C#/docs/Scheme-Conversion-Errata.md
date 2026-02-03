# Scheme Conversion Errata

This document lists errors found in the JSON scheme files (`Schemes2/`) when comparing to the original XML scheme definitions.

## GRAI-96.json - BARE_IDENTIFIER Pattern

**Location:** `Schemes2/GRAI-96.json`, BARE_IDENTIFIER level

**Original XML:**
```
pattern="grai=([0-9]{15,26})"
```

**JSON (incorrect):**
```
"pattern": "^grai=([0-9]{14,25})$"
```

**Issue:**
- Minimum digits: XML says 15, JSON had 14
- Maximum digits: XML says 26, JSON had 25

The maximum of 26 digits is correct because:
- GRAI prefix: 14 digits (leading 0 + company prefix + asset type + check digit)
- Serial: up to 12 digits for GRAI-96 (max value 274877906943)
- Total: 14 + 12 = 26 digits

**Fixed:** Changed to `^grai=([0-9]{15,26})$`

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

*Last updated: 2026-02-03*
