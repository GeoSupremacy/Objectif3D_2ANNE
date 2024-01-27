using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMComponent : MonoBehaviour
{
    [SerializeField]
    protected FSM FSM = null;
    [SerializeField, HideInInspector]
    protected FSM currentFSM = null;
    public Robot Owner { get;  set; }
    [field:SerializeField]
    public bool IsInfo { get; private set; } = true;
    private void Start() => Init();
    private void Update()
    {
        currentFSM?.Update();
    }
    private void OnDestroy()=> currentFSM?.StopFSM();
  
   protected virtual void Init()
    {
        Owner = this.GetComponent<Robot>();
        currentFSM = Instantiate(FSM);
        currentFSM?.StartSFM(this);
    }
}
