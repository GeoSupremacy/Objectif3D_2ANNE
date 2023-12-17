using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
        Transform target;

    Vector3 FinalPosition => target.position +TurnAround();
    void Start()
    {
        
    }

   
    void Update()
    {
        FollowTargetView();
    }
    private void OnDrawGizmos() => DrawCircle();
    
    void FollowTargetView()
    { 

        Vector3 _target = (target.position -transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(_target);
        transform.position = FinalPosition;
    }
    Vector3 TurnAround()
    {
        float _angle = Time.time * 360;
        float x = Mathf.Cos(_angle * Mathf.Deg2Rad)  *5, 
              z = Mathf.Sin(_angle * Mathf.Deg2Rad)  * 5;
        return new Vector3(x,0, z);
    }
    void DrawCircle()
    {
        int _part = 360 / 20;
        //
        for (int i = 0; i <= _part; i++)
        {
            float _x = Mathf.Deg2Rad * (_part * i), 
                  _y = Mathf.Deg2Rad * (_part *(i+1));
            Vector3 _from = new Vector3(Mathf.Cos(_x) * 5, 0, Mathf.Sin(_x) * 5), 
                    _to = new Vector3(Mathf.Cos(_y) * 5, 0, Mathf.Sin(_y) * 5);
            Gizmos.DrawLine(transform.position + _from, transform.position + _to);
        }
    }
    void DrawDebug()
    { 
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward *5);
    }
}
