using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu(fileName = "WaitNode", menuName = "BehaviourTree/TreeNode/Leaf/WaitNode")]
public class WaitNode : Leaf
{
    [SerializeField] float duration = 1;
    float startTime = 0;
    protected override ENodeReturnStatus ProcessNode()
    {
        Debug.Log("ProcessNode " + name);
        if (Time.time - startTime > duration)
            return ENodeReturnStatus.SUCCESS;
        return ENodeReturnStatus.RUNNING;
    }

    protected override void StartNode()
    {
        startTime =Time.time;
        Debug.Log("StartNode " + name);
    }

    protected override void StopNode()
    {
        Debug.Log("StopNode " + name);
    }

   
}
