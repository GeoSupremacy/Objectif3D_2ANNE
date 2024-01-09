// Fill out your copyright notice in the Description page of Project Settings.


#include "FSMComponent.h"


UFSMComponent::UFSMComponent()
{
	
	PrimaryComponentTick.bCanEverTick = true;

}

void UFSMComponent::BeginPlay()
{
	Super::BeginPlay();
	Init();
	
}
void UFSMComponent::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);
	UpdateFSM();
}

void UFSMComponent::EndPlay(EEndPlayReason::Type _type)
{
	CloseFSM();
	Super::EndPlay( _type);
}

void UFSMComponent::Init()
{
	if (!currentFSMType)
	{
		GEngine->AddOnScreenDebugMessage(0, 10, FColor::Red, "Note Final state machine in FSMComponent");
		return;
	}
	runningFSM = NewObject<UFSMObject>(this, currentFSMType);
	runningFSM->StartFSM(this);
}

void UFSMComponent::UpdateFSM()
{
	if (!runningFSM)
		return;
	runningFSM->UpdateFSM();
}

void UFSMComponent::CloseFSM()
{
	if (!runningFSM)
		return;
	runningFSM->StopFSM();
}

