# @mimasu/tdt

GS1 EPC Tag Data Translation for JavaScript and TypeScript, powered by WebAssembly.

Encode and decode all EPC schemes: SGTIN, SSCC, SGLN, GRAI, GIAI, GSRN, GDTI, and more. Supports TDS 2.3 with Digital Link URIs and '++' hostname encoding.

## Installation

```bash
npm install @mimasu/tdt
```

## Quick Start

```javascript
const { createEngine } = require("@mimasu/tdt");

async function main() {
  const engine = await createEngine();

  // decode hex to pure identity URI
  const binary = engine.hexToBinary("30340242201d8840009efdf7");
  const uri = engine.translate(binary, "tagLength=96", "PURE_IDENTITY");
  console.log(uri);
  // urn:epc:id:sgtin:0037000.030241.10419703
}

main();
```

## API

### `createEngine(): Promise<TDTEngine>`

Initialize the WASM engine. Must be called once before using translation methods.

### `engine.translate(epcIdentifier, parameterList, outputFormat): string`

Translate an EPC between encoding levels. Throws on error.

### `engine.tryTranslate(epcIdentifier, parameterList, outputFormat): string | null`

Translate without throwing. Returns null on failure.

### `engine.hexToBinary(hex): string`

Convert hexadecimal to binary string.

### `engine.binaryToHex(binary): string`

Convert binary string to hexadecimal.

## License

Business Source License 1.1. Production use requires a commercial license -- contact tdt@mimasu.nl.
