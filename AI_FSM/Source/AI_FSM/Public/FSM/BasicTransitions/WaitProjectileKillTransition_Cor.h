// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "FSM/Transition.h"
#include "WaitProjectileKillTransition_Cor.generated.h"

/**
 * 
 */
UCLASS()
class AI_FSM_API UWaitProjectileKillTransition_Cor : public UTransition
{
	GENERATED_BODY()
		UPROPERTY() TObjectPtr<AActor>currentProjectile = nullptr;
public:
	void SendProjectile(AActor* _projectile);
	virtual bool IsValidTranstition()override ;
};
