using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//[CreateAssetMenu(fileName = "DataDialogue")]
public class DataDialogue
{
    [SerializeField] protected List<Dialogue> dialogues;
    
    public List<Dialogue> AllDialogue =>dialogues;
    public int Count => dialogues.Count;    
  public void Remove(int _id)
   {
        if (!dialogues.Contains(dialogues[_id]))
            return;
        
        dialogues.RemoveAt(_id);
   }
  
}

[Serializable]
public class Dialogue
{
    [SerializeField] string dialogue = "dialogue";
    [SerializeField] List<Choice> allChoice;
    public Choice this[int index] => allChoice[index]; 
    public void Add(Choice _choice)
    {
        allChoice.Add(_choice);
    }
    public void Delete(Choice _choice)
    {
        allChoice.Remove(_choice);
    }
    public string CurrentDialogue => dialogue;

   
}

[Serializable]
public class Choice
{
    [SerializeField] string answer = "answer";
    public string Answer => answer;
}