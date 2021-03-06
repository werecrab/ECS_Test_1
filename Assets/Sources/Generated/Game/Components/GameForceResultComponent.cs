//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ForceResultComponent forceResult { get { return (ForceResultComponent)GetComponent(GameComponentsLookup.ForceResult); } }
    public bool hasForceResult { get { return HasComponent(GameComponentsLookup.ForceResult); } }

    public void AddForceResult(UnityEngine.Vector2 newForceVector) {
        var index = GameComponentsLookup.ForceResult;
        var component = CreateComponent<ForceResultComponent>(index);
        component.ForceVector = newForceVector;
        AddComponent(index, component);
    }

    public void ReplaceForceResult(UnityEngine.Vector2 newForceVector) {
        var index = GameComponentsLookup.ForceResult;
        var component = CreateComponent<ForceResultComponent>(index);
        component.ForceVector = newForceVector;
        ReplaceComponent(index, component);
    }

    public void RemoveForceResult() {
        RemoveComponent(GameComponentsLookup.ForceResult);
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

    static Entitas.IMatcher<GameEntity> _matcherForceResult;

    public static Entitas.IMatcher<GameEntity> ForceResult {
        get {
            if (_matcherForceResult == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ForceResult);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherForceResult = matcher;
            }

            return _matcherForceResult;
        }
    }
}
