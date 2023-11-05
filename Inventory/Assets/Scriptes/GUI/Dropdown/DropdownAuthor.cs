using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropdownAuthor : MonoBehaviour
{
    
    private void Awake()=> BookUi.OnDisplay += Display;
  
    void Display(Book _currentBook)
    {
        if (_currentBook.VolumeInfo.Authors == null)
            return;
        TMP_Dropdown _dropdown = transform.GetComponent<TMP_Dropdown>();
        _dropdown.ClearOptions();
        _dropdown.options.Clear();
        
        // _dropdown.options.Add(new TMP_Dropdown.OptionData() { text = currentBook.VolumeInfo.Authors[1] });
        foreach (var _author in _currentBook.VolumeInfo.Authors)
            _dropdown.options.Add(new TMP_Dropdown.OptionData() { text = _author });
    }
}
