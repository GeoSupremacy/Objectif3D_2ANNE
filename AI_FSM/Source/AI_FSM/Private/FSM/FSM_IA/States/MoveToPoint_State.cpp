
#include "IA/IA_Guard.h"
#include "FSM/FSMComponent.h"
#include "FSM/FSMObject.h"
#include "FSM/FSM_IA/States/MoveToPoint_State.h"

void UMoveToPoint_State::Enter(UFSMObject* _owner)
{
	Super::Enter(_owner);
	AIA_Guard* _ia =Cast<AIA_Guard>(_owner->GetFSMComponent()->GetOwner());
	if (!_ia)
	{
		GEngine->AddOnScreenDebugMessage(0, 10, FColor::Red, TEXT("Not AIA_Guard "));
		return;
	}
	_ia->SetMove(true);
	_ia->SetHasDestination(false);
}

void UMoveToPoint_State::Update()
{
	Super::Update();
}
