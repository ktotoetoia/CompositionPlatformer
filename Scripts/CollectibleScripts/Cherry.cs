using UnityEngine;

public class Cherry : Collectible
{
    [SerializeField] private float healPower = 20;

    public override void Collect(Collector collector)
    {
        if(collector.gameObject.TryGetComponent(out Health health))
        {
            health.Heal(healPower);
            base.Collect(collector);
        }
    }
}
