// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "CameraSettingsFollowCorrection.h"


#include "CoreMinimal.h"
#include "CameraMovementCorrection.h"
#include "CameraFollowCorrection.generated.h"

/**
 * 
 */
UCLASS()
class CAMERAFOLLOW_API ACameraFollowCorrection : public ACameraMovementCorrection
{
	GENERATED_BODY()
public:
	FORCEINLINE virtual FVector Offset()const override
	{
		UCameraSettingsFollowCorrection* _set = Cast<UCameraSettingsFollowCorrection>(cameraSettings);
		if (!_set)
			return FVector(0, 0, 0);

		if(_set->MovementType() == EMovementType::LErp)
			return GetLocalOffset(_set->OffsetX(), _set->OffsetY(), _set->OffsetZ());
		else
			return FVector(_set->OffsetX(), _set->OffsetY(), _set->OffsetZ());
	}
protected:
	virtual void UpdateCameraPosition() override;
	virtual void DrawDebug() override;
};
