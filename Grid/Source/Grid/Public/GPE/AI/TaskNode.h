// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GPE/AI/Custom_AIController.h"

#include "BehaviorTree/BTTaskNode.h"
#include "TaskNode.generated.h"

/**
 * 
 */
UCLASS(Abstract)
class GRID_API UTaskNode : public UBTTaskNode
{
	GENERATED_BODY()
protected: 
	UPROPERTY()
		TObjectPtr<UBehaviorTreeComponent> tree = nullptr;
	UPROPERTY()
		TObjectPtr<ACustom_AIController> brain = nullptr;
protected:
	virtual EBTNodeResult::Type ExecuteTask(UBehaviorTreeComponent& OwnerCop, uint8* NodeMemery ) override;
};
