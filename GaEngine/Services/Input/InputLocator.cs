
public static class InputLocator
{
    public static void Initialize()
    {
        _service = _nullService;
    }
    
    public static IInput GetInput() { return _service; }
    
    public static void ProvideInput(IInput service)
    {
        if (service == null)
        {
            _service = _nullService;
        }
        else
        {
            Logger.Log("Received IInput Implementer", LogType.Debug);
            _service = service;
        }
    }
        
    private static IInput _service;
    private static readonly NullInput _nullService = new NullInput();
}
