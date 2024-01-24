// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GPE/AI/TaskNode.h"
#include "AttackTask.generated.h"

/**
 * 
 */
UCLASS()
class GRID_API UAttackTask : public UTaskNode
{
	GENERATED_BODY()
protected:
	virtual EBTNodeResult::Type ExecuteTask(UBehaviorTreeComponent& OwnerCop, uint8* NodeMemery) override;
};
