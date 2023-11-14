// Fill out your copyright notice in the Description page of Project Settings.


#include "CameraFollow.h"

void ACameraFollow::UpdateCameraPosition()
{
    FVector _location = FVector(0);
    UCameraFollowSettings* _set = Cast<UCameraFollowSettings>(cameraSettings);
    if (_set && _set->MovemementType() == EMovementType::Lerp)
        _location = FMath::Lerp(CurrentPosition(), FinalPosition(), GetWorld()->DeltaTimeSeconds * _set->CameraSpeed());
    else
        _location = FMath::VInterpConstantTo(CurrentPosition(), FinalPosition(), GetWorld()->DeltaTimeSeconds, _set->CameraSpeed());
    SetActorLocation(_location);

}

void ACameraFollow::DrawDebugMovement()
{
    Super::DrawDebugMovement();
    if (!cameraSettings)
        return;
    const UWorld* _world = GetWorld(); 
    const FColor _validColor = IsValid() ? validDebugColor : noValidDebugColor;
    DrawDebugBox(_world, CurrentPosition(), FVector(50), _validColor, false,-1,0, 3);
    if (!IsValid())
        return;
    DrawDebugLine(_world, CurrentPosition(), TargetPosition(), FColor::Magenta, false, -1, 0, 3);
    DrawDebugLine(_world, FinalPosition(), TargetPosition(), FColor::Magenta, false, -1, 0, 3);
    DrawDebugBox(_world, FinalPosition(), FVector(50), FColor::Magenta, false, -1, 0, 3);
    DrawDebugSphere(_world, TargetPosition(), 50, 10, FColor::Magenta, false, -1, 0, 2);

}
