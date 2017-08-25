using System.Diagnostics;

namespace GaGame.GaEngine
{
    public abstract class PaddleCommand
    {
        public abstract void Execute(Paddle paddle);
    }

    public class PedalCommandMoveUp : PaddleCommand
    {
        public override void Execute(Paddle paddle)
        {
            Debug.Assert(paddle != null);
            Debug.Assert(paddle.Physics != null);

            PaddlePhysicsComponent physics = paddle.Physics;
            physics.Velocity.Y = -physics.Speed;
        }
    }
    
    public class PedalCommandMoveDown : PaddleCommand
    {
        public override void Execute(Paddle paddle)
        {
            Debug.Assert(paddle != null);
            Debug.Assert(paddle.Physics != null);

            PaddlePhysicsComponent physics = paddle.Physics;
            physics.Velocity.Y = physics.Speed;
        }
    }
}