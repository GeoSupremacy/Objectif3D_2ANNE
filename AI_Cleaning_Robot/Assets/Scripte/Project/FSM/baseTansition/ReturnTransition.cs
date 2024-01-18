using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ReturnTransition", menuName = "FSM/Transition/Create ReturnTransition")]
public class ReturnTransition : Transition
{
   
    public override bool IsValisTransition()
    {
        return true;
    }
    
}
