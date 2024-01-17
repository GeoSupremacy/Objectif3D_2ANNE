
#include "FSM/FSMObject.h"
#include "FSM/FSMComponent.h"
#include "IA/IA_Guard.h"
#include "FSM/FSM_IA/Transitions/Target_Transition.h"

void UTarget_Transition::InitTranstition()
{
	current_Guard = Cast<AIA_Guard>(currentFSMObject->GetFSMComponent()->GetThisOwner());
	if (!current_Guard)
	{
		UE_LOG(LogTemp, Error, TEXT("UTarget_Transition Not Guard "));
		GEngine->AddOnScreenDebugMessage(5, 10, FColor::Red, TEXT("UTarget_Transition Not Guard "));
			return;
		
	}
}

bool UTarget_Transition::IsValidTranstition()
{
	if (!current_Guard)
		return false;
	
	return current_Guard->GetHasTarget();
}
