using System;
using UnityEngine;

public class Turn_Around_Camera : MonoBehaviour
{
    [SerializeField] 
    private Transform target = null;
   // [SerializeField, Range(-10,10)]
   // private float distanceSpeed = .1f;
    
    float currentX, currentY;

    float distance;
    public Vector3 TargetPosition
    {
        get
        {
            if (!target)
                throw new CameraTargetNullReferenceException();
            return target.position;
        }

    }

    public Vector3 CurrentPosition => transform.position;
    private void Start()
    {
        distance =Vector2.Distance(CurrentPosition, TargetPosition);
    }
    private void OnDrawGizmos() => DrawDebug();

    private void LateUpdate() => TurnAround();
    private void DrawDebug()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(CurrentPosition, TargetPosition);
    }
    private void TurnAround()
    {
        
        float _y = Mathf.Sin(transform.eulerAngles.y) *Mathf.Cos(transform.eulerAngles.x);
        float _x = Mathf.Cos(transform.eulerAngles.y) * Mathf.Cos(transform.eulerAngles.x);
        // transform.RotateAround(TargetPosition, Vector3.up, distanceSpeed * Time.deltaTime);
    }
}
