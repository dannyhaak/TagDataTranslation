# @mimasu/tdt

**Encode and decode GS1 EPC identifiers for RAIN (UHF) RFID in JavaScript and TypeScript.** Convert between GTIN, SSCC, SGLN, and 50+ other formats — from barcode to EPC hex and back.

Powered by WebAssembly. No native dependencies. Works in Node.js and browsers.

Implements the **GS1 EPC Tag Data Standard (TDS) 2.3** and **Tag Data Translation (TDT) 2.2** specifications.

**Try it online**: https://www.mimasu.nl/tag-data-translation/try-online

## Installation

```bash
npm install @mimasu/tdt
```

## Quick Start

### Encode a GTIN to EPC Hex

```javascript
import { createEngine } from "@mimasu/tdt";

const engine = await createEngine();

// encode GTIN + serial to SGTIN-96 binary
const epc = engine.translate(
  "gtin=00037000302414;serial=10419703",
  "filter=3;gs1companyprefixlength=7;tagLength=96",
  "BINARY"
);
const hex = engine.binaryToHex(epc);
console.log(hex);
// 30340242201d8840009efdf7
```

### Decode EPC Hex to GTIN

```javascript
const binary = engine.hexToBinary("30340242201d8840009efdf7");
const uri = engine.translate(binary, "", "PURE_IDENTITY");
console.log(uri);
// urn:epc:id:sgtin:0037000.030241.10419703
```

### CommonJS

```javascript
const { createEngine } = require("@mimasu/tdt");

async function main() {
  const engine = await createEngine();
  // ...
}
main();
```

## Use Cases

- **Tag programming**: Encode GTINs and SSCCs to EPC hex for writing to RFID tags
- **Tag reading**: Decode EPC hex from RFID readers back to human-readable identifiers
- **Inventory systems**: Translate between barcode and RFID representations
- **Supply chain apps**: Convert between GS1 Digital Link URIs and EPC binary

## API

### `createEngine(): Promise<TDTEngine>`

Initialize the WASM engine. Call once, reuse the engine instance for all translations.

### `engine.translate(epcIdentifier, parameterList, outputFormat): string`

Translate an EPC between encoding levels. Output formats: `BINARY`, `LEGACY`, `LEGACY_AI`, `TAG_ENCODING`, `PURE_IDENTITY`.

Throws on invalid input.

### `engine.tryTranslate(epcIdentifier, parameterList, outputFormat): string | null`

Same as `translate`, but returns `null` instead of throwing. Use this for high-throughput scenarios.

### `engine.hexToBinary(hex): string`

Convert hexadecimal string to binary string.

### `engine.binaryToHex(binary): string`

Convert binary string to hexadecimal string.

## Supported Schemes

SGTIN-96, SGTIN-198, SSCC-96, SGLN-96, SGLN-195, GRAI-96, GRAI-170, GIAI-96, GIAI-202, GSRN-96, GSRNP-96, GDTI-96, GDTI-113, GDTI-174, SGCN-96, ITIP-110, ITIP-212, GID-96, CPI-96, CPI-var, ADI-var, USDOD-96, plus all TDS 2.3 '+' and '++' variants with Digital Link URI support.

## Performance

The underlying .NET engine runs as compiled WebAssembly — no interpretation overhead.

| Operation | Time |
|-----------|------|
| SGTIN-96 encode | 7.8 us |
| SGTIN-96 decode | 7.7 us |
| HexToBinary (96-bit) | 99 ns |
| BinaryToHex (96-bit) | 54 ns |

## License

Business Source License 1.1 (BSL-1.1). Non-production use (development, testing, evaluation) is free. Production use requires a commercial license — contact tdt@mimasu.nl.

See [LICENSING.md](https://github.com/dannyhaak/TagDataTranslation/blob/master/LICENSING.md) for full details.
