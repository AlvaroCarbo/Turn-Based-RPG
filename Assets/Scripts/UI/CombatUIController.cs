using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace UI
{
    public class CombatUIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text combatTurn;

        [SerializeField] private TMP_Text playerLastAction;
        [SerializeField] private TMP_Text enemyLastAction;

        [SerializeField] private Button attackButton;

        public void Start()
        {
            attackButton.onClick.AddListener(Attack);
        }

        private void Attack()
        {
            attackButton.onClick.RemoveListener(Attack);
            StartCoroutine(AttackHandler());
        }

        private IEnumerator AttackHandler()
        {
            var randomValue = CombatManager.Instance.playerBase.baseStats.speed >
                              CombatManager.Instance.enemyBase.baseStats.speed;

            int attack;
            if (randomValue)
            {
                PlayerUITurn();
                yield return new WaitForSeconds(1f);
                EnemyUITurn();
                yield return new WaitForSeconds(1f);
            }
            else
            {
                EnemyUITurn();
                yield return new WaitForSeconds(1f);
                PlayerUITurn();
                yield return new WaitForSeconds(1f);
            }

            CombatManager.Instance.currentTurn++;
            SetTextTurn();
            
            attackButton.onClick.AddListener(Attack);
        }

        private void PlayerUITurn()
        {
            var attack = CombatManager.Instance.playerBase.baseStats.GetAttack();
            CombatManager.Instance.HandleTurn(CombatManager.Instance.enemyBase, attack);
            playerLastAction.text = $"Player Attack: {attack}";
        }
        
        private void EnemyUITurn()
        {
            var attack = CombatManager.Instance.enemyBase.baseStats.GetAttack();
            CombatManager.Instance.HandleTurn(CombatManager.Instance.playerBase, attack);
            enemyLastAction.text = $"Enemy Attack: {attack}";
        }

        private void SetTextTurn()
        {
            combatTurn.text = $"Turn {CombatManager.Instance.currentTurn}";
        }
    }
}