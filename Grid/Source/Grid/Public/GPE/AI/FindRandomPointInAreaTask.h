// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GPE/AI/TaskNode.h"
#include "FindRandomPointInAreaTask.generated.h"

/**
 * 
 */
UCLASS()
class GRID_API UFindRandomPointInAreaTask : public UTaskNode
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere)
		FVector randomLocation = FVector(0);
	UPROPERTY(EditAnywhere)
		float radius = 1000;
	UPROPERTY(EditAnywhere)
		FName patrolLocationBBKeyName = "patrolLocation";
protected:
	virtual EBTNodeResult::Type ExecuteTask(UBehaviorTreeComponent& OwnerCop, uint8* NodeMemery) override;
};
