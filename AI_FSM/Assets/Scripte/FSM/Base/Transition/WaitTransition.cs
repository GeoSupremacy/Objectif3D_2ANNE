using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTransition : Transition
{
    [SerializeField]
    private float waitTime = 5;
    bool isDone = false;
    //FTimerHandle waitTimer;
    public override void InitTranstition()
    {
        StartCoroutine(Ti);
    }
    public override bool IsValidTranstition()
    { 
        return isDone; 
    }
    IEnumerator Ti()
    {
        yield return waitTime;
    }
private void Wait()
    {
        isDone = true;
    }
}
