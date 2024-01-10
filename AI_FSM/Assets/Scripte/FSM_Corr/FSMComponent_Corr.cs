using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMComponent_Corr : MonoBehaviour
{
    [field: SerializeField] public Launcher GetLauncher { get; private set; }
    [field: SerializeField] public FSM_Corr FSM { get; private set; }
    [SerializeField]  FSM_Corr currentFSM = null;
    private void Start()
    {
        currentFSM = Instantiate(FSM);
        currentFSM?.StartFSM(this);
    }

    private void Update()
    {
        currentFSM?.UpdateSFM();
    }
    private void OnDestroy()
    {
        currentFSM?.StopFSM();
    }
}
