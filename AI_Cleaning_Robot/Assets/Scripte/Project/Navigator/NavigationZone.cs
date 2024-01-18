using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class NavigationZone : Navigator
{
    [SerializeField]
        BoxCollider boxCollider = null;


    protected override void Init()=> boxCollider = this.GetComponent<BoxCollider>();
    protected override void DrawDebug()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(boxCollider.gameObject.transform.position, boxCollider.gameObject.transform.localScale);
    }
    public  override void NextMove()
    {
        float _x = Random.Range(-(boxCollider.gameObject.transform.localScale / 2).x, (boxCollider.gameObject.transform.localScale / 2).x),
             _z = Random.Range(-(boxCollider.gameObject.transform.localScale / 2).z, (boxCollider.gameObject.transform.localScale / 2).z);
        Move = new(_x, 0, _z);
    }
   

}
