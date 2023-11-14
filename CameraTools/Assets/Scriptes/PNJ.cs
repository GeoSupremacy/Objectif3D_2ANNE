using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(PNJDialogCameraSystem))]
public class PNJ : MonoBehaviour
{
    [SerializeField] PNJDialogCameraSystem pnjDialogSystem = null;
    [SerializeField] DialogueSystem_Data dialogueSystem_Data = null; //Corecction
  //  [SerializeField] DialogUI dialogUI = null;

    void Start() => Init();

    void Init()
    {
        dialogueSystem_Data.OnNext += (d) => //Corecction
        {
            /*
             * pnjDialogSystem.SetLoookAt(d.IsPnj);
             camera->IsPNJ ? 
            //TODO updateUI
            dialogUI.Generate(dialogueSystem_Data);
            */
        };
        pnjDialogSystem = GetComponent<PNJDialogCameraSystem>();
        pnjDialogSystem.InitCameraDialog();
        dialogueSystem_Data.StartDialog(); //Corecction
    }
    //private void Update()
   // {
        //if (!pnjDialogSystem)  
           // throw new System.NullReferenceException("PNJ => Update:  pnjDialogSystem is missing");
       // pnjDialogSystem.UpdateCameraLocation();
   // }
}