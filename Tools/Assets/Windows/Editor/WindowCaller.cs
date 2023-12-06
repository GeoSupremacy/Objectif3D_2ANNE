using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class WindowCaller
{
    [MenuItem("MyTool/Call")]
    public static void CallWindow()
    {
        // WindowsExample _w = EditorWindow.GetWindow<WindowsExample>(true,"MyTool"); //Ancien modèle permet plus de chose tel que la persistence
        // de fenêtre avec le paramètre true
        WindowsExample _w = EditorWindow.CreateWindow<WindowsExample>("MyTool"); //Permet l'ancrage
        _w.Show();
    }

    [MenuItem("MyTool/Start/Other")]
    public static void CallOtherWindow()
    {

    }

    [MenuItem("MyTool/Spawner/Init")]
    public static void InitSpawner()
    {
        SpawnerToolComponent _instance = GameObject.FindAnyObjectByType<SpawnerToolComponent>();

        //On ne peut faire de Singleton donc prend le 1er qui existe indépendant de la créarion d'u autre ailleur
        if (_instance)
        {
            Selection.activeObject = _instance.gameObject;
            return;
        }
        GameObject _spawner = new GameObject("spawner", typeof(SpawnerToolComponent));
        Selection.activeObject = _spawner;
    }
}//
