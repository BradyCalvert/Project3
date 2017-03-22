                            using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Level1))]
public class LevelInspector : Editor {


    public int _width;
    public int _height;
    public bool _ObjectToggle=true;
    Level1 myTarget;
    private void OnEnable()
    {
        myTarget = (Level1)target;
    }

    private void ResetValues()
    {
        _width = myTarget.width;
        _height = myTarget.height;
        ResetValues();
    }
    public  void OnInspectorGUI()
    {

        DrawLevelData();
        DrawLevelSize();
        DrawObjectFields();
        //base.OnInspectorGUI();
    }
    private void DrawLevelData()
    {
        EditorGUILayout.LabelField("Data",EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");
        myTarget.timeAllowed = EditorGUILayout.IntField("Time Allowed", Mathf.Max(1, myTarget.timeAllowed));
        myTarget.gravity = EditorGUILayout.FloatField("Gravity", myTarget.gravity);
        EditorGUILayout.EndVertical();
    }

    private void DrawLevelSize()
    {
        EditorGUILayout.LabelField("Size", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal("box");
        EditorGUILayout.BeginVertical();
        _width = EditorGUILayout.IntField("Width",Mathf.Max(1,_width));
        _height = EditorGUILayout.IntField("Height", Mathf.Max(1, _height));
        EditorGUILayout.EndVertical();
        bool myResize = GUILayout.Button("Resize",GUILayout.Height(2*EditorGUIUtility.singleLineHeight));
        if(myResize)
        {
            if(EditorUtility.DisplayDialog(

                "Level Inspector",
                "Are you sure you want to resize? This cannot be undone!",
                "Yes",
                "No"
                ))
            {
                myTarget.width = _width;
                myTarget.height = _height;
                myTarget.ResizeLevel();

            }
        }
        EditorGUILayout.EndHorizontal();
    }

    private void DrawObjectFields()
    {
        _ObjectToggle = EditorGUILayout.Foldout(_ObjectToggle, "Wall Objects");
        if(_ObjectToggle)
        {
            EditorGUILayout.BeginVertical("Box");
            myTarget.top = (GameObject)EditorGUILayout.ObjectField("Top", myTarget.top, typeof(GameObject), true);
            myTarget.bottom = (GameObject)EditorGUILayout.ObjectField("Bottom", myTarget.top, typeof(GameObject), true);
            myTarget.right = (GameObject)EditorGUILayout.ObjectField("Right", myTarget.top, typeof(GameObject), true);
            myTarget.left = (GameObject)EditorGUILayout.ObjectField("Left", myTarget.top, typeof(GameObject),true);
            EditorGUILayout.EndVertical();
        }
    }
}
