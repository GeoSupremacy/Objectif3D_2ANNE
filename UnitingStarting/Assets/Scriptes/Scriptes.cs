using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scriptes : MonoBehaviour
{
   // [SerializeField] float value = 2, other =74, brek=60;

   // public float Value => value;
    void Awake()
    {
      //  Debug.Log("Awake");
       // name = gameObject.name;
       // transform.transform.localPosition = Vector3.zero;
       // GetComponent<Collider>().gameObject.name = name;
    }
    // Start is called before the first frame update
    void Start()
    {
      //  Debug.Log("Start");
    }

    // Update is called once per frame le moteur sans fout de la visibilité
    void Update()
    {
        //Debug.Log("Update");
    }
    void FixedUpdate()
    {
       // Debug.Log("FixedUpdate");
    }
    void LateUpdate()
    {
       // Debug.Log("Late Update");
    }
    void OnDestroy()
    {
        //Debug.Log("OnDestroy");
    }
}//
