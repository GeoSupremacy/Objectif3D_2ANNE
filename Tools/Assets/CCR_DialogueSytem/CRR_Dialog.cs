using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CRR_Dialog : ScriptableObject
{
    [SerializeField] string title = "Dialog";
    [SerializeField] string text = "Lorem Ipsum";
    [SerializeField] Rect dialoRect = new Rect(200, 200, 300, 150);
    public void InitDialog(string _title) => title = _title;
#if UNITY_EDITOR
    public void Draw()
    {
        dialoRect = GUILayout.Window(GetInstanceID(), dialoRect, DialogWindow, title);
    }
    void DialogWindow(int _id)//Draw in Window les réponces
    {
        title = EditorGUILayout.TextField(new GUIContent("Dialog name"), title);
        AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), title);
        name = title;
        EditorGUILayout.HelpBox(text, MessageType.Warning);
        text = EditorGUILayout.TextArea(text);
        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Add Answer", GUILayout.Height(20)))
            Debug.Log("???");
    
        GUI.DragWindow();
    }
#endif
}//
