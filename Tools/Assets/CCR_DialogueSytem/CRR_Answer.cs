using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[Serializable]
public class CRR_Answer 
{
    [SerializeField] string text = "";
    [SerializeField] Rect answerRect = new Rect(200, 200, 300, 100);
    public Rect AnswerRect { get => answerRect; set => answerRect = value; }

    public CRR_Answer(Vector2 _init) => answerRect = new Rect(_init.x, _init.y,300,100);
#if UNITY_EDITOR
    public void Draw(int _id, Action _callback)
    {
        EditorGUILayout.HelpBox("Answer content :", MessageType.None);
        text = EditorGUILayout.TextArea(text);
        GUI.backgroundColor = Color.white;
        if (GUILayout.Button("Delete content: ", GUILayout.Height(30)))
            _callback();
        GUI.DragWindow();
    }

    public void DrawCurve(Rect _origin)
    {
        Vector2 _from = new Vector2(_origin.x + _origin.width, _origin.y/2),
                _to = new Vector2(answerRect.x - _origin.height, answerRect.y/2),
                _bez = _to - _from;
            _bez.x *= .2f;
                _bez.y *= .4f;
        Handles.DrawBezier(_from, _to, _from+ _bez, _to - _bez, Color.green,null, 5);
    }
#endif
}
