#include "FSM/FSMObject.h"
#include "FSM/FSMComponent.h"
#include "FSM/FSM_IA/Transitions/Wait_Follow_Transition.h"

void UWait_Follow_Transition::InitTranstition()
{
	waitTime = FMath::FRandRange(minTime, maxTime);
	GetWorld()->GetTimerManager().SetTimer(waitTimer, this, &UWait_Follow_Transition::Wait, waitTime, false);
}

bool UWait_Follow_Transition::IsValidTranstition()
{
	return isDone;
}

void UWait_Follow_Transition::Wait()
{
	AIA_Guard* _currentGuard = Cast<AIA_Guard>(currentFSMObject->GetFSMComponent()->GetThisOwner());
		if (!_currentGuard)
		{
			return;
		}
	
	isDone = true;
}
