using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [SerializeField]
    public List<Item> items = new List<Item>();

    [SerializeField]
    private GameObject inventoryItem;
    [SerializeField]
    private Transform ItemContent;

    bool IsValid() => inventoryItem && ItemContent;
    private void Awake()=> Instance = this;

    private void Start()
    {
        if (!IsValid())
        {
            Debug.Log("Can not good Component");
            return;
        }
        inventoryItem.gameObject.AddComponent<NetworkFetcher>();
        NetworkFetcher.Ondeals += ListItems;
        SetInventory();
       
    }


    public void AddItem(Item _newItem) 
    {
        bool isAlreadyExists = false;

        foreach (Item item in items) 
        { 
            if(item.ItemName== _newItem.ItemName)
            {
                item.ItemQuantity += _newItem.ItemQuantity;
                isAlreadyExists = true;
                _newItem = null;
                break;
            }
        }
        if (!isAlreadyExists) 
            items.Add(_newItem);

        Debug.Log($"x{ _newItem.ItemQuantity} {_newItem.ItemName}: added to inventory. ");
    }
    public void RemoveItem(Item _ItemRemove)
    {
        bool isEmpty = false;

        foreach (Item item in items)
        {
            if (item.ItemName == _ItemRemove.ItemName)
            {
                item.ItemQuantity -= _ItemRemove.ItemQuantity;
                if (item.ItemQuantity <= 0)
                {
                    isEmpty = false;
                    items.Remove(_ItemRemove);
                    Debug.Log($"{_ItemRemove.ItemName}: has been completely removed from the inventory. ");
                }
                break;
            }
        }

        if (!isEmpty)
            Debug.Log($"x{_ItemRemove.ItemQuantity} {_ItemRemove.ItemName}: removed to inventory. ");
    }
    private void SetInventory()
    {
        
        Debug.Log($"Set inventory. ");

     
        Item _newPotion = new Item("Potions",5);
        AddItem(_newPotion);
        Item _newSword = new Item("Sword", 1);
        AddItem(_newSword);
        
        
    }
    void ClearTransform(Transform _tr)
    {
        foreach (Transform items in _tr)
            Destroy(_tr.gameObject);

    }
    public void ListItems(Deals[] _dealList)
    {
       
        ClearTransform(ItemContent);
        Debug.Log("ListItems");
       
        foreach (Deals item in _dealList)
        {
            GameObject _object = Instantiate(inventoryItem, ItemContent);
            if(!_object.gameObject.GetComponent<TMP_Text>())
            {
                Debug.Log("Problem TMP_Text component");
                return;
            }
            else if(!_object.gameObject.GetComponent<Image>())
            {
                Debug.Log("Problem Image component");
                return;
            }
            TMP_Text _itemName = _object.gameObject.GetComponent<TMP_Text>();
            Image _itemIcon = _object.transform.GetComponent<Image>();
            

            _itemName.text= item.Title;
            
        }

    }
}
