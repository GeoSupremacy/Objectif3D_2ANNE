// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "FSM/Transition.h"
#include "Target_Transition.generated.h"

/**
 * 
 */
UCLASS()
class AI_FSM_API UTarget_Transition : public UTransition
{
	GENERATED_BODY()
private:
	UPROPERTY(VisibleAnywhere)
		TObjectPtr<class AIA_Guard> current_Guard = nullptr;
public:
	virtual void InitTranstition() override;
	virtual bool IsValidTranstition() override;
};
