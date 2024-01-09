// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "UObject/NoExportTypes.h"
#include "StateObject.generated.h"

/**
 * 
 */
UCLASS(Abstract, Blueprintable)
class AI_FSM_API UStateObject : public UObject
{
	GENERATED_BODY()
protected:
	UPROPERTY() TObjectPtr<class UFSMObject> currentFSMObject = nullptr;
	UPROPERTY(EditAnywhere) TArray<TSubclassOf<class UTransition>> transitions ={};
	UPROPERTY(VisibleAnywhere, meta = (EditInLine)) TArray<TObjectPtr<class UTransition>> runningTransitions = {};
public:
	virtual void Enter(class UFSMObject* _owner);
	virtual void Update();
	virtual void Exit();
protected:
	virtual void InitTransitions();
	void CheckForValidTransition();
}; 
