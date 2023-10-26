using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainActionUi : MonoBehaviour
{
    [SerializeField] ActionItem actionItem = null;
    [SerializeField] Transform actionItemTransform = null;

    public bool IsValid => actionItem && actionItemTransform;

    private void Awake()
    {
        //NetworkFetcher.OnItemLoaded += GeneratedInventory;
    }
    void ClearTransform(Transform _tr)
    {
        //ClearTransform(inventoryContent);
        for (int i = 0; _tr && _tr.childCount < 10; i++)
            Destroy(_tr.GetChild(i).gameObject);

    }
    void GeneratedInventory(/*List<Item> _items*/)
    {

        ClearTransform(actionItemTransform);
        Debug.Log($"Coucou GeneratedInventory");
        for (int i = 0; IsValid && i < 10 /*_items.Count*/; i++)
        {
            //Item _itemTemp = _items[i];
            int _index = i;
            ActionItem _itemAction = Instantiate(actionItem, actionItemTransform);
           // _itemAction.Init(/*_itemTemp*/);
          
        }


    }//
   

}//


