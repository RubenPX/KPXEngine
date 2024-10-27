using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;

namespace KPXEngine.Graphics;

public class Image {
    public readonly string src;
    internal JSObject reference;

    private Image(string src) {
        this.src = src;
    }
    
    public bool isLoaded { get; private set; }

    public static Image Create(string src) {
        Image image = new(src);
        Action onLoad = () => image.isLoaded = true;
        image.reference = WASM.CreateImage(src, onLoad);
        return image;
    }
}