using System;
using UnityEditor;
using UnityEngine;
using EditorUtils.Button;
using Codice.Client.BaseCommands;
using EditorUtils.Handles;
using EditorUtils.Style;
using UnityEditor.PackageManager.UI;
using UnityEditor.SceneManagement;

//OnEnable s'éxécute grace à ça 
[CustomEditor(typeof(ExampleComponent))] 
public class ExampleComponentEditor : Editor
{

    #region Property
    ExampleComponent example  = null;
    GUISkin customSkin = null;
    SerializedProperty itemNumber; //SerializedProperty: Un objet reflector  
    SerializedProperty gapNumber, typeNumber;// value;
    SerializedProperty spawmItems;

    ToolSave save = null;
    #endregion

    #region UNITY_METHOD
    //Equivalent du start 
    private void OnEnable() => Init();
    // Draw Inspector
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();//Inspector par défaut d'un interface d'un gameObjet
        EditSpawnerUI();
        DrawSpawnButtonGUI();
        serializedObject.ApplyModifiedProperties();// autoriser la modification
    }
    //Draw dans Scene
    private void OnSceneGUI() 
    {

        DrawSpawnPreviewUI();
        DrawIntreactSpawnerUI();
        //  Handles.DrawSolidDisc(example.transform.position, Vector3.up, 20);
        // Handles.DrawSolidArc(example.transform.position, example.transform.position, Vector3.forward, 20, 20);
        // Handles.DrawSolidRectangleWithOutline(new Rect(0, 0, 100, 100), Color.red, Color.green);
        // Handles.Label(example.transform.position, new GUIContent("EXAMPLE"));
    }
    #endregion

    #region SCENE
    void DrawSpawnPreviewUI()
    {
        for (int i = 0,  number =0; i < itemNumber.intValue * gapNumber.intValue; i += gapNumber.intValue, number++)
        {
            Handles.color = Color.green;
            Vector3 _point = example.transform.position + new Vector3(i, 0, 0);
            Handles.DrawSolidDisc(_point, Vector3.up, .2f);
            HandlesUtils.Label(_point, $"item {example.transform.position}", Color.white, FontStyle.Italic, TextAnchor.MiddleCenter,9) ;
            if (i < (itemNumber.intValue - 1) * gapNumber.intValue)
                HandlesUtils.DottedLine(_point, example.transform.position + new Vector3(i + gapNumber.intValue, 0,0),5,Color.yellow);
        }



    
        Handles.color = Color.white;
    }
    void DrawIntreactSpawnerUI()
    {
        //Draw Interface !toujours BeginGUI et EndGUI pour l'interface

        Handles.BeginGUI();
        save.Window = GUILayout.Window(0, save.Window, InteractWindows, "TEST", GUIStyleUtils.WindowStyle(save.WindowsColor, save.WindowOpacity));
        Handles.EndGUI();
    }

   
    void InteractWindows(int _id)
    {
        if (!save)
            return;

        Rect _toClamp = save.Window;
        _toClamp.x = Mathf.Clamp(_toClamp.x, 0, Screen.width - _toClamp.width);
        _toClamp.y = Mathf.Clamp(_toClamp.y, 0, Screen.height - _toClamp.height - 50);
        save.Window = _toClamp;
        EditSpawnerUI();
        DrawSpawnButtonGUI();

        save.R = EditorGUILayout.Slider(new GUIContent("ColorR", ""), save.R, 0, 1);
        save.G = EditorGUILayout.Slider(new GUIContent("ColorG", ""), save.G, 0, 1);
        save.B = EditorGUILayout.Slider(new GUIContent("ColorB", ""), save.B, 0, 1);
        save.WindowsColor = new Color(save.R, save.G ,save.B );
        save.WindowOpacity = EditorGUILayout.Slider(new GUIContent("Windows opacity", ""), save.WindowOpacity, 0, 1);
        serializedObject.ApplyModifiedProperties();
        GUI.DragWindow();
        //Save scène
        if(GUI.changed)
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
    }
    #endregion

    #region UI
    void DrawSpawnButtonGUI()
    {
        // Créer des éléments UI
        //  GUI.skin = customSkin;
        //EditorGUILayout.HelpBox("Problem Cube", MessageType.Warning);

        
        ButtonUtils.MakeInteractButton(example.ISValid(), $"Spawn objects x{itemNumber.intValue}", example.SpawnCubes, Color.green, new Padding2D(10, 10), "The spawn number cube is equal or low by 0");
        ButtonUtils.MakeInteractButtonWithPoppup(example.ISValid(), "Delete objects", example.ClearItems, Color.red, new AlertBox($"Delete {spawmItems.arraySize} ", "","Yes", "No") );

      
        // EditorUtility.DisplayDialog("Coucou","Message","Yes", "No"); //popup retournant un booléen
    }
    void EditSpawnerUI()
    {
        // EditorGUILayout.IntField("Cube number's", 0);  //0 n'est pas modifiable dans l'éditeur
        itemNumber.intValue= EditorGUILayout.IntSlider("Cube number's", itemNumber.intValue, 0 ,100);
        gapNumber.intValue = EditorGUILayout.IntSlider("gap", gapNumber.intValue, 0, 100);
      //  value.intValue = EditorGUILayout.IntSlider("value", value.intValue, 0, 100);
        EditorGUILayout.PropertyField(typeNumber, new GUIContent("Item type","tool type"));
    }


    #endregion

    void Init()
    {
        example = (ExampleComponent)target; //Recuper l'instance du type qui est lié

        //-Pas d'extension a préciser
        //-Les assets peuvent être dans des dossier ("dossier/dossier/.../assetName")
        //Ressources.LoadAll("NomDossier, typeOf(Type)) => load toute les ressources du type précisé
        customSkin = Resources.Load<GUISkin>("ToolExampleSkin");// Peut marcher en runTime

        itemNumber = serializedObject.FindProperty("numberCubes"); //Returne l'objet. ExampleComponent est déjà en mémoire, ne serialise que se
                                                                   //que Unity peut sérialiser numberCast possible
        gapNumber = serializedObject.FindProperty("gap");
        typeNumber = serializedObject.FindProperty("type");
        spawmItems = serializedObject.FindProperty("spawmItems");
        // value = serializedObject.FindProperty("info.value"); // Accéder une valeur d'un objet sérialisable (pas serializedObject mais l'objet que serializedObject a)
        save = Resources.Load<ToolSave>("Tools save example");
        EditorUtility.SetDirty(save);
    }
    

}//
