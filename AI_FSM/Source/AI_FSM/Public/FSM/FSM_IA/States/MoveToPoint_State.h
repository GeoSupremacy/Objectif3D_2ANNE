// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "FSM/StateObject.h"
#include "MoveToPoint_State.generated.h"

/**
 * 
 */
UCLASS()
class AI_FSM_API UMoveToPoint_State : public UStateObject
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere)
	float timer = 5.f;
	FTimerHandle waitTransition;
	TObjectPtr<class AIA_Guard> currentGuard = nullptr;
protected:
	virtual void Enter(class UFSMObject* _owner) override;
private:
	void WaitReLook();
};
