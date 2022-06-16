using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Base Stats", menuName = "Character/Stats")]
public class BaseStats : ScriptableObject
{
    public int level;
    [Space] [Header("Base Stats")] 
    public float health;
    [HideInInspector] public float mana;
    [HideInInspector] public float stamina;
    [HideInInspector] public float luck;
    public float speed;
    public int attack;
    [HideInInspector] public float defense;
    [HideInInspector] public float resistance;
    [HideInInspector] public float accuracy;
    public float evasion;
    [Range(0, 100)] public float critical;

    public List<float> GetStats()
    {
        return new List<float>
            {health, mana, stamina, luck, speed, attack, defense, resistance, accuracy, evasion, critical};
    }

    public int GetAttack()
    {
        var random = Random.Range(0, 100);
        if (random <= critical)
        {
            return attack * 2;
        }

        return attack;
    }
}