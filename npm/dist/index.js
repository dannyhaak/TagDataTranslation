"use strict";

const path = require("path");

/**
 * @typedef {import('./index').TDTEngine} TDTEngine
 */

let _runtime = null;
let _exports = null;

/**
 * Initialize the TDT WebAssembly engine.
 * @returns {Promise<TDTEngine>}
 */
async function createEngine() {
  if (!_exports) {
    const wasmPath = path.join(__dirname, "wasm");
    const { dotnet } = await import(
      "file://" + path.join(wasmPath, "dotnet.js")
    );
    const { getAssemblyExports, getConfig, runMain } = await dotnet.create();

    const config = getConfig();
    _exports = await getAssemblyExports(config.mainAssemblyName);

    // run Main to ensure the runtime is fully initialized
    await runMain();
  }

  const interop = _exports.TagDataTranslation.Wasm.JsInterop;

  return {
    translate: (epcIdentifier, parameterList, outputFormat) =>
      interop.Translate(epcIdentifier, parameterList, outputFormat),

    tryTranslate: (epcIdentifier, parameterList, outputFormat) =>
      interop.TryTranslate(epcIdentifier, parameterList, outputFormat),

    translateDetails: (epcIdentifier, parameterList, outputFormat) => {
      const json = interop.TranslateDetails(epcIdentifier, parameterList, outputFormat);
      return json ? JSON.parse(json) : null;
    },

    hexToBinary: (hex) => interop.HexToBinary(hex),

    binaryToHex: (binary) => interop.BinaryToHex(binary),

    getLoadErrors: () => interop.GetLoadErrors(),
  };
}

module.exports = { createEngine };
