using UnityEditor;
using UnityEngine;

namespace EditorScripts
{
#if UNITY_EDITOR
    [CustomEditor(typeof(StatsHelper))]
    public class StatsHelperEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            StatsHelper myScript = (StatsHelper) target;

            if (GUILayout.Button("Get Attack"))
            {
                Debug.Log(myScript.GetComponent<CharacterBase>().stats.CalculateAttack());
            }

            if (GUILayout.Button("Randomize Stats"))
            {
                myScript.GetComponent<CharacterBase>().stats.health = Random.Range(100, 1000);
                // mana// stamina// luck// speed// attack// defense// resistance// accuracy// evasion// critical
                myScript.GetComponent<CharacterBase>().stats.mana = Random.Range(10, 100);
                myScript.GetComponent<CharacterBase>().stats.stamina = Random.Range(10, 100);
                myScript.GetComponent<CharacterBase>().stats.luck = Random.Range(0, 10);
                myScript.GetComponent<CharacterBase>().stats.speed = Random.Range(10, 100);
                myScript.GetComponent<CharacterBase>().stats.attack = Random.Range(10, 200);
                myScript.GetComponent<CharacterBase>().stats.defense = Random.Range(10, 100);
                myScript.GetComponent<CharacterBase>().stats.resistance = Random.Range(10, 100);
                myScript.GetComponent<CharacterBase>().stats.accuracy = Random.Range(80, 100);
                myScript.GetComponent<CharacterBase>().stats.evasion = Random.Range(10, 40);
                myScript.GetComponent<CharacterBase>().stats.critical = Random.Range(10, 100);
            }
        }
    }
#endif
}