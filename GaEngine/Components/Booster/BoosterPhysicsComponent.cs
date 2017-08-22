
public class BoosterPhysicsComponent
{
    public void Update(Booster booster)
    {
    }
    
    public bool Intersects( Vec2 otherPosition, Vec2 otherSize, Booster booster) {
        return
            booster.Position.X < otherPosition.X+otherSize.X && booster.Position.X + booster.Size.X > otherPosition.X &&
            booster.Position.Y < otherPosition.Y+otherSize.Y && booster.Position.Y + booster.Size.Y > otherPosition.Y;
    }
}
