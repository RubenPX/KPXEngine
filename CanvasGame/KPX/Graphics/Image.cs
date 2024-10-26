using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;

namespace KPX.Graphics;

public class Image {
    public readonly string src;
    internal JSObject JSImageObject;

    private Image(string src) {
        this.src = src;
    }
    
    public bool isLoaded { get; private set; }

    public static Image Create(string src) {
        Image image = new(src);
        image.JSImageObject = WASM.CreateImage(src);
        // image.init();
        return image;
    }

    public void init() {
        Action update = () => isLoaded = true;
        WASM.lisenCallback(JSImageObject, "onload", update);
    }
}