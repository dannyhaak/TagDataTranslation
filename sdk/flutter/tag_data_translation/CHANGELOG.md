## 3.0.2

- AOT-safe JSON serialization (source-generated JsonSerializerContext)
- CI pipeline fixes

## 3.0.0

- Initial release
- dart:ffi bindings to NativeAOT-compiled TagDataTranslation library
- Supports all GS1 EPC schemes: SGTIN-96, SGTIN-198, SSCC-96, SGLN, GRAI, GIAI, GSRN, GDTI, SGCN
- TDS 2.3 '+' and '++' scheme support with GS1 Digital Link URIs
- Pure Dart `hexToBinary` and `binaryToHex` utilities
- iOS (arm64) and Android (arm64-v8a, x86_64) native libraries
