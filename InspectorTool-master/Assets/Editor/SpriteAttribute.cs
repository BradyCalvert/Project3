using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomPropertyDrawer(typeof(AttributeTest))]
public class DegRadDrawer : PropertyDrawer {
  public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
  {
    {
      if (property.propertyType == SerializedPropertyType.ObjectReference &&
          (property.objectReferenceValue as Sprite) != null)
      {
        return EditorGUI.GetPropertyHeight(property, label, true) + 100 + 10;
      }
      return EditorGUI.GetPropertyHeight(property, label, true);
    }

  }

  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
  {
    EditorGUI.PropertyField(position, property, label, true);
    if (property.propertyType == SerializedPropertyType.ObjectReference)
    {
      var sprite = property.objectReferenceValue as Sprite;
      Rect drawingRect = position;
      position.y += EditorGUI.GetPropertyHeight(property, label, true) + 5;
      position.height = 100;
      GUI.DrawTexture(position, sprite.texture, ScaleMode.ScaleToFit);

    }
  }
}