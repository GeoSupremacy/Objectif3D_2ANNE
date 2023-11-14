// Fill out your copyright notice in the Description page of Project Settings.


#include "PNJ.h"

// Sets default values
APNJ::APNJ()
{
	PrimaryActorTick.bCanEverTick = true;
	RootComponent = CreateDefaultSubobject<USceneComponent>("Root");
	pnjDialogSystem = CreateDefaultSubobject<UPNJDialogCameraSystem>("DialogCameraSystem");
	AddOwnedComponent(pnjDialogSystem);
#if WITH_EDITOR
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif
}

void APNJ::BeginPlay()
{
	Super::BeginPlay();
	Init();
}

void APNJ::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}

bool APNJ::ShouldTickIfViewportsOnly() const
{
	return true;
}

void APNJ::Init()
{
	pnjDialogSystem->InitCameraDialog();
}
