
using GaGame.GameObjects;

public abstract class PhysicsComponent
{
    protected IPhysics _physicsService;
    
    public PhysicsComponent()
    {
        _physicsService = PhysicsLocator.GetPhysics();
    }

    public virtual void OnCollision(object e, CollisionEventArgs args)
    {
        Logger.Log(args.Me.Name + " hit " + args.Other.Name);
    }
}
