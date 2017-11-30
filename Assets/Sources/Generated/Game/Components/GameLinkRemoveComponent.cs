//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LinkRemoveComponent linkRemove { get { return (LinkRemoveComponent)GetComponent(GameComponentsLookup.LinkRemove); } }
    public bool hasLinkRemove { get { return HasComponent(GameComponentsLookup.LinkRemove); } }

    public void AddLinkRemove(string newTargetEntityId, string newSourceEntityId) {
        var index = GameComponentsLookup.LinkRemove;
        var component = CreateComponent<LinkRemoveComponent>(index);
        component.TargetEntityId = newTargetEntityId;
        component.SourceEntityId = newSourceEntityId;
        AddComponent(index, component);
    }

    public void ReplaceLinkRemove(string newTargetEntityId, string newSourceEntityId) {
        var index = GameComponentsLookup.LinkRemove;
        var component = CreateComponent<LinkRemoveComponent>(index);
        component.TargetEntityId = newTargetEntityId;
        component.SourceEntityId = newSourceEntityId;
        ReplaceComponent(index, component);
    }

    public void RemoveLinkRemove() {
        RemoveComponent(GameComponentsLookup.LinkRemove);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLinkRemove;

    public static Entitas.IMatcher<GameEntity> LinkRemove {
        get {
            if (_matcherLinkRemove == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LinkRemove);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLinkRemove = matcher;
            }

            return _matcherLinkRemove;
        }
    }
}
