// entry point for the .NET WASM runtime
import { dotnet } from './_framework/dotnet.js';

const { getAssemblyExports, getConfig } = await dotnet.create();

const exports = getAssemblyExports(getConfig().mainAssemblyName);
export { exports };
