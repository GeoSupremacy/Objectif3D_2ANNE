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
        ClearTransform(inventoryContent);
        for (int i = 0; _tr && i < 10; i++)
            Destroy(_tr.GetChild(i).gameObject);

    }
    void GeneratedInventory(Deals[] _deals)
    {
        ClearTransform(inventoryContent);
        for (int i = 0; IsValid && i < _deals.Length; i++)
        {
            int _index = i;
            InventoryButton _button = Instantiate(inventoryItem, inventoryContent);
            _button.Init($"index : {_index}", () => Debug.Log($"Coucou {_index}"));
            // Instantiate(inventoryItem, inventoryContent);
        }


    }

}
