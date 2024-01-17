// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "FSM/StateObject.h"
#include "Follow_Target_State.generated.h"

/**
 * 
 */
UCLASS()
class AI_FSM_API UFollow_Target_State : public UStateObject
{
	GENERATED_BODY()
private:
	UPROPERTY(VisibleAnywhere)
		TObjectPtr<class AIA_Guard> current_Guard = nullptr;
	
public:
	virtual void Enter(class UFSMObject* _owner)override;
	virtual void Update() override;
	virtual void Exit() override;
};
