// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "CameraFollow.h"
#include "CameraPNJ.generated.h"

/**
 * 
 */
UCLASS()
class CCC_2023_API ACameraPNJ : public ACameraFollow
{
	GENERATED_BODY()

    FVector destination, pivot;
public :
    virtual FVector FinalPosition() override  
    {
        UE_LOG(LogTemp, Warning, TEXT("%s"),*destination.ToString());
        return destination; 
    } ;
    virtual FVector TargetPosition() const override  { return pivot; } ;
    FORCEINLINE void SetDestination(FVector _vector)
    {
        destination = _vector;
    }
    FORCEINLINE void SetLookat(FVector _vector)
    {
        pivot = _vector;
    }
};
