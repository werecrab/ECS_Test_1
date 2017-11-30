using Entitas.Unity;
using UnityEngine;

public class TimberScript : MonoBehaviour
{
    private GameContext _context;
    private IEntityObjectHandler _entityHandler;
    

    private void Awake()
    {
        //store context
        _context = Contexts.sharedInstance.game;
        
        //add entity
        _entityHandler = new EntityObjectHandler();
        var entity = _entityHandler.Init(_context, gameObject);
        
        //add appropriate components
        entity.AddPosition(transform.position);
    }

    private void OnDestroy()
    {
        //unlink and destroy entity
        _entityHandler.Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        CheckTriggeredObject(collidedObject, true);
    }
    private void OnTriggerExit2D(Collider2D collidedObject)
    {
        CheckTriggeredObject(collidedObject, false);
    }

    private void CheckTriggeredObject(Collider2D collidedObject, bool triggerEnter)
    {
        var collidedEntity = collidedObject.gameObject.GetEntityLink().entity as GameEntity;
        if (collidedEntity != null)
        {
            var collidedEntityId = collidedEntity.id.Id;
            var triggerEntity = _context.CreateEntity();
            triggerEntity.AddTrigger(_entityHandler.EntityId, collidedEntityId, triggerEnter); 
        }
        //else - we dont know what entity was "triggered" (no entity linked to collidedObject)
    }
}