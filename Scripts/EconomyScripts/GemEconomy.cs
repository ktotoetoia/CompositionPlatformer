using UnityEngine;

public class GemEconomy : MonoBehaviour
{
    private int gemCount;
    public int GemCount { get { return gemCount;} }

    public delegate void GemsChanged(int amount);
    public event GemsChanged OnGemsChanged;

    public void AddGems(int amount)
    {
        gemCount += amount;
        OnGemsChanged?.Invoke(gemCount);
    }
}
