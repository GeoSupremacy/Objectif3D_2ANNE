// Fill out your copyright notice in the Description page of Project Settings.


#include "CameraTurnAround.h"

void ACameraTurnAround::Tick(float DeltaTime)
{
	
	UpdateCameraPosition();
	DrawDebug();
}

void ACameraTurnAround::DrawDebug()
{
	DrawDebugSphere(GetWorld(), ancientLocation,100, 32, FColor::Red);
	DrawDebugLine(GetWorld(), ancientLocation,GetActorLocation(), FColor::Yellow);
}
