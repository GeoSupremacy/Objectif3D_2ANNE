using UnityEditor;
using UnityEngine;


//OnEnable s'éxécute grace à ca 
[CustomEditor(typeof(ExampleComponent))] 
public class ExampleComponentEditor : Editor
{
    ExampleComponent example  = null;
    GUISkin customSkin = null;
    private void OnEnable() //Equivalent du start 
    {
        example = (ExampleComponent)target; //Recuper l'instance du type qui est lié

        //-Pas d'extension a préciser
        //-Les assets peuvent être dans des dossier ("dossier/dossier/.../assetName")
        //Ressources.LoadAll("NomDossier, typeOf(Type)) => load toute les ressources du type précisé
        customSkin = Resources.Load<GUISkin>("ToolExampleSkin");// Peut marcher en runTime
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();//Inspector par défaut d'un interface d'un gameObjet
        DrawSpawnButtonGUI();
    }

    void DrawSpawnButtonGUI()
    {
        // Créer des éléments UI
        //  GUI.skin = customSkin;
         GUILayout.Space(5);
        if (GUILayout.Button("Spawn objects", GetButtonStyle(Color.green, FontStyle.Bold, 20)))
            example.SpawnCubes();
       GUILayout.Space(5);
        if (GUILayout.Button("Delete objects", GetButtonStyle(Color.red, FontStyle.Bold, 20)))
            example.ClearItems();
      
    }

    GUIStyle DefineButtonStyle() //Un button possède de base un GUIStyle 
    {
        GUIStyle _style = new();
        _style.normal.textColor = Color.white;
        return _style;
    }
    GUIStyle GetButtonStyle(Color _color, FontStyle _fontStyle, int _fontSize =15)
    {
        GUIStyle _style = new(GUI.skin.button);
        GUI.backgroundColor = _color;
        _style.fontSize = _fontSize;
        _style.fontStyle = _fontStyle;
        return _style;
    }
    Texture2D GenerateTexture(Color _color)
    {
        Texture2D _text = new Texture2D(1, 1);
        _text.SetPixel(1,1, _color);
        _text.Apply();
        return _text;
    }
}//
