using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMObject : MonoBehaviour
{

    [SerializeField]
    private  State startingState = null;
    [SerializeField]
    private State currentState = null;
    [SerializeField, HideInInspector]
    FSMComponent owner = null;
public:
	FORCEINLINE TObjectPtr<class UFSMComponent> GetOwner() const {return owner;}
void StartFSM(class UFSMComponent*_owner);
void SetNextState(TSubclassOf<UStateObject> _state);
virtual void UpdateFSM();
virtual void StopFSM();




void Start()
    {
        
    }
    void Update()
    {
        
    }
}
