using System.Diagnostics;
using System.Drawing;

namespace GaGame.GameObjects
{
    public class RenderContext : IGraphics
    {
        private Graphics _graphics;
        
        public void SetGraphics(Graphics graphics)
        {
            _graphics = graphics;
        }
        
        public void DrawSprite(Image image, Vec2 position)
        {
            Debug.Assert(_graphics != null);
            Debug.Assert(image != null);
            _graphics.DrawImage(image, position.X, position.Y);
        }

        public void DrawSpriteSelection(Image image, Vec2 position, Vec2 rectCorner, Vec2 rectSize)
        {
            Debug.Assert(_graphics != null);
            Debug.Assert(image != null);
            Rectangle rect = new Rectangle((int)rectCorner.X, (int)rectCorner.Y, (int)rectSize.X, (int)rectSize.Y);
            _graphics.DrawImage( image, position.X, position.Y, rect, GraphicsUnit.Pixel );
        }
    }
}