namespace GaGame.GameObjects
{
    public class Simple2DPhysics : IPhysics
    {
        public static void Register()
        {
            PhysicsLocator.ProvidePhysics(new Simple2DPhysics());
        }

        private Simple2DPhysics(){}
        
        public bool Intersects(Vec2 thisPosition, Vec2 thisSize, Vec2 otherPosition, Vec2 otherSize)
        {
            return thisPosition.X < otherPosition.X+otherSize.X && thisPosition.X + thisSize.X > otherPosition.X &&
                   thisPosition.Y < otherPosition.Y+otherSize.Y && thisPosition.Y + thisSize.Y > otherPosition.Y;
        }
    }
}