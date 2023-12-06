using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "DataDialogue")]
public class ScriptableDataDialogue : DataDialogue
{

    public void Init(DataDialogue _data)
    {
        dialogues = _data.AllDialogue;
    }

}

