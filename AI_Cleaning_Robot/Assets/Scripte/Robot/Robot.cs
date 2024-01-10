using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Robot : MonoBehaviour
{

    [field: SerializeField] Vector3 NextMove { get; set; }
    [field: SerializeField] Garbage garbage;
    [SerializeField] private LayerMask hitLayer;
    [SerializeField]
    Vector3 position; 
    [SerializeField, Range(0,100)]
    float distance = 5;
    [SerializeField, Range(0, 100)]
    float speed = 5;
    bool touch = false;
    Vector3 RobotPosition => position + transform.position;
    public void SetRotate(Quaternion _rotate) => transform.rotation = _rotate;
    void Update()
    {
        Detected();
        MoveTo();
        Collect();
    }
    private void OnDrawGizmos() => DrawDebug();
    void Collect()
    {
        if (garbage == null)
            return;
        float _v= math.abs(NextMove.x- transform.position.x);
        
        if(_v >= 0.05f ) return;
        
        garbage.Collected();
        garbage = null;
        touch = false;
    }
    void MoveTo() 
    {
        if(touch)
            transform.position = Vector3.MoveTowards(transform.position, NextMove, speed);
    }
    void Detected()
    {
        if (touch)
            return;
        bool _hit = Physics.Raycast(new(RobotPosition, transform.forward), out RaycastHit _result, distance, hitLayer);
        if (_hit)
        {
         
            garbage = _result.collider.gameObject.GetComponent<Garbage>();
            NextMove = garbage.transform.position;
            touch = true;
        }
    }
    void DrawDebug()
    {
        Color _color;
        Ray _r = new(RobotPosition, transform.forward);
        bool _hit = Physics.Raycast(_r.origin, _r.direction, out RaycastHit _result, distance, hitLayer);
        if (_hit)
        {
            _color = Color.white;
        }
        else
            _color = Color.red;
        Gizmos.color = _color;
        Gizmos.DrawRay(_r.origin, _r.direction * distance);
    }
}
