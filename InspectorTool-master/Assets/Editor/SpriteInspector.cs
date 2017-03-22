using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Sprites;

[CustomEditor(typeof(SpriteComponent))]
public class SpriteInspector : Editor {
  public Sprite mySprite;
  public int width;
  public int height;

  public override void OnInspectorGUI()
  {
    
    EditorGUILayout.LabelField("Sprite", EditorStyles.boldLabel);
    EditorGUILayout.BeginVertical("box");
    mySprite = (Sprite)EditorGUILayout.ObjectField(mySprite, typeof(Sprite), mySprite);
    EditorGUILayout.LabelField("Width", EditorStyles.boldLabel);
    width = EditorGUILayout.IntSlider(width,32, 345);
    EditorGUILayout.LabelField("Height", EditorStyles.boldLabel);
    height = EditorGUILayout.IntSlider(height, 32, 64);
    EditorGUILayout.EndVertical();
    EditorGUILayout.BeginVertical("box");
    Rect spriteSheetRect = GUILayoutUtility.GetRect(width, height, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(true));
    EditorGUI.DrawPreviewTexture(spriteSheetRect, mySprite.texture);
    EditorGUILayout.EndVertical();
  }




}
