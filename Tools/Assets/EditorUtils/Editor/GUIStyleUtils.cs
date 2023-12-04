using UnityEngine;

using Hdl = UnityEditor.Handles;
namespace EditorUtils.Style
{
    public class GUIStyleUtils
    {
       public static GUIStyle GetButtonStyle(Color _color, FontStyle _fontStyle, int _fontSize = 15) //Un button possède de base un GUIStyle 
        {
            GUIStyle _style = new(GUI.skin.button);
            GUI.backgroundColor = _color;
            _style.fontSize = _fontSize;
            _style.fontStyle = _fontStyle;
            return _style;
        }
        public static GUIStyle GetLabelStyle(Color _color, FontStyle _fontStyle,TextAnchor _textAnchor ,int _fontSize = 15) //Un button possède de base un GUIStyle 
        {
            GUIStyle _style = new(GUI.skin.button);
            GUI.backgroundColor = _color;
            _style.fontSize = _fontSize;
            _style.fontStyle = _fontStyle;
            return _style;
        }
        public static Texture2D GenerateTexture(Color _color)
        {
            Texture2D _text = new Texture2D(1, 1);
            _text.SetPixel(1, 1, _color);
            _text.Apply();
            return _text;
        }

        public static GUIStyle WindowStyle(Color _color, float _opacity = 0.2f)
        {
            GUIStyle _s = new GUIStyle(GUI.skin.window);
            GUI.backgroundColor = new Color(_color.r, _color.g, _color.b, _opacity);
            return _s;
        }
    }//
}// *
