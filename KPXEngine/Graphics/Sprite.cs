using System.Runtime.InteropServices.JavaScript;

namespace KPXEngine.Graphics;

public sealed class Sprite {
    public readonly Image image;
    public (int x, int y) frameSize;

    public int vFrames = 1;
    public int hFrames = 1;
    public int frameCount = 0;
    
    public int frame = 0;
    public int scale = 1;
    public Dictionary<int, (int x, int y)> frameMap = new Dictionary<int, (int x, int y)>();
    

    public Sprite(Image image, (int x, int y)? frameSize = null) {
        this.image = image;
        this.frameSize = frameSize ?? new(16, 16);
        this.buildFrameMap();
    }

    private void buildFrameMap() {
        int frameCount = 0;
        for (int v = 0; v < vFrames; v++) {
            for (int h = 0; h < hFrames; h++) {
                frameMap[frameCount] = (frameSize.x * h, frameSize.y * v);
            }
            frameCount++;
        }
    }

    internal void drawImage(JSObject canvas, int posX, int posY) {
        if (!image.isLoaded) return;

        (int x, int y) imageCords = new(0, 0);
        if (frameMap.ContainsKey(this.frame)) imageCords = frameMap[this.frame];
        
        WASM.DrawImage(
            canvas, 
            image.reference, 
            imageCords.x, 
            imageCords.y, 
            frameSize.x, 
            frameSize.y, 
            posX, 
            posY, 
            frameSize.x * scale, 
            frameSize.y * scale
        );
    }
}