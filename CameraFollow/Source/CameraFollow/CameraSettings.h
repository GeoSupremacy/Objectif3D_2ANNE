// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine/DataAsset.h"
#include "CameraSettings.generated.h"

/**
 * 
 */
UENUM()
enum MovementType
{
    Lerp,
    ConstantLerp,
};
UENUM()
enum OffsetType
{
    World,
    Local,
};

UCLASS()
class CAMERAFOLLOW_API UCameraSettings : public UDataAsset
{
	GENERATED_BODY()
#pragma region Settings


private:
    UPROPERTY(EditAnywhere, Category = "Camera settings", meta = ( UIMin = -20, ClampMin = 20))
        float offsetX;
    UPROPERTY(EditAnywhere, Category = "Camera settings", meta = (UIMin = -20, ClampMin = 20))
        float offsetY;
    UPROPERTY(EditAnywhere, Category = "Camera settings", meta = (UIMin = -20, ClampMin = 20))
        float  offsetZ;
 


    UPROPERTY(EditAnywhere)
        TEnumAsByte <MovementType> movementType;
    UPROPERTY(EditAnywhere)
        TEnumAsByte <OffsetType> offsetType;

    UPROPERTY(EditAnyWhere, meta = (UIMin = 0, ClampMin = 10))
    float speed;
public:
    FORCEINLINE float GetSpeed()const { return speed; }
    FORCEINLINE float OffsetX() const { return offsetX; }
    FORCEINLINE float OffsetY() const { return offsetY; }
    FORCEINLINE float OffsetZ() const { return offsetZ; }

    virtual OffsetType FOffsetType()const { return offsetType; }
    virtual MovementType FMovementType() const {return movementType;}


#pragma endregion 
};
