using System.Drawing;

public interface IGraphics
{
    void DrawSprite(Image image, Vec2 position);
    void DrawSpriteSelection(Image image, Vec2 position, Vec2 rectCorner, Vec2 rectSize);
}
