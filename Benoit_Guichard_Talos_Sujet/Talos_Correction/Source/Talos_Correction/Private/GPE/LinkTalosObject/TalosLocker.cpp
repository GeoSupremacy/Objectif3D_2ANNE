// Fill out your copyright notice in the Description page of Project Settings.


#include "GPE/LinkTalosObject/TalosLocker.h"

void ATalosLocker::NodeBehaviour()
{
	Super::NodeBehaviour();
	if (!door)
		return;
		DrawDebugLine(GetWorld(), GetActorLocation(), door->GetActorLocation(), FColor::Yellow,false, -1, 0, 5);
}

void ATalosLocker::BeginPlay()
{
	Super::BeginPlay();
	GetWorld()->GetTimerManager().SetTimer( checkTimer, this, &ATalosLocker::CheckOpenDoor, 2, true);
}

void ATalosLocker::CheckOpenDoor()
{
	if (!door)
		return;
	if (isSource)
		door->OpenDoor();
	else
		door->CloseDoor();
}
