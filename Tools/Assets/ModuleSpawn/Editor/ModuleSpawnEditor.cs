using EditorUtils.Button;
using EditorUtils.Handles;
using log4net.Util;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;


[CustomEditor(typeof(SpawnObject))]
public class ModuleSpawnEditor : Editor
{
    #region Property
    SpawnObject spawnObject = null;
    SerializedProperty prefabObjet, choice;
    EChoiceSpawn EChoice;
    #endregion

    #region UNITY_METHOD
    private void OnEnable() => Init();
    public override void OnInspectorGUI()
    {
        //  base.OnInspectorGUI();
        serializedObject.ApplyModifiedProperties();
        EditSpawnerUI();
        DrawSpawnButtonGUI();
       
       
    }
    private void OnSceneGUI()
    {

        DimensionPosition();
        DrawGrid();

    }
    #endregion


    #region Method
    void Init()
    {
        spawnObject = (SpawnObject)target;
        prefabObjet =serializedObject.FindProperty("spawnObject");
        choice = serializedObject.FindProperty("choice");
    }

    #region Method_Inspector
    void DrawSpawnButtonGUI()
    {
        int _numberGameObject = spawnObject.Column * spawnObject.Line;
        ButtonUtils.MakeInteractButton(spawnObject.ISValid(), $"Spawn objects x{_numberGameObject}", spawnObject.Spawn, Color.green, new Padding2D(10, 10), "The _numberGameObject is equal or low by 0");
        ButtonUtils.MakeInteractButtonWithPoppup(spawnObject.ISValid(), $"Delete {spawnObject.DeleteList.Count}", spawnObject.Delete, Color.red, new AlertBox($"Delete  x{spawnObject.DeleteList.Count}", "Delete all gameObject in actually scene, are you sure?", "Yes", "No"));



    }
    void EditSpawnerUI()
    {
        serializedObject.ApplyModifiedProperties();
        if (spawnObject.EChoice == EChoiceSpawn.PrefabChoice)
            EditorGUILayout.ObjectField(prefabObjet);

        spawnObject.Column = EditorGUILayout.IntField("Column ", spawnObject.Column);
        spawnObject.Line = EditorGUILayout.IntField("Line ", spawnObject.Line);
        spawnObject.SpaceColumn = EditorGUILayout.FloatField("SpaceColumn ", spawnObject.SpaceColumn);
        spawnObject.SpaceLine = EditorGUILayout.FloatField("SpaceLine ", spawnObject.SpaceLine);
        EditorGUILayout.EnumPopup("Echoice ", EChoice);
        spawnObject.EChoice = EChoice;
        //listGameObject. = EditorGUILayout.LabelField($"ListGameObject {listGameObject}");


    }

    #endregion

    #region Method_Scene
    void DrawGrid()
    {
        Vector3 _position = spawnObject.transform.position;
        for (int i = 0; i < spawnObject.Line; i++)
            for (int j = 0; j < spawnObject.Column; j++)
                HandlesUtils.SolidDisc(new Vector3(_position.x + j * spawnObject.SpaceColumn, _position.y, _position.z + i * spawnObject.SpaceLine), .25f, Color.white);
            
    }
    void DimensionPosition()
    {
        Vector3 _positionline = spawnObject.transform.position,
               _positionlineLabelLine = _positionline + spawnObject.transform.forward * 1.5f + spawnObject.transform.right * -0.5f,
               _positionlineLabelColumn = _positionline +spawnObject.transform.right * 1.5f + spawnObject.transform.forward * -0.5f;

        HandlesUtils.Label(_positionlineLabelColumn, "Column", Color.red);
        HandlesUtils.Label(_positionlineLabelLine, "Line", Color.blue);
        HandlesUtils.DrawLine(_positionline, _positionline + spawnObject.transform.right * 3, Color.red);
        HandlesUtils.DrawLine(_positionline, _positionline + spawnObject.transform.forward * 3, Color.blue);
       
    }

    #endregion
    #endregion

}//*
