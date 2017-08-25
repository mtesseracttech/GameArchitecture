using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GaGame.GameObjects;

public class PhysicsHandler : IPhysics
{
    public delegate void CollisionEventHandler(object sender, CollisionEventArgs e);
    public event CollisionEventHandler ObjectsCollided;

    private Dictionary<GameObject, PhysicsComponent> _pairs;
    private Vec2 _fieldBounds;

    public PhysicsHandler(Vec2 fieldBounds)
    {
        _pairs = new Dictionary<GameObject, PhysicsComponent>();
        _fieldBounds = fieldBounds;
    }
    
    public void Intersects(GameObject obj1, GameObject obj2, Vec2 obj1Size, Vec2 obj2Size)
    {
        Debug.Assert(obj1 != null && obj2 != null);
        Debug.Assert(obj1Size != null && obj2Size != null);
        
        bool collided = obj1.Position.X < obj2.Position.X+ obj2Size.X && obj1.Position.X + obj1Size.X > obj2.Position.X &&
               obj1.Position.Y < obj2.Position.Y+ obj2Size.Y && obj1.Position.Y + obj1Size.Y > obj2.Position.Y;

        if (collided)
        {
            OnObjectsCollided(obj1, obj2);
        }    
    }

    public Vec2 GameFieldBounds()
    {
        return _fieldBounds;
    }

    public void RegisterPhysicsComponent(GameObject gameObject, PhysicsComponent physics)
    {
        Debug.Assert(gameObject != null && physics != null);
        if (!_pairs.ContainsKey(gameObject))
        {
            _pairs.Add(gameObject, physics);
            Logger.Log("Successfully Registered " + gameObject.Name + " in the Physics Handler " + _pairs.Count, LogType.Debug);
        }
        else
        {
            Logger.Log(gameObject.Name + " was already present in the physics handler", LogType.Debug);
        }
    }

    protected virtual void OnObjectsCollided(GameObject obj1, GameObject obj2)
    {
        CreateEvent(obj1, obj2);
        CreateEvent(obj2, obj1);
    }
    
    private void CreateEvent(GameObject collider, GameObject collidee)
    {
        PhysicsComponent comp = null;
        
        if (_pairs.ContainsKey(collider))
        {
            comp = _pairs[collider];
            ObjectsCollided += comp.OnCollision;
        }
        
        if (ObjectsCollided != null)
        {
            ObjectsCollided(this, new CollisionEventArgs(collider, collidee));
            if (comp != null) ObjectsCollided -= comp.OnCollision;
        }
    }
}

public class CollisionEventArgs : EventArgs
{
    private GameObject _one;
    private GameObject _other;
    
    public CollisionEventArgs(GameObject one, GameObject other)
    {
        _one = one;
        _other = other;
    }

    public GameObject One { get { return _one; } }
    public GameObject Other{ get {return _other;} }
}