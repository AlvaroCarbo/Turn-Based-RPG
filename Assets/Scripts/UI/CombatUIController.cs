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
        [SerializeField] public Animator anim;



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
            playerLastAction.gameObject.SetActive(false);
            enemyLastAction.gameObject.SetActive(false);
            attackButton.onClick.AddListener(PlayAttackTurn);
        }

        private void PlayAttackTurn()
        {
            attackButton.interactable = false;
            StartCoroutine(CombatManager.Instance.RunNextTurn());
        }

        public void SetLastAttack(int attack, bool isPlayer)
        {
            if (isPlayer)
            {
                StartCoroutine(showTextUIPlayer());
                SetPlayerLastAttack(attack);
                
            }
            else
            {
                StartCoroutine(showTextUIEnemy());
                SetEnemyLastAttack(attack);
                
            }
        }

        private void SetPlayerLastAttack(int attack) => playerLastAction.text = $"{attack}";
        private void SetEnemyLastAttack(int attack) => enemyLastAction.text = $"{attack}";
        public void SetTurnText(int turn) => combatTurn.text = $"Turn: {turn}";
        public void SetStateText(CombatState combatState) => stateText.text = $"State {combatState}";

        IEnumerator showTextUIPlayer() {
            yield return new WaitForSeconds(0.1f);           
            playerLastAction.gameObject.SetActive(true);  
            yield return new WaitForSeconds(1f);
            playerLastAction.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
        
        IEnumerator showTextUIEnemy() {
            yield return new WaitForSeconds(0.1f);
            enemyLastAction.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            enemyLastAction.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
    }
}