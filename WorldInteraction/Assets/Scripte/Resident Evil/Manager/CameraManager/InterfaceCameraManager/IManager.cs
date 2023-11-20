using System.Collections.Generic;
using UnityEngine;

public interface IManagerT<Tkey, TItem> where TItem : MonoBehaviour
{
    Dictionary<Tkey, TItem> itemsManaged { get; }
    void Add(TItem _item);
    void Remove(TItem _item);
    void EnableItem(TItem _item);
    void DisableItem(TItem _item);
    void EnableItem(Tkey _item);
    void DisableItem(Tkey _item);
}
