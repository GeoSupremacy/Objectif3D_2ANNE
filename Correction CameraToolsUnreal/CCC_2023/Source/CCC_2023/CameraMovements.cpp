// Fill out your copyright notice in the Description page of Project Settings.


#include "CameraMovements.h"
#include "Kismet/KismetMathLibrary.h"

ACameraMovements::ACameraMovements()
{
	PrimaryActorTick.bCanEverTick = true;
	#if WITH_EDITOR
		PrimaryActorTick.bStartWithTickEnabled = true;
	#endif
}
void ACameraMovements::BeginPlay()
{
	Super::BeginPlay();
}
void ACameraMovements::Tick(float DeltaSeconds)
{
	Super::Tick(DeltaSeconds);
	if (GetWorld()->IsPlayInEditor())
	{
		UpdateCameraPosition();
		UpdateLookatCamera();
	}
	DrawDebugMovement();
}
void ACameraMovements::UpdateCameraPosition()
{
}
void ACameraMovements::UpdateLookatCamera()
{
	const FRotator _rot = UKismetMathLibrary::FindLookAtRotation(GetActorLocation(), TargetPosition());
	SetActorRotation(FMath::RInterpTo(GetActorRotation(), _rot, GetWorld()->DeltaTimeSeconds, 100));;
}
void ACameraMovements::DrawDebugMovement()
{
}
bool ACameraMovements::ShouldTickIfViewportsOnly() const
{
	return useDebug;
}
