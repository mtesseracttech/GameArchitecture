public class PaddlePhysicsAutoComponent : PaddlePhysicsComponent
{
    public override void Update(Paddle paddle, Ball ball)
    {
        paddle.Position.Add(Velocity);

        CheckBallCollision(paddle, ball);
        
        TopBottomCheck(paddle);
    }

    public override void OnCollision(object e, CollisionEventArgs args)
    {
        if (args.One is Paddle && args.Other is Ball)
        {
            Ball ball = (Ball) args.Other;
            Paddle paddle = (Paddle) args.One;
            BallXReflect(ball, paddle);
            ball.Velocity.Y = ( ball.Center.Y - paddle.Center.Y ) / 32 + ( (float)(Game.Random.NextDouble())-0.5f ) * 10.0f;
        }
    }
}