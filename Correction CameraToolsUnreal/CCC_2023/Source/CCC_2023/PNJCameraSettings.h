// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine/DataAsset.h"
#include "CameraPNJ.h"
#include "PNJCameraSettings.generated.h"

/**
 * 
 */
UCLASS()
class CCC_2023_API UPNJCameraSettings : public UDataAsset
{
	GENERATED_BODY()
    UPROPERTY(EditAnywhere, meta = (UIMin = 0, UIMax = 1, ClampMin = 0, ClampMax = 1))
        float targetPivotLocation = .5f;
    UPROPERTY(EditAnywhere, meta = (UIMin = 0, UIMax = 360, ClampMin = 0, ClampMax = 360))
        int angle = 45;
    UPROPERTY(EditAnywhere, meta = (UIMin = 0, UIMax = 360, ClampMin = 0, ClampMax = 360))
        int height = 200;
    UPROPERTY(EditAnywhere)
        TSubclassOf<ACameraPNJ> cameraPnj = nullptr;
public :
    FORCEINLINE float TargetPivotLocation() { return targetPivotLocation; }
    FORCEINLINE int Angle() { return angle; }
    FORCEINLINE int Height() { return height; }
    FORCEINLINE TSubclassOf<ACameraPNJ> CameraPnj() { return cameraPnj; }
};
