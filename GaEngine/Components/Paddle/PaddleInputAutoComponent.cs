using System;
using GaGame.GaEngine;
using GaGame.GameObjects;

public class PaddleInputAutoComponent : PaddleInputComponent
{
    private PaddleCommand _up;
    private PaddleCommand _down;

    public PaddleInputAutoComponent(PaddlePhysicsComponent physics) : base(physics)
    {
        _up = new PedalCommandMoveUp();
        _down = new PedalCommandMoveDown();
    }
    
    public override void Update(Paddle paddle, Ball ball)
    {
        _physics.Velocity.Y = 0;
        
        if (ball.Position.Y + paddle.Size.X < paddle.Position.Y + paddle.Size.Y/2 - paddle.Size.X)   _up.Execute(paddle);
        if (ball.Position.Y + paddle.Size.X > paddle.Position.Y + paddle.Size.Y/2 + paddle.Size.X) _down.Execute(paddle);
    }
}