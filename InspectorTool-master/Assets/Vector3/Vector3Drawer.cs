using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Vector3Attribute))]
public class Vector3Drawer : PropertyDrawer
{
  public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
  {
    return base.GetPropertyHeight(property, label) * 2;
  }

  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
  {
    if (property.propertyType == SerializedPropertyType.Integer)
    {
      Rect drawingRect = position;
      drawingRect.height = drawingRect.height / 2;
      property.intValue = EditorGUI.IntField(drawingRect, label, Mathf.Max(0, property.intValue));
    }
  }
}
