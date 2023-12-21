// Fill out your copyright notice in the Description page of Project Settings.



#include "../DrawDebugUtils.h"
#include "../Utils.h"
#include "../DebugUtils.h"

#include "GPE/Door.h"
ADoor::ADoor()
{
 	PrimaryActorTick.bCanEverTick = true;

}



void ADoor::BeginPlay()
{
	Super::BeginPlay();
	Init();
}
void ADoor::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	Move(DeltaTime);
}



void ADoor::Move(float DeltaTime)
{
	if (hasSource)
		Up(DeltaTime);
	else
		Down(DeltaTime);
	

}

void ADoor::Init()
{
	oldPosition = GetActorLocation();
	finalPosition = GetActorLocation() + GetActorUpVector() * 200;
	

	if (!looker)
	{
		SCREEN_DEBUG_MESSAGE_ERROR(5,"ADoor as not looker")
		return;
	}
	looker->BIND(OnOpenDoor(), this, &ADoor::SetHasSource);
}

void ADoor::Down(float DeltaTime)
{
	if (FVector::Dist(GetActorLocation(), oldPosition) <= 0.5f)
		return;
	float _speed = speed * DELTATIME;
	SetActorLocation(FMath::Lerp(GetActorLocation(), oldPosition, _speed));
}

void ADoor::Up(float DeltaTime)
{
	if (FVector::Dist(GetActorLocation(), finalPosition) <= 0.5f)
		return;
	FVector _location = GetActorLocation();
	float _speed = 100 * DeltaTime;
	_location += GetActorUpVector() * _speed;
	
	SetActorLocation(_location);
}

