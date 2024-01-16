using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Maze))]
public class MapGenEditorRandom : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Maze myGenerator = (Maze)target;
        if(GUILayout.Button("맵을 생성합니다."))
        {
            myGenerator.BuildGenerator();
        }
    }
}
