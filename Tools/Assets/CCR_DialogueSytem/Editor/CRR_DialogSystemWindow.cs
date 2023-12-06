using EditorUtils.Button;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CRR_DialogSystemWindow : EditorWindow
{


    #region Properties
    const string dialogFolder = "Assets/CCR_DialogueSytem/Resources/Dialogs/";
    bool showDialogCreation = false;
    string dialogNameCreation = "";
    CRR_Dialog[] dialogs = null;
    int currentDialogIndex = 0;
    CRR_Dialog currentDialog = null;
    #endregion

    #region METHOD_UNITY
    private void OnEnable()=> ReloadDialogs();
    
    private void OnGUI() =>DrawUI();
    #endregion

    #region DRAW_MENU
    void ReloadDialogs()
    {
        dialogs = Resources.LoadAll<CRR_Dialog>("Dialogs"); //Sert à charger les dialogs
    }
    void DrawUI()
    {
        BeginWindows();
        GUILayout.Window(-1, new Rect(0, 0, 200, position.height), MenuWindow, string.Empty);  //-1 pas boucle /:Les button delete/add
        if (showDialogCreation)
            GUILayout.Window(0, new Rect(200, 10, 300, 100), CreateDialogWindow, string.Empty);  //nouvelle fenêtre window
        DrawDialogSystemGrid();
        DrawDialogSystemContent(); //chaque dialog draw son contenu
        EndWindows();
    }
    void MenuWindow( int _id)
    {
        ButtonUtils.MakeButton("Create dialog", ShowCreateDialogs, Color.green);
        ButtonUtils.MakeButton("Delete dialog", DeleteDialog, Color.red);
        EditorGUILayout.Space(10);
       
        EditorGUILayout.HelpBox("Dialog List: ", MessageType.None);
        ShowAllDialogs();  //Choisi un dialogue
    }
    void CreateDialogWindow(int _id)
    {
        dialogNameCreation = GUILayout.TextArea(dialogNameCreation);
        ButtonUtils.MakeButton("Create", ()=> CreateDialog(dialogNameCreation), Color.green, new Padding2D(10,10)); //Créer un nouveau dialogue
    }
     #endregion

    #region DRAW_INTERFACE
    void DrawDialogSystemGrid(int _gap = 25)
    {
        Handles.color = Color.grey;
        for (int y = 0; y < position.height; y += _gap)
            for (int x = 0; x < position.width; x += _gap)
            {
                Handles.DrawLine(new Vector2(x, position.height), new Vector2(x, y));
                Handles.DrawLine(new Vector2(0, y), new Vector2(position.width, y));
            }
    }
    void DrawDialogSystemContent()
    {
        if (!currentDialog)
            return;
        currentDialog.Draw();
    }
    void ShowAllDialogs()
    {
        for (int i = 0; dialogs != null && i < dialogs.Length; i++)
        {

            int _index = i;
            if (!dialogs[i])
                continue;
            CRR_Dialog _dialog = dialogs[i];
            ButtonUtils.MakeButton(dialogs[i].name, () => SelectDialog(_index, _dialog), currentDialogIndex == i ? Color.cyan : Color.gray); //Choisi un dialog
        }
    }
    #endregion

    #region ACTION
    bool HasUniqueName(string _name)
    {
        for (int i = 0; dialogs != null && i < dialogs.Length; i++)
        {
            if (dialogs[i].name == _name)
                return true;
        }
        return false;
    }
    void SelectDialog(int _index ,CRR_Dialog _dilalog)
    {
        currentDialog = _dilalog;
        currentDialogIndex = _index;
    }
    void ShowCreateDialogs() => showDialogCreation = true;
    void DeleteDialog()
    { 

    }
    void CreateDialog(string _name)
    {
        if (HasUniqueName(_name))
            return;
        if (!AssetDatabase.IsValidFolder(dialogFolder))
            Directory.CreateDirectory(dialogFolder);
        CRR_Dialog _dialog = ScriptableObject.CreateInstance<CRR_Dialog>();
        _dialog.InitDialog(_name);
        AssetDatabase.CreateAsset(_dialog, dialogFolder + $"{_name}.asset");
        ReloadDialogs();
        dialogNameCreation = "";
        showDialogCreation = false;
    }
    #endregion
}
