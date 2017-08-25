namespace GaGame.GaEngine.Services.Score
{
    public class ScoreLocator
    {
        public static void Initialize()
        {
            _service = _nullService;
        }

        public static IScore GetScore()
        {
            return _service;
        }

        public static void ProvideScore(IScore service)
        {
            if (service == null)
            {
                _service = _nullService;
            }
            else
            {
                Logger.Log("Received IScore Implementer", LogType.Debug);
                _service = service;
            }
        }
        
        private static IScore _service;
        private static readonly NullScore _nullService = new NullScore();
    }
}