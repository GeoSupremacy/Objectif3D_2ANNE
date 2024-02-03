using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;



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
    [field: SerializeField] public GameObject Target { get;  set; } = null;
    public bool FinalDestination => DestinationNextMove <= 1f;
    public bool LostTarget => DestinationTarget >= sightSensorComponent.LostRange;
    public float DestinationNextMove => math.abs(Vector3.Magnitude(NextMove - transform.position));
    public float DestinationTarget => math.abs(Vector3.Magnitude(Target.transform.position - transform.position));
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
        
        if (FinalDestination)
        {
            Move = false;
            return;
        }
        
           

        if (Move)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void Look()
    {
        Vector3 _relativePosition = NextMove - transform.position;
        Quaternion rotation = Quaternion.LookRotation(_relativePosition, Vector3.up);
        rotation = new(0, rotation.y, 0, rotation.w);
        transform.rotation = rotation;
    }
    public void ClearnSight()=> sightSensorComponent.ClearnSight();
    [SerializeField] public bool Detection => sightSensorComponent.Target;
    protected virtual void Patrol() 
    {
       
        Look();
        Move = true;
    }
    protected virtual void Init() { }
    public virtual void Follow() 
    {
        Look();
        if (LostTarget)
        {
            sightSensorComponent.ClearnSight();
            return;
        }

        if (Target)
            NextMove = Target.transform.position;
       
       
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
