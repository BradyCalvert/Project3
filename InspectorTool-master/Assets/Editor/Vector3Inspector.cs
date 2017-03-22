using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Vector3Component))]
public class Vector3Inspector : Editor {
  Vector3Component myTarget;
  int choice1;
  int choice2;
  public int x=12;
  public int y;
  public int z;

  public override void OnInspectorGUI()
  {
    EditorGUILayout.LabelField("Vector Values", EditorStyles.boldLabel);
    EditorGUILayout.BeginVertical("box");
    EditorGUILayout.IntField(choice1);
    EditorGUILayout.IntField(choice2);
    EditorGUILayout.EndVertical();
    DrawStuff();
  }
  public void DrawStuff()
  {

    EditorGUILayout.LabelField("Vector3", EditorStyles.boldLabel);
    EditorGUILayout.BeginVertical("box");
    EditorGUILayout.LabelField("x", EditorStyles.boldLabel);
    x = EditorGUILayout.IntSlider(12, x, x);
    EditorGUILayout.LabelField("y", EditorStyles.boldLabel);
    y = EditorGUILayout.IntSlider(choice1, 1, 1000);
    EditorGUILayout.LabelField("z", EditorStyles.boldLabel);
    z = EditorGUILayout.IntSlider(choice2, 1, 1000);
    EditorGUILayout.EndVertical();
    EditorGUILayout.BeginVertical("box");
    EditorGUILayout.EndVertical();
  }

}
