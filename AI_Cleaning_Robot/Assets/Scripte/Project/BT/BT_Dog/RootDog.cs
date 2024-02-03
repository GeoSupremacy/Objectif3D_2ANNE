using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "RootDog", menuName = "BT/Root/Create DogNode")]

public class RootDog : DogNode
{

    [SerializeField] Node child = null;
    [SerializeField] static RootDog instance = null;
    public RootDog Instance => instance;
    DogRobot dog;
    public Node Child { get => child; set { child = value; } }
    protected override ENodeState ProcessNode()
    {
        if (!child) { Debug.LogError("RootDog: ProcessNode as failed "); return ENodeState.FAILED; }
        Debug.Log("ProcessNode "+name);
        child.AddParent(this);
        return child.Execute();
       
    }
    public override ENodeState Execute()
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
    protected override void AddOwner(Robot _dog)
    {
        dog = (DogRobot)_dog;
    }
    protected override void StartNode()
    {
        Debug.LogError("StartNode " + name +" Child: " +child);
    }

    protected override void StopNode()
    {
        Debug.LogError("StopNode " + name);
    }

    public override Node Clone()
    {
        RootDog _node = Instantiate(this);
        if (_node.child) return _node;
        _node.child = child.Clone();
        return _node;
    }
}
