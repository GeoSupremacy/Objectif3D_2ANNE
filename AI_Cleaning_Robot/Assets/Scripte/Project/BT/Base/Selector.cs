using System.Collections;
using UnityEngine;

public class Selector : Node
{

    protected override ENodeState ProcessNode()
    {
       
        foreach (Node node in children)
        {
            switch (node.Execute())
            {
                case ENodeState.FAILED:
                    continue;
                case ENodeState.SUCCESS:
                    currentState = ENodeState.SUCCESS;
                    return currentState;
                case ENodeState.RUNNING:
                    currentState = ENodeState.RUNNING;
                    return currentState;
                default:
                    continue;
            }
        }
        currentState = ENodeState.FAILED;
        return currentState;
    }


    protected override void StartNode()
    {

    }

    protected override void StopNode()
    {

    }
}
