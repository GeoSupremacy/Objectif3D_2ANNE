// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "CameraSettings.h"
#include "CameraOrbitSettings.generated.h"

/**
 * 
 */
UCLASS()
class CAMERAFOLLOW_API UCameraOrbitSettings : public UCameraSettings
{
	GENERATED_BODY()
        UPROPERTY(Editanywhere, Category = "Settings")
    float radius = 4.77f;

   

public:
    float Radius() { return radius; }

};
