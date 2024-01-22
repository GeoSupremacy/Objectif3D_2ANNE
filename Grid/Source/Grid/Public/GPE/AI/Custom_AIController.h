// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "AIController.h"
#include "Custom_AIController.generated.h"

/**
 * 
 */
UCLASS()
class GRID_API ACustom_AIController : public AAIController
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere)
		TObjectPtr<UBehaviorTree> tree = nullptr;
	UPROPERTY(EditAnywhere)
		TObjectPtr<APawn> controlledPawn = nullptr;
public:
	ACustom_AIController();
public:
	TObjectPtr<APawn> GetControlledPawn() const { return controlledPawn; }
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float _time) override;
	void Init();
};
