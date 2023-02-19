using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();

        slider.maxValue = health.GetMaxHealth();
        slider.value = health.GetMaxHealth();

        health.OnHealthChanged += UpdateHealthBar;
    }

    private void UpdateHealthBar(float amount)
    {
        slider.value = amount;
    }
}
