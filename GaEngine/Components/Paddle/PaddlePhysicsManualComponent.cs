public class PaddlePhysicsManualComponent : PaddlePhysicsComponent
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
            BallXReflect((Ball)args.Other, (Paddle)args.One);
        }
    }
}
