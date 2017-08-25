
using System;
using System.Diagnostics;

public class BoosterPhysicsComponent : PhysicsComponent
{
    private BoosterBehaviourComponent _behaviour;
    private Ball _ball;
    
    public BoosterPhysicsComponent(BoosterBehaviourComponent behaviour, Ball ball)
    {
        _physicsService = PhysicsLocator.GetPhysics();
        _behaviour = behaviour;
        _ball = ball;
    }
    
    public void Update(Booster booster)
    {
        
        HitByBall(booster, _ball);
    }
    
    public void HitByBall(Booster booster, Ball ball)
    {
        _physicsService.Intersects(booster, ball, booster.Size, ball.Size);
    }

    public override void OnCollision(object e, CollisionEventArgs args)
    {
        Debug.Assert(args != EventArgs.Empty);

        if (_behaviour.State == BoosterState.Active && args.Other is Ball)
        {
            Ball ball = (Ball)args.Other;
            _behaviour.BoostBall(ball);
        }
    }
}
