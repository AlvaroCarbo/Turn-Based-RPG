using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public int currentHealth;

    public BaseStats stats;
    
    public HealthBar healthBar;
    
    private void Start()
    {
        SetMaxHealth();
    }

    private void SetMaxHealth() => currentHealth = (int) stats.health;

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
        CombatManager.Instance.state = CombatState.Finished;
    }
}