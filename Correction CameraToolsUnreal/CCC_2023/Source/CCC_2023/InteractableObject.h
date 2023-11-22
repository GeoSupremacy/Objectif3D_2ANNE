// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "InteractableObject.generated.h"

UCLASS()
class CCC_2023_API AInteractableObject : public AActor
{
	GENERATED_BODY()
		TObjectPtr<APlayerCollector> character = nullptr;

	FVector currentPosition;
public:	
	AInteractableObject();
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
private:
	void Init();
	UFUNCTION()	void HasInteractableObject();
};
