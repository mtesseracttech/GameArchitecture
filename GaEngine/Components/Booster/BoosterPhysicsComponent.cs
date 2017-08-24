
public class BoosterPhysicsComponent : PhysicsComponent
{
    public BoosterPhysicsComponent()
    {
        _physicsService = PhysicsLocator.GetPhysics();
    }
    
    public void Update(Booster booster)
    {
        
    }
    
    public bool HitByBall(Booster booster, Ball ball)
    {
        return _physicsService.Intersects(booster.Position, booster.Size, ball.Position, ball.Size);
    }
}
