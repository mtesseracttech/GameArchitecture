using System;
using System.Diagnostics;
using System.Drawing.Text;
using GaGame.GaEngine;

public enum BoosterState
{
    Active,
    Inactive
}

public class BoosterBehaviourComponent : BehaviourComponent
{   
    private BoosterState _state;
    private Ball _ball;

    public BoosterBehaviourComponent(Ball ball)
    {
        _state = BoosterState.Active;
        _ball = ball;
    }
    
    public void Update(Booster booster)
    {
        Debug.Assert(booster != null);
    }

    private void DeBoost(object sender,  Time.TimeoutEvent timeout)
    {
        _ball.DeBoost(); //No idea how to get ball here through a direct line, so I had to store it in the class
        _state = BoosterState.Active;
    }

    public void BoostBall(Ball ball)
    {
        _state = BoosterState.Inactive;
        _ball.Boost();
        Time.Timeout( "Deboosting", 0.5f, DeBoost );
    }
    
    public void Reset(Booster booster) 
    {
        booster.Position.X = 320-8;
        booster.Position.Y = 240-8;
    }

    public BoosterState State
    {
        get { return _state; }
        set { _state = value; }
    }
}