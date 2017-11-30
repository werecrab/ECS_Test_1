using System.Collections.Generic;
using Entitas;

public class TriggerResolveSystem : ReactiveSystem<GameEntity>
{
	private readonly GameContext _context;
	public TriggerResolveSystem(Contexts contexts) : base(contexts.game)
	{
		_context = contexts.game;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Trigger);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasTrigger;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			var triggeredEntity1 = _context.GetEntityWithId(entity.trigger.SourceEntityId);
			var triggeredEntity2 = _context.GetEntityWithId(entity.trigger.TargetEntityId);

			ProcessForceSourceTrigger(triggeredEntity1, triggeredEntity2, entity.trigger.TriggerEnter);
			ProcessForceSourceTrigger(triggeredEntity2, triggeredEntity1, entity.trigger.TriggerEnter);
			
			entity.Destroy();
		}
	}

	private void ProcessForceSourceTrigger(GameEntity forceEntity, GameEntity targetEntity, bool addLink)
	{
		if (!forceEntity.hasForceSource || !targetEntity.hasPosition) 
			return;
		
		if (addLink)
		{
			var entityId = string.Format(GameConsts.ForceLinkIdPrefix, targetEntity.id.Id, forceEntity.id.Id);
			if (_context.GetEntityWithId(entityId) == null)
			{
				var linkEntity = _context.CreateEntity();
				linkEntity.AddLink(targetEntity.id.Id, forceEntity.id.Id);
				linkEntity.AddId(entityId);
			}
		}
		else
		{
			var removeLinkEntity = _context.CreateEntity();
			removeLinkEntity.AddLinkRemove(targetEntity.id.Id, forceEntity.id.Id);
		}
	}
}