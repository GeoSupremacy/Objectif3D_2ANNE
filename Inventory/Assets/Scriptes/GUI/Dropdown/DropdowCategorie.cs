using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DropdowCategorie : MonoBehaviour
{
    private void Awake() => BookUi.OnDisplay += Display;

    void Display(Book _currentBook)
    {
        if (_currentBook.VolumeInfo.Categories == null)
            return;

        TMP_Dropdown _dropdown = transform.GetComponent<TMP_Dropdown>();

        _dropdown.ClearOptions();
        _dropdown.options.Clear();


        if (_currentBook.VolumeInfo.Categories.Count <0)
        {
            _dropdown.options.Add(new TMP_Dropdown.OptionData() { text = "None" });
            return;
        }
            foreach (var _categorie in _currentBook.VolumeInfo.Categories)
            _dropdown.options.Add(new TMP_Dropdown.OptionData() { text = _categorie });
    }
   
}

