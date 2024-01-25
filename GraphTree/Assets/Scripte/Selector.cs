using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    [SerializeField] int current = 0;

    protected override ENodeReturnStatus ProcessNode()
    {
        TreeNode _child = allChidren[current];
        switch (_child.Execute())
        {
            case ENodeReturnStatus.SUCCESS:
                return ENodeReturnStatus.SUCCESS;
            case ENodeReturnStatus.FAILED:
                current++;
                break;
            case ENodeReturnStatus.RUNNING:
                return ENodeReturnStatus.RUNNING;
            default:
                break;
        }
        return current>= allChidren.Count ? ENodeReturnStatus.FAILED : ENodeReturnStatus.RUNNING;
    }

    protected override void StartNode()
    {
       
    }

    protected override void StopNode()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
