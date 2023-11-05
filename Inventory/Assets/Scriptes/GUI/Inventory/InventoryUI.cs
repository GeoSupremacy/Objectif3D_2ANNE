using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class InventoryUI : MonoBehaviour
{
    public static event Action OnBook;
    public static event Action<Book> OnBookUI;
    private ListBook currentBook = null;

   

    [SerializeField] InventoryButton inventoryItem = null;
    [SerializeField] Transform inventoryContent = null;
    [SerializeField] Button refreshButton = null;
    public bool IsValid => inventoryItem && inventoryContent && refreshButton;
    //TO Awake event end GetVolume

    private void Awake()=> NetworkFetcher.OnEndCoroutine += GeneratedInventory;
    
    private void Start() =>
        refreshButton.onClick?.AddListener(() => 
        {
            OnBook?.Invoke(); //StartCoroutine
            WaitingRequest();
        }
        );
           
        

    void ClearTransform(Transform _tr)
    {
       
        for (int i = 0; _tr && i < _tr.childCount; i++)
            Destroy(_tr.GetChild(i).gameObject);
       
    }
    void GeneratedInventory()
    {
      
        currentBook = NetworkFetcher.ListBook;
        
        if (!IsValid)
            return;

        ClearTransform(inventoryContent);

        foreach (Book _book in currentBook.Items)
        {
           
            InventoryButton _button = Instantiate(inventoryItem, inventoryContent);
            _button.Init(_book.VolumeInfo.Title, () => OnBookUI?.Invoke(_book));
                
        }
        
       
    }
    public void ReadStringInput(string _stringInput) => API.Search = _stringInput;

    private void WaitingRequest()
    {
        ClearTransform(inventoryContent);
        InventoryButton _button = Instantiate(inventoryItem, inventoryContent);
        _button.Init("Wainting") ;
    }
}//
