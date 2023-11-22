// Fill out your copyright notice in the Description page of Project Settings.


#include "InteractableObject.h"
#include "PlayerCollector.h"
#include "DebugUtils.h"


// Sets default values
AInteractableObject::AInteractableObject()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	RootComponent = CreateDefaultSubobject<USceneComponent>("Root");
}

// Called when the game starts or when spawned
void AInteractableObject::BeginPlay()
{
	Super::BeginPlay();
	Init();
}

// Called every frame
void AInteractableObject::Tick(float DeltaTime)
{
	
	Super::Tick(DeltaTime);
	
	const float _dis = FVector::Distance(GetActorLocation(), character->GetActorLocation());
	const float _size = 100*GetActorScale().X;
	if (_dis <= _size / 2 + 50)
	{
			DRAW_SPHERE(GetActorLocation(), _size/2 + 50, Blue, 16)
				return;
	}

	DRAW_SPHERE(GetActorLocation(), _size/2 + 50, Red, 16)
}

void AInteractableObject::Init()
{
	character = Cast<APlayerCollector>(FIRST_PLAYER_CONTROLLER);
	if (!character)
		return;

	
	character->OnInteract().AddDynamic(this, &AInteractableObject::HasInteractableObject);
}

void AInteractableObject::HasInteractableObject()
{
	
	const float _dis = FVector::Distance(GetActorLocation(), character->GetActorLocation());
	const float _size = 100 * GetActorScale().X;
	if (character->GetInteract())
	{
		
		character->SetInteracted(false);
		SetActorLocation(character->CurrentPosition());
		
	}
	else if(_dis <= _size / 2 + 50)
	{
		SetActorLocation(-GetActorLocation());
		character->SetInteracted(true);
	}
}

