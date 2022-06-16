using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public int currentHealth;

    public BaseStats baseStats;
    
    public HealthBar healthBar;
    
    private void Start()
    {
        SetMaxHealth();
    }

    private void SetMaxHealth() => currentHealth = (int) baseStats.health;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Dead");
    }
}