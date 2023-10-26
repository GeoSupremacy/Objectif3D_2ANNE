using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//How item affect and Item in scene
public class ItemController : MonoBehaviour
{
    public Item Item;
   public void RemoveItem()
    {
        InventorySystem.Instance.RemoveItem(Item);
        Destroy(gameObject);
    }

    public void AddItem(Item _newItem)
    {
        Item = _newItem;
    }

    public void Update()
    {
        switch(Item.itemType)
        {
            case Item.ItemType.Potion:
                Debug.Log("Potion");
                //TODO Player
                break;
            case Item.ItemType.Food:
                Debug.Log("Food");
                //TODO Player
                break;
            case Item.ItemType.CC:
                Debug.Log("CC");
                //TODO Player
                break;
            default:
                break;
        }
    }
}
