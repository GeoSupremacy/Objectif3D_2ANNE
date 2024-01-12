using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class NativZone : MonoBehaviour
{
    [SerializeField]
        BoxCollider boxCollider = null;
    private void Start()
    {
        boxCollider = this.GetComponent<BoxCollider>();
    }
    private void Update()
    {
       
    }
    private void OnDrawGizmos() => DrawDebug();
    void DrawDebug()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(boxCollider.gameObject.transform.position, boxCollider.gameObject.transform.localScale);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(boxCollider.gameObject.transform.localScale-boxCollider.gameObject.transform.position, 1);
    }
}
