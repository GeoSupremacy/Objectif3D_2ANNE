// Fill out your copyright notice in the Description page of Project Settings.

#include "FSM/FSMObject.h"
#include "Kismet/KismetSystemLibrary.h"
#include "FSM/Transition.h"
#include "FSM/StateObject.h"

void UStateObject::Enter(UFSMObject* _owner)
{
	currentFSMObject = _owner;
	InitTransitions();
	UKismetSystemLibrary::PrintString(this, "Enter->"+ GetName(), true, true, FColor::Green);
}

void UStateObject::Update()
{
	CheckForValidTransition();
	UKismetSystemLibrary::PrintString(this, "UpDate" + GetName(), true, true, FColor::Yellow,0);
}

void UStateObject::Exit()
{
	UKismetSystemLibrary::PrintString(this, "Exit" + GetName(), true, true, FColor::Red);
	currentFSMObject =nullptr;

}

void UStateObject::InitTransitions()
{
	for (TSubclassOf<UTransition> transition : transitions)
	{
		if (!transition)
			continue;
		UTransition* _transition = NewObject <UTransition> (this, transition);
		//UDumTrans _dm = Cast<uDm>(tr)
		//if (_dm) = do
		_transition->InitTranstition();//???
		runningTransitions.Add(_transition);
	}
}

void UStateObject::CheckForValidTransition()
{
	for (TObjectPtr<UTransition> transition : runningTransitions)
	{
		if (transition->IsValidTranstition())
		{
			currentFSMObject->SetNextState(transition->GetNextState());
			Exit();
			return;
		}
	}
}
