
using EditorUtils.Style;
using UnityEditor;
using UnityEngine;


using Hdl = UnityEditor.Handles;


namespace EditorUtils.Handles
{
    public class HandlesUtils 
    {
        public static void Label(Vector3 _position, string _text, Color _color, FontStyle _style = FontStyle.Bold, TextAnchor _anchor = TextAnchor.MiddleCenter, int _fontSize =12)
        {
            Hdl.Label(_position, _text, GUIStyleUtils.GetLabelStyle(_color, _style, _anchor, _fontSize));
        }
        public static void Label(Vector3 _position, string _text, Color _color, GUIStyle _style)
        {
            Hdl.Label(_position, _text,_style);
        }
        public static void SolidDisc(Vector3 _from ,float radius, Color _color)
        {
            Hdl.color = _color;
            Hdl.DrawSolidDisc(_from, Vector3.up, radius);
            Hdl.color = Color.white;
        }
        public static void DottedLine(Vector3 _from, Vector3 _to, float _space ,Color _color)
        {
            Hdl.color = _color;
            Hdl.DrawDottedLine(_from, _to,_space);
            Hdl.color = Color.white;
        }
        public static void DrawLine(Vector3 _from, Vector3 _to, Color _color)
        {
            Hdl.color= _color;
            Hdl.DrawLine(_from, _to);
            Hdl.color = Color.white;
        }
    }
}
