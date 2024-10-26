import { dotnet } from '/_framework/dotnet.js'
import * as Extensions from "./Extensions.js";

'/JS/Extensions.js'

function InitCanvas(width, height) {
    let canvas = document.getElementById('screen');
    canvas.width = width;
    canvas.height = height;

    let context = canvas.getContext('2d');
    
    context.mozImageSmoothingEnabled = false;
    context.webkitImageSmoothingEnabled = false;
    context.msImageSmoothingEnabled = false;
    context.imageSmoothingEnabled = false;
    
    return context;
}

async function run() {
    const wasm = await dotnet
        .withDiagnosticTracing(false)
        .withApplicationArgumentsFromQuery()
        .create();

    wasm.setModuleImports('main.js', {
        initializeCanvas: (width, height) => InitCanvas(width, height),
        createImage: (src) => Extensions.createImage(src),
        drawImage: (context, img, x, y) => Extensions.drawImage(context, img, x, y),
        listenCallback: (obj, methodName, callback) => Extensions.lisenCallback(obj, methodName, () => callback()),
        requestAnimationFrame: (callback) => window.requestAnimationFrame(() => callback()),
        log: (any) => console.log(any)
    });

    const config = wasm.getConfig();
    const exports = await wasm.getAssemblyExports(config.mainAssemblyName);
    
    exports.CanvasGame.Program.Main();
}

run();
