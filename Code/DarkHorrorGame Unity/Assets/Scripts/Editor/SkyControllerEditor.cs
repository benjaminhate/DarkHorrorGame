using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(SkyController))]
    public class SkyControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var controller = (SkyController) target;
            
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Day"))
            {
                controller.ChangeToDay();
            }

            if (GUILayout.Button("Night"))
            {
                controller.ChangeToNight();
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}