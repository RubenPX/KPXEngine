using KPXEngine.Entity;
using KPXEngine.Graphics;

namespace KPXEngine;

public class EngineContext {
    public Dictionary<string, Image> images { get; } = new Dictionary<string, Image>();
    public Dictionary<string, Sprite> sprites { get; } = new Dictionary<string, Sprite>();
    public Dictionary<string, GameObject> gameObjects { get; } = new Dictionary<string, GameObject>();
}