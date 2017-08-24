using System;
using System.Diagnostics;

public enum StateBall
{
    Active,
    Pausing
}

public class BallBehaviourComponent
{
    private readonly BallPhysicsComponent _physics;
    private StateBall _stateBall;
    
    public BallBehaviourComponent(BallPhysicsComponent physics)
    {
        _stateBall = StateBall.Pausing;
        _physics = physics;
    }
    
    public void Update(Ball ball)
    {
        Debug.Assert(ball != null);
        if( _stateBall == StateBall.Active ) 
        {
            ball.Position.Add( _physics.Velocity );
        }
    }
    
    public StateBall BallState
    {
        get { return _stateBall; }
        set { _stateBall = value; }
    }
    
    public void Reset(Ball ball) //not really sure where this method should be... has both properties of physics and behaviour to it
    {
        ball.Position.X = 320-8;
        ball.Position.Y = 240-8;
        _physics.Velocity.X = _physics._speed.X;
        _physics.Velocity.Y = (float)(Game.Random.NextDouble() - 0.5) * 2.0f *_physics._speed.Y;
        _stateBall = StateBall.Pausing;
        Time.Timeout( "Reset", 1.0f, Restart );	// restart after 1 sec.
    }
    
    public void Restart( Object sender,  Time.TimeoutEvent timeout )
    {
        _stateBall = StateBall.Active;
        Logger.Log("Restart");
    }

    public void TogglePause()
    {
        _stateBall = _stateBall == StateBall.Active ? StateBall.Pausing : StateBall.Active;
        Logger.Log( _stateBall == StateBall.Active ? "Resuming" : "Pausing");
    }
}
