// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "FSM/Transition.h"
#include "Wait_Follow_Transition.generated.h"

/**
 * 
 */
UCLASS()
class AI_FSM_API UWait_Follow_Transition : public UTransition
{
	GENERATED_BODY()
	UPROPERTY(EditAnywhere, Category = "Transition") float minTime = 0;
	UPROPERTY(EditAnywhere, Category = "Transition") float maxTime = 5;
	float waitTime;
	bool isDone = false;
	FTimerHandle waitTimer;
public:
	virtual void InitTranstition() override;
	virtual bool IsValidTranstition() override;
private:
	void Wait();
};
