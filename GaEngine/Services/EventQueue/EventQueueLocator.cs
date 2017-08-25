
using GaGame.GaEngine.Services.EventQueue;

public class EventQueueLocator
{
    public static void Initialize()
    {
        _service = _nullService;
    }

    public static IEventQueue GetEventQueue() { return _service; }

    public static void ProvideEventQueue(IEventQueue service)
    {
        if (service == null)
        {
            _service = _nullService;
        }
        else
        {
            _service = service;
            Logger.Log("Received IEventQueue Implementer", LogType.Debug);
        }
    }

    private static IEventQueue _service;
    private static readonly NullEventQueue _nullService = new NullEventQueue();
}
