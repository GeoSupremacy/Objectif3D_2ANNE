using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu(fileName = "Sequence", menuName = "BehaviourTree/TreeNode/Composite/Sequence")]
public class Sequence : Composite
{
    [SerializeField] int current = 0;

    protected override ENodeReturnStatus ProcessNode()
    {
        TreeNode _child = allChidren[current];
        switch (_child.Execute()) 
        { 
            case ENodeReturnStatus.SUCCESS:
                current++;
                break;
            case ENodeReturnStatus.FAILED:
                return ENodeReturnStatus.FAILED;
            case ENodeReturnStatus.RUNNING:
                return ENodeReturnStatus.RUNNING;
        }
        return current ==allChidren.Count ? ENodeReturnStatus.SUCCESS : ENodeReturnStatus.FAILED;
    }

    protected override void StartNode()
    {
       current = 0;
    }

    protected override void StopNode()
    {
      
    }

    
}
