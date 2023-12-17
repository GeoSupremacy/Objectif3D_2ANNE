using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_Button : MonoBehaviour
{
    [SerializeField] Button Button = null;
    [SerializeField] TMP_Text Text = null;

    public bool IsValid => Button && Text;

    public void Init(string _label, Action _toDo)
    {
        if (!IsValid)
         throw new System.NullReferenceException("UI_Button => not button or text");
           
        

        Text.text = _label;
        Button.onClick.AddListener(() => _toDo?.Invoke());
    }
   
}
