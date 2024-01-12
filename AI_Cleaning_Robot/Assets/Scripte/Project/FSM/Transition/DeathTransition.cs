using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeathTransition", menuName = "FSM/Transition/Create DeathTransition")]
public class DeathTransition : Transition
{
    public override bool IsValisTransition() => CurrentFSM.Robot.IsDead;
    
}
