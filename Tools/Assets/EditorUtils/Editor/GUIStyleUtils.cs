using UnityEngine;


namespace EditorUtils.Style
{
    public class GUIStyleUtils
    {
       public static GUIStyle GetButtonStyle(Color _color, FontStyle _fontStyle, int _fontSize = 15)
        {
            GUIStyle _style = new(GUI.skin.button);
            GUI.backgroundColor = _color;
            _style.fontSize = _fontSize;
            _style.fontStyle = _fontStyle;
            return _style;
        }
    }//
}// *
