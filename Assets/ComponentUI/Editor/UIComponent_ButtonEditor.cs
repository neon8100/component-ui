using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UIComponent_Button))]
public class UIComponent_ButtonEditor : Editor {

    UIComponent_Button instance;

    public override void OnInspectorGUI()
    {
        instance = (UIComponent_Button)target;

        instance.SkinObject();
        
        DrawDefaultInspector();
    }
}
