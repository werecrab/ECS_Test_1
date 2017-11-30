using System.Collections.Generic;
using Entitas;

public class LinkRemoveSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    public LinkRemoveSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LinkRemove);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLinkRemove;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            //get target link entity by its id and destroy it
            var linkEntity = _context.GetEntityWithId(string.Format(GameConsts.ForceLinkIdPrefix,
                entity.linkRemove.TargetEntityId, entity.linkRemove.SourceEntityId));
            if(linkEntity != null)
                linkEntity.Destroy();
            entity.Destroy();
        }
    }
}