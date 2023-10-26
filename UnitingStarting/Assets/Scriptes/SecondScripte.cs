using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondScripte : MonoBehaviour
{
   // [SerializeField]
    //Scriptes scriptes = null;
    [SerializeField]
    GameObject myObject = null;
    void Start() => Init();
    void Init()
    {
       
        myObject.AddComponent<Scriptes>();
      //  Debug.Log($" FROM {name} TO {scriptes?.name} COUCOU => {scriptes?.Value}");
        myObject = new GameObject();
    }
}//
