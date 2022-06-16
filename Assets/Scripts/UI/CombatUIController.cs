using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CombatUIController : MonoBehaviour
    {
        public static CombatUIController Instance;

        [SerializeField] private TMP_Text combatTurn;

        [SerializeField] private TMP_Text playerLastAction;
        [SerializeField] private TMP_Text enemyLastAction;
        
        [SerializeField] private TMP_Text stateText;

        [SerializeField] public Button attackButton;


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
        
        public void Start()
        {
            attackButton.onClick.AddListener(Attack);
        }

        private void Attack()
        {
            attackButton.interactable = false;
            StartCoroutine(CombatManager.Instance.RunNextTurn());
        }

        public void SetPlayerLastAttack(int attack) => playerLastAction.text = $"Player Attack: {attack}";
        public void SetEnemyLastAttack(int attack) => enemyLastAction.text = $"Enemy Attack: {attack}";
        public void SetTurnText(int turn) => combatTurn.text = $"Turn {turn}";
        public void SetStateText(CombatState combatState) => stateText.text = $"State {combatState}";
    }
}