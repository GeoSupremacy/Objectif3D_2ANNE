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

	Init();

}


void UCameraManagedComponent::Enable()
{
	if (!cameraSystem)
		return;
		
}

void UCameraManagedComponent::Disable()
{
	if (!cameraSystem)
		return;
		
}
void UCameraManagedComponent::RegisterCamera(FString _id)
{
	id = _id;
	Init();
}
UCameraManager* UCameraManagedComponent::GetManager()
{

	ACustomGameMode* _gm = GetWorld()->GetAuthGameMode<ACustomGameMode>();
	if (!_gm)
		return nullptr;

	return _gm->GetCameraManager();

}

void UCameraManagedComponent::Init()
{
	cameraSystem = GetCameraMovementSystem();
	isManaged = GetManager()->AddCamera(this);
}

void UCameraManagedComponent::RemoveCamera()
{
	if (!isManaged)
		return;
	isManaged = !GetManager()->RemoveCamera(this);
}

