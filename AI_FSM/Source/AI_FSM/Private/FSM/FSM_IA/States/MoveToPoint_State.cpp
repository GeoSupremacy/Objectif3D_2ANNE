
#include "IA/IA_Guard.h"
#include "FSM/FSMComponent.h"
#include "FSM/FSMObject.h"
#include "FSM/FSM_IA/States/MoveToPoint_State.h"

void UMoveToPoint_State::Enter(UFSMObject* _owner)
{
	Super::Enter(_owner);
	currentGuard =Cast<AIA_Guard>(_owner->GetFSMComponent()->GetOwner());
	if (!currentGuard)
	{
		GEngine->AddOnScreenDebugMessage(0, 10, FColor::Red, TEXT("Not AIA_Guard "));
		return;
	}
	GetWorld()->GetTimerManager().SetTimer(waitTransition, this, &UMoveToPoint_State::WaitReLook, timer, true);
	currentGuard->SetMove(true);
	currentGuard->SetHasDestination(false);
}

void UMoveToPoint_State::WaitReLook()
{
	currentGuard->Look();
}

