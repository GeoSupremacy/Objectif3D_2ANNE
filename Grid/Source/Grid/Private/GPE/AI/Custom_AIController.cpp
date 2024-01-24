// Fill out your copyright notice in the Description page of Project Settings.

#include "BehaviorTree/BlackboardComponent.h"
#include "GPE/AI/Custom_AIController.h"

ACustom_AIController::ACustom_AIController()
{
	PrimaryActorTick.bCanEverTick = true;
}

void ACustom_AIController::BeginPlay()
{
	Super::BeginPlay();
	Init();
}

void ACustom_AIController::Tick(float _DeltaTime)
{
	Super::Tick(_DeltaTime);
	Debug();
}

void ACustom_AIController::Init()
{
	controlledPawn = GetPawn();
	if (!controlledPawn|| !tree)return;
	bAttachToPawn = true;
	AttachToPawn(controlledPawn);
	
	RunBehaviorTree(tree);
}

void ACustom_AIController::Debug()
{
	UBlackboardComponent* _bb = Blackboard.Get();
	if (!_bb)
		return;
	const FVector _location =_bb->GetValueAsVector(patrolLockKeyName);
	DrawDebugSphere(GetWorld(),_location,100,12,FColor::Red, false, -1,0,2);
}

void ACustom_AIController::ReceiveTargetDetected(bool _targetDetected)
{
	Blackboard->SetValueAsBool(keyDetected, _targetDetected);
}
void ACustom_AIController::ReceiveIsInRange(bool _value)
{
	Blackboard->SetValueAsBool(keyIsinRange, _value);
}
//
void ACustom_AIController::ReceiveTarget(AActor* _target)
{
	Blackboard->SetValueAsObject(keyTarget, _target);

}
