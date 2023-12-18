// Fill out your copyright notice in the Description page of Project Settings.


#include "Player/InteractComponent.h"
#include "../DebugUtils.h"

UInteractComponent::UInteractComponent()
{
	
	PrimaryComponentTick.bCanEverTick = true;

	
}
void UInteractComponent::BeginPlay()
{
	Super::BeginPlay();

	
	
}
void UInteractComponent::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);
	DetectedObject();
	
}

void UInteractComponent::Drop()
{
	SCREEN_DEBUG_MESSAGE_WARNING(5, " Drop")
}

void UInteractComponent::Grab()
{
	if (!canGrabItem)
		SCREEN_DEBUG_MESSAGE_WARNING(5," cant Grab")
}

void UInteractComponent::DetectedObjectFeedback(TObjectPtr<AActor>)
{
}

void UInteractComponent::DetectedObject()
{
}

