using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

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
    public IEnumerator SetSister(Managed _regist)
    {
        yield return new WaitForSeconds(1);
     
        foreach (var item in listManaged)
        {
            float _dist = Vector3.Distance(item.transform.position, _regist.transform.position);
            if (item != _regist)
                if (_dist >= spawnGrid.RangeColumn && _dist <= Hypothenuse(spawnGrid.RangRown, spawnGrid.RangeColumn)
                                                    ||
                    _dist >= spawnGrid.RangRown && _dist <= Hypothenuse(spawnGrid.RangRown, spawnGrid.RangeColumn))
                        _regist.AddSister(item);
                    
           
        }
    }
    float Hypothenuse(float _a, float _b)
    {
       
        return Mathf.Sqrt((_a * _a) + (_b * _b));
    }
}
