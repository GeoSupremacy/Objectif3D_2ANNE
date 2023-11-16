// Fill out your copyright notice in the Description page of Project Settings.
#include "CameraManagedComponent.h"
#include "CustomGameMode.h"
#include "CameraManager.h"

// Sets default values for this component's properties
UCameraManagedComponent::UCameraManagedComponent()
{
	PrimaryComponentTick.bCanEverTick = true;
}




// Called when the game starts
void UCameraManagedComponent::BeginPlay()
{
	Super::BeginPlay();

	Init();
	
}


void UCameraManagedComponent::Enable()
{
	//if(!camera) nullp
	//cameraSystem->SetActiveEnable
}

void UCameraManagedComponent::Disable()
{
	//if !camera nullp
	//cameraSystem->SetActiveEnable
}
UCameraManager* UCameraManagedComponent::GetManager()
{
	
	ACustomGameMode* _gm = GetWorld()->GetAuthGameMode<ACustomGameMode>();
	if(!_gm)
		return nullptr;

	return _gm->GetCameraManager();
	
}

void UCameraManagedComponent::Init()
{
	//camerasystem =GetCameraMovmentSystem
	isManaged = GetManager()->AddCamera(this);
}

void UCameraManagedComponent::RemoveCamera()
{
	if (!isManaged)
		return;
	isManaged = !GetManager()->RemoveCamera(this);
}

