using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using EditorUtils.Button;
using UnityEditor.TerrainTools;


public class WindowDialogue : EditorWindow
{
    DataDialogue dialogueEditor = null;
    bool noCOunt = false;
    Rect rectAction;
    private void OnEnable() => InitProperties();
    private void OnGUI() => Display();
    void InitProperties()
    {
        dialogueEditor = new DataDialogue();


        rectAction = new Rect(0, 0, 200, position.height);
    }
    #region Action
    void Add()
    {
        noCOunt=true;
        dialogueEditor.AllDialogue.Add(new Dialogue());
    }
    void Delete()
    {
        noCOunt =false;
        dialogueEditor.Remove(dialogueEditor.Count-1);
    }
    void Window(int _id)
    {

        GUI.backgroundColor = Color.gray;
        GUILayout.BeginVertical();
        ButtonUtils.MakeButton("Add", Add, Color.green);
        ButtonUtils.MakeButton("Delete", Delete, Color.red);
        GUILayout.EndVertical();


    }
    #endregion

    #region Display
    void Display()
    {
        DisplayGrid();
        DisplayWindow();
    }

    void DisplayWindow()
    {
        BeginWindows();
        rectAction = GUILayout.Window(0, rectAction, Window, "");
        if(noCOunt)
            for (int i = 0; i < dialogueEditor.Count; i++)
                GUILayout.Label($"{dialogueEditor.AllDialogue[i-1]}");
        EndWindows();
    }

    void DisplayGrid()
    {
        for (int y = 0; y < position.height; y += 20)
            for (int x = 0; x < position.width; x += 20)
            {
                Handles.DrawLine(new Vector3(x, position.height, 0), new Vector3(x, y, 0));//Uniquement les Handle non propre à la scène
                Handles.DrawLine(new Vector3(position.width, y, 0), new Vector3(x, y, 0));//Uniquement les Handle non propre à la scène
            }
    }
    #endregion
  
}//
