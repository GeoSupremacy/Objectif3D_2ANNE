// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "FSM/Transition.h"
#include "Define_New_Patrol_Transition.generated.h"

/**
 * 
 */
UCLASS()
class AI_FSM_API UDefine_New_Patrol_Transition : public UTransition
{
	GENERATED_BODY()
private:
	TObjectPtr<class AIA_Guard> currentGuard = nullptr;
public:
	virtual void InitTranstition() override;
	virtual bool IsValidTranstition() override;
};
