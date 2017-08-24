public abstract class PaddlePhysicsComponent
{
    protected Vec2 _velocity;
    protected float _speed;
    protected IPhysics _physicsService;
    
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

    protected bool HitsBall(Paddle paddle, Ball ball)
    {
        return _physicsService.Intersects(paddle.Position, paddle.Size, ball.Position, ball.Size);
    }
    
    /*protected bool Intersects( Vec2 otherPosition, Vec2 otherSize, Paddle paddle) {
        return
            paddle.Position.X < otherPosition.X+otherSize.X && paddle.Position.X + paddle.Size.X > otherPosition.X &&
            paddle.Position.Y < otherPosition.Y+otherSize.Y && paddle.Position.Y + paddle.Size.Y > otherPosition.Y;
    }*/
}