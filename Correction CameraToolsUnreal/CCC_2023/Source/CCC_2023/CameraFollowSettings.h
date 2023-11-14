// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "CameraSettings.h"
#include "EnumCameraSettings.h"
#include "CameraFollowSettings.generated.h"

/**
 * 
 */
UCLASS()
class CCC_2023_API UCameraFollowSettings : public UCameraSettings
{
	GENERATED_BODY()
#pragma region settings
		    UPROPERTY(EditAnywhere , Category= "Camera settings")
		        TEnumAsByte<EMovementType> movemementType;
			UPROPERTY(EditAnywhere, Category = "Camera settings")
				TEnumAsByte<EOffsetType> offsetType;
			UPROPERTY(EditAnywhere, Category = "Camera settings", meta = (UIMin = -2000, UIMax = 2000, ClampMin = -2000, ClampMax = 2000))
				float offsetX = 300;
			UPROPERTY(EditAnywhere, Category = "Camera settings", meta = (UIMin = -2000, UIMax = 2000, ClampMin = -2000, ClampMax = 2000))
				float offsetY = 0;
			UPROPERTY(EditAnywhere, Category = "Camera settings", meta = (UIMin = -2000, UIMax = 2000, ClampMin = -2000, ClampMax = 2000))
				float offsetZ = 0;
			UPROPERTY(EditAnywhere, Category = "Camera settings", meta = (UIMin = 0, UIMax = 1000, ClampMin = 0, ClampMax = 1000))
				float cameraSpeed = 100;
#pragma endregion settings
public :
	FORCEINLINE EOffsetType OffsetType() const { return offsetType; }
	FORCEINLINE EMovementType MovemementType() const { return movemementType; }
	FORCEINLINE float OffsetX() const { return offsetX;}
	FORCEINLINE float OffsetY() const { return offsetY;}
	FORCEINLINE float OffsetZ() const { return offsetZ; }
	FORCEINLINE float CameraSpeed() const { return  cameraSpeed; }
};