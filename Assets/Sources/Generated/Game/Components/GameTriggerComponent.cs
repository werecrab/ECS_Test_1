//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TriggerComponent trigger { get { return (TriggerComponent)GetComponent(GameComponentsLookup.Trigger); } }
    public bool hasTrigger { get { return HasComponent(GameComponentsLookup.Trigger); } }

    public void AddTrigger(string newTargetEntityId, string newSourceEntityId, bool newTriggerEnter) {
        var index = GameComponentsLookup.Trigger;
        var component = CreateComponent<TriggerComponent>(index);
        component.TargetEntityId = newTargetEntityId;
        component.SourceEntityId = newSourceEntityId;
        component.TriggerEnter = newTriggerEnter;
        AddComponent(index, component);
    }

    public void ReplaceTrigger(string newTargetEntityId, string newSourceEntityId, bool newTriggerEnter) {
        var index = GameComponentsLookup.Trigger;
        var component = CreateComponent<TriggerComponent>(index);
        component.TargetEntityId = newTargetEntityId;
        component.SourceEntityId = newSourceEntityId;
        component.TriggerEnter = newTriggerEnter;
        ReplaceComponent(index, component);
    }

    public void RemoveTrigger() {
        RemoveComponent(GameComponentsLookup.Trigger);
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

    static Entitas.IMatcher<GameEntity> _matcherTrigger;

    public static Entitas.IMatcher<GameEntity> Trigger {
        get {
            if (_matcherTrigger == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Trigger);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTrigger = matcher;
            }

            return _matcherTrigger;
        }
    }
}
