using System;
using System.Diagnostics;
using GaGame.GaEngine;
using GaGame.GameObjects;

public class BallPhysicsComponent
{
    private Vec2 _velocity;
    public readonly Vec2 _speed;

    public BallPhysicsComponent(Vec2 velocity, Vec2 speed)
    {
        _velocity = velocity;
        _speed = speed;
    }
        
    public void Update(Ball ball)
    {
        Console.WriteLine("Ball velocity: " + _velocity);
        if( ball.Position.Y < 0 ) 
        { 
            ball.Position.Y = 0;
            _velocity.Y = -_velocity.Y;
        }
        if( ball.Position.Y > 480-16 ) 
        {
            ball.Position.Y = 480-16;
            _velocity.Y = -_velocity.Y;
        }
    }
    
    public void Boost() {
        _velocity = _velocity * 2.0f;
    }

    public void DeBoost() {
        _velocity = _velocity / 2.0f;
    }

    public Vec2 Velocity
    {
        get { return _velocity; }
    }
    
    public bool Intersects(Ball ball, Vec2 otherPosition, Vec2 otherSize) {
        return
            ball.Position.X < otherPosition.X+otherSize.X && ball.Position.X + ball.Size.X > otherPosition.X &&
            ball.Position.Y < otherPosition.Y+otherSize.Y && ball.Position.Y + ball.Size.Y > otherPosition.Y;
    }
}