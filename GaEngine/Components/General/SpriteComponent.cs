using System.Diagnostics;
using System.Drawing;
using GaGame.GameObjects;

namespace GaGame.GaEngine
{
    public class SpriteComponent : GraphicsComponent
    {
        private Image _image;
        
        public SpriteComponent(string imageFile)
        {
            _image = Image.FromFile( imageFile );
            _graphicsService = GraphicsLocator.GetGraphics();
        }
        
        public void Update(Sprite sprite)
        {
            Debug.Assert(sprite != null );
            _graphicsService.DrawSprite(_image, sprite.Position);
        }

        public Image Image
        {
            get{ return _image; }
        }
    }
}