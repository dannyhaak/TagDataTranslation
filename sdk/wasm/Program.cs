// WASM entry point — required by the runtime but unused for library-style interop
// force the trimmer to preserve RuntimeInformation (Mono WASM resolves it by token at startup)
_ = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
return 0;
