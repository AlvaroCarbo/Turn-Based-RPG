using System;
using UnityEngine;
using Random = System.Random;

[CreateAssetMenu(fileName = "New Base Stats", menuName = "Character/Stats")]
public class BaseStats : ScriptableObject
{
        public int level;
        // public BaseAttributes baseAttributes;
        
        // Base Stats
        [Space]
        [Header("Base Stats")]
        public float health;
        public float mana;
        public float stamina;
        public float luck;
        public float speed;
        public float attack;
        public float defense;
        public float resistance;
        public float accuracy;
        
        public float evasion;
        
        [Range(0, 100)]
        public float critical;

        
}