// Fill out your copyright notice in the Description page of Project Settings.

#include "FSM/FSMComponent.h"
#include "FSM/FSMObject.h"


void UFSMObject::StartFSM(UFSMComponent* _owner)
{

	currentFSMComponent = _owner;
	desactivateMS = _owner->GetDesactivateMS();
	SetNextState(startingState);
}

void UFSMObject::SetNextState(TSubclassOf<UStateObject> _state)
{
	if(!_state)
		return;
	if (currentState)
		currentState->Exit();
	currentState = NewObject<UStateObject>(this, _state);
	currentState->Enter(this);
}

void UFSMObject::UpdateFSM()
{
	if (currentState)
		currentState->Update();
}

void UFSMObject::StopFSM()
{
	if (!currentState)
		return;
	currentState->Exit();
	currentState = nullptr;
}
