// entry point for the .NET WASM runtime (build-time requirement, not used directly by npm package)
import { dotnet } from './_framework/dotnet.js';

const { getAssemblyExports, getConfig } = await dotnet.create();

const exports = await getAssemblyExports(getConfig().mainAssemblyName);
export { exports };
