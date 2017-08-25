using GaGame.GameObjects;

public interface IPhysics
{
    void Intersects(GameObject obj1, GameObject obj2, Vec2 obj1Size, Vec2 obj2Size);

    void RegisterPhysicsComponent(GameObject gameObject, PhysicsComponent physics);
}
