function InitCanvas(canvas, width, height) {
    // let canvas = document.getElementById('screen');
    canvas.width = width;
    canvas.height = height;

    let context = canvas.getContext('2d');

    context.mozImageSmoothingEnabled = false;
    context.webkitImageSmoothingEnabled = false;
    context.msImageSmoothingEnabled = false;
    context.imageSmoothingEnabled = false;

    return context;
}

function createImage(src, onLoad) {
    let img =  new Image()
    img.src = src;
    img.onload = () => onLoad();
    return img;
}

// (JSObject canvas, JSObject image, int imageX, int imageY, int width, int height, int posX, int posY, int scaleX, int scaleY);

function drawImage(canvas, img, imageX, imageY, width, height, posX, posY, scaleX, scaleY) {
    canvas.drawImage(img, imageX, imageY, width, height, posX, posY, scaleX, scaleY);
}



function lisenCallback(obj, methodName, callback) {
    obj[methodName] = callback;
}

export function AttachWASMModules(wasm) {
    wasm.setModuleImports('Extensions.js', {
        initializeCanvas: (canvas, width, height) => InitCanvas(canvas, width, height),
        createImage: (src, onload) => createImage(src, onload),
        drawImage: (canvas, img, imageX, imageY, width, height, posX, posY, scaleX, scaleY) => drawImage(canvas, img, imageX, imageY, width, height, posX, posY, scaleX, scaleY),
        listenCallback: (obj, methodName, callback) => lisenCallback(obj, methodName, () => callback()),
        requestAnimationFrame: (callback) => window.requestAnimationFrame(() => callback()),
        log: (any) => console.log(any)
    });
}