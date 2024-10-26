export function drawImage(canvas, img, x, y) {
    canvas.drawImage(img, 0, 0);
}

export function createImage(src) {
    let img =  new Image()
    img.src = src;
    return img;
}

export function lisenCallback(obj, methodName, callback) {
    obj[methodName] = callback;
}