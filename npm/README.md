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

## Performance

The underlying .NET engine translates a typical SGTIN-96 in ~8 us. Hex/binary conversion completes in under 100 ns. The WASM bridge adds minimal overhead on top of the native .NET performance.

| Operation | .NET native |
|-----------|-------------|
| SGTIN-96 encode | 7.8 us |
| SGTIN-96 decode | 7.7 us |
| HexToBinary (96-bit) | 99 ns |
| BinaryToHex (96-bit) | 54 ns |

## License

Business Source License 1.1. Production use requires a commercial license -- contact tdt@mimasu.nl.
