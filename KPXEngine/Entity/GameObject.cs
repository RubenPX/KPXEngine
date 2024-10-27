using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using KPXEngine.Graphics;

namespace KPXEngine.Entity;

public class GameObject(Sprite sprite) {
    public readonly Sprite sprite = sprite;
    public Vector2 position = Vector2.Zero;
    public int renderPriority = 0;

    internal void draw(JSObject canvas) {
        sprite.drawImage(canvas, (int)position.X, (int)position.Y);
    }
}