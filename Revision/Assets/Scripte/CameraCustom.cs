using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraCustom : MonoBehaviour
{
    Quaternion fwd;
    [SerializeField] float speedRotation = 100;
    [SerializeField] protected Transform target;

    public Vector3 TargetPosition => target.position;
    private void LateUpdate() =>UpdateRotation();
    

    public void UpdateRotation()
    {
       
        if (!target)
            return;
        fwd = Quaternion.LookRotation(TargetPosition - transform.position).normalized;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, fwd, speedRotation * Time.deltaTime);
    }
}
