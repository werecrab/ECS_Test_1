using Entitas;
using UnityEngine;

[Game]
public sealed class PositionComponent : IComponent
{
    //object position
    public Vector2 PositionVector;
}

[Game]
public sealed class RotationComponent : IComponent
{
    //object rotation (all hail to 2d! we need only 1 float)
    public float EulerAngle;
}

[Game]
public sealed class GameobjectComponent : IComponent
{
    //gameobject..
    public GameObject gameObject;
}