public class Food : CollectableObject
{
    public float HealAmount { get; private set; } = 20;

    public void Heal(IHealable healable)
    {
        healable.Heal(HealAmount);
    }
}

