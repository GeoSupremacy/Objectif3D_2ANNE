using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition: MonoBehaviour
{

  [SerializeField]
    private State nextState = null;
public State NextState => nextState;
    public virtual void InitTranstition()
    {

    }
 public virtual bool IsValidTranstition()
    {
        return false;
    }

}
