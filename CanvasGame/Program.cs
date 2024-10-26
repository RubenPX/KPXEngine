
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using KPX;
using KPX.Entity;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Implementation;

namespace CanvasGame;

public static partial class Program {
    
    public static int width = 800;
    public static int height = 600;
    
    public static JSObject canvas;
    private static Game game = new Game();
    
    [JSExport]
    public static void Main() {
        try {
            Initialize();
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            Console.WriteLine("Press any key to exit...");
        }
    }
    
    public static void Initialize() {
        canvas = WASM.InitializeCanvas(width, height);
        game.Init();
        
        var img = new GameObject(Global.images["sky"]);
        Global.gameObjects.Add(img);
        
        
        loop();
    }

    private static void loop() {
        game.loop();
        draw();
        
        WASM.requestAnimationFrame(loop);
    }

    private static void draw() {
        Global.gameObjects.ForEach(obj => {
            try {
                WASM.drawImage(canvas, obj.image.JSImageObject, obj.position.X, obj.position.Y);
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine(e.InnerException);
                throw;
            }
        });
    }
}