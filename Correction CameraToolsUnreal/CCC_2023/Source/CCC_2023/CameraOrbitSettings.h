// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Curves/CurveFloat.h"
#include "CameraSettings.h"
#include "CameraOrbitSettings.generated.h"

/**
 * 
 */
UCLASS()
class CCC_2023_API UCameraOrbitSettings : public UCameraSettings
{
	GENERATED_BODY()
    UPROPERTY(EditAnywhere, Category="Orbit settings", meta = (UIMin = 10, UIMax = 1000, ClampMin = 10, ClampMax = 1000))
        float radius = 200;
    UPROPERTY(EditAnywhere)
        TObjectPtr<UCurveFloat> expression = nullptr;

public :
    FORCEINLINE float Radius() const { return radius; }
    FORCEINLINE TObjectPtr<UCurveFloat> Expression() { return expression; }
};
