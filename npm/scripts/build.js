#!/usr/bin/env node

/**
 * Build script for the @mimasu/tdt npm package.
 * Compiles the .NET WASM project and copies output to dist/wasm/.
 */

const { execSync } = require("child_process");
const fs = require("fs");
const path = require("path");

const ROOT = path.resolve(__dirname, "..", "..");
const WASM_PROJECT = path.join(ROOT, "sdk/wasm", "TagDataTranslation.Wasm.csproj");
const DIST_WASM = path.join(__dirname, "..", "dist", "wasm");

console.log("Building TagDataTranslation.Wasm...");
execSync(
  `dotnet publish "${WASM_PROJECT}" -c Release -o "${path.join(ROOT, "sdk/wasm", "bin", "publish")}"`,
  { stdio: "inherit" }
);

// copy WASM output to dist/wasm/
const publishDir = path.join(ROOT, "sdk/wasm", "bin", "publish", "wwwroot", "_framework");
if (fs.existsSync(DIST_WASM)) {
  fs.rmSync(DIST_WASM, { recursive: true });
}
fs.mkdirSync(DIST_WASM, { recursive: true });

// copy all framework files
for (const file of fs.readdirSync(publishDir)) {
  fs.copyFileSync(path.join(publishDir, file), path.join(DIST_WASM, file));
}

console.log("Build complete. WASM files copied to dist/wasm/");
