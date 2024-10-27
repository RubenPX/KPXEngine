using System.Runtime.InteropServices.JavaScript;
using KPXEngine;
using KPXEngine.Entity;

namespace CanvasGame;

public static partial class Program {
    
    public static int width = 320;
    public static int height = 180;
    
    [JSExport]
    public static void Main(JSObject canvas) {
        try {
            MyGame game = new MyGame(canvas, width, height);
            game.RunGame();
        } catch (Exception e) {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            Console.WriteLine("Press any key to exit...");
        }
    }
}