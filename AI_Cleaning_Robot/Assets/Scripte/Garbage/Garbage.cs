using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    
   

    public void Collected()
    {
        Destroy(this.gameObject);
    }
}
