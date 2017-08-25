
using System;
using System.Diagnostics;
using GaGame.GaEngine;

public abstract class PhysicsComponent
{
    protected IPhysics _physicsService;
    protected Vec2 _center;
    protected Vec2 _size;
    protected GraphicsComponent _graphics;

    protected PhysicsComponent()
    {
        _physicsService = PhysicsLocator.GetPhysics();
    }

    public virtual void OnCollision(object e, CollisionEventArgs args)
    {
        Logger.Log(args.One.Name + " hit " + args.Other.Name);
    }
}
