using System.Collections;
using UnityEngine;


public enum ENodeReturnStatus
{
    SUCCESS,
    FAILED,
    RUNNING,
}


public abstract class TreeNode : MonoBehaviour
{
    [SerializeField] protected ENodeReturnStatus currentReturnStatus =ENodeReturnStatus.RUNNING;
    [SerializeField] protected bool startDone = false, processDone = false, stopDone = false;

    public ENodeReturnStatus CurrentReturnStatus => currentReturnStatus;
    public ENodeReturnStatus Execute()
    {
        if(!startDone) { StartNode(); startDone = true; }
        currentReturnStatus =ProcessNode();
        Debug.Log("Execute");
        if (currentReturnStatus != ENodeReturnStatus.RUNNING)
        {
            StopNode();
            startDone = false;
            stopDone = true;
        }
        return currentReturnStatus;
    }

    public virtual TreeNode Clone()=> Instantiate(this); 
    protected abstract void StartNode();
    protected abstract ENodeReturnStatus ProcessNode();
    protected abstract void StopNode();
}
