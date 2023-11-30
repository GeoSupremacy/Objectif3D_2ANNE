using System;
using UnityEditor;
using UnityEngine;
using EditorUtils.Button;

//OnEnable s'�x�cute grace � �a 
[CustomEditor(typeof(ExampleComponent))] 
public class ExampleComponentEditor : Editor
{
    ButtonUtils
    ExampleComponent example  = null;
    GUISkin customSkin = null;
    SerializedProperty itemNumber; //SerializedProperty: Un objet reflector  
    SerializedProperty gapNumber, typeNumber, value;
    private void OnEnable() //Equivalent du start 
    {
        example = (ExampleComponent)target; //Recuper l'instance du type qui est li�

        //-Pas d'extension a pr�ciser
        //-Les assets peuvent �tre dans des dossier ("dossier/dossier/.../assetName")
        //Ressources.LoadAll("NomDossier, typeOf(Type)) => load toute les ressources du type pr�cis�
        customSkin = Resources.Load<GUISkin>("ToolExampleSkin");// Peut marcher en runTime

        itemNumber = serializedObject.FindProperty("numberCubes"); //Returne l'objet. ExampleComponent est d�j� en m�moire, ne serialise que se
                                                                   //que Unity peut s�rialiser numberCast possible
        gapNumber = serializedObject.FindProperty("gap");
        typeNumber = serializedObject.FindProperty("type");
        value = serializedObject.FindProperty("info.value"); // Acc�der une valeur d'un objet s�rialisable (pas serializedObject mais l'objet que serializedObject a)
    }

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();//Inspector par d�faut d'un interface d'un gameObjet
        EditSpawnerUI();
        DrawSpawnButtonGUI();
        serializedObject.ApplyModifiedProperties();// autoriser la modification
    }

    void DrawSpawnButtonGUI()
    {
        // Cr�er des �l�ments UI
        //  GUI.skin = customSkin;
        //EditorGUILayout.HelpBox("Problem Cube", MessageType.Warning);

        
        ButtonUtils.MakeInteractButton(example.ISValid(), $"Spawn objects x{itemNumber.intValue}", example.SpawnCubes, Color.green, new Padding2D(10, 10), "The spawn number cube is equal or low by 0");
        ButtonUtils.MakeInteractButtonWithPoppup(example.ISValid(), "Delete objects", example.ClearItems, Color.red, new AlertBox("Delete ", "","Yes", "No") );

      
        // EditorUtility.DisplayDialog("Coucou","Message","Yes", "No"); //popup retournant un bool�en
    }
    void EditSpawnerUI()
    {
        // EditorGUILayout.IntField("Cube number's", 0);  //0 n'est pas modifiable dans l'�diteur
        itemNumber.intValue= EditorGUILayout.IntSlider("Cube number's", itemNumber.intValue, 0 ,100);
        gapNumber.intValue = EditorGUILayout.IntSlider("gap", gapNumber.intValue, 0, 100);
        //typeNumber.enumValueIndex = EditorGUILayout.Popup("Type ", typeNumber.enumValueIndex, typeNumber.enumDisplayNames);
        EditorGUILayout.PropertyField(typeNumber, new GUIContent("Item type","tool type"));
    }

    GUIStyle DefineButtonStyle() //Un button poss�de de base un GUIStyle 
    {
        GUIStyle _style = new();
        _style.normal.textColor = Color.white;
        return _style;
    }
    Texture2D GenerateTexture(Color _color)
    {
        Texture2D _text = new Texture2D(1, 1);
        _text.SetPixel(1,1, _color);
        _text.Apply();
        return _text;
    }

    //ex reflection

}//
