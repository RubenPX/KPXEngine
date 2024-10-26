using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace KPX;

public static partial class WASM {
    [JSImport("createImage", "main.js")]
    public static partial JSObject CreateImage(string filename);

    [JSImport("drawImage", "main.js")]
    public static partial void drawImage(JSObject canvas, JSObject image, float x, float y);

    [JSImport("listenCallback", "main.js")]
    public static partial void lisenCallback(JSObject obj, string methodName, [JSMarshalAs<JSType.Function>] Action callback);
    
    [JSImport("initializeCanvas", "main.js")]
    public static partial JSObject InitializeCanvas(int width, int height);
    
    [JSImport("requestAnimationFrame", "main.js")]
    public static partial void requestAnimationFrame([JSMarshalAs<JSType.Function>] Action callback);
    
    [JSImport("log", "main.js")]
    public static partial void log(JSObject callback);
}