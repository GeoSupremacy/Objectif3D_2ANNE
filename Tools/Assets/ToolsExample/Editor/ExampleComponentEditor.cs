using UnityEditor;
using UnityEngine;


//OnEnable s'�x�cute grace � ca 
[CustomEditor(typeof(ExampleComponent))] 
public class ExampleComponentEditor : Editor
{
    ExampleComponent example  = null;
    GUISkin customSkin = null;
    private void OnEnable() //Equivalent du start 
    {
        example = (ExampleComponent)target; //Recuper l'instance du type qui est li�

        //-Pas d'extension a pr�ciser
        //-Les assets peuvent �tre dans des dossier ("dossier/dossier/.../assetName")
        //Ressources.LoadAll("NomDossier, typeOf(Type)) => load toute les ressources du type pr�cis�
        customSkin = Resources.Load<GUISkin>("ToolExampleSkin");// Peut marcher en runTime
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();//Inspector par d�faut d'un interface d'un gameObjet
        DrawSpawnButtonGUI();
    }

    void DrawSpawnButtonGUI()
    {
        // Cr�er des �l�ments UI
        //  GUI.skin = customSkin;
         GUILayout.Space(5);
        if (GUILayout.Button("Spawn objects", GetButtonStyle(Color.green, FontStyle.Bold, 20)))
            example.SpawnCubes();
       GUILayout.Space(5);
        if (GUILayout.Button("Delete objects", GetButtonStyle(Color.red, FontStyle.Bold, 20)))
            example.ClearItems();
      
    }

    GUIStyle DefineButtonStyle() //Un button poss�de de base un GUIStyle 
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
