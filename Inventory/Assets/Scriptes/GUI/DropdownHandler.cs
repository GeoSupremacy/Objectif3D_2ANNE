using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{

     Dictionary<string, string> Term = new Dictionary<string, string>()
    {
        { "Titre" , "intitle" },
        { "Auteur" , "inauthor" },
        { "Editeur" , "inpublisher" },
        { "Sujet" , "subject" },
      //  { "numero ISBN" , "isbn" },
      //  { "lccn" , "lccn" },
      //  { "oclc" , "oclc" },
    };
    void Start() => TermInventory();

    public void TermInventory()
    {
        TMP_Dropdown _dropdown = transform.GetComponent<TMP_Dropdown>();
        _dropdown.options.Clear();

        foreach (var _option in Term)
            _dropdown.options.Add(new TMP_Dropdown.OptionData() { text = _option.Key });

        SetTerm(_dropdown);
         _dropdown.onValueChanged.AddListener(delegate { SetTerm(_dropdown); });
    }

    void SetTerm(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;

        API.chooseTerm = Term[dropdown.options[index].text];
        Debug.Log($"chooseTerm: {API.chooseTerm}");
        
    }
    //(dropdown.options[index].text).ToString()
    //  Term.ContainsKey("intitle")
}//
