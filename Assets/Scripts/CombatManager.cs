using System;
using System.Collections;
using UI;
using UnityEngine;
using Random = System.Random;

public enum CombatState
{
    Waiting,
    PlayerTurn,
    EnemyTurn,
    Finished
}

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    public CombatState state;

    public int turn;

    [Space] [Header("Combat Settings")] public PlayerBase player;
    public EnemyBase enemy;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player.healthBar.SetMaxHealth(player.currentHealth);
        enemy.healthBar.SetMaxHealth(enemy.currentHealth);

        state = CombatState.Waiting;
    }

    public IEnumerator RunNextTurn()
    {
        CombatUIController.Instance.SetTurnText(turn++);

        var isFast = player.stats.speed >= enemy.stats.speed;

        if (isFast)
        {
            HandleTurn(CombatState.PlayerTurn);
            yield return new WaitForSeconds(0.5f);
            HandleTurn(CombatState.EnemyTurn);
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            HandleTurn(CombatState.EnemyTurn);
            yield return new WaitForSeconds(0.5f);
            HandleTurn(CombatState.PlayerTurn);
            yield return new WaitForSeconds(0.5f);
        }

        if (state != CombatState.Finished)
        {
            state = CombatState.Waiting;
            CombatUIController.Instance.attackButton.interactable = true;
        }

        CombatUIController.Instance.SetStateText(state);
    }

    private void HandleTurn(CombatState newState)
    {
        if (state == CombatState.Finished)
        {
            return;
        }

        state = newState;

        CombatUIController.Instance.SetStateText(state);

        switch (state)
        {
            case CombatState.PlayerTurn:
                Attack(player, enemy);
                break;
            case CombatState.EnemyTurn:
                Attack(enemy,player);
                break;
            case CombatState.Waiting:
            case CombatState.Finished:
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Attack(CharacterBase attacker, CharacterBase defender)
    {
        Debug.Log($"==============={attacker.name} Attacks to {defender.name}================");
        var damage = attacker.stats.CalculateAttack();
        Debug.Log($"{attacker.name} base attacks for {damage}, critical {attacker.stats.attack < damage}");
        var luck = attacker.stats.CalculateLuck();
        damage += luck;
        Debug.Log($"{attacker.name} luck is {luck}");
        var accuracy = attacker.stats.CalculateAccuracy();
        Debug.Log($"{attacker.name} accuracy is {accuracy}");
        damage *= accuracy ? 1 : 0;
        Debug.Log($"{attacker.name} actual attacks for {damage}");
        var takeDamage = defender.TakeDamage(damage);
        Debug.Log($"{defender.name} took  {takeDamage} damage");
        CombatUIController.Instance.SetLastAttack(takeDamage ? damage : 0, attacker.name == "Player");
        Debug.Log($"==============={attacker.name} Attacks to {defender.name}================");
    }
}