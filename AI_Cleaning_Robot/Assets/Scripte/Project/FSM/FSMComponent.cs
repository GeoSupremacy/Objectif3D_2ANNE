using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMComponent : MonoBehaviour
{
    [SerializeField] private FSM FSM;
    [field: SerializeField] public Robot Robot { get; private set; }

    private void Start()
    {
        Robot=this.GetComponent<Robot>();
        FSM= Instantiate(FSM);
        FSM?.StartSFM(this);
    }
    private void Update()
    {
        if (FSM == null)
        {
            Debug.Log("FSMComponent: " + name + " as not FSM");
        }
        FSM?.Update();
    }
}
