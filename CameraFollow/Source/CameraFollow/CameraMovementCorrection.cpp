// Fill out your copyright notice in the Description page of Project Settings.


#include "CameraMovementCorrection.h"

ACameraMovementCorrection::ACameraMovementCorrection()
{
	PrimaryActorTick.bCanEverTick = true;
#if WITH_EDITOR
	PrimaryActorTick.bStartWithTickEnabled = true;

#endif
}

void ACameraMovementCorrection::BeginPlay()
{
	Super::BeginPlay();
}

void ACameraMovementCorrection::Tick(float _delataime)
{
	Super::Tick( _delataime);
	if (GetWorld()->IsPlayInEditor())
		UpdateCameraPosition();
	DrawDebug();
}

void ACameraMovementCorrection::UpdateCameraPosition()
{
	
}

bool ACameraMovementCorrection::ShouldTickIfViewportsOnly() const
{
	return useDebug;
}

void ACameraMovementCorrection::DrawDebug()
{
	
}
