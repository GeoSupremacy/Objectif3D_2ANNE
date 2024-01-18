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
	UPROPERTY() TObjectPtr<class UFSMComponent> currentFSMComponent = nullptr;
	UPROPERTY(EditAnywhere, Category = "State Object") bool desactivateMS = false;
public:
	FORCEINLINE bool GetDesactivateMS() const { return desactivateMS; }
	FORCEINLINE TObjectPtr<class UFSMComponent> GetFSMComponent() const { return currentFSMComponent; }
public:
	void StartFSM(class UFSMComponent* _owner);
	void SetNextState(TSubclassOf<UStateObject> _state);
	virtual void UpdateFSM();
	virtual void StopFSM();
};
