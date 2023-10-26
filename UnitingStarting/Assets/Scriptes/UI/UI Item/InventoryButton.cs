using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] Button inventoryButton = null;
    [SerializeField] TMP_Text inventoryText = null;

    public bool IsValid => inventoryButton && inventoryText;

    public void Init(string _label, Action _toDo)
    {
        if (!IsValid)
            return;
        Debug.LogWarning("Init InventoryButton");
        inventoryText.text = _label;
        inventoryButton.onClick.AddListener(() => _toDo?.Invoke());
    }
}
