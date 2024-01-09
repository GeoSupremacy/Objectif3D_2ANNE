// Fill out your copyright notice in the Description page of Project Settings.


#include "FSM/BasicState/Shoot_State.h"

void UShoot_State::Enter(UFSMObject* _owner)
{
	if (!shoot)
	{
		GEngine->AddOnScreenDebugMessage(1, 10, FColor::Red, "Not Shoot");
		return;
	}

	currentshoot = NewObject<AActor>(this, shoot);
	currentshoot->SetActorLocation(shootPosition);

	Super::Enter( _owner);
}
