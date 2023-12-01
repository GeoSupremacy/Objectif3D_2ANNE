using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Tools save example")]
public class ToolSave : ScriptableObject
{
  [SerializeField]  Rect window = new Rect(10, 10, 300, 100);
  [SerializeField] float windowOpacity = 1, r = 1, g = 1, b = 1;
  [SerializeField]  Color windowColor = Color.white;


    public Rect Window { get => window; set => window = value; }
    public Color WindowsColor { get => windowColor; set => windowColor = value; }
    public float WindowOpacity { get => windowOpacity; set => windowOpacity = value; }

    public float R { get => r; set => r = value; }
    public float G { get => g; set => g = value; }
    public float B { get => b; set => b = value; }
}
