// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "FSM/StateObject.h"
#include "Shoot_State.generated.h"

/**
 * 
 */
UCLASS()
class AI_FSM_API UShoot_State : public UStateObject
{
	GENERATED_BODY()
private:
	UPROPERTY(VisibleAnywhere, Category = "Shoot State") TObjectPtr<AActor> currentshoot = nullptr;
	UPROPERTY(EditAnywhere, Category="Shoot State")TSubclassOf<AActor> shoot = nullptr;
	UPROPERTY(EditAnywhere, Category = "Shoot State") FVector shootPosition;
	UPROPERTY(EditAnywhere, Category = "Shoot State") float lifeShoot;
	FTimerHandle lifeShotTimer;
public:
	virtual void Enter(class UFSMObject* _owner) override;
};
