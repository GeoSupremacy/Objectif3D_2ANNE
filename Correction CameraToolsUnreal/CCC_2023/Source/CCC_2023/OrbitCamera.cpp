// Fill out your copyright notice in the Description page of Project Settings.


#include "OrbitCamera.h"
#include "CameraOrbitSettings.h"

FVector AOrbitCamera::RotationPoint()
{
    UCameraOrbitSettings* _set = Cast<UCameraOrbitSettings>(cameraSettings);
    const float _radius = _set ? _set->Radius() : 1;
    angle = ComputeAngle();
    float _a = FMath::DegreesToRadians(angle); 
    float _x = FMath::Cos(_a) * _radius,
          _y = FMath::Sin(_a) * _radius;
    return FVector(_x, _y, 0);
}

float AOrbitCamera::ComputeAngle()
{
    UCameraOrbitSettings* _set = Cast<UCameraOrbitSettings>(cameraSettings);
    return _set ? _set->Expression()->GetFloatValue(GetWorld()->TimeSeconds) * 360.f : 0;
}

void AOrbitCamera::UpdateCameraPosition()
{
    SetActorLocation(FinalPosition());
}

void AOrbitCamera::DrawDebugMovement()
{
    DrawDebugBox(GetWorld(), GetActorLocation(), FVector(50), FColor::Red, false, -1,0, 3);
    UCameraOrbitSettings* _set = Cast<UCameraOrbitSettings>(cameraSettings);
    DrawDebugCircle(GetWorld(), TargetPosition(), _set ? _set->Radius() : 300, 100, FColor::White, false, -1, 0, 5, FVector(1, 0, 0), FVector(0, 1, 0));
}
