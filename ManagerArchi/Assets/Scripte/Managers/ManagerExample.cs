

using System.Collections.Generic;
using UnityEngine;

public class ManagerExample : SingletonPattern<ManagerExample>, IManager<string, ItemManaged>
{
    Dictionary<string, ItemManaged> items = new();
   public  Dictionary<string, ItemManaged> ItemMnaged => items;
    public void Add(ItemManaged _item)
    {
        if (items.ContainsKey(_item.ItemID.ToLower()))
            return;
        items.Add(_item.ItemID.ToLower(), _item);
        _item.name += "[MaNAGED]";
    }
    public  void Remove(ItemManaged _item)
    {
        if (!items.ContainsKey(_item.ItemID.ToLower()))
            return;
        items.Remove(_item.ItemID.ToLower());
    }
     public void EnableItem(string _item) =>items[_item.ToLower()].Enable();
    public  void DisableItem(string _item)=> items[_item.ToLower()].Disable();
    
    public void EnableItem(ItemManaged _item) => items[_item.ItemID.ToLower()].Enable();
    public  void DisableItem(ItemManaged _item) =>items[_item.ItemID.ToLower()].Disable();
    

}
