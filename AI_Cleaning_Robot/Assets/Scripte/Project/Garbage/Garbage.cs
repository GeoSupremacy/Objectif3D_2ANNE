using System;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public static Action<Garbage> onRegister = null;
    public static Action<Garbage> onDeath = null;
    public Vector3 Position =>transform.position;
    private void Awake()
    {
        onRegister?.Invoke(this);
    }
    public void Collected()
    {
       
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        onDeath?.Invoke(this);
        onRegister = null;
        onDeath =null;
    }
}
