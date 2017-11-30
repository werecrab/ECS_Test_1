using Entitas;

[Game]
public sealed class TriggerComponent : IComponent
{
    //this component used to declare triggered collision between 2 entitis (via its id)
    public string TargetEntityId;
    public string SourceEntityId;
    public bool TriggerEnter;
}
