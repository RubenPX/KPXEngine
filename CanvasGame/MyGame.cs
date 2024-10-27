using System.Runtime.InteropServices.JavaScript;
using KPXEngine;
using KPXEngine.Entity;
using KPXEngine.Graphics;

namespace CanvasGame;

public class MyGame : CanvasEngine<EngineContext> {
    public MyGame(JSObject canvas, int width, int height) : base(canvas, width, height) {
        
    }

    public override EngineContext Init() {
        var context = new EngineContext();
        
        Resources.Initializeimages(context);
        
        context.gameObjects.Add("sky", new GameObject(context.sprites["sky"]));
        
        return context;
    }

    public override EngineContext Loop(EngineContext context) {
        return context;
    }
}