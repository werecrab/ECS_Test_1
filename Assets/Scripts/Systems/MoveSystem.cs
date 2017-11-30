using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class MoveSystem : ReactiveSystem<GameEntity>
{
    //this system moves object as a react on result force appearance;
    public MoveSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ForceResult);
    }

    protected override bool Filter(GameEntity entity)
    {
        //find all entities with 1. result force and 2. position component
        return entity.hasForceResult && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            var resPosition = entity.position.PositionVector + entity.forceResult.ForceVector;
            entity.RemoveForceResult();         //force applied, and should be removed. Does it generate unnecessary relaunch of this reactive system ?
            entity.ReplacePosition(resPosition);
            if(entity.hasGameobject)            //move to another system?
                entity.gameobject.gameObject.transform.position = new Vector3(resPosition.x, resPosition.y, entity.gameobject.gameObject.transform.position.z);
        }
    }
}