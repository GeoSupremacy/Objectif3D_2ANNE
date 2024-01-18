using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMComponent : MonoBehaviour
{
   
     private FSM FSM;
     public Robot Owner { get;  set; }

    private  void Start()
    {
        Owner = this.GetComponent<Robot>();
        FSM= Instantiate(FSM);
        FSM?.StartSFM(this);
    }
    private void Update()
    {
        FSM?.Update();
    }
    private void OnDestroy()=> FSM?.StopFSM();
  
}
