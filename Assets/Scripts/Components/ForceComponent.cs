using Entitas;
using UnityEngine;

[Game]
public sealed class ForceSourceComponent : IComponent
{
    //force source component
    public Vector2 ForceVector;
}

[Game]
public sealed class ForceResultComponent : IComponent
{
    //sum of all forces applied to the object
    public Vector2 ForceVector;
}