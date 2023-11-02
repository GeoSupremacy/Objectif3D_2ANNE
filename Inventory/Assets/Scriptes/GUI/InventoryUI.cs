using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class InventoryUI : MonoBehaviour
{
    public static event Action OnBook;
    private ListBook currentBook = null;


    
    [SerializeField] InventoryButton inventoryItem = null;
    [SerializeField] Transform inventoryContent = null;
    [SerializeField] Button refreshButton = null;
    public bool IsValid => inventoryItem && inventoryContent && refreshButton;


    private void Start()
    {
        refreshButton.onClick?.AddListener(() => OnBook?.Invoke());
       
    }
    void ClearTransform(Transform _tr)
    {
       
        for (int i = 0; _tr && i < _tr.childCount; i++)
            Destroy(_tr.GetChild(i).gameObject);
       
    }
    void GeneratedInventory()
    {

        currentBook = NetworkFetcher.ListBook;


        if (!IsValid || currentBook == null)
            return;
        
        ClearTransform(inventoryContent);
        Debug.Log($"Search: {API.Search.ToString()}");
        Debug.Log($"GeneratedInventory {currentBook.Items.Count}");
        foreach (Book _deal in currentBook.Items)
        {
            
            InventoryButton _button = Instantiate(inventoryItem, inventoryContent);
            _button.Init(_deal.VolumeInfo.Title, () => Debug.Log($"Coucou"));
            // Instantiate(inventoryItem, inventoryContent);
        }


    }
    public void ReadStringInput(string _stringInput)
    {
        API.Search = _stringInput;

        Debug.Log($"Search: {API.Search}");
    }
    private void LateUpdate() => GeneratedInventory();
   
}//
