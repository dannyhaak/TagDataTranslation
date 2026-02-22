# TagDataTranslation Node.js Example

Minimal Node.js application demonstrating EPC tag data encoding and decoding via WebAssembly.

## Prerequisites

Build the WASM package first:

```bash
cd ../../npm
node scripts/build.js
```

## Run

```bash
cd examples/NodeApp
npm install
node index.js
```

## Expected Output

```
=== TagDataTranslation Node.js Example ===

Loading WASM engine...

Decode hex to all formats:
  Hex:           30340242201d8840009efdf7
  Binary:        00110000001101000000001001000010...
  Pure Identity: urn:epc:id:sgtin:0037000.030241.10419703
  Tag URI:       urn:epc:tag:sgtin-96:3.0037000.030241.10419703
  Legacy:        gtin=00037000302414;serial=10419703

Encode GTIN to hex:
  Input:  gtin=00037000302414;serial=10419703
  Hex:    30340242201d8840009efdf7

TryTranslate with invalid input:
  Result: null (translation failed gracefully)

Done.
```
