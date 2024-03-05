using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMovement : DogNode
{
    [SerializeField]
    private Navigator zone;
    [SerializeField]
    private DogRobot dog;
    protected override ENodeState ProcessNode()
    {
        currentState = ENodeState.RUNNING;
        return currentState;
    }

    protected override void StartNode()
    {
        zone.NextMove();
        Root.Move = true;
        Root.NextMove = zone.Move;
        Root.Look();
    }

    protected override void StopNode()
    {
       
    }

    
}
