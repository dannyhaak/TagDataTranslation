"use strict";

const path = require("path");

/**
 * @typedef {import('./index').TDTEngine} TDTEngine
 */

let _dotnetRuntime = null;

/**
 * Initialize the TDT WebAssembly engine.
 * @returns {Promise<TDTEngine>}
 */
async function createEngine() {
  if (!_dotnetRuntime) {
    // load the .NET WASM runtime
    const wasmPath = path.join(__dirname, "wasm");
    const { dotnet } = await import(
      path.join(wasmPath, "dotnet.js")
    );
    _dotnetRuntime = await dotnet.create();
  }

  const exports = _dotnetRuntime.getAssemblyExports(
    "TagDataTranslation.Wasm"
  );
  const interop = exports.TagDataTranslation.Wasm.JsInterop;

  return {
    translate: (epcIdentifier, parameterList, outputFormat) =>
      interop.Translate(epcIdentifier, parameterList, outputFormat),

    tryTranslate: (epcIdentifier, parameterList, outputFormat) =>
      interop.TryTranslate(epcIdentifier, parameterList, outputFormat),

    hexToBinary: (hex) => interop.HexToBinary(hex),

    binaryToHex: (binary) => interop.BinaryToHex(binary),

    getLoadErrors: () => interop.GetLoadErrors(),
  };
}

module.exports = { createEngine };
