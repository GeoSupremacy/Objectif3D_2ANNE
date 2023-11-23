// Fill out your copyright notice in the Description page of Project Settings.


#include "InteractableObjectComponent.h"
#include "DebugUtils.h"

// Sets default values for this component's properties
UInteractableObjectComponent::UInteractableObjectComponent()
{
	// Set this component to be initialized when the game starts, and to be ticked every frame.  You can turn these features
	// off to improve performance if you don't need them.
	PrimaryComponentTick.bCanEverTick = true;

	// ...
}


// Called when the game starts
void UInteractableObjectComponent::BeginPlay()
{
	Super::BeginPlay();

	Init();
	
}


// Called every frame
void UInteractableObjectComponent::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);

	const float _dis = FVector::Distance(ACTOR->GetActorLocation(), character->GetActorLocation());
	const float _size = 100 * ACTOR->GetActorScale().X;
	if (_dis <= _size / 2 + 50)
	{
		DRAW_SPHERE(ACTOR->GetActorLocation(), _size / 2 + 50, Blue, 16)
			return;
	}

	DRAW_SPHERE(ACTOR->GetActorLocation(), _size / 2 + 50, Red, 16)
}

void UInteractableObjectComponent::Init()
{
	character = Cast<APlayerCollector>(FIRST_PLAYER_CONTROLLER);
	if (!character)
		return;


	character->OnInteract().AddDynamic(this, &UInteractableObjectComponent::HasInteractableObject);
}

void UInteractableObjectComponent::HasInteractableObject()
{
	
	const float _dis = FVector::Distance(ACTOR->GetActorLocation(), character->GetActorLocation());
	const float _size = 100 * ACTOR->GetActorScale().X;
	if (character->GetInteract())
	{
		SCREEN_DEBUG_MESSAGE_ERROR(0, 10, "HasInteractableObject");
		character->SetInteracted(false);
		ACTOR->SetActorLocation(character->CurrentPosition());

	}
	else if (_dis <= _size / 2 + 50)
	{
		SCREEN_DEBUG_MESSAGE_WARNING(2, 10, "Move");
		ACTOR->SetActorLocation(-ACTOR->GetActorLocation());
		character->SetInteracted(true);
	}
}