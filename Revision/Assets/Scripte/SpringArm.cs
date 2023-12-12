using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringArm : MonoBehaviour
{
    Transform cameraTransform = null;
    [SerializeField, Range(0, 100)] float armLenght = 5;
    Vector3 FinalPoint => transform.position + transform.forward * armLenght;


    private void LateUpdate() => UpdateCameraPosition(GetCameraAlpha());
    private void OnDrawGizmos() => DrawDebug();
    void Start() => FindCamera();

    void FindCamera()
    {
        if (transform.childCount == 0) 
            throw new System.NullReferenceException("Not possed child");


        Camera _cam = transform.GetChild(0).GetComponent<Camera>();
        if (!_cam)
            throw new System.NullReferenceException("Not possed child camera");
        cameraTransform = _cam.transform;
    }

    float GetCameraAlpha()
    {
        bool _result = Physics.Raycast(new Ray(transform.position, transform.forward * armLenght), out RaycastHit _hitInfo, armLenght);
        return _result ? (_hitInfo.distance / armLenght) : 1;
    }
    void UpdateCameraPosition(float _alpha = 1)
    {
        if (!cameraTransform)
            return;
        cameraTransform.transform.position = Vector3.Lerp(transform.position, FinalPoint, _alpha);
    }
    private void DrawDebug()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * armLenght);
    }
}

