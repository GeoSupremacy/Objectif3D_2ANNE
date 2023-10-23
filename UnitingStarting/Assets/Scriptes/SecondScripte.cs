using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondScripte : MonoBehaviour
{
    [SerializeField]
    Scriptes scriptes = null;

    void Start() => Init();
    void Init()
    {
        Debug.Log($" FROM {name} TO {scriptes?.name} COUCOU => {scriptes?.Value}");
        gameObject.AddComponent<Scriptes>();
    }
}
