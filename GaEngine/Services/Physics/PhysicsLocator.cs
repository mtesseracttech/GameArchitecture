public class PhysicsLocator
{
    public static void Initialize()
    {
        _service = _nullService;
    }

    public static IPhysics GetPhysics()
    {
        return _service;
    }

    public static void ProvidePhysics(IPhysics service)
    {
        if (service == null)
        {
            _service = _nullService;
        }
        else
        {
            Logger.Log("Received IPhysics Implementer", LogType.Debug);
            _service = service;
        }
    }

    private static IPhysics _service;
    private static readonly NullPhysics _nullService = new NullPhysics();
}