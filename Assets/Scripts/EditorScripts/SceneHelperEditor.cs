using UnityEditor;
using UnityEngine;

namespace EditorScripts
{
    [CustomEditor(typeof(SceneHelper))]
    public class SceneHelperEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var sceneHelper = (SceneHelper) target;
            if (GUILayout.Button("SetTypo"))
            {
                sceneHelper.SetTypo();
            }
        }
    }
}