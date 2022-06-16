using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Base Stats", menuName = "Character/Stats")]
public class BaseStats : ScriptableObject
{
    public int level;
    [Space] [Header("Base Stats")] public int health;
    [HideInInspector] public int mana;
    [HideInInspector] public int stamina;
    public int luck;
    public int speed;
    public int attack;
    [HideInInspector] public int defense;
    [HideInInspector] public int resistance;
    public int accuracy;
    public int evasion;
    [Range(0, 100)] public int critical;

    public List<int> GetStats()
    {
        return new List<int>
            {health, mana, stamina, luck, speed, attack, defense, resistance, accuracy, evasion, critical};
    }

    public int CalculateAttack()
    {
        var random = Random.Range(1, 101);
        if (random <= critical)
        {
            return attack * 2;
        }

        return attack;
    }

    public bool CalculateAccuracy() => Random.Range(1, 101) <= accuracy;
    
    public int CalculateLuck() => Random.Range(0, luck + 1);
    
}