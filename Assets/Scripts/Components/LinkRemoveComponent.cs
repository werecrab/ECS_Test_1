using Entitas;

[Game]
public sealed class LinkRemoveComponent : IComponent
{
    //remove link with folllowing IDs
    public string TargetEntityId;
    public string SourceEntityId;
}
