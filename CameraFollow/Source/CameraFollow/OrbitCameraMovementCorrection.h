// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "CameraMovementCorrection.h"
#include "OrbitCameraMovementCorrection.generated.h"

/**
 * 
 */
UCLASS()
class CAMERAFOLLOW_API AOrbitCameraMovementCorrection : public ACameraMovementCorrection
{
	GENERATED_BODY()
		float angle = 0; 
	float ComputeAngle();
public:
	FORCEINLINE virtual FVector FinalPosition() override{ return FVector(0); }
protected:
	virtual void DrawDebug() override;
	void UpdateCameraPosition() override { SetActorLocation(FinalPosition()); }
	FVector3d RotationPoint();
private:
    virtual void Tick(float DeltaTime) override;

   
};
