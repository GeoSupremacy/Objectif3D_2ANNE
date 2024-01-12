using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Robot : MonoBehaviour
{


    #region f/p
    [SerializeField, Range(0, 100)] float speed = 5;
    [field: SerializeField] public Vector3 NextMove { get; set; }
    public bool Move { get; set; }
 
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
        if (Destination())
        {
            Move = false;
            return;
        }

        if (Move)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public bool Destination()=> Magnitude ()<= 1f;
    public float Magnitude() => math.abs(Vector3.Magnitude(NextMove - transform.position));
    public void Look()
    {
        Vector3 _relativePosition = NextMove - transform.position;
        Quaternion rotation = Quaternion.LookRotation(_relativePosition, Vector3.up);
        rotation = new(0, rotation.y, 0, rotation.w);
        transform.rotation = rotation;
    }
    protected virtual void Init() { }
    protected virtual void DrawDebug() { }
    protected virtual void Bind() { }
    public virtual void Dead()=>Destroy(this.gameObject); 
    public virtual void Stop()
    {
       
        Move = false;
    }
    #endregion
}
