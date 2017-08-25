using System.Drawing.Text;
using System.Windows.Forms;
using GaGame.GaEngine;

public class PaddleInputManualComponent : PaddleInputComponent
{
    private PaddleCommand _up;
    private PaddleCommand _down;
    
    public PaddleInputManualComponent(PaddlePhysicsComponent physics) : base(physics)
    {
        _up = new PedalCommandMoveUp();
        _down = new PedalCommandMoveDown();
    }

    public override void Update(Paddle paddle, Ball ball)
    {
        _physics.Velocity.Y = 0;

        if (_inputService.Pressed(Keys.Up))   _up.Execute(paddle);
        if (_inputService.Pressed(Keys.Down)) _down.Execute(paddle);
    }
    
    
}
