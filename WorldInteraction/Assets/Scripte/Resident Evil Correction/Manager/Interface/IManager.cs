using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public interface  IManager<TID, TItem> where TItem : MonoBehaviour,IManagedItem<TID>
{
   
    Dictionary<TID, TItem> AllItems { get; }
    TItem Add( TItem item);
    TItem Remove(TItem item);
    bool Enable(TID _id);
    bool Disable(TID _id);
}
