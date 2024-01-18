// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "FSM/Transition.h"
#include "Return_Transition.generated.h"

/**
 * 
 */
UCLASS()
class AI_FSM_API UReturn_Transition : public UTransition
{
	GENERATED_BODY()
public:
		bool IsValidTranstition() override;

};
