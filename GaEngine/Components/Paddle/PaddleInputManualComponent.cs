using System.Windows.Forms;

public class PaddleInputManualComponent : PaddleInputComponent
{
    private IInput _input;
    
    
    public PaddleInputManualComponent(PaddlePhysicsComponent physics) : base(physics)
    {
        _input = InputLocator.GetInput();
    }

    public override void Update(Paddle paddle, Ball ball)
    {
        _physics.Velocity.Y = 0;
        if ( _input.Pressed( Keys.Up ) ) _physics.Velocity.Y = -_physics.Speed;
        if ( _input.Pressed( Keys.Down ) ) _physics.Velocity.Y = _physics.Speed;
    }
}
