using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;

[CustomEditor(typeof(TextureGenerator))]
public class TextureGeneratorEditor : Editor
{
    TextureGenerator textureGenerator = null;
    private void OnEnable()
    {
        textureGenerator = (TextureGenerator)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GeneratedButtonGUI();
    }

    void GeneratedButtonGUI()
    {
       if(GUILayout.Button("Generated"))
        {
            textureGenerator.GenerateTextures();
            AssetDatabase.Refresh();
        }
    }
}
