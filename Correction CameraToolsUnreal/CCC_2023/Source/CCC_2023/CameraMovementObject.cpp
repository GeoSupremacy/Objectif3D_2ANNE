// Fill out your copyright notice in the Description page of Project Settings.


#include "CameraMovementObject.h"

ACameraMovementObject::ACameraMovementObject()
{
	PrimaryActorTick.bCanEverTick = true;
}

void ACameraMovementObject::BeginPlay()
{
	Super::BeginPlay();
}

void ACameraMovementObject::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}

