using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
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
