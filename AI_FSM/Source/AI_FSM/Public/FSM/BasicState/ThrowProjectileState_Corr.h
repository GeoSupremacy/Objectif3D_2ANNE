// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "FSM/StateObject.h"
#include "ThrowProjectileState_Corr.generated.h"

/**
 * 
 */
UCLASS()
class AI_FSM_API UThrowProjectileState_Corr : public UStateObject
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category ="Projectile") TSubclassOf<AActor> projectile = nullptr;
	UPROPERTY(VisibleAnywhere, Category = "Projectile") TObjectPtr<class UWaitProjectileKillTransition_Cor> waitForKill = nullptr;
public:
	virtual void Enter(class UFSMObject* _owner) override;
protected:
	virtual void InitTransitions() override;
};
