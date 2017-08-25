
public class ScoreManager : IScore
{
    private int _leftScore;
    private int _rightScore;

    public ScoreManager()
    {
        ResetScores();
    }

    public void IncScore(Side side)
    {
        Logger.Log(side + " scored!", LogType.Info);
        switch (side)
        {
                case Side.Left:
                    _leftScore++;
                    EventQueueLocator.GetEventQueue().Post(new ScoreEvent(Side.Left, _leftScore));
                    break;
                case Side.Right:
                    _rightScore++;
                    EventQueueLocator.GetEventQueue().Post(new ScoreEvent(Side.Right, _rightScore));
                    break;
        }
        EventQueueLocator.GetEventQueue().Deliver();
    }

    public void ResetScores()
    {
        _leftScore = 0;
        _rightScore = 0;
    }
}

public enum Side
{
    Left, Right
}