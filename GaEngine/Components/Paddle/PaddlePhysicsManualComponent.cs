
    public class PaddlePhysicsManualComponent : PaddlePhysicsComponent
    {
        public override void Update(Paddle paddle, Ball ball)
        {
            paddle.Position.Add(Velocity);
        
            if(HitsBall(paddle, ball)) 
            {
                BallXReflect(ball, paddle);
            }

            TopBottomCheck(paddle);
        }
    }
