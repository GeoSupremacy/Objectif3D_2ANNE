using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ENodeState
{
   
    SUCCESS,
    RUNNING,
    FAILED,
   
}

public abstract class Node : ScriptableObject
{
    [SerializeField] protected ENodeState currentState = ENodeState.RUNNING;
    [SerializeField] protected bool startDone = false, processDone = false, stopDone = false;
    [SerializeField] public Node parent;
    [SerializeField] protected List<Node> children = new List<Node>();
    [SerializeField] protected Robot robot;
    public int Count => children.Count;
    public Robot Robot => robot;
    protected virtual void AddOwner(Robot _robot)
    {
        robot = _robot;
    }
    public virtual void AddParent(Node _parent)
    {
        parent = _parent;
        parent.AddOwner(_parent.Robot);
    }
    
    public ENodeState CurrentState => currentState;
    public virtual ENodeState Execute()
    {
        if (!startDone) { StartNode(); startDone = true; }
        currentState = ProcessNode();
        Debug.Log("Execute " + name);
        if (currentState != ENodeState.RUNNING)
        {
            StopNode();
            startDone = false;
            stopDone = true;
        }
        return currentState;
    }

    private void Attach(Node node)
    {
        //Add child to Node
        node.parent = this;
        children.Add(node);
    }
    public void AttachAll(List<Node> children)
    {
        //Add all child to Node
        foreach (Node child in children)
            Attach(child);
    }
   
    public virtual Node Clone() => Instantiate(this);
    protected abstract void StartNode();
    protected abstract ENodeState ProcessNode();
    protected abstract void StopNode();

   
}













/*
   public void SetData(string key, object value)=> dataContext[key] = value;
   public object GetData(string key)
   {
       object val = null;
       if (dataContext.TryGetValue(key, out val))
           return val;

       Node node = parent;
       if (node != null)
           val = node.GetData(key);
       return val;
   }
   public bool ClearData(string key)
   {
       bool cleared = false;
       if (dataContext.ContainsKey(key))
       {
           dataContext.Remove(key);
           return true;
       }

       Node node = parent;
       if (node != null)
           cleared = node.ClearData(key);
       return cleared;
   }
   */