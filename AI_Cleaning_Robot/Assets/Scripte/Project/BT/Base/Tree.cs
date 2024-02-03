using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tree : MonoBehaviour
{
 
    void Start()
    {
        Enter();
    }
  protected virtual void Enter()
    { 
    }
    protected virtual void UpdateTree()
    {
        
    }
    public virtual  void NextNode(Node _node)
    { 
    }
    public virtual void Exit()
    { 

    }
    void Update()
    {
        UpdateTree();
       
    }

    private void OnDestroy()
    {
        Exit();
    }
}
