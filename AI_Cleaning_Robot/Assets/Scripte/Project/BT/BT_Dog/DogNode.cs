using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogNode : Node
{
    [SerializeField] new public DogNode parent;
    [SerializeField] private DogRobot root;

    public DogRobot Root =>root;
    protected override ENodeState ProcessNode()
    {
        return ENodeState.RUNNING;
    }

    protected override void StartNode()
    {
       
    }

    protected override void StopNode()
    {
       
    }

    
}
