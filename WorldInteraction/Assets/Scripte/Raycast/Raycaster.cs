using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Raycaster : MonoBehaviour
{
    Vector2 hitPoint;
    float pointrange =100;
    [SerializeField] private LayerMask hitLayer;
    bool hit = false;
    private void Update() => DetectObjbect();
    private void Start()
    {
        InvokeRepeating(nameof(DetectObjbect), 0, 1);
       // CancelInvoke();
    }
    void DetectObjbect()
    {
        hit =  Physics.Raycast(new(transform.position, transform.forward), out RaycastHit _result, 100, hitLayer);
        if (hit)
        {
            hitPoint = _result.point;
            Debug.Log("RayCast");
        }
        else
        {
            hitPoint = transform.position;
            pointrange = 100;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Ray _r = new(transform.position, transform.forward);
        if (!hit)
            Gizmos.DrawRay(_r.origin, _r.direction * pointrange);
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_r.origin, hitPoint);
        }
    }
}
