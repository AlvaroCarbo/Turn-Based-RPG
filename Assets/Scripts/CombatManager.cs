using System;
using System.Collections;
using UI;
using UnityEngine;

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

        yield return new WaitForSeconds(0.5f);
        if (isFast)
        {
            HandleTurn(CombatState.PlayerTurn);
            yield return new WaitForSeconds(1f);
            HandleTurn(CombatState.EnemyTurn);
        }
        else
        {
            HandleTurn(CombatState.EnemyTurn);
            yield return new WaitForSeconds(1f);
            HandleTurn(CombatState.PlayerTurn);
        }

        yield return new WaitForSeconds(0.5f);

        if (state != CombatState.Finished)
        {
            state = CombatState.Waiting;
            CombatUIController.Instance.attackButton.interactable = true;
        }
        
        CombatUIController.Instance.SetStateText(state);
    }

    private void HandleTurn(CombatState newState)
    {
        CombatUIController.Instance.SetStateText(state);
        if (state == CombatState.Finished)
        {
            return;
        }

        state = newState;

        switch (state)
        {
            case CombatState.PlayerTurn:
                var playerDamage = player.stats.GetAttack();
                DecreaseHealth(enemy, playerDamage);
                CombatUIController.Instance.SetPlayerLastAttack(playerDamage);
                break;
            case CombatState.EnemyTurn:
                var enemyDamage = enemy.stats.GetAttack();
                DecreaseHealth(player, enemyDamage);
                CombatUIController.Instance.SetEnemyLastAttack(enemyDamage);
                break;
            case CombatState.Waiting:
            case CombatState.Finished:
            default:
                throw new ArgumentOutOfRangeException();
        }
    }


    private void DecreaseHealth(CharacterBase character, int damage)
    {
        if (character.currentHealth <= 0)
        {
            return;
        }

        character.TakeDamage(damage);
        character.healthBar.SetHealth(character.currentHealth);
    }
}