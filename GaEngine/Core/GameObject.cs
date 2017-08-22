using System.Drawing;

namespace GaGame.GameObjects
{
    public abstract class GameObject
    {
        protected Vec2 _position;
        protected string _name;

        protected GameObject(string name, Vec2 position)
        {
            _name = name;
            _position = position;
        }

        public string Name
        {
            get { return _name; }
        }

        public Vec2 Position
        {
            get { return _position; }
        }

        public virtual void Update(){}
        
        public virtual void Render(Graphics graphics){}
        
        public virtual void ProcessInput(){}
    }
}