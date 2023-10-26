using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionItem : MonoBehaviour
{
    [SerializeField] RawImage icon = null;
    [SerializeField] TMP_Text text = null;
    //Item item = null;

    public bool IsValid => icon  && text;

    public void Init(/*Item _item*/)
    {
        /*
        if (!IsValid)
            return;
        item = _item;
        icon = _item.icon;
        icon.texture = _item.Icon;
        text.text = _item.ID.ToString();
        */
    }
}
