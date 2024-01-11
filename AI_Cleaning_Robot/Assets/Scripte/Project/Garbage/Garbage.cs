using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public static Action<Garbage> onRegister;
    public static Action<Garbage> onDeath;
    private void Awake()
    {
        onRegister?.Invoke(this);
    }
    public void Collected()
    {
        onDeath?.Invoke(this);
        Destroy(this.gameObject);
    }
}
