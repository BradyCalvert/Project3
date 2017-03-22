using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(TimeFormatAttribute))]
public class TimeFormatDrawer : PropertyDrawer {

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 2;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if(property.propertyType==SerializedPropertyType.Integer)
        {
            Rect drawingRect = position;
            drawingRect.height = drawingRect.height / 2;
            property.intValue = EditorGUI.IntField(drawingRect, label, Mathf.Max(0, property.intValue));

        }
        else
        {
            EditorGUI.HelpBox(position, "To use the Time Attribtue " + label.text + " must be an int!",MessageType.Error);
        }

        //base.OnGUI(position, property, label);
    }


    private string ConvertTime(int totalSeconds)
    {
        TimeFormatAttribute timeAtt = attribute as TimeFormatAttribute;

        if(timeAtt.showHour) 
        {
            int hours = totalSeconds / (60 * 60);
            int minutes = ((totalSeconds % (60 * 60)) / 60);
            int seconds = (totalSeconds % 60);

            return string.Format("{0}:{2:}:{2} {h:m:s}", hours, minutes.ToString().PadLeft(2, '0'));
        }
        else
        {
            int hours = totalSeconds / (60 * 60);
            int minutes = ((totalSeconds % (60 * 60)) / 60);
            return string.Format("{0}:{2:}:{2} {h:m:s}", hours, minutes.ToString().PadLeft(2, '0'));
        }
    }

}
