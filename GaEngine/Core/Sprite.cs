using System.Drawing;
using GaGame.GaEngine;

namespace GaGame.GameObjects
{
    public abstract class Sprite : GameObject
    {
        protected SpriteComponent _graphics;
        
        protected Sprite(string name, Vec2 position, string imageFile) : base(name, position)
        {
            _graphics = new SpriteComponent(imageFile);
        }
        
        public override void Render()
        {
            _graphics.Update(this);
        }

        public Vec2 Center 
        {
            get { return _position + 0.5f * Size; }
        }	
        
        public Vec2 Size 
        {
            get { return new Vec2( _graphics.Image.Width, _graphics.Image.Height ); }
        }
        
        public SpriteComponent Graphics
        {
            get { return _graphics; }
        }
    }
}