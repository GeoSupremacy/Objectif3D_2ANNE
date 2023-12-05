using EditorUtils.Button;
using EditorUtils.Handles;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

[CustomEditor(typeof(SpawnObject))]
public class ModuleSpawnEditor : Editor
{
    #region Property
    SpawnObject spawnObject = null;
    SerializedProperty prefabObjet, choice, list, snapSpawObject;
    EChoiceSpawn EChoice;
    int sizeList;
    bool asButton =false, dispersion, snap;
    #endregion

    #region UNITY_METHOD
    private void OnEnable() => Init();
    public override void OnInspectorGUI()
    {
        //  base.OnInspectorGUI();
        serializedObject.ApplyModifiedProperties();
        EditUI();
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
        list = serializedObject.FindProperty("listGameObject");
        sizeList = list.arraySize;
        snapSpawObject = serializedObject.FindProperty("snap");
    }

    #region Method_Inspector
    void DrawSpawnButtonGUI()
    {
        int _numberGameObject = spawnObject.Column * spawnObject.Line;
        ButtonUtils.MakeInteractButton(spawnObject.ISValid(), $"Spawn objects x{_numberGameObject}", spawnObject.Spawn, Color.green, new Padding2D(10, 10),dispersion ,"The _numberGameObject is equal or low by 0");
        ButtonUtils.MakeInteractButtonWithPoppup(spawnObject.ISValid(), $"Delete {spawnObject.DeleteList.Count}", spawnObject.Delete, Color.red, new AlertBox($"Delete  x{spawnObject.DeleteList.Count}", "Delete all gameObject in actually scene, are you sure?", "Yes", "No"));



    }
    void EditUI()
    {
       
        serializedObject.ApplyModifiedProperties();
        if (EChoice == EChoiceSpawn.PrefabChoice)
            EditorGUILayout.ObjectField(prefabObjet);
        else
            DisplayListObject();
        EditUISettings();
     


    }
    void EditUISettings()
    {
        dispersion = EditorGUILayout.Toggle("Dispersion",dispersion);
       // spawnObject.Snap = EditorGUILayout.Toggle("Snap", snapSpawObject.boolValue);
        spawnObject.CurrentPrefab = prefabObjet.objectReferenceValue as GameObject;
        spawnObject.Column = EditorGUILayout.IntField("Column ", spawnObject.Column);
        spawnObject.Line = EditorGUILayout.IntField("Line ", spawnObject.Line);
        spawnObject.SpaceColumn = EditorGUILayout.FloatField("SpaceColumn ", spawnObject.SpaceColumn);
        spawnObject.SpaceLine = EditorGUILayout.FloatField("SpaceLine ", spawnObject.SpaceLine);
        EChoice = (EChoiceSpawn)EditorGUILayout.EnumPopup(spawnObject.EChoice);
        spawnObject.EChoice = EChoice;
    }
   
    void DisplayListObject()
    {
        
        CheckListSize();
        DisplayList();
    }
    void DisplayList()
    {
        for (int i = 0; i < sizeList; i++)
        {

            var _gameObject = list.GetArrayElementAtIndex(i);
            EditorGUILayout.ObjectField(_gameObject);
            spawnObject.ListGameObject[i] = _gameObject.objectReferenceValue as GameObject;
        }
        ButtonUtils.MakeButton("Add", AddNewObject, Color.green,5,dispersion);
        if (spawnObject.ListGameObject.Count > 0)
            ButtonUtils.MakeButton("Remove", RemoveObject, Color.red, 5, dispersion);
        else
            ButtonUtils.MakeButton("Remove", () => { }, Color.gray);

        GUI.backgroundColor = Color.white;
    }
    private void AddNewObject(bool _mode)
    {
        if (sizeList <=0)
            return;

        if(!_mode)
            sizeList++;
        asButton = true;
        var _gameObject = new GameObject();
        if (spawnObject.ListGameObject == null)
            spawnObject.ListGameObject = new List<GameObject>();
       

        spawnObject.ListGameObject.Add(_gameObject);
        DestroyImmediate(_gameObject);
        
    }
    private void RemoveObject(bool _mode)
    {
        if (!_mode)
            sizeList--;
        var gameObject = spawnObject.ListGameObject[spawnObject.ListGameObject.Count - 1];
        spawnObject.ListGameObject.Remove(gameObject);
    }
    private void CheckListSize()
    {
        sizeList = EditorGUILayout.IntField("Size: ", sizeList);
        sizeList = sizeList<0? 0 : sizeList;
        if (asButton)
        {
            asButton = false;
            return;
        }
        if (spawnObject.ListGameObject.Count> sizeList)
            for (int i = spawnObject.ListGameObject.Count; i > sizeList; i--)
                RemoveObject(true);
        
        else  if (spawnObject.ListGameObject.Count < sizeList)
            for (int i = spawnObject.ListGameObject.Count; i < sizeList; i++)
                AddNewObject(true);
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
