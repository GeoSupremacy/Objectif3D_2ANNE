using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManaged : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CameraManager.AddCameraManaged(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
