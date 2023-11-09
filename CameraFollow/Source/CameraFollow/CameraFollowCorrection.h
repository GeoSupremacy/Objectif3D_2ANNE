// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

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
		return GetLocalOffset(0, 0, 0);
	}
protected:
	virtual void UpdateCameraPosition() override;
	virtual void DrawDebug() override;
};
