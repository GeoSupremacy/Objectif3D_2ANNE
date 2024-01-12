using System.Collections;
using UnityEngine;

public class SightSensorComponent : MonoBehaviour
{
    [SerializeField, Range(0, 100)] int sightAngle = 90;
    [SerializeField, Range(0, 100)] int range = 5;
    [SerializeField, Range(0, 100)] int definition = 5;
    [SerializeField, Range(0, 100)] float hightPosition = 0.75f;
    [field: SerializeField] public GameObject Target { get; private set; }
    [SerializeField] LayerMask mask;
    [SerializeField] bool onDrawDebug =false, 
                          stop = false;
    public void Desactivate() => stop = true;
    public bool Impact { get; private set; }
    private void Start()=> onDrawDebug = false;
    private void Update()=> UpdateSight();
    private void OnDrawGizmos() => DrawDebug();
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
                return;
            }
           
        }
    }
    void DrawDebug()
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
    public void ClearnSight() => Target = null;
}


/*
           float _a = (float) i;
           float _x =Mathf.Cos(_a * Mathf.Deg2Rad) *range,
                 _z = Mathf.Sin(_a * Mathf.Deg2Rad) * range;

           Debug.DrawLine(transform.position, transform.position+ new Vector3(_x,0,_z));
 */