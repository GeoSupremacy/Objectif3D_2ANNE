using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CameraManager : SingletonPattern<CameraManager>
{
    Dictionary<string, ItemManaged> itemsManaged = new();
    public Dictionary<string, ItemManaged> ItemsManaged => itemsManaged;
    public void Add(ItemManaged _item)
    {
        if (itemsManaged.ContainsKey(_item.ItemID.ToLower()))
            return;
        itemsManaged.Add(_item.ItemID.ToLower(), _item);
        _item.name += "[MANAGED]";
    }
    public void Remove(ItemManaged _item)
    {
        if (!itemsManaged.ContainsKey(_item.ItemID.ToLower()))
            return;
        itemsManaged.Remove(_item.ItemID.ToLower());
    }
    public void EnableItem(string _item) => itemsManaged[_item.ToLower()].Enable();
    public void DisableItem(string _item) => itemsManaged[_item.ToLower()].Disable();

    public void EnableItem(ItemManaged _item) => itemsManaged[_item.ItemID.ToLower()].Enable();
    public void DisableItem(ItemManaged _item) => itemsManaged[_item.ItemID.ToLower()].Disable();
}
