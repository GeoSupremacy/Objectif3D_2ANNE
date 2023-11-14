// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "CameraMovements.h"
#include "CameraFollowSettings.h"
#include "CameraFollow.generated.h"

/**
 * 
 */
UCLASS()
class CCC_2023_API ACameraFollow : public ACameraMovements
{
	GENERATED_BODY()
public :
    FORCEINLINE virtual FVector Offset() const override
    {
        UCameraFollowSettings* _set = Cast<UCameraFollowSettings>(cameraSettings);
        if (!_set)
            return FVector(0);
        if (_set->OffsetType() == EOffsetType::Local)
            return GetLocalOffset(_set->OffsetX(), _set->OffsetY(), _set->OffsetZ());
        else
             return FVector(_set->OffsetX(), _set->OffsetY(), _set->OffsetZ());
    }
protected :
    virtual void UpdateCameraPosition() override;
    virtual void DrawDebugMovement() override;
};
