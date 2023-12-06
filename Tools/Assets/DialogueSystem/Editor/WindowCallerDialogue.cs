using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WindowCallerDialogue
{
    [MenuItem("System Dialogue/Open")]
    public static void CallWindow()
    {
        // WindowsExample _w = EditorWindow.GetWindow<WindowsExample>(true,"MyTool"); //Ancien modèle permet plus de chose tel que la persistence
        // de fenêtre avec le paramètre true
        WindowDialogue _windowDialogue = EditorWindow.CreateWindow<WindowDialogue>("System Dialogue"); //Permet l'ancrage
        _windowDialogue.Show();
    }

   
}
