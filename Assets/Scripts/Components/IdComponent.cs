using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Input]
public sealed class IdComponent : IComponent
{
    //string index used for qwick access to desired entity
    [PrimaryEntityIndex]
    public string Id;
}
