// Fill out your copyright notice in the Description page of Project Settings.

#include "FSM/FSMComponent.h"
#include "FSM/FSMObject.h"
#include "FSM/FSM_IA/Transitions/Return_AfterDestinationTransit.h"

void UReturn_AfterDestinationTransit::InitTranstition()
{
	currentFSMObject->GetFSMComponent()->GetThisOwner();
}

bool UReturn_AfterDestinationTransit::IsValidTranstition()
{
	auto _el =Cast<AIA_Guard>(currentFSMObject->GetFSMComponent()->GetThisOwner());
	if (!_el)
		return false;

	return _el->GetHasDestination();
}
