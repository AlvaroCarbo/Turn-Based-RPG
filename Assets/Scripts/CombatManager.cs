using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    public int currentTurn;
    
    [Space]
    [Header("Combat Settings")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    [HideInInspector] public PlayerBase playerBase;
    [HideInInspector] public EnemyBase enemyBase;

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
        playerBase = player.GetComponent<PlayerBase>();
        enemyBase = enemy.GetComponent<EnemyBase>();

        playerBase.healthBar.SetMaxHealth(playerBase.currentHealth);
        enemyBase.healthBar.SetMaxHealth(enemyBase.currentHealth);
    }
    
    public void HandleTurn(CharacterBase character, int damage)
    {
        character.TakeDamage(damage);
        character.healthBar.SetHealth(character.currentHealth);
    }
}