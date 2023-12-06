using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Rendering;
using Codice.Client.Common.TreeGrouper;

public class WindowsExample : EditorWindow
{

   [SerializeField] Rect node = new Rect(50,50,300,300); //Variable non éditable dans l'Editor
    //Dans le window n'a pas d'instance donc de cast
    private void OnEnable()
    {
        EditorUtility.SetDirty(this);
        //EditorUtility.SetDirty(data); //Window ne peut save sans data
    }

    //En window tous est GUI 
    private void OnGUI()
    {
       
        GUI.backgroundColor = Color.green;
        for (int y = 0; y < position.height; y+=50)
        {
            for (int x = 0; x < position.width; x+=50)
            {
                Handles.DrawLine(new Vector3(x,position.height, 0), new Vector3(x, y, 0));//Uniquement les Handle non propre à la scène
            }
        }
        Handles.DrawBezier(Vector2.zero, new Vector2(0,position.height), Vector2.one * 2, Vector2.up * 5, Color.yellow, null, 2);//Faire des courbes
        GUILayout.Box("TOTO");
        GUILayout.Button("CC");
        EditorGUILayout.HelpBox("", MessageType.None); //Peut être utilisé

        BeginWindows();
            node = GUILayout.Window(0, node, Window, "Example"); //une WIndow dans une window mais ne vit qu'à partir de son window
        EndWindows();
    }


    void Window(int _id)
    {
        if (GUILayout.Button("Test"))
        {
            SaveChanges();
            Close();
        }

        GUI.DragWindow();

    }
}//
