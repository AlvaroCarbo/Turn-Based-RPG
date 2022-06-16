using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace UI
{
    public class StatsUIController : MonoBehaviour
    {
        [SerializeField] private List<TMP_Text> statsValues;
        [SerializeField] private BaseStats baseStats;

        private void Start()
        {
            foreach (Transform child in transform)
            {
                if (child.name.Contains("Value"))
                {
                    statsValues.Add(child.GetComponent<TMP_Text>());
                }
            }
        
            var stats = baseStats.GetStats();
        
            for (var i = 0; i < statsValues.Count; i++)
            {
                statsValues[i].text = stats[i].ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
