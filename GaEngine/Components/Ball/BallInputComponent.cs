using System;
using System.Windows.Forms;
using GaGame.GaEngine;

public class BallInputComponent : InputComponent
{
    private readonly BallBehaviourComponent _behaviour;
    private BallCommand _keyP;
    
    
    public BallInputComponent(BallBehaviourComponent behaviour)
    {
        _behaviour = behaviour;
        _keyP = new PauseCommand();
    }

    public void Update(Ball ball)
    {
        if (_inputService.Enter(Keys.P))
        {
            _keyP.Execute(ball);
        }
    }
}