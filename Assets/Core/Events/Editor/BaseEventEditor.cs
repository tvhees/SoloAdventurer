using UnityEditor;
using UnityEngine;

namespace Core.Events
{
    [CustomEditor(typeof(BaseEvent), true)]
    public class BaseEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var e = target as BaseEvent;

            if (GUILayout.Button("Raise"))
                e.Raise();
        }
    }
}
