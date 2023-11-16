// Fill out your copyright notice in the Description page of Project Settings.


#include "CameraActorTester.h"
#include "CameraManager.h"
#include "CustomGameMode.h"

// Sets default values
ACameraActorTester::ACameraActorTester()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	RootComponent = CreateDefaultSubobject<USceneComponent>("Root");
}

// Called when the game starts or when spawned
void ACameraActorTester::BeginPlay()
{
	Super::BeginPlay();
	ACustomGameMode* _gm = GetWorld()->GetAuthGameMode<ACustomGameMode>();
	if (!_gm)
		return;
	_gm->GetCameraManager()->SpawnCameraOrbit("Test", this);
	
}

// Called every frame
void ACameraActorTester::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

