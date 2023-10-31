using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] InventoryButton inventoryItem = null;
    [SerializeField] Transform inventoryContent = null;
   
    public bool IsValid => inventoryItem && inventoryContent;

    private void Awake()
    {
        NetworkFetcher.Ondeals += GeneratedInventory;
    }
    void ClearTransform(Transform _tr)
    {
       
        for (int i = 0; _tr && i < _tr.childCount; i++)
            Destroy(_tr.GetChild(i).gameObject);
       
    }
    void GeneratedInventory(Deals[] _deals)
    {
        if (!IsValid)
            return;
        ClearTransform(inventoryContent);
        foreach (Deals _deal in _deals)
        {
            
            InventoryButton _button = Instantiate(inventoryItem, inventoryContent);
            _button.Init(_deal.Title, () => Debug.Log($"Coucou"));
            // Instantiate(inventoryItem, inventoryContent);
        }


    }

}
