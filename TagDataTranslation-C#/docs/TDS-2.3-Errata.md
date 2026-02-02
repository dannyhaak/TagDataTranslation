# TDS 2.3 Errata

This document lists errors found in the TDS 2.3 (Tag Data Standard) specification, Release 2.3, Ratified October 2025.

## Section E.3 - Summary Examples of All EPC Schemes

### Error 1: SGTIN++ (Table 509) - Incorrect Hostname

**Location:** Section E.3, Table 509 (page 357)

**Document states:**
- GS1 Digital Link URI: `https://example.com/01/79521141123453/21/32a%2Fb`
- Hostname: example.com

**Actual encoding:**
- The hex value `FD3795211411234538566CB0AFC525065F1876F0D996D800` decodes to hostname `id.example.com`, not `example.com`
- The hostname encoding uses the `id.` optimization sequence (0100000) followed by `example` and `.com` optimization

**Correct value:**
- Hostname: `id.example.com`
- Or correct hex for `example.com` would be: `FD3795211411234538566CB0AFC5232F8C3B786CCB6C`

---

### Error 2: DSGTIN++ (Table 510) - Incorrect Hostname

**Location:** Section E.3, Table 510 (page 357)

**Document states:**
- GS1 Digital Link URI: `https://example.com/01/79521141123453/21/32a%2Fb?17=220630`
- Hostname: example.com

**Actual encoding:**
- The hex value `FC342CDE795211411234538566CB0AFC525065F1876F0D996D80` decodes to hostname `id.example.com`, not `example.com`
- Same issue as SGTIN++ - uses `id.` optimization sequence

**Correct value:**
- Hostname: `id.example.com`

---

### Error 3: SSCC++ (Table 513) - Incorrect Header

**Location:** Section E.3, Table 513 (page 358)

**Document states:**
- EPC Binary Encoding (hex): `F9009520123456789123592832F8C3B786CCB6C0`

**Issue:**
- The hex starts with `F9` which is the SSCC+ header (11111001)
- SSCC++ should have header `EF` (11101111) per Table 14-1

**Correct value:**
- Header should be `EF`, not `F9`
- Correct hex should start with `EF...`

---

### Error 4: ITIP++ (Table 549) - Incorrect Header

**Location:** Section E.3, Table 549 (page 365)

**Document states:**
- EPC Binary Encoding (hex): `F3309521141123454010266AE27FDF3592832F8C3B786CCB6C00`

**Issue:**
- The hex starts with `F3` which is the ITIP+ header (11110011)
- ITIP++ should have header `ED` (11101101) per Table 14-1

**Correct value:**
- Header should be `ED`, not `F3`
- Correct hex should start with `ED...`

---

## Hostname Encoding Reference

For reference, the following hostname optimizations are defined in Table 14-11 (Optimisation Table A):

| 7-bit value | Decoded string |
|-------------|----------------|
| 0100000     | id.            |
| 0011110     | qr.            |
| 0011111     | www.           |
| 1011011     | .com           |
| 1011100     | .org           |
| 1011101     | .net           |
| 1011110     | .int           |
| 1100000     | .edu           |
| 1111011     | .gov           |
| 1111100     | .mil           |
| 1111101     | .biz           |
| 1111110     | .eco           |
| 1111111     | .med           |

When encoding hostnames, the length field indicates the number of 7-bit sequences, NOT the number of output characters. For example:
- `example.com` = 8 sequences (e, x, a, m, p, l, e, .com)
- `id.example.com` = 9 sequences (id., e, x, a, m, p, l, e, .com)

---

## Verification Method

These errors were discovered by:
1. Converting the hex values to binary
2. Parsing the binary according to the scheme structure defined in the standard
3. Decoding the hostname using the optimization tables from Section 14.5.16
4. Comparing the decoded hostname with the claimed hostname in E.3

The verification code and tests are available in `TagDataTranslationUnitTest/TDS23Tests.cs`.

---

*Last updated: 2026-02-01*
