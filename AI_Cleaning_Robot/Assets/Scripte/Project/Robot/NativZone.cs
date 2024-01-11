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
}
