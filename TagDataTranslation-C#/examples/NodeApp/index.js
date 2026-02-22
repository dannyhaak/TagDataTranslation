/**
 * TagDataTranslation Node.js Example
 *
 * Demonstrates EPC tag data encoding and decoding using the @mimasu/tdt
 * WebAssembly package.
 *
 * Prerequisites:
 *   1. Build the WASM package: cd ../../npm && node scripts/build.js
 *   2. npm install
 *   3. node index.js
 */

const { createEngine } = require("@mimasu/tdt");

async function main() {
  console.log("=== TagDataTranslation Node.js Example ===\n");
  console.log("Loading WASM engine...");

  const engine = await createEngine();

  // check for scheme load errors
  const errors = engine.getLoadErrors();
  if (errors) {
    console.warn("Scheme load errors:", errors);
  }

  // decode: hex -> all representations
  const hex = "30340242201d8840009efdf7";
  const binary = engine.hexToBinary(hex);

  console.log(`\nDecode hex to all formats:`);
  console.log(`  Hex:           ${hex}`);
  console.log(`  Binary:        ${binary.substring(0, 32)}...`);

  const pureIdentity = engine.translate(binary, "tagLength=96", "PURE_IDENTITY");
  console.log(`  Pure Identity: ${pureIdentity}`);

  const tagUri = engine.translate(binary, "tagLength=96", "TAG_ENCODING");
  console.log(`  Tag URI:       ${tagUri}`);

  const legacy = engine.translate(binary, "tagLength=96", "LEGACY");
  console.log(`  Legacy:        ${legacy}`);

  // encode: GTIN + serial -> binary -> hex
  console.log(`\nEncode GTIN to hex:`);
  const input = "gtin=00037000302414;serial=10419703";
  const params = "filter=3;gs1companyprefixlength=7;tagLength=96";
  const encodedBinary = engine.translate(input, params, "BINARY");
  const encodedHex = engine.binaryToHex(encodedBinary);
  console.log(`  Input:  ${input}`);
  console.log(`  Hex:    ${encodedHex}`);

  // exception-free translation
  console.log(`\nTryTranslate with invalid input:`);
  const result = engine.tryTranslate("invalid-input", "", "BINARY");
  console.log(`  Result: ${result === null ? "null (translation failed gracefully)" : result}`);

  console.log("\nDone.");
}

main().catch((err) => {
  console.error("Error:", err);
  process.exit(1);
});
