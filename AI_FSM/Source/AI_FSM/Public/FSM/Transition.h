// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "UObject/NoExportTypes.h"
#include "Transition.generated.h"

/**
 * 
 */
UCLASS(Abstract, Blueprintable)
class AI_FSM_API UTransition : public UObject
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category ="State") TSubclassOf<class UStateObject> nextState = nullptr;
public:
	FORCEINLINE  TSubclassOf<class UStateObject> GetNextState() const{ return nextState; }
	virtual void InitTranstition();
	virtual bool IsValidTranstition();
};
