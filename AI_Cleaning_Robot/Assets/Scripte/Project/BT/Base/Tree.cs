using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tree : MonoBehaviour
{
     [SerializeField, HideInInspector] private Node root = null;
    protected abstract Node SetupTree();
    void Start()
    {
        root = SetupTree();
    }

    // Update is called once per frame
    void Update()
    {
        if (root != null)
            root.Execute();
    }
}
