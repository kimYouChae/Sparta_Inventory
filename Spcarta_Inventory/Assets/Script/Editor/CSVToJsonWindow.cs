using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CSVToJsonWindow : EditorWindow
{
    

    [MenuItem("Window/CustomEditor/CSV To Json Window")]
    public static void ShowWindow() 
    {
        GetWindow<CSVToJsonWindow>("Csv to Json Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Csv to Json Editor", EditorStyles.boldLabel);



        if (GUILayout.Button("Convert")) 
        {
            
        }
    }
}
