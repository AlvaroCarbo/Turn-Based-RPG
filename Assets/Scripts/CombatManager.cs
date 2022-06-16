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
                PlayerAttack();
                break;
            case CombatState.EnemyTurn:
                EnemyAttack();
                break;
            case CombatState.Waiting:
            case CombatState.Finished:
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void PlayerAttack()
    {
        var playerDamage = player.stats.GetAttack();
        CombatUIController.Instance.SetPlayerLastAttack(enemy.TakeDamage(playerDamage) ? playerDamage : 0);
    }

    private void EnemyAttack()
    {
        var enemyDamage = enemy.stats.GetAttack();
        CombatUIController.Instance.SetEnemyLastAttack(player.TakeDamage(enemyDamage) ? enemyDamage : 0);
    }
    
}