#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ObjectIdAttribute))]
public class ObjectIdDrawer : PropertyDrawer
{
    private const float _regenerateButtonWidth = 80;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;

        Rect buttonRect = position;
        buttonRect.x += position.width - _regenerateButtonWidth;
        buttonRect.width = _regenerateButtonWidth;
        if (GUI.Button(buttonRect, "Regenerate") || string.IsNullOrEmpty(property.stringValue))
        {
            property.stringValue = Guid.NewGuid().ToString();
        }
    }
}
#endif
