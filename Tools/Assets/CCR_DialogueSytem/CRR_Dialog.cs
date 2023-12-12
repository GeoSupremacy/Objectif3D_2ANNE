using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CRR_Dialog : ScriptableObject
{
    [SerializeField] string title = "Dialog";
    [SerializeField] string text = "Lorem Ipsum";
    [SerializeField] Rect dialoRect = new Rect(200, 200, 300, 150);
    [SerializeField] List<CRR_Answer> answers = new List<CRR_Answer>();
    Rect toolRect;
    public void InitDialog(string _title) => title = _title;
#if UNITY_EDITOR
    public void Draw(Rect _tool)
    {
        toolRect = _tool;
        dialoRect = GUILayout.Window(GetInstanceID(), dialoRect, DialogWindow, title);
        dialoRect =ClampWindow(dialoRect);
        DrawAnswers();
    }

    Rect ClampWindow(Rect _toClamp)
    {
        _toClamp.x = Mathf.Clamp(_toClamp.x,toolRect.x, toolRect.width - _toClamp.width);
        _toClamp.y = Mathf.Clamp(_toClamp.y, toolRect.y, toolRect.height - _toClamp.height);
        return _toClamp;
    }
    void DialogWindow(int _id)//Draw in Window les réponces
    {
        title = EditorGUILayout.TextField(new GUIContent("Dialog name"), title);
        AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), title);
        name = title;
        EditorGUILayout.HelpBox(text, MessageType.Warning);
        text = EditorGUILayout.TextArea(text);
        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Add Answer", GUILayout.Height(20)))
            AddAnswer();


        GUI.DragWindow();
    }
    void AddAnswer()
    {
        Vector2 _position = answers.Count == 0 ? new Vector2(dialoRect.x, dialoRect.y) + new Vector2(dialoRect.width * 1.2f, 0) :
                                                  new Vector2(answers[answers.Count-1].AnswerRect.x, answers[answers.Count - 1].AnswerRect.y) + new Vector2(0, answers[answers.Count - 1].AnswerRect.height  +20);
        answers.Add(new CRR_Answer(Vector2.zero));
    }
    void DrawAnswers( )
    {
        for(int i = 0; i<answers.Count; i++)
        {
            int _index = i;
            answers[i].AnswerRect= GUILayout.Window(i, answers[i].AnswerRect, (id)=>answers[_index].Draw(id,()=> answers.RemoveAt(_index)), $" Answer :{ i + 1}");
            // answers[i].AnswerRect = ClampWindow(answers[i].AnswerRect);
            answers[i].DrawCurve(dialoRect);
        }
    }
   
#endif
}//
