using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomPropertyDrawer(typeof(ColorLineAttribute))]
public class ColorSpacerDrawer : DecoratorDrawer
{

  ColorSpacer colorSpacer
  {
    get { return ((ColorSpacer)attribute); }
  }

  public override float GetHeight()
  {
    return base.GetHeight() + colorSpacer.spaceHeight;
  }

  public override void OnGUI(Rect position)
  {
    // calculate the rect values for where to draw the line in the inspector
    float lineX = (position.x + (position.width / 2)) - colorSpacer.lineWidth / 2;
    float lineY = position.y + (colorSpacer.spaceHeight / 2);
    float lineWidth = colorSpacer.lineWidth;
    float lineHeight = colorSpacer.lineHeight;

    // Draw the line in the calculated place in the inspector
    // (using the built in white pixel texture, tinted with GUI.color)
    Color oldGuiColor = GUI.color;
    GUI.color = colorSpacer.lineColor;
    EditorGUI.DrawPreviewTexture(new Rect(lineX, lineY, lineWidth, lineHeight), Texture2D.whiteTexture);
    GUI.color = oldGuiColor;
  }

}
