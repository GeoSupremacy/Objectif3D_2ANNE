// Fill out your copyright notice in the Description page of Project Settings.


#include "OrbitCameraMovementCorrection.h"
#include "OrbitCameraSettingsCorrection.h"


float AOrbitCameraMovementCorrection::ComputeAngle()
{
    return TObjectPtr<UOrbitCameraSettingsCorrection>()->Expression()->bIsEventCurve*630;
	
}

void AOrbitCameraMovementCorrection::UpdateCameraPosition()
{
    SetActorLocation(FinalPosition());
}

void AOrbitCameraMovementCorrection::Tick(float DeltaTime)
{
}

void AOrbitCameraMovementCorrection::DrawDebug()
{
}

FVector3d AOrbitCameraMovementCorrection::RotationPoint()
{
    TObjectPtr<UOrbitCameraSettingsCorrection> _set = Cast<UOrbitCameraSettingsCorrection>(cameraSettings);
    float _radius = _set ? _set->Radius() : 1;
    angle = ComputeAngle();
    float _x = FMath::Cos(FMath::DegreesToRadians(angle)) * _radius,
        _y = FMath::Sin(FMath::DegreesToRadians(angle)) * _radius;
    return FVector3d(_x, _y, 0);
	return FVector3d();
}
