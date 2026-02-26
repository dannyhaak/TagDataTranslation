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
// override TargetFrameworks on the referenced main csproj to avoid needing MAUI workloads on CI
execSync(
  `dotnet publish "${WASM_PROJECT}" -c Release /p:TargetFrameworks=net10.0`,
  { stdio: "inherit" }
);

// .NET 10 outputs to AppBundle/_framework/
const publishDir = path.join(ROOT, "sdk/wasm", "bin", "Release", "net10.0", "browser-wasm", "AppBundle", "_framework");
if (!fs.existsSync(publishDir)) {
  console.error(`Publish directory not found: ${publishDir}`);
  process.exit(1);
}

if (fs.existsSync(DIST_WASM)) {
  fs.rmSync(DIST_WASM, { recursive: true });
}
fs.mkdirSync(DIST_WASM, { recursive: true });

// copy framework files, skip source maps and symbol files
const skipPatterns = [".js.map", ".js.symbols"];
for (const file of fs.readdirSync(publishDir)) {
  if (skipPatterns.some((p) => file.endsWith(p))) continue;
  fs.copyFileSync(path.join(publishDir, file), path.join(DIST_WASM, file));
}

// patch boot config to remove wasmSymbols (prevents MONO_WASM symbol file warning)
const bootConfigPath = path.join(DIST_WASM, "dotnet.boot.js");
let bootConfig = fs.readFileSync(bootConfigPath, "utf8");
bootConfig = bootConfig.replace(
  /,\s*"wasmSymbols"\s*:\s*\[[^\]]*\]/,
  ""
);
fs.writeFileSync(bootConfigPath, bootConfig);

// copy license from repo root
const licenseSrc = path.join(ROOT, "LICENSING.md");
const licenseDst = path.join(__dirname, "..", "LICENSE.md");
fs.copyFileSync(licenseSrc, licenseDst);

console.log("Build complete. WASM files copied to dist/wasm/");
