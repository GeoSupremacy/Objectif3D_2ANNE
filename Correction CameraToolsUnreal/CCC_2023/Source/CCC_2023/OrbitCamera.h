// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "CameraMovements.h"
#include "OrbitCamera.generated.h"

/**
 * 
 */
UCLASS()
class CCC_2023_API AOrbitCamera : public ACameraMovements
{
	GENERATED_BODY()
		float angle = 0;
		FVector RotationPoint();
		float ComputeAngle();
public :
	FORCEINLINE virtual FVector FinalPosition() override { return TargetPosition() + RotationPoint(); };
protected:
	virtual void UpdateCameraPosition() override;
	virtual void DrawDebugMovement() override;
};
