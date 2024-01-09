// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "StateObject.h"
#include "UObject/NoExportTypes.h"
#include "FSMObject.generated.h"


UCLASS(Abstract, Blueprintable)
class AI_FSM_API UFSMObject : public UObject
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category="State Object") TSubclassOf<UStateObject> startingState = nullptr;
	UPROPERTY(VisibleAnywhere, Category = "State Object", meta = (EditInLine)) TObjectPtr<UStateObject> currentState = nullptr;
	UPROPERTY() TObjectPtr<class UFSMComponent> owner = nullptr;
public:
	FORCEINLINE TObjectPtr<class UFSMComponent> GetOwner() const {return owner;}
	void StartFSM(class UFSMComponent* _owner);
	void SetNextState(TSubclassOf<UStateObject> _state);
	virtual void UpdateFSM();
	virtual void StopFSM();
};
