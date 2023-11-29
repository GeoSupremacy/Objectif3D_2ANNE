using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextureGenerator : MonoBehaviour
{
    [SerializeField] private List<Color> colors = new List<Color>();
   
  public void GenerateTextures()
    {
        Texture2D _texture = new Texture2D(1, 1);
        string _path = Path.Combine(Application.dataPath, "TextureGenerated");
        if(!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
        for (int i = 0; i < colors.Count; i++)
        {
            _texture.SetPixel(1, 1, colors[i]);
                _texture.Apply();
            File.WriteAllBytes(_path + $"\\tex_{i}.jpg", _texture.EncodeToJPG());
        }
        DestroyImmediate(_texture);
    }
}
