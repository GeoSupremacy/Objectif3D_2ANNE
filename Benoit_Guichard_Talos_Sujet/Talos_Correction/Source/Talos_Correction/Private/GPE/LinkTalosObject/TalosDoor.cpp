// Fill out your copyright notice in the Description page of Project Settings.


#include "GPE/LinkTalosObject/TalosDoor.h"

void ATalosDoor::OpenDoor()
{
	
	SetActorEnableCollision(false);
}

void ATalosDoor::CloseDoor()
{

	SetActorEnableCollision(true);
}
