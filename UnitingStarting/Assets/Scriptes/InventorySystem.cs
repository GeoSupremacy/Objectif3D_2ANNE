using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEditor.SceneManagement;
using Unity.VisualScripting;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;
  
    [SerializeField]
   private GameObject objectInventory;
    
    public List<Item> Items = new List<Item>();

    
    private void Awake()
    {   
        Instance = this;
        
     
    }
    private void Start()
    {
        if(!objectInventory.activeSelf) 
        {
            Debug.Log("Not Inventory");
            return; 
        }
       
       
        objectInventory.AddComponent<SetInventory>();
        objectInventory.AddComponent<InventorySystem>();
        if (!SetInventory.InstanceSetInventory)
        {
            Debug.Log("Not SetIventoryItem");
            return;
        }
        Items = SetInventory.Items;
    }
    public void AddItem(Item _itemToAdd)
    {
        bool itemAlreadyExists = false;

        foreach (Item existingItem in Items) 
            if(existingItem.itemName == _itemToAdd.itemName)
            {
                itemAlreadyExists = true;
                existingItem.itemQuantity += _itemToAdd.itemQuantity;
                break;
            }
        

        if (!itemAlreadyExists)
            Items.Add(_itemToAdd);
     }
    public void RemoveItem(Item _itemToRemove)
    {
        foreach (Item existingItem in Items)
            if (existingItem.itemName == _itemToRemove.itemName)
            {
                existingItem.itemQuantity -= _itemToRemove.itemQuantity;
                if (existingItem.itemQuantity <= 0)
                    Items.Remove(_itemToRemove);
                
                break;
            }
        
        Debug.Log(_itemToRemove.itemQuantity + " " + _itemToRemove.itemName + "removed from inventory.");
    }

    private void SetInventoryItem()
    {
       /*
        Debug.Log("Init Item in inventory");
        GameObject _item = Item.itemContainer;
        _item.GetComponent<Item>().itemQuantity = 1;

      
        Text _itemName = _item.transform.Find("Textures/Sword").GetComponent<Text>();
        Image _itemIcon = _item.transform.Find("Textures/Sword").GetComponent<Image>();


        _item.GetComponent<Item>().itemName =_itemName.text;
         _item.GetComponent<Item>().itemIcon =_itemIcon.sprite;

       
        AddItem(_item);
        
       */
    }
       
    }//
