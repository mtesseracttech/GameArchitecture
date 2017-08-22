using System;
using GaGame.GameObjects;

public class PaddleInputAutoComponent : PaddleInputComponent
{
    public override void Update(Paddle paddle, Ball ball)
    {
        _physics.Velocity.Y = 0; // no move 
        if ( ball.Position.Y+8 > paddle.Position.Y+32 + 8 ) _physics.Velocity.Y = +_physics.Speed;
        if ( ball.Position.Y+8 < paddle.Position.Y+32 - 8 ) _physics.Velocity.Y = -_physics.Speed;
    }

    public PaddleInputAutoComponent(PaddlePhysicsComponent physics) : base(physics){}
}