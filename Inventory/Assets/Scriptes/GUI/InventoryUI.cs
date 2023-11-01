using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private ListBook currentBook = null;

    [SerializeField] InventoryButton inventoryItem = null;
    [SerializeField] Transform inventoryContent = null;
    [SerializeField] Button refreshButton = null;
    [SerializeField] TextAreaAttribute researchField = null;

    public bool IsValid => inventoryItem && inventoryContent && refreshButton;

    private void Awake()
    {
        NetworkFetcher.OnListBook += GeneratedInventory;
        refreshButton.onClick?.AddListener(() => GeneratedInventory(currentBook));
       
    }
   
    void ClearTransform(Transform _tr)
    {
       
        for (int i = 0; _tr && i < _tr.childCount; i++)
            Destroy(_tr.GetChild(i).gameObject);
       
    }
    void GeneratedInventory(ListBook _deals)
    {
        currentBook = _deals;

        API.Search = researchField.ToString();
        if (!IsValid)
            return;
        ClearTransform(inventoryContent);
        Debug.Log($"Search: {API.Search.ToString()}");
        Debug.Log($"GeneratedInventory {_deals.Items.Count}");
        foreach (Book _deal in _deals.Items)
        {
            
            InventoryButton _button = Instantiate(inventoryItem, inventoryContent);
            _button.Init(_deal.VolumeInfo.Title, () => Debug.Log($"Coucou"));
            // Instantiate(inventoryItem, inventoryContent);
        }


    }

}
