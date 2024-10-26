using System.Numerics;
using KPX.Graphics;

namespace KPX.Entity;

public class GameObject(Image img) {
    public Image image = img;
    public Vector2 position = Vector2.Zero;
    public int renderPriority = 0;
}