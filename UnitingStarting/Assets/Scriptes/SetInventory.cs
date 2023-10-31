using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using UnityEngine.UI;

public class SetInventory : MonoBehaviour
{
   static public List<Item> Items = new List<Item>();
   public static SetInventory InstanceSetInventory;
    [SerializeField]
     private GameObject Item;

    void Start()
    {
        InstanceSetInventory = this;
        Init();
    }

  
    void Init()
    {
        if (!Item)
        {
            Debug.Log("We can't iniate Item!");
            return;
        }
        for (int i = 0; i < 10; i++) 
        {
            
            GameObject _newGameObject =Item;
            _newGameObject.AddComponent<Item>();
            _newGameObject.GetComponent<Item>().itemName = "Sword";
            _newGameObject.name = "NewItem";
            Text _itemName = _newGameObject.transform.Find("Textures/Potion").GetComponent<Text>();
            Image _itemIcon = _newGameObject.transform.Find("Textures/Potion").GetComponent<Image>();

            _newGameObject.GetComponent<Item>().itemName = _itemName.text;
            _newGameObject.GetComponent<Item>().itemIcon =_itemIcon.sprite;
            Items.Add(_newGameObject.GetComponent<Item>());
        }
    }
}
