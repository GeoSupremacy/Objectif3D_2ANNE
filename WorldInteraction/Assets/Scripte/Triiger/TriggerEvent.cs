using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       Test _test = other.GetComponent<Test>();
        if (_test != null)
            return;
        Debug.Log("Enter "+ other.name);
    }
    private void OnTriggerStay(Collider other) // agit de similitude comme un update
    {
        Debug.Log("Stay ");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit ");
    }
    private void OnCollisionEnter(Collision collision) //Fin mur
    {
        
    }
}
public class Test : MonoBehaviour
{ 

}