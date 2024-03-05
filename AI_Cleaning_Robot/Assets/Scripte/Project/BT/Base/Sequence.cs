using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{

    protected override ENodeState ProcessNode()
    {
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
        
    }

    protected override void StopNode()
    {
      
    }

    
}
