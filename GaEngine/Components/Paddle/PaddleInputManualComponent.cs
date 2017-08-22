using System.Windows.Forms;

public class PaddleInputManualComponent : PaddleInputComponent
{

    public PaddleInputManualComponent(PaddlePhysicsComponent physics) : base(physics)
    {
    }

    public override void Update(Paddle paddle, Ball ball)
    {
        _physics.Velocity.Y = 0;
        if ( Input.Key.Pressed( Keys.Up ) ) _physics.Velocity.Y = -_physics.Speed;
        if ( Input.Key.Pressed( Keys.Down ) ) _physics.Velocity.Y = _physics.Speed;
    }
}
