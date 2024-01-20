using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class Manager : MonoBehaviour
{
   
    [SerializeField]
        List<Managed> listManaged = new List<Managed>();
    public int Count { get; private set; }
    [SerializeField]
    SpawnGrid spawnGrid = null;
    private void Awake()
    { 
        spawnGrid = this.GetComponent<SpawnGrid>();
       
    }
    
    void Delete(Managed _regist)=> listManaged.Remove(_regist);
    public void Register(Managed _regist)
    {
        Count++;
        listManaged.Add(_regist);
        _regist.Name(this);
    }
    public void SetSister(Managed _regist)
    {
        foreach (var item in listManaged)
        {
            float _dist = Vector3.Distance(item.transform.position, _regist.transform.position);
            if (item != _regist)
                if (_dist >= spawnGrid.RangeColumn || _dist >= spawnGrid.RangRown && 
                    _dist <= spawnGrid.RangeColumn+1 || _dist <= spawnGrid.RangRown+1)
                        _regist.AddSister(item);
            
        }
    }

}
