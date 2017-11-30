using Entitas;

[Game]
public sealed class LinkComponent : IComponent
{
    //this component used to declare link between 2 entitis (via its id)
    public string TargetEntityId;
    public string SourceEntityId;
}
