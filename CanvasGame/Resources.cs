using KPXEngine;
using KPXEngine.Graphics;

namespace CanvasGame;

public class Resources {
    public static void Initializeimages(EngineContext ctx) {
        ctx.images.Add("sky", Image.Create("/sprites/sky.png"));
        ctx.images.Add("ground", Image.Create("/sprites/ground.png"));
        ctx.images.Add("shadow", Image.Create("/sprites/shadow.png"));
        ctx.images.Add("rod", Image.Create("/sprites/rod.png"));
        ctx.images.Add("spritesheet", Image.Create("/sprites/spritesheet.png"));
        
        ctx.sprites.Add("sky", new Sprite(ctx.images["sky"], (320, 180)));
        ctx.sprites.Add("ground", new Sprite(ctx.images["ground"]));
        ctx.sprites.Add("shadow", new Sprite(ctx.images["shadow"]));
        ctx.sprites.Add("rod", new Sprite(ctx.images["rod"]));
        ctx.sprites.Add("spritesheet", new Sprite(ctx.images["spritesheet"]));
    }
}