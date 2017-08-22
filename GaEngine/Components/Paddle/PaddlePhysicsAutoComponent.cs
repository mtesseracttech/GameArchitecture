using System;

public class PaddlePhysicsAutoComponent : PaddlePhysicsComponent
{
    public override void Update(Paddle paddle, Ball ball)
    {
        paddle.Position.Add(Velocity);
        
        if( Intersects( ball.Position, ball.Size, paddle) ) 
        {
            BallXReflect(ball, paddle);
            ball.Velocity.Y = ( ball.Center.Y - paddle.Center.Y ) / 32 + ( (float)(Game.Random.NextDouble())-0.5f ) * 10.0f; // curve randomly
        }
        
        TopBottomCheck(paddle);
    }
}