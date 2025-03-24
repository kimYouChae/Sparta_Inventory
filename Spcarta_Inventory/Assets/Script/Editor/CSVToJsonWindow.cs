using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CSVToJsonWindow : EditorWindow
{
    // Ŭ���� �� ����Ʈ 
    public List<string> className;
    
    // ����Ʈ ǥ�� object
    private SerializedObject serializedObject;
    private SerializedProperty classNameProperty;

    [MenuItem("Window/CustomEditor/CSV To Json Window")]
    public static void ShowWindow() 
    {
        GetWindow<CSVToJsonWindow>("Csv to Json Editor");
    }


    private void OnEnable()
    {
        serializedObject = new SerializedObject(this);
        classNameProperty = serializedObject.FindProperty("className");
    }

    private void OnGUI()
    {
        GUILayout.Label("Csv to Json Editor", EditorStyles.boldLabel);

        // InputField�� ����Ʈ�� 
        serializedObject.Update();
        EditorGUILayout.PropertyField(classNameProperty, true);
        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Convert"))
        {
            CsvToJsonConverter.CsvConverByName(className);
        }
    }
}
