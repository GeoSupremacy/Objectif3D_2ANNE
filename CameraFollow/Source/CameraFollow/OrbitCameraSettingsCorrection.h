// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "Curves/CurveFloat.h"

#include "CoreMinimal.h"
#include "CameraSettingsCorrection.h"
#include "OrbitCameraSettingsCorrection.generated.h"

/**
 * 
 */
UCLASS()
class CAMERAFOLLOW_API UOrbitCameraSettingsCorrection : public UCameraSettingsCorrection
{
	GENERATED_BODY()
private:
	UPROPERTY(Editanywhere)
	float radius = 200;
	UPROPERTY()
		TObjectPtr<UCurveFloat> expression = nullptr;
public:
	FORCEINLINE float Radius() const {return radius;}
	FORCEINLINE TObjectPtr<UCurveFloat>  Expression() const { return expression; }
};
