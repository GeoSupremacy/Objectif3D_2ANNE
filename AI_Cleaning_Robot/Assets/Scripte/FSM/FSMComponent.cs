using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMComponent : MonoBehaviour
{
    [SerializeField] private FSM FSM;
    [field:SerializeField] private Robot robot;

    private void Start()
    {
        robot=this.GetComponent<Robot>();
        FSM= Instantiate(FSM);
        FSM?.StartSFM();
    }
    private void Update()
    {
        FSM?.Update();
    }
}
