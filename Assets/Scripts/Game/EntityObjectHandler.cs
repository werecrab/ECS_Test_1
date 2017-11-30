using Entitas.Unity;
using UnityEngine;

public class EntityObjectHandler: IEntityObjectHandler
{
	public string EntityId { get; private set; }
	private GameContext _context;
	public GameEntity Init(GameContext context, GameObject gameObject = null)
	{
		//store context
		_context = context;
		//add entity
		var entity = context.CreateEntity();
		//add components
		var entityName = "undefined";
		if (gameObject != null)
		{
			entity.AddGameobject(gameObject);                       //GO reference component
			gameObject.Link(entity, context);                       //link entity to GO
			entityName = gameObject.name;
		}
		EntityId = string.Format("{0}_{1}", entityName, 
			entity.creationIndex);    								//store creation index
		entity.AddId(EntityId);
		
		return entity;
	}

	public void Destroy(GameObject gameObject = null)
	{
		var entity = _context.GetEntityWithId(EntityId);
		entity.Destroy();
		if(gameObject != null)
			gameObject.Unlink();
	}
}

public interface IEntityObjectHandler
{
	string EntityId { get; }
	GameEntity Init(GameContext context, GameObject gameObject);
	void Destroy(GameObject gameObject);
}
