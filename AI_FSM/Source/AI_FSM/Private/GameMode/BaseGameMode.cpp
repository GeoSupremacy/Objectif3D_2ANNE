// Fill out your copyright notice in the Description page of Project Settings.


#include "GameMode/BaseGameMode.h"
#include "Manager/IA_GuardManager.h"

void ABaseGameMode::InitGame(const FString& MapName, const FString& Options, FString& ErrorMessage)
{
	

	Super::InitGame(MapName, Options, ErrorMessage);
	if (IA_GuardManagerToCreate)
	{
		currentIA_GuardManagerInstance = NewObject<UIA_GuardManager>(this, IA_GuardManagerToCreate);
		
	}

}
