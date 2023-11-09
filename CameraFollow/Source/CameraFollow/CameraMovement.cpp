// Fill out your copyright notice in the Description page of Project Settings.


#include "CameraMovement.h"

// Sets default values
ACameraMovement::ACameraMovement()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void ACameraMovement::BeginPlay()
{
	Super::BeginPlay();
	ancientLocation = GetActorLocation();
}

// Called every frame
void ACameraMovement::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	UpdateCameraPosition();
	DrawDebug();
	UE_LOG(LogTemp, Warning, TEXT("ACameraMovement %d"));
}

void ACameraMovement::DrawDebug()
{
	DrawDebugLine(GetWorld(), ancientLocation, GetTargetPosition(), FColor::Red);
	DrawDebugSphere(GetWorld(), ancientLocation, 100, 32, FColor::Black);
}

