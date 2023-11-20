using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using static UnityEditor.Progress;

public class CamZoneManager : SingletonPattern<CamZoneManager>, IManager<string, CamZoneTrigger>
{
    [SerializeField] Dictionary<string, CamZoneTrigger> items = new();
    public Dictionary<string, CamZoneTrigger> AllItems => items;

   public  CamZoneTrigger Add(CamZoneTrigger item)
    {
        string _tol = item.ID.ToLower();
        if (items.ContainsKey(_tol))
            return null;
        item.name += "[Managed]";
        items.Add(_tol, item);
        return item;
    }
    public CamZoneTrigger Remove(CamZoneTrigger item)
    {
        string _tol = item.ID.ToLower();
        if (!items.ContainsKey(_tol))
            return null;
        items.Remove(_tol);
        return item;
    }
    public bool Enable(string _id)
    {
        string _tol = _id.ToLower();
        if (!items.ContainsKey(_tol))
            return false;

        foreach (KeyValuePair<string, CamZoneTrigger> item in items)//Parcourir Dictionnaire
            item.Value.Disable();

        items[_tol].Enable();
        return true;
    }
    public  bool Disable(string _id)
    {
        string _tol = _id.ToLower();
        if (!items.ContainsKey(_tol))
            return false;
        
       
        items[_tol].Disable();
        return true;
    }
}
