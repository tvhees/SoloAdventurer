
using UnityEditor;
using UnityEngine;

namespace Core.Events
{
  [CustomEditor(typeof(GameEvent), true)]
  public class GameEventEditor : Editor
  {
    public override void OnInspectorGUI()
    {
      GUI.enabled = Application.isPlaying;

      var e = target as GameEvent;
      if (GUILayout.Button("Raise"))
        e.Raise();
      
      var listeners = serializedObject.FindProperty("eventListeners");
      listeners.NextVisible(true);
      while (listeners.NextVisible(true))
      {
        if(GUILayout.Button(listeners.objectReferenceValue.name))
        {
          Selection.activeObject = listeners.objectReferenceValue;
        }
      }
    }
  }
}