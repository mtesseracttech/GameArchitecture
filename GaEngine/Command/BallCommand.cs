using System.Diagnostics;

namespace GaGame.GaEngine
{
    public abstract class BallCommand
    {
        public abstract void Execute(Ball ball);
    }
    
    public class PauseCommand : BallCommand
    {
        public override void Execute(Ball ball)
        {
            Debug.Assert(ball?.Behaviour != null);
            ball.Behaviour.TogglePause();
        }
    }
}