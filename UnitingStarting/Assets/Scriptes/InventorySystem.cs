using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEditor.SceneManagement;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;

   // [SerializeField]
   // private GameObject itemObject;
    public List<Item> Items = new List<Item>();

    
    
    private void Awake()
    {   
        Instance = this;
       
    }
    private void Start()=> Init();
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
    public void Init()
    {
        Debug.Log("Init Item in inventory");
        Item _item = new Item();
        _item.itemName = "Sword";
        _item.itemQuantity = 1;
         /*itemObject = Instantiate();
            Text _itemName = _object.transform.Find("Textures/Potion").GetComponent<Text>();
            Image _itemIcon = _object.transform.Find("Textures/Potion").GetComponent<Image>();
                
            _itemName.text = item.itemName;
            _itemIcon.sprite = item.itemIcon;
            Text _itemName = transform.Find("Textures/Potion").GetComponent<Text>();
             Image _itemIcon = transform.Find("Textures/Potion").GetComponent<Image>();

              _itemName.text = _item.itemName;
              _itemIcon.sprite = _item.itemIcon;
        */
        Items.Add(_item);
       /*
        * InventoryItrms = >ItemContent.Het
        for (int i = 0; i < Items.Count; i++)
        {
            Items.Add(InventoryItemsController[i]);
        }
        InventoryItemsController = ItemsContent
       */
    }
}
