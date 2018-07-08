using UnityEditor;
using UnityEngine;

namespace Core.Variables {
  [CustomPropertyDrawer(typeof(MultiLineIfStringAttribute))]
  public class MultiLineIfStringDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
      var type = property.propertyType;
      if (type == SerializedPropertyType.String) {
        EditorStyles.textField.wordWrap = true;
        position = EditorGUI.PrefixLabel(position, label);
        var rect = new Rect(position.xMin, position.yMin, position.width, 5 * position.height);
        EditorGUI.BeginChangeCheck();
        var newValue = EditorGUI.TextArea(rect, property.stringValue);
        if (EditorGUI.EndChangeCheck())
          property.stringValue = newValue;
      }
      else
        EditorGUI.PropertyField(position, property, label);
    }
  }
}