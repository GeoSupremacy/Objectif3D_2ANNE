using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WaitTransition", menuName = "FSM/Transition/Create WaitTransition")]
public class WaitTransition : Transition
{
    [SerializeField, Range(0,100)]
       float wait = 5;
    bool isDone = false;
    public override void InitTransition(FSM _fsm)
    {
        base.InitTransition(_fsm);
       
            _fsm.CurrentFSMComponent.StartCoroutine(Wait());
       
    }

    private IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(wait);
       
        if (CurrentFSM.Robot.IsGarbage)
            yield break;
       
        float _x = Random.Range(-20, 20), _z = Random.Range(-20, 20);
        CurrentFSM.Robot.Move = true;
        CurrentFSM.Robot.NextMove =new(_x, 0, _z);
        CurrentFSM.Robot.Look();
        isDone = true;
    }
    public override bool IsValisTransition()
    {
        return isDone;
    }
}
