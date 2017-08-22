namespace GaGame.GaEngine.Paddle
{
    public class PaddlePhysicsManualComponent : PaddlePhysicsComponent
    {
        public override void Update(global::Paddle paddle, global::Ball ball)
        {
            paddle.Position.Add(Velocity);
        
            if(Intersects( ball.Position, ball.Size, paddle)) 
            {
                BallXReflect(ball, paddle);
            }

            TopBottomCheck(paddle);
        }
    }
}