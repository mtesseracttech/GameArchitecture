using GaGame.GameObjects;

public abstract class PaddleInputComponent
{
    protected PaddlePhysicsComponent _physics;

    public PaddleInputComponent(PaddlePhysicsComponent physics)
    {
        _physics = physics;
    }
    
    public abstract void Update(Paddle paddle, Ball ball);
}
