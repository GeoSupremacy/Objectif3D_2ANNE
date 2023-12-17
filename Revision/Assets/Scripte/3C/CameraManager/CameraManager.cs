using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonPattern<CameraManager>
{
    [SerializeField] 
    private  List<CameraManaged> cameraManageds = new List<CameraManaged>();
    private void Start()
    {
        name +=" [Instanciate]";
    }

    public static void AddCameraManaged(CameraManaged camera)
    {
        camera.name += " [Managed]";
        //cameraManageds.Add(camera);
    }
}
