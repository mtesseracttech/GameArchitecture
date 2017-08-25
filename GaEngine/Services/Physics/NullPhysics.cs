
using System;
using GaGame.GameObjects;

public class NullPhysics : IPhysics
{
    public void Intersects(GameObject obj1, GameObject obj2, Vec2 obj1Size, Vec2 obj2Size)
    {
    }

    public Vec2 GameFieldBounds()
    {
        return new Vec2(0,0);
    }

    public void RegisterPhysicsComponent(GameObject gameObject, PhysicsComponent physics)
    {
        Logger.Log("Failed to register a physicscomponent, because physics service is null");
    }
}
