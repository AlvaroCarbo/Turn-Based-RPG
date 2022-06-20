using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SceneHelper : MonoBehaviour
{
    public TMP_FontAsset font;

    void Start()
    {
        SetTypo();
    }

    public void SetTypo()
    {
        foreach (var item in FindObjectsOfType<TMP_Text>())
        {
            if (item == null) continue;
            item.font = font;
            item.text = item.text.Replace("\\n", "\n");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}