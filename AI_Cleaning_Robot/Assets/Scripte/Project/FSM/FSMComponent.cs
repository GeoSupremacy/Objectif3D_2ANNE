using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMComponent : MonoBehaviour
{
    [SerializeField] private FSM FSM;
    [field: SerializeField] public RobotClean Owner { get; private set; }

    private void Start()
    {
        Owner = this.GetComponent<RobotClean>();
        FSM= Instantiate(FSM);
        FSM?.StartSFM(this);
    }
    private void Update()
    {
       
        FSM?.Update();
    }
    private void OnDestroy()=> FSM?.StopFSM();
    
}
