public abstract class CollectableObject : SpawnableObject
{
    public override void Disable()
    {
        RaiseOnDisabled();
    }
}
