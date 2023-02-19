using UnityEngine;
using UnityEngine.UI;
public class GemDisplay : MonoBehaviour
{
    [SerializeField] private GemEconomy gemEconomy;

    private Text gemCount;

    private void Start()
    {
        gemCount = GetComponentInChildren<Text>();

        gemEconomy.OnGemsChanged += UpdateGemCount;
    }

    private void UpdateGemCount(int amount)
    {
        gemCount.text = amount.ToString();
    }
}
