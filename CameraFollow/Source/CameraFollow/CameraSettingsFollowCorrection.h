// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "EnumCameraSettings.h"

#include "CoreMinimal.h"
#include "CameraSettingsCorrection.h"
#include "CameraSettingsFollowCorrection.generated.h"



UCLASS()
class CAMERAFOLLOW_API UCameraSettingsFollowCorrection : public UCameraSettingsCorrection
{
	GENERATED_BODY()

#pragma region settings
private:
	const int maxValue = 200;
	UPROPERTY(EditAnywhere, Category = "Camera Settings")
		TEnumAsByte<EMovementType> movementType;
	UPROPERTY(EditAnywhere, Category = "Camera Settings")
		TEnumAsByte<EOffsetType> offsetType;
	UPROPERTY(EditAnywhere, Category = "Camera Settings", meta = (UIMin = -2, UIMax = 20, ClampMin = -20, ClampMax = 200))
		float offsetX = 30;
	UPROPERTY(EditAnywhere, Category = "Camera Settings", meta = (UIMin = -2, UIMax = 20, ClampMin = -20, ClampMax = 200))
		float offsetY = 30;
	UPROPERTY(EditAnywhere, Category = "Camera Settings", meta = (UIMin = -2, UIMax = 20, ClampMin = -20, ClampMax = 200))
		float offsetZ = 30;
	UPROPERTY(EditAnywhere, Category = "Camera Settings", meta = (UIMin = -2, UIMax = 20, ClampMin = -20, ClampMax = 200))
		float cameraSpeed = 100;
#pragma endregion settings

public:
	FORCEINLINE  EOffsetType OffsetType() const { return offsetType; }
	FORCEINLINE  EMovementType MovementType() const { return movementType; }
	FORCEINLINE float OffsetX()  const { return offsetX; }
	FORCEINLINE float OffsetY()  const { return offsetY; }
	FORCEINLINE float OffsetZ()  const { return offsetZ; }
	FORCEINLINE float CameraSpeed()  const { return cameraSpeed; }
};
