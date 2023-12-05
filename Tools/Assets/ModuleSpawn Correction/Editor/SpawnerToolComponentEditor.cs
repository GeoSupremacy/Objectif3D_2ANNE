using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using EditorUtils.Button;
using EditorUtils.Handles;
using UnityEngine;

[CustomEditor(typeof(SpawnerToolComponent))]
public class SpawnerToolComponentEditor : Editor
{
    SpawnerToolComponent spawner = null;
    SerializedProperty modules = null, 
                       itemBehaviour = null,
                       item =null,
                       items = null;
   private void OnEnable()
    { 
        spawner =(SpawnerToolComponent) target;
        spawner.name = "[SPAWNER TOOL]";
        spawner.InitModule();
        InitProperties();
    }

    void InitProperties()
    {
        modules = serializedObject.FindProperty("modules");
        itemBehaviour = serializedObject.FindProperty("itemBehaviour.useSingleItem");
        item = serializedObject.FindProperty("itemBehaviour.item");
        items = serializedObject.FindProperty("itemBehaviour.items");
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawAllModuleUI();
        DrawSpawnnerBehaviourUI();
        serializedObject.ApplyModifiedProperties();
    }
    private void OnSceneGUI()
    {
        DrawAllModuleScene();
        if(GUI.changed) 
            SceneView.RepaintAll();
        serializedObject.ApplyModifiedProperties();
    }
    void DrawAllModuleUI()
    {
        for (int i = 0; i < modules.arraySize; i++)
        {
            SpawnerModule _mod =(SpawnerModule) modules.GetArrayElementAtIndex(i).objectReferenceValue;
            _mod.DrawModule(spawner);
        }
    }
    void DrawAllModuleScene()
    {
        for (int i = 0; i < modules.arraySize; i++)
        {
            SpawnerModule _mod = (SpawnerModule)modules.GetArrayElementAtIndex(i).objectReferenceValue;
            _mod.DrawSceneModule(spawner.gameObject.transform.position);
        }
    }
    void DrawSpawnnerBehaviourUI()
    {
        System.Action _spawn = () =>
            {
                for (int i = 0;i < modules.arraySize;i++)
                {
                    SpawnerModule _mod = (SpawnerModule)modules.GetArrayElementAtIndex(i).objectReferenceValue;
                    if(_mod.ModuleEnable)
                        spawner.AddNewItems(_mod.ModuleName, _mod.Spawn(spawner));
                }
            };
        System.Action _delete = () =>
        {
            for (int i = 0; i < modules.arraySize; i++)
            {
                SpawnerModule _mod = (SpawnerModule)modules.GetArrayElementAtIndex(i).objectReferenceValue;
                if (_mod.ModuleEnable)
                    _mod.Delete();
            }
        };
        EditorGUILayout.PropertyField(itemBehaviour);
        if (itemBehaviour.boolValue)
            EditorGUILayout.PropertyField(item, new GUIContent("Single item"));
        else
            EditorGUILayout.PropertyField(items, new GUIContent("List"));
        ButtonUtils.MakeButton($"Spawn: X{spawner}", _spawn, Color.green);
        ButtonUtils.MakeInteractButtonWithPoppup(true,"Delete", _delete, Color.red, new Padding2D(5,5),"Error");
    }
}//
