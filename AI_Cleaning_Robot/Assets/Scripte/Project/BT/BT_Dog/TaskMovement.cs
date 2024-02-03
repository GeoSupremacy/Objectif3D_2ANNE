using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TaskMovement", menuName = "BT/Node/Create TaskMovement")]

public class TaskMovement : DogNode
{
    [SerializeField]
    private Navigator zone;
  
    protected override ENodeState ProcessNode()
    {
        if (robot.FinalDestination)
            currentState = ENodeState.SUCCESS;
        else
            currentState = ENodeState.RUNNING;
        return currentState;
    }

    protected override void StartNode()
    {
        if (!currentRoot)
        {
            Debug.LogError("Prgram free Style " + name);
            return;
        }
        zone =currentRoot.Robot.Zone;
        if (!zone)
        {
            Debug.LogError("Not zone " + name);
            return;
        }
        Debug.LogError("StartNode " + name);
        zone.NextMove();
        robot.Move = true;
        robot.NextMove = zone.Move;
        robot.Look();
    }
    protected  override void AddOwner(Robot _dog)
    {
        robot = (DogRobot)_dog;
    }
    protected override void StopNode()
    {
        Debug.LogError("StopNode " + name);
    }

    
}
