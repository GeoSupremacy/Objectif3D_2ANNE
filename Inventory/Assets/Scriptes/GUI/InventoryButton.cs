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
        inventoryText.text = _label;
        inventoryButton.onClick.AddListener(() => _toDo?.Invoke());
    }
}

#region r
/*
  [SerializeField]
   Inventory inventory = null;

   GameObject inventoryItem = null;
    Transform inventoryContent = null;

   private void Start()
   {
       if (!inventory.GetComponent<Inventory>() || !inventory)
       {
           Debug.Log("We can't display Inventory! ");
           return; //inventory = gameObject.AddComponent<Inventory>();
       }
       ListInventory();
   }

   void ListInventory()
   { 
       foreach (Item item in inventory.GetComponent<Inventory>().items) 
       {


           GameObject _object = Instantiate(inventoryItem, inventoryContent);
           Text _itemName = _object.transform.Find("Textures/Potion").GetComponent<Text>();
           Image _itemIcon = _object.transform.Find("Textures/Potion").GetComponent<Image>();

           _itemName.text = item.ItemName;
           _itemIcon.sprite = item.ItemIcon;
       }
   }
   */
#endregion