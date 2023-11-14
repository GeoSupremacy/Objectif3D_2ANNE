// Fill out your copyright notice in the Description page of Project Settings.


#include "PNJDialogCameraSystem.h"

// Sets default values for this component's properties
UPNJDialogCameraSystem::UPNJDialogCameraSystem()
{
	PrimaryComponentTick.bCanEverTick = true;
#if WITH_EDITOR
	PrimaryComponentTick.bStartWithTickEnabled = true;
#endif

}


void UPNJDialogCameraSystem::InitCameraDialog()
{
	if (!settings || !settings->CameraPnj())
		return;
	activeCamera = GetWorld()->SpawnActor<ACameraPNJ>(settings->CameraPnj(), FinalCameraLocation(), FRotator::ZeroRotator);
	GetWorld()->GetFirstPlayerController()->SetViewTarget(activeCamera);
}

void UPNJDialogCameraSystem::UpdateCameraLocation()
{
	if (!activeCamera)
		return;
	activeCamera->SetDestination(FinalCameraLocation());
}

FVector UPNJDialogCameraSystem::GetCameraPosition(const float& _angle, const float& _radius)
{
	float _rad = FMath::DegreesToRadians(_angle);
	return TargetPivot() + FVector(FMath::Cos(_rad) * _radius,  FMath::Sin(_rad) * _radius,0);
}

void UPNJDialogCameraSystem::BeginPlay()
{
	Super::BeginPlay();
}


void UPNJDialogCameraSystem::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);
	DrawDebug();
	UpdateCameraLocation();
}

void UPNJDialogCameraSystem::DrawDebug()
{
	if (!target)
		return;
	const UWorld* _world = GetWorld(); 
	DrawDebugLine(_world, CurrentTargetPosition(), CurrentPNJLocation(), FColor::Magenta,false,-1,0,3);
	DrawDebugSphere(_world, TargetPivot(), 30,10, FColor::Yellow, false, -1, 0, 3);
	DrawDebugCircle(_world,TargetPivot(), Radius(), 50, FColor::Green, false, -1, 0, 2, FVector(1,0,0), FVector(0, 1, 0));
	DrawDebugSphere(_world, FinalCameraLocation(), 30, 10, FColor::Yellow, false, -1, 0, 3);
	DrawDebugLine(_world, FinalCameraLocation(), TargetPivot(), FColor::Magenta, false, -1, 0, 3);
	DrawDebugLine(_world, FinalCameraLocationWithoutHeight(), TargetPivot(), FColor::Magenta, false, -1, 0, 3);
	DrawDebugLine(_world, FinalCameraLocationWithoutHeight(), FinalCameraLocation(), FColor::Magenta, false, -1, 0, 3);

}

