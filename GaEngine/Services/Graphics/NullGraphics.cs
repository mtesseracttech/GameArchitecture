using System.Drawing;

public class NullGraphics : IGraphics
{
    public void DrawSprite(Image image, Vec2 position){}
    public void DrawSpriteSelection(Image image, Vec2 textPosition, Vec2 rectCorner, Vec2 rectSize) {}
}