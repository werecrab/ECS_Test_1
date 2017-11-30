using Entitas.Unity;
using UnityEngine;

public class RiverScript : MonoBehaviour
{
    [SerializeField] private Vector2 _forceVector = Vector2.zero;
    public string EntityId { get; private set; }

    private void Awake()
    {
        //add river entity
        var context = Contexts.sharedInstance.game;
        var riverEntity = context.CreateEntity();
        //add components
        riverEntity.AddForceSource(_forceVector);               //force component
        gameObject.Link(riverEntity, context);
        EntityId = "river_" + riverEntity.creationIndex;        //store creation index
        riverEntity.AddId(EntityId);         //ID 
    }

    private void OnDestroy()
    {
        //TODO remove all links
    }
}
