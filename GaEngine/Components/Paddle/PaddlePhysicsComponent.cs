public abstract class PaddlePhysicsComponent : PhysicsComponent
{
    protected Vec2 _velocity;
    protected float _speed;
    
    public PaddlePhysicsComponent()
    {
        _velocity = new Vec2( 0, 0 );
        _speed = 5.0f;
        _physicsService = PhysicsLocator.GetPhysics();
    }

    public abstract void Update(Paddle paddle, Ball ball);

    protected void TopBottomCheck(Paddle paddle)
    {
        if( paddle.Position.Y < 0 )   paddle.Position.Y = 0;
        if( paddle.Position.Y > 416 ) paddle.Position.Y = 416;
    }

    protected void BallXReflect(Ball ball, Paddle paddle)
    {
        if( ball.Velocity.X > 0 )
        {
            ball.Position.X = paddle.Position.X - ball.Size.X;
        } 
        else if( ball.Velocity.X < 0 ) 
        {
            ball.Position.X = paddle.Position.X + paddle.Size.X;
        }
        ball.Velocity.X = -ball.Velocity.X;
    }
    
    public Vec2 Velocity
    {
        get { return _velocity; }
    }

    public float Speed
    {
        get { return _speed; }
    }

    protected void CheckBallCollision(Paddle paddle, Ball ball)
    {
        _physicsService.Intersects(paddle, ball, paddle.Size, ball.Size);
    }
}