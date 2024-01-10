using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WaitTransistion_Corr", menuName = "FSM/Transition/Create new WaitTransistion_Corr")]
public class WaitTransistion_Corr : Transition_Corr
{
    [SerializeField, Range(0f, 10)] int delay = 2;
    bool isDone = false;
    public override bool IsValidTransition => isDone;  
    public override void InitTransition(FSM_Corr _fsm) 
        {
             base.InitTransition(_fsm);
            _fsm.Owner.StartCoroutine(Wait());
        }

    private IEnumerator Wait()
    {
        
      yield return new WaitForSeconds(delay);
        isDone = true;
    }
}
