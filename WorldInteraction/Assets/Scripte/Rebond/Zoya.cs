using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class Zoya : MonoBehaviour
{
    [SerializeField] int bounces = 5;
    [SerializeField] float range = 5;
    Vector3[] points = null; 


    void Update() =>ZoyaBounce();
    
    void ZoyaBounce()
    {
        points  =new Vector3[bounces];
        RaycastHit _result;
        Ray _ray = new(transform.position, transform.forward);

        for (int i = 0; i < bounces; i++) 
        {
            points[i] = _ray.origin;
            Physics.Raycast(_ray.origin, _ray.direction, out _result, 100);
           // Debug.DrawRay(_ray.origin, _ray.direction* range, Color.red);//
           // Gizmos.DrawWireSphere(_ray.direction * range, 0.5f);
            _ray = new(_result.point, Vector3.Reflect(_ray.direction, _result.normal));
            
            //UkismetMathLibrary::GetReflectionVector(d, n)
        }
    }
    Vector3 Reflect (Vector3 _direction, Vector3 _normal) => _direction - 2 * Vector3.Dot(_direction, _normal) * _normal;

    private void OnDrawGizmos() => DrawDebug();
   
    void DrawDebug()
    {
        
        Gizmos.color = Color.red;
        for (int i = 0; i < points?.Length; i++)
        {
            if (i < points.Length - 1)
                Gizmos.DrawLine(points[i], points[i + 1]);
            Gizmos.DrawWireSphere(points[i], 0.5f);

        }
    }
}
