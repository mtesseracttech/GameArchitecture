
public abstract class PhysicsComponent
{
    protected IPhysics _physicsService;
    
    public PhysicsComponent()
    {
        _physicsService = PhysicsLocator.GetPhysics();
    }
}
