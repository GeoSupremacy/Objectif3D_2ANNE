using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;

public class UI_Content : MonoBehaviour
{

    [SerializeField] UI_Button button = null;
    [SerializeField] Transform content = null;
    private List<TMP_Text> texts = null;

    bool IsValid => button && content;

    private void Awake()
    {
        //TODO InitContent
    }
    public void Generated()
    {
        if (!IsValid)
            throw new System.NullReferenceException("UI_Content => not button or content");
        ClearTransform(content);

        foreach (TMP_Text _book in texts)
        {

            UI_Button _button = Instantiate(button, content);
            _button.Init(_book.text, () => Debug.Log($"{_book.text}"));

        }
    }

    void ClearTransform(Transform _transform)
    {
        for (int i = 0; _transform && i < _transform.childCount; i++)
            Destroy(_transform.GetChild(i).gameObject);
    }

    private void InitContent(List<TMP_Text> _texts)
    {
        if (!IsValid)
            throw new System.NullReferenceException("UI_Content => not button or content");
        texts = _texts;
    }
}
