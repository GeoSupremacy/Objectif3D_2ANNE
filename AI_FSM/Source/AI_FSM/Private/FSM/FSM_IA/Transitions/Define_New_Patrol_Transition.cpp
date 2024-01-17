#include "IA/IA_Guard.h"
#include "FSM/FSMObject.h"
#include "FSM/FSMComponent.h"
#include "IA/IA_Guard.h"
#include "FSM/FSM_IA/Transitions/Define_New_Patrol_Transition.h"

void UDefine_New_Patrol_Transition::InitTranstition()
{
	currentGuard = Cast<AIA_Guard>(currentFSMObject->GetFSMComponent()->GetThisOwner());
}

bool UDefine_New_Patrol_Transition::IsValidTranstition()
{
	if(!currentGuard)
		return false;
	return currentGuard->GetCanChangePatrol();
}
