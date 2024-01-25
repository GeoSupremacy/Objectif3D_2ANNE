using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


[RequireComponent(typeof(SightSensorComponent))]
public class Robot : MonoBehaviour
{
    //

    #region f/p
    [SerializeField, Range(0, 100)] float speed = 5;
    protected SightSensorComponent sightSensorComponent;
    [SerializeField] protected bool isDebug = false;
    [field: SerializeField] public Vector3 NextMove { get; set; }
    [field: SerializeField]  public bool Move { get; set; }
    public bool IsDead { get; set; } = false;
    [field: SerializeField] public Navigator Zone { get;  set; }
    [field: SerializeField] public GameObject Target { get; private set; } = null;
    #endregion

    #region Acesseur
    public void SetRotate(Quaternion _rotate) => transform.rotation = _rotate;
    #endregion

    #region UNITY_METHOD
    private void Awake() => Bind();
    private void Start() => Init();
    protected virtual void Update()=> MoveTo();
    private void OnDrawGizmos() => DrawDebug();
    #endregion

    #region METHOD
    void MoveTo()
    {
        
        if (Destination)
        {
            Move = false;
            return;
        }
        
           

        if (Move)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public bool Destination=> Magnitude <= 1f;
    public bool LostTarget  => Magnitude >= 5f; 
    public float Magnitude => math.abs(Vector3.Magnitude(NextMove - transform.position));
    public void Look()
    {
        Vector3 _relativePosition = NextMove - transform.position;
        Quaternion rotation = Quaternion.LookRotation(_relativePosition, Vector3.up);
        rotation = new(0, rotation.y, 0, rotation.w);
        transform.rotation = rotation;
    }
    [SerializeField] public bool Detection => sightSensorComponent.Target;
    protected virtual void Patrol() 
    {
       
        Look();
        Move = true;
    }
    protected virtual void Init() { }
    public virtual void Follow() 
    {
        
        if (LostTarget)
        {
            sightSensorComponent.ClearnSight();
            return;
        }

        if (Target)
            NextMove = Target.transform.position; 
        Look();
        if (Move)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    protected virtual void DrawDebug() {  }
    protected virtual void Bind() { }
    public virtual void Dead()=>Destroy(this.gameObject); 
    public virtual void Stop()
    {
       
        Move = false;
        IsDead = true;
        sightSensorComponent.Desactivate();
        sightSensorComponent = null;
    }
    public void SetFollower(GameObject _target) {  Target = _target;
        if (_target)
        {
            NextMove = _target.transform.position;
            Move = true;
        }
        else 
        { Move = false; } }
    #endregion
}
