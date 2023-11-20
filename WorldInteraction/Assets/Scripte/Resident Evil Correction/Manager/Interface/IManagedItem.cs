using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManagedItem<TID>
{ 
    TID ID { get;  }
    void Register();
    void Enable();
    void Disable();
}
