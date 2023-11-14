using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public interface IQuote
{
    string Quote { get; }
}







[CreateAssetMenu(fileName ="Dialog")]
public class DialogueSystem_Data : ScriptableObject
{
    public event Action<Dialog> OnNext = null;

    [SerializeField] private Dialog[] allDialogs = null;
    public Dialog this[int index] => allDialogs[index];
    public Dialog GetCurrentDialog => allDialogs[DialogProgress];
    public int DialogProgress { get; private set; }
    public int Length => allDialogs.Length;
    public void StartDialog()
    {
        DialogProgress = 0;
        OnNext?.Invoke(GetCurrentDialog);
    }

    public void SetNextDialog()
    {
        DialogProgress++;
        //TODO LOOP EXAMPLE
        DialogProgress %= allDialogs.Length;
        OnNext?.Invoke(GetCurrentDialog);
    }
}

[Serializable]
public class Dialog : IQuote
{
    [SerializeField] string quote = "Example";
    [SerializeField] private Choice[] choices = null;
    public Choice this[int index] => choices[index]; //for -> GetCurrent[i]
    public string Quote => quote;

    [SerializeField] bool isPNG = true;
    public bool IsPNG => isPNG;
}

[Serializable]
public class Choice : IQuote
{
    [SerializeField] string quote = "Example";
    public string Quote => quote;
}