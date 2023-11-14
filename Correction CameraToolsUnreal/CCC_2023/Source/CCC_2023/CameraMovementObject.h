// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "CameraMovementObject.generated.h"

UCLASS()
class CCC_2023_API ACameraMovementObject : public AActor
{
	GENERATED_BODY()
	
public:	
	ACameraMovementObject();
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;//

};
