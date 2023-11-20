using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamZoneCamera : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Camera view = null;
    [SerializeField, Range(1, 100)] private float speed = 2;
    [SerializeField] bool canLookAt = true;
    private void LateUpdate()=> LookTarget();
    
    public void SetTarget(Transform _target)=> target = _target;
    
    void LookTarget()
    {
        if (!target)
            throw new System.NullReferenceException("CamZoneCamera => missing Target");

        if ( !canLookAt) 
            return;

        Quaternion _fwd = Quaternion.LookRotation(target.position- transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _fwd, speed);
       
    }
    public void EnableView(bool _statue) =>view.enabled = _statue;
    
}
