using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Dialog settings")]
public class Dialog_Settings : ScriptableObject
{
    [SerializeField]
    List<Dialogue> dialogues = new List<Dialogue>();
    public List<Dialogue> Dialogues => dialogues;
}

[Serializable]
public class Dialogues
{
    [SerializeField]
    List<Dialogue> dialogues;
   public int CountDialogues => dialogues.Count;
}

[Serializable]
public class Dialogue
{
    [SerializeField]
     string quote;
    [SerializeField]
    List<Answers> answers;
    public List<Answers> Answers => answers;
    public string Answer(int _index) => answers[_index].Answer;
    public int CountAnswers => answers.Count;
    public string Quote => quote;
}

[Serializable]
public class Answers
{
    [SerializeField]
     string answer;
    public string Answer => answer;
}