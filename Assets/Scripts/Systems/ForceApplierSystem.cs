using Entitas;

public class ForceApplierSystem : IExecuteSystem
{
    readonly IGroup<GameEntity> _forceLinks;
    readonly GameContext _context;

    public ForceApplierSystem(Contexts contexts)
    {
        _context = contexts.game;
        _forceLinks = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Link));
    }

    public void Execute()
    {
        //iterate through all link entities and apply forces to its targets
        foreach (var entity in _forceLinks.GetEntities())
        {
            var forceEntity = _context.GetEntityWithId(entity.link.SourceEntityId);
            
            //somehow we're added link to absent force.. kill it and move on!
            if (!forceEntity.hasForceSource)
            {
                entity.Destroy();
                continue;
            }

            var targetEntity = _context.GetEntityWithId(entity.link.TargetEntityId);
            if (targetEntity.hasForceResult)
            {
                //some forces were applied already, add this one too
                targetEntity.ReplaceForceResult(targetEntity.forceResult.ForceVector +
                                                forceEntity.forceSource.ForceVector);
            }
            else
            {
                //first force applied
                targetEntity.AddForceResult(forceEntity.forceSource.ForceVector);
            }
        }
    }
}