public interface IPhysics
{
    bool Intersects(Vec2 thisPosition, Vec2 thisSize, Vec2 otherPosition, Vec2 otherSize);
}
