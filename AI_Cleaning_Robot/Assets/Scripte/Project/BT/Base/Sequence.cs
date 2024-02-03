using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Sequence", menuName = "BT/Sequence/Create Sequence")]

public class Sequence : Node
{

    protected override ENodeState ProcessNode()
    {
        Debug.LogError("???????");
        bool anyChildIsRunning = false;
        foreach (Node node in children)
        {
            switch (node.Execute())
            {
                case ENodeState.FAILED:
                    currentState = ENodeState.FAILED;
                    return currentState;
                case ENodeState.SUCCESS:
                    continue;
                case ENodeState.RUNNING:
                    anyChildIsRunning = true;
                    continue;
                default:
                    currentState = ENodeState.SUCCESS;
                    return currentState;
            }
        }
        currentState = anyChildIsRunning ? ENodeState.RUNNING : ENodeState.SUCCESS;
        return currentState;
    }


    protected override void StartNode()
    {
      
        if(children.Count==0)
        {
            Debug.LogError("Not Children " + name);
            return;
        }
        Debug.LogError("StartSequence " + name);
        foreach (Node node in children)
        {
            node.AddParent(this);
        }
    }
    protected override void StopNode()
    {
        Debug.LogError("Sequence " + name);
    }

    
}
