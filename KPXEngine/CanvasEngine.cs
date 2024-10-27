using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using KPXEngine.Entity;
using KPXEngine.Graphics;
using Microsoft.JSInterop;

namespace KPXEngine;

// This class provides an example of how JavaScript functionality can be wrapped
// in a .NET class for easy consumption. The associated JavaScript module is
// loaded on demand when first needed.
//
// This class can be registered as scoped DI service and then injected into Blazor
// components for use.

public abstract class CanvasEngine<Context> where Context : EngineContext {
    private JSObject canvas;
    public CanvasEngine(JSObject canvas, int width, int height) {
        this.canvas = WASM.InitializeCanvas(canvas, width, height);;
    }

    public void RunGame() {
        var ctx = Init();
        internalLoop(ctx);
    }

    private void internalLoop(Context ctx) {
        ctx = Loop(ctx);
        draw(ctx);
        WASM.RequestAnimationFrame(() => internalLoop(ctx));
    }
    
    public abstract Context Init();
    public abstract Context Loop(Context context);

    private void draw(Context ctx) {
        foreach (GameObject gameObject in ctx.gameObjects.Values) {
            gameObject.draw(canvas);
        }
    }
}