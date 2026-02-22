#!/usr/bin/env node

/**
 * Smoke test for the @mimasu/tdt npm package.
 * Verifies basic encode/decode functionality.
 */

const { createEngine } = require("../dist/index.js");

async function main() {
  console.log("Loading TDT WASM engine...");
  const engine = await createEngine();

  // check for load errors
  const errors = engine.getLoadErrors();
  if (errors) {
    console.warn("Load errors:", errors);
  }

  // decode hex to pure identity
  const hex = "30340242201d8840009efdf7";
  const binary = engine.hexToBinary(hex);
  const pureIdentity = engine.translate(binary, "tagLength=96", "PURE_IDENTITY");

  console.log(`Hex:           ${hex}`);
  console.log(`Pure Identity: ${pureIdentity}`);

  const expected = "urn:epc:id:sgtin:0037000.030241.10419703";
  if (pureIdentity === expected) {
    console.log("\nSmoke test PASSED");
  } else {
    console.error(`\nSmoke test FAILED: expected ${expected}, got ${pureIdentity}`);
    process.exit(1);
  }
}

main().catch((err) => {
  console.error(err);
  process.exit(1);
});
