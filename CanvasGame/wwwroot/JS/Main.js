import { dotnet } from '/_framework/dotnet.js'
import { AttachWASMModules } from '/_content/KPXEngine/Extensions.js'

async function run() {
    let wasmEngine = await dotnet
        .withDiagnosticTracing(false)
        .withApplicationArgumentsFromQuery()
        .create();

    AttachWASMModules(wasmEngine);
    
    const config = wasmEngine.getConfig();
    const exports = await wasmEngine.getAssemblyExports(config.mainAssemblyName);
    
    let canvas = document.getElementById('screen');
    exports.CanvasGame.Program.Main(canvas);
}

run();
