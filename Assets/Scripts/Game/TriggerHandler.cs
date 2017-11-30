using Entitas.Unity;
using UnityEngine;

public class TriggerHandler
{
	private GameContext _context;
	private string _entityId;
	
	public void Init(GameContext context, string entityId)
	{
		_context = context;
		_entityId = entityId;
	}
	
	private void OnTriggerEnter2D(Collider2D collidedObject)
	{
		//Trigger enter fired, create appropriate trigger entity
		var collidedEntity = collidedObject.gameObject.GetEntityLink().entity as GameEntity;
		if (collidedEntity != null)
		{
			var collidedEntityId = collidedEntity.id.Id;
			var triggerEntity = _context.CreateEntity();
			triggerEntity.AddTrigger(_entityId, collidedEntityId, true); 
		}
		//else - we dont know what entity was "triggered" (no entity linked to collidedObject)
	}
	private void OnTriggerExit2D(Collider2D collidedObject)
	{
		//Trigger exit fired, create appropriate trigger entity
		var collidedEntity = collidedObject.gameObject.GetEntityLink().entity as GameEntity;
		if (collidedEntity != null)
		{
			var collidedEntityId = collidedEntity.id.Id;
			var triggerEntity = _context.CreateEntity();
			triggerEntity.AddTrigger(_entityId, collidedEntityId, false); 
		}
		//else - we dont know what entity was "triggered" (no entity linked to collidedObject)
	}
}
