using System;
using System.Windows.Forms;

public class BallInputComponent
{
    private readonly BallBehaviourComponent _behaviour;
    private IInput _input;
    
    public BallInputComponent(BallBehaviourComponent behaviour)
    {
        _behaviour = behaviour;
        _input = InputLocator.GetInput();
    }

    public void Update()
    {
        if( _input.Enter( Keys.P ) ) 
        {
            _behaviour.TogglePause();
        }
    }
}