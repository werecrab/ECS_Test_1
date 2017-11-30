using Entitas;

public class GameSystemsFeature : Feature
{
	public GameSystemsFeature(Contexts contexts) : base ("Game Systems")
	{
		Add(new TriggerResolveSystem(contexts));
		Add(new LinkRemoveSystem(contexts));
		Add(new ForceApplierSystem(contexts));
		Add(new MoveSystem(contexts));
	}
}