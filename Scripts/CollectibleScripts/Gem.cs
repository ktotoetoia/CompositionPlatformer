using UnityEngine;

public class Gem : Collectible
{
    [SerializeField] private int price = 1;

    public override void Collect(Collector collector)
    {
        if(collector.gameObject.TryGetComponent(out GemEconomy gemEconomy))
        {
            gemEconomy.AddGems(price);
            base.Collect(collector);
        }
    }
}
