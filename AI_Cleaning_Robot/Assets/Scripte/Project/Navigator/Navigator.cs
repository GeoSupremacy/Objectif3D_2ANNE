using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Navigator : MonoBehaviour
{
    [SerializeField, Range(-20, 20)] float min = -20;
    [SerializeField, Range(-20, 20)] float max = 20;
    public Vector3 Move { get;  set; }
    private void Start() => Init();
    private void OnDrawGizmos() => DrawDebug();
    protected virtual void DrawDebug()
    {
      
    }
    protected virtual void Init()
    {
         
    }
    public virtual void NextMove()
    {
        float _x = Random.Range(-min, max), _z = Random.Range(-min, max);
        Vector3 _nextMove = new(_x, 0, _z);
        Move= _nextMove;
    }
}
