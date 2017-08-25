using System;
using System.Diagnostics;
using System.Drawing;
using GaGame.GaEngine;
using GaGame.GaEngine.Services.Score;
using GaGame.GameObjects;

public class BallPhysicsComponent : PhysicsComponent
{
    private Vec2 _velocity;
    private readonly Vec2 _speed;
    private Size _playfieldSize;


    public BallPhysicsComponent(Vec2 velocity, Vec2 speed, Size playfieldSize)
    {
        _velocity = velocity;
        _speed = speed;
        _playfieldSize = playfieldSize;
        Debug.Assert(_playfieldSize != null);
    }
        
    public void Update(Ball ball)
    {
        Debug.Assert(ball != null);
        if( ball.Position.Y < 0 ) 
        { 
            ball.Position.Y = 0;
            _velocity.Y = -_velocity.Y;
        }
        if( ball.Position.Y > _playfieldSize.Height-ball.Size.Y ) 
        {
            ball.Position.Y = _playfieldSize.Height-ball.Size.Y;
            _velocity.Y = -_velocity.Y;
        }
    }
    
    public void Boost() 
    {
        _velocity = _velocity * 2.0f;
    }

    public void DeBoost() {
        _velocity = _velocity / 2.0f;
    }

    public Vec2 Velocity
    {
        get { return _velocity; }
    }

    public Vec2 Speed
    {
        get { return _speed; }
    }
}  