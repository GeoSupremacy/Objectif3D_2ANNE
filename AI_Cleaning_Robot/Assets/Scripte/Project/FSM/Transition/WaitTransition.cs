using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WaitTransition", menuName = "FSM/Transition/Create WaitTransition")]
public class WaitTransition : Transition
{
    [SerializeField, Range(0,100)]
       float min = 0;
    [SerializeField, Range(0, 100)]
    float max = 15;
    float wait;
    bool isDone = false;
    public override void InitTransition(FSM _fsm)
    {
        base.InitTransition(_fsm);

        wait = Random.Range(min, max);
       _fsm.CurrentFSMComponent.StartCoroutine(Wait());
       
    }

    private IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(wait);
       
        if (CurrentFSM.Robot.IsGarbage)
            yield break;
        isDone = true;
        
        

         
    }
    public override bool IsValisTransition()
    {
        return isDone;
    }
}
