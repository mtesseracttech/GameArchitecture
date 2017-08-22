using System.Drawing.Text;

public enum BoosterState
{
    Active,
    Inactive
}

public class BoosterBehaviourComponent
{   
    private BoosterState _state = BoosterState.Inactive;
    private BoosterPhysicsComponent _physics;
    private Ball _ball;

    public BoosterBehaviourComponent(BoosterPhysicsComponent physics, Ball ball)
    {
        _physics = physics;
        _state = BoosterState.Active;
        _ball = ball;
    }
    
    public void Update(Booster booster)
    {
        if( _state == BoosterState.Active && _physics.Intersects( _ball.Position, _ball.Size, booster ) ) 
        {
            _state = BoosterState.Inactive;
            _ball.Boost();
            Time.Timeout( "Deboosting", 0.5f, DeBoost );
        }
    }

    private void DeBoost(object sender,  Time.TimeoutEvent timeout)
    {
        _ball.DeBoost(); //No idea how to get ball here through a direct line, so I had to store it in the class
        _state = BoosterState.Active;
    }
    
    public void Reset(Booster booster) 
    {
        booster.Position.X = 320-8;
        booster.Position.Y = 240-8;
    }

}