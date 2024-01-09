using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMComponent : MonoBehaviour
{
    #region f/p
    [SerializeField]
    private FSMObject currentFSMType = null;
    #endregion

    #region Method
    void Init()
    { 
    }
    void UpdateFSM()
    { 
    }
    void CloseFSM()
    {
    }
    #endregion

    #region UNITY_METHOD
    void Start()
    {
        Init();
    }

    void Update()
    {
        UpdateFSM();
    }
    private void OnDestroy()
    {
        CloseFSM();
    }
     #endregion
}
