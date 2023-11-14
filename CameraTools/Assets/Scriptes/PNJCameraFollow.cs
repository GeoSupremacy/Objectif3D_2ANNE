using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJCameraFollow : CameraFollow
{
    Vector3 destination, pivot;
    public override Vector3 FinalPosition => destination;
    public override Vector3 TargetPosition => pivot;
    public void SetDestination(Vector3 _vector)
    {
       transform.position = _vector;
        destination = _vector;
    }
    public void SetLookAt(Vector3 _vector)
    {
       
        pivot = _vector;
    }
}