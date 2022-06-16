using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class CharacterBase : MonoBehaviour
{
    public int currentHealth;

    public BaseStats stats;

    public HealthBar healthBar;
    
    public TMP_Text healthText;

    private void Start()
    {
        SetMaxHealth();

        SetHealthText();
    }

    public void SetHealthText()
    {
        healthText.text = currentHealth.ToString();
    }

    private void SetMaxHealth() => currentHealth = (int) stats.health;

    public bool TakeDamage(int damage)
    {
        if (AvoidDamage())
        {
            return false;
        }


        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

        healthBar.SetHealth(currentHealth);
        SetHealthText();
        return true;
    }

    private bool AvoidDamage() => Random.Range(0, 100) <= stats.evasion;
    
    private void Die() => CombatManager.Instance.state = CombatState.Finished;
    
}