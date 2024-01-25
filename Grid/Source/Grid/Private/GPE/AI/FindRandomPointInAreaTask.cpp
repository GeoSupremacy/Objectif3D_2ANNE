// Fill out your copyright notice in the Description page of Project Settings.

#include"NavigationSystem.h"
#include "BehaviorTree/BlackboardComponent.h"
#include "GPE/AI/Custom_AIController.h"
#include "GPE/AI/FindRandomPointInAreaTask.h"

EBTNodeResult::Type UFindRandomPointInAreaTask::ExecuteTask(UBehaviorTreeComponent& OwnerCop, uint8* NodeMemery)
{
	Super::ExecuteTask(OwnerCop, NodeMemery);
	UNavigationSystemV1* _nav= UNavigationSystemV1::GetCurrent(GetWorld());
	const FVector _origin = brain.Get()->GetControlledPawn()->GetActorLocation();
	FNavLocation _point;
	const bool _succes =_nav->GetRandomPointInNavigableRadius(_origin, radius, _point);
	if (!_succes)
	{
		UE_LOG(LogTemp, Warning, TEXT("Failed to find random point during task"));
		return EBTNodeResult::Failed;
	}
	randomLocation = _point.Location;
	
	brain.Get()->GetBlackboardComponent()->SetValueAsVector(patrolLocationBBKeyName,randomLocation);
	return EBTNodeResult::Succeeded;
}
