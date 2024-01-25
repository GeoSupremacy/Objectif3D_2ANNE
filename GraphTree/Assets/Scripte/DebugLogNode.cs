using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu(fileName = "DebugLogNode", menuName = "BehaviourTree/TreeNode/Leaf/DebugLogNode")]
public class DebugLogNode : Leaf
{
    [SerializeField] string debugMessage = "message";
    [SerializeField] bool taskSucess = true;  
    protected override ENodeReturnStatus ProcessNode()
    {
        Debug.Log(debugMessage);
        return taskSucess?ENodeReturnStatus.SUCCESS : ENodeReturnStatus.FAILED;
    }

    protected override void StartNode()
    {
        
    }

    protected override void StopNode()
    {
        
    }

    
}
