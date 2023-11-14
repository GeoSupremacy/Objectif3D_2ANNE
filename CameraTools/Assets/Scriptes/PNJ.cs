using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PNJDialogCameraSystem))]
public class PNJ : MonoBehaviour
{
    [SerializeField] PNJDialogCameraSystem pnjDialogSystem = null;

    void Start() => Init();

    void Init()
    {
        pnjDialogSystem = GetComponent<PNJDialogCameraSystem>();
        pnjDialogSystem.InitCameraDialog();
    }
    //private void Update()
   // {
        //if (!pnjDialogSystem)  
           // throw new System.NullReferenceException("PNJ => Update:  pnjDialogSystem is missing");
       // pnjDialogSystem.UpdateCameraLocation();
   // }
}