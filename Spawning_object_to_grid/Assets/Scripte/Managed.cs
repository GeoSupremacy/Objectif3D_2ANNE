using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.ComponentModel;

public class Managed : MonoBehaviour
{
    static public Action<Managed> onRegister = null;
    static public Action<Managed> onDelete = null;

    [SerializeField]
    Manager creator = null;
    [SerializeField]
    List<Managed> sister = new List<Managed>();
    private void Awake()
    {
        onRegister?.Invoke(this);
        
      
    }
    private void Start()
    {
        
    }
   public void Register(Managed _sis)=>sister.Add(_sis); 
   private void OnDestroy()=>Destroy();


   private void Destroy()
    {
        onDelete?.Invoke(this);
        onRegister = null;
        onDelete = null;
       
    }
   public void AddSister(Managed _sister)=> sister.Add(_sister);
   public  void MyCreator(Manager _manager)=> creator = _manager; 
   public void Name(Manager _manager)=> name = _manager.Count+" " +"Managed: " + _manager.name;
       
    
}
