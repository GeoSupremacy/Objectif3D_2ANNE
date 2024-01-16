// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "FSM/Transition.h"
#include "Return_AfterDestinationTransit.generated.h"


UCLASS()
class AI_FSM_API UReturn_AfterDestinationTransit : public UTransition
{
	GENERATED_BODY()
public:
	virtual void InitTranstition() override;
	virtual bool IsValidTranstition() override;
};
