
public class GraphicsLocator
{
    public static void Initialize()
    {
        _service = _nullService;
    }

    public static IGraphics GetGraphics() { return _service; }

    public static void ProvideGraphics(IGraphics service)
    {
        if (service == null)
        {
            _service = _nullService;
        }
        else
        {
            _service = service;
            Logger.Log("Received IGraphics Implementer", LogType.Debug);
        }
    }
    
    private static IGraphics _service;
    private static readonly NullGraphics _nullService = new NullGraphics();
}
