using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    Dictionary<string, CameraManaged> allCameras = new();
    [SerializeField] private CameraFollow cameraFollowType = null;
    //[SerializeField] private OrbitCamera cameraOrbitType = null;
    public void AddCamera(CameraManaged _camera)
    {
        string _lowerID = _camera.CameraID.ToLower();
        if (allCameras.ContainsKey(_lowerID))
            return;
        allCameras.Add(_lowerID, _camera);
        _camera.name += " [MANAGED]";
    }
    public void RemoveCamera(CameraManaged _camera)
    {
        string _lowerID = _camera.CameraID.ToLower();
        if (!allCameras.ContainsKey(_lowerID))
            return;
        allCameras.Remove(_lowerID);
    }

    public void DisableCamera(CameraManaged _camera)=> allCameras[_camera.CameraID.ToLower()].Disable();
    public void EnableCamera(CameraManaged _camera) => allCameras[_camera.CameraID.ToLower()].Enable();

    public void EnableCamera(string _cameraID) =>  allCameras[_cameraID.ToLower()].Enable();

    public void DisableCamera(string _cameraID) => allCameras[_cameraID.ToLower()].Disable();


   public void CreateCameraFollow(string _id, Transform _target)
    {
        CameraFollow _instance = Instantiate(cameraFollowType);
        _instance.SetTarget(_target);
        _instance.GetComponent<CameraManaged>().RegisterCamera(_id);
    }
    public void CreateCamera<T>(T prefab, string _id, Transform _target) where T :CameraMovements
    {

        T _instance = Instantiate(prefab);
        _instance.SetTarget(_target);
        _instance.GetComponent<CameraManaged>().RegisterCamera(_id);
    }
    
    /*  public void CreateCameraOrbit(string _id, Transform _target)
      {
          CameraFollow _instance = Instantiate(cameraOrbitType);
          _instance.SetTarget(_target);
          _instance.GetComponent<CameraManaged>().RegisterCamera(_id);
      }
    */
}
