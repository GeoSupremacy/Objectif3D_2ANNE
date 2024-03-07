using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextInChat : MonoBehaviour
{
    
    [SerializeField] TMP_Text content = null;
    public bool IsValid => content;
   

    public void Init(string text)
    {
        if (!IsValid)
            return;

        content.text = text;
    }

   
}
