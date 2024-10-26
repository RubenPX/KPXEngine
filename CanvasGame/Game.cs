using KPX.Graphics;

namespace CanvasGame;

public class Game {
    public void Init() {
        /* LOAD IMAGES */
        Global.images.Add("sky", Image.Create("/sprites/sky.png"));
        Global.images.Add("ground", Image.Create("/sprites/ground.png"));
        Global.images.Add("hero", Image.Create("/sprites/shadow.png"));
        Global.images.Add("rod", Image.Create("/sprites/rod.png"));
        Global.images.Add("spritesheet", Image.Create("/sprites/spritesheet.png"));
    }

    public void loop() {
        
    }
}