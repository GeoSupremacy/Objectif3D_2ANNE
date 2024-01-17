#include "FSM/FSMObject.h"
#include "FSM/FSMComponent.h"
#include "IA/IA_Guard.h"
#include "FSM/FSM_IA/States/Follow_Target_State.h"

void UFollow_Target_State::Enter(UFSMObject* _owner)
{
	Super::Enter(_owner);
	current_Guard = Cast<AIA_Guard>(currentFSMObject->GetFSMComponent()->GetThisOwner());
	if (!current_Guard)
	{

		GEngine->AddOnScreenDebugMessage(0, 10, FColor::Red, TEXT("UFollow_Target_State Not Guard "));
		return;

	}
}



void UFollow_Target_State::Update()
{
	Super::Update();
	if (current_Guard)
		current_Guard->Look();
}

void UFollow_Target_State::Exit()
{
	if (current_Guard)
		current_Guard->ClearTarget();
	Super::Exit();

}
