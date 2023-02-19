using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    private float health;

    public delegate void HealthChanged(float health);
    public event HealthChanged OnHealthChanged;

    private void Start()
    {
        health = maxHealth;
    }

    public void Heal(float amount)
    {
        if(health+amount > maxHealth) health = maxHealth;

        else health +=amount;

        OnHealthChanged?.Invoke(health);
    }

    public void ApplyDamage(float amount)
    {
        if (health - amount <= 0) health = 0;

        else health -= amount;

        OnHealthChanged?.Invoke(health);
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}