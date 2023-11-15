// Fill out your copyright notice in the Description page of Project Settings.
#include "CameraManagedComponent.h"
#include "CustomGameMode.h"
#include "CameraManager.h"

// Sets default values for this component's properties
UCameraManagedComponent::UCameraManagedComponent()
{
	PrimaryComponentTick.bCanEverTick = false;
}


// Called when the game starts
void UCameraManagedComponent::BeginPlay()
{
	Super::BeginPlay();

	isManaged = GetManager()->AddCamera(this);
	
}

UCameraManager* UCameraManagedComponent::GetManager()
{
	
	ACustomGameMode* _gm = GetWorld()->GetAuthGameMode<ACustomGameMode>();
	if(!_gm)
		return nullptr;
	return _gm->GetCameraManager();
	
}

