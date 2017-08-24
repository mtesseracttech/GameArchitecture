using System;
using System.Windows.Forms;
using GaGame.GaEngine;

public class BallInputComponent : InputComponent
{
    private readonly BallBehaviourComponent _behaviour;
    
    public BallInputComponent(BallBehaviourComponent behaviour)
    {
        _behaviour = behaviour;
    }

    public void Update()
    {
        if( _inputService.Enter( Keys.P ) ) 
        {
            _behaviour.TogglePause();
        }
    }
}