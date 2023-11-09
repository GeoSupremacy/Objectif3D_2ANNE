// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "CameraSettingsFollow.h"

#include "CoreMinimal.h"
#include "CameraMovement.h"
#include "CameraFollowActor.generated.h"


UCLASS()
class CAMERAFOLLOW_API ACameraFollowActor : public ACameraMovement
{
	GENERATED_BODY()
public:
	FVector3d  Offset() override
	{
		TObjectPtr<UCameraSettingsFollow> _set = Cast<UCameraSettingsFollow> (CameraSettings);
		if(_set->FOffsetType() == Settings().offsetType)
			return GetLocalOffset(_set->OffsetX(), _set->OffsetY(), _set->OffsetZ());
		else
			return  FVector3d(_set->OffsetX(), _set->OffsetY(), _set->OffsetZ());
	}
private:
	void UpdateCameraPosition() override;
	
};
