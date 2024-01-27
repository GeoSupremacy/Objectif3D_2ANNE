using System.Collections;
using System;
using UnityEngine;

public class SightSensorComponent : MonoBehaviour
{
     public Action<GameObject> OnTarget = null;
    [SerializeField, Range(0, 100)]protected int sightAngle = 90;
    [SerializeField, Range(0, 100)]protected int range = 5;
    [field:SerializeField, Range(0, 100)] public float LostRange { get; private set; } = 5;
    [SerializeField, Range(0, 100)] protected int definition = 5;
    [SerializeField, Range(0, 100)] float hightPosition = 0.75f;
    [field: SerializeField] public GameObject Target { get;  set; }
    [SerializeField] protected LayerMask mask;
    [SerializeField] protected bool onDrawDebug = false;
    bool stop = false;
    [SerializeField] protected bool hit = false;
    public Vector3 Offset => new(0, hightPosition, 0);
   public Vector3 PositionOffset => transform.position + Offset;
    public void Desactivate() => stop = true;
    public bool Impact { get; private set; }
   
    private void Update()=> UpdateSight();
    private void OnDrawGizmos() => DrawDebug();
    private void OnDestroy()
    {
        OnTarget = null;
    }
    public virtual void UpdateSight()
    {
        if(Target || stop)
            return; 


        Vector3 _offset = new(0, hightPosition, 0),
                _origin= transform.position +_offset,
                _to;

        for (int i = -(sightAngle/2); i < sightAngle/2; i+=definition) 
        {

            _to =(transform.position  + Quaternion.Euler(0,i,0 )*(transform.forward * range))  
                + (_offset * Mathf.Sin(Time.time));
           
            Debug.DrawRay(_origin, _to- _origin, Color.magenta);
            Impact = Physics.Raycast(_origin, _to - _origin, out RaycastHit _hit, range, mask);
            if(Impact)
            {
                
                Target = _hit.collider.gameObject;
                OnTarget?.Invoke(_hit.collider.gameObject);
                return;
            }
           
        }
    }
    protected virtual void DrawDebug()
    {
        if (!onDrawDebug || stop)
            return;
        Vector3 _offset = new(0, hightPosition, 0),
                _origin = transform.position + _offset,
                _to;

        for (int i = -(sightAngle / 2); i < sightAngle / 2; i += definition)
        {

            _to = (transform.position + Quaternion.Euler(0, i, 0) * (transform.forward * range))
                + (_offset * Mathf.Sin(Time.time));

          
            bool Impact = Physics.Raycast(_origin, _to - _origin, out RaycastHit _hit, range, mask);
            Debug.DrawRay(_origin, _to - _origin, Impact? Color.red : Color.magenta);

        }
    }
    public void ClearnSight() { Target = null; OnTarget?.Invoke(null); }

}


/*
           float _a = (float) i;
           float _x =Mathf.Cos(_a * Mathf.Deg2Rad) *range,
                 _z = Mathf.Sin(_a * Mathf.Deg2Rad) * range;

           Debug.DrawLine(transform.position, transform.position+ new Vector3(_x,0,_z));
 */