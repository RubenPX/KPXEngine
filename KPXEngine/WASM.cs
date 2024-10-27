using System.Runtime.InteropServices.JavaScript;

namespace KPXEngine;

public static partial class WASM {
    [JSImport("initializeCanvas", "Extensions.js")]
    internal static partial JSObject InitializeCanvas(JSObject canvas, int width, int height);
    
    [JSImport("requestAnimationFrame", "Extensions.js")]
    internal static partial void RequestAnimationFrame([JSMarshalAs<JSType.Function>] Action callback);
    
    [JSImport("createImage", "Extensions.js")]
    public static partial JSObject CreateImage(string filename, [JSMarshalAs<JSType.Function>] Action onLoad);

    [JSImport("drawImage", "Extensions.js")]
    public static partial void DrawImage(JSObject canvas, JSObject image, int imageX, int imageY, int width, int height, int posX, int posY, int scaleX, int scaleY);

    [JSImport("listenCallback", "Extensions.js")]
    public static partial void LisenCallback(JSObject obj, string methodName, [JSMarshalAs<JSType.Function>] Action callback);
    
    [JSImport("log", "Extensions.js")]
    public static partial void log(JSObject callback);
}