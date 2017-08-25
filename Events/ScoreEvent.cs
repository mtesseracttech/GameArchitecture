using System;

class ScoreEvent : Event
{
    public static EventHandler<ScoreEvent> Handlers;

    private readonly Side _side;
    private readonly int _score;
	
    public ScoreEvent( Side side, int score)
    {
        _side = side;
        _score = score;
    }

    public override void Deliver()
    {
        if( Handlers != null ) Handlers( this, this );
    }

    public Side Side
    {
        get { return _side; }
    }

    public int Score
    {
        get { return _score; }
    }
}