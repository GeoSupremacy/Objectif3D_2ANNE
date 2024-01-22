// Fill out your copyright notice in the Description page of Project Settings.


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
}

void ACustom_AIController::Init()
{
	controlledPawn = GetPawn();
	if (!controlledPawn)return;
	bAttachToPawn = true;
	AttachToPawn(controlledPawn);
	/*
	if (!tree)
		tree = controlledPawn->GetTree();
		*/
	RunBehaviorTree(tree);
}
