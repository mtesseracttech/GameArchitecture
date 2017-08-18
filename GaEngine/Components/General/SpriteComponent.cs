using System.Diagnostics;
using System.Drawing;
using GaGame.GameObjects;

namespace GaGame.GaEngine
{
    public class SpriteComponent
    {
        private Image _image;
        
        public SpriteComponent(string imageFile)
        {
            _image = Image.FromFile( imageFile );
        }
        
        public void Update(Graphics graphics, Sprite sprite)
        {
            Debug.Assert(graphics != null );
            Debug.Assert(sprite != null );
            graphics.DrawImage(_image, sprite.Position.X, sprite.Position.Y );
        }

        public Image Image
        {
            get{ return _image; }
        }
    }
}