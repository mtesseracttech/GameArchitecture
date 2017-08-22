using System;
using System.Windows.Forms;

public class BallInputComponent
{
    private readonly BallBehaviourComponent _behaviour;
    
    public BallInputComponent(BallBehaviourComponent behaviour)
    {
        _behaviour = behaviour;
    }

    public void Update()
    {
        if( Input.Key.Enter( Keys.P ) ) 
        {
            _behaviour.TogglePause();
        }
    }
}