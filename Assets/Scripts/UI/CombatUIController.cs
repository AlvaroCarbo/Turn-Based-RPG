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
            Debug.Log("Attack " + CombatManager.Instance.playerBase.baseStats.attack);

            var randomValue = UnityEngine.Random.value > 0.5f;

            if (randomValue)
            {
                CombatManager.Instance.HandleTurn(CombatManager.Instance.enemyBase,
                    CombatManager.Instance.playerBase.baseStats.attack);
                yield return new WaitForSeconds(1f);
                CombatManager.Instance.HandleTurn(CombatManager.Instance.playerBase,
                    CombatManager.Instance.enemyBase.baseStats.attack);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                CombatManager.Instance.HandleTurn(CombatManager.Instance.playerBase,
                    CombatManager.Instance.enemyBase.baseStats.attack);
                yield return new WaitForSeconds(1f);
                CombatManager.Instance.HandleTurn(CombatManager.Instance.enemyBase,
                    CombatManager.Instance.playerBase.baseStats.attack);
                yield return new WaitForSeconds(1f);
            }
            
            CombatManager.Instance.currentTurn++;
            SetTurn();
            attackButton.onClick.AddListener(Attack);
        }

        private void SetTurn()
        {
            combatTurn.text = $"Turn {CombatManager.Instance.currentTurn}";
        }
    }
}