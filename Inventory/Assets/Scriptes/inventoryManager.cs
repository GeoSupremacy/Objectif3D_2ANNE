using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    public event Action OnOpenInventory = null;
    public event Action OnCloseInventory = null;

    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject mainGamePage;


    [SerializeField]
    private Button openInventoryButton;
    [SerializeField]
    private Button closeInventoryButton;
    bool IsValidUI => openInventoryButton && closeInventoryButton;
    private void Awake()
    {
        OnOpenInventory += OpenInventory;
        OnCloseInventory += CloseInventory;
    }
    void Start() => InitUI();

    void InitUI()
    {
        if (!IsValidUI)
        {
            Debug.Log("Button or action is empty!");
            return;
        }
        openInventoryButton.onClick.AddListener(() => OnOpenInventory?.Invoke());
        closeInventoryButton.onClick?.AddListener(() => OnCloseInventory?.Invoke());


        closeInventoryButton?.gameObject.SetActive(false);
        openInventoryButton?.gameObject.SetActive(true);
        inventoryUI?.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    private void OpenInventory()
    {
        openInventoryButton?.gameObject.SetActive(false);
        mainGamePage?.gameObject.SetActive(false);

        closeInventoryButton?.gameObject.SetActive(true);
        inventoryUI?.gameObject.SetActive(true);
       
        //Inventory.Instance.ListItems();
    }
    private void CloseInventory()
    {
        openInventoryButton?.gameObject.SetActive(true);

        closeInventoryButton?.gameObject.SetActive(false);
        mainGamePage?.gameObject.SetActive(true);
        inventoryUI?.gameObject.SetActive(false);
        
    }

    private void OnDestroy()
    {
        OnOpenInventory = null;
        OnCloseInventory = null;
    }
}//
