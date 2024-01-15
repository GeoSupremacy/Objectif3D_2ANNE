using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class NatigationZone : MonoBehaviour
{
    [SerializeField]
        BoxCollider boxCollider = null;

   public Vector3 Move { get; private set; }
   private void Start()=>boxCollider = this.GetComponent<BoxCollider>();
   
   public void NextMove()
    {
        float _x = Random.Range(-(boxCollider.gameObject.transform.localScale / 2).x, (boxCollider.gameObject.transform.localScale / 2).x),
             _z = Random.Range(-(boxCollider.gameObject.transform.localScale / 2).z, (boxCollider.gameObject.transform.localScale / 2).z);
        Move = new(_x, 0, _z);
    }
    private void OnDrawGizmos() => DrawDebug();
    void DrawDebug()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(boxCollider.gameObject.transform.position, boxCollider.gameObject.transform.localScale);
       
    }
}
