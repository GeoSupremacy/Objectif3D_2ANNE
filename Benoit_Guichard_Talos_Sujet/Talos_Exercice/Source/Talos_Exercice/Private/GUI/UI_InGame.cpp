// Fill out your copyright notice in the Description page of Project Settings.


#include "GUI/UI_InGame.h"
#include "../DebugUtils.h"
#include "../Utils.h"
void UUI_InGame::Bind()
{
	player = Cast<APlayableCharacter>(GetWorld()->GetFirstPlayerController()->GetPawn());
	if (!player)
		return;
	
	player->GetInteract()->BIND(OnInteracUI(), this, &UUI_InGame::DisplayInteract);
	player->BIND(OnEnable(), this, &UUI_InGame::DisplayIcon);
	player->BIND(OnDisable(), this, &UUI_InGame::HiddenIcon);
}

void UUI_InGame::DisplayInteract(bool _canDisplay)
{
	onDisplayInteract.Broadcast(_canDisplay);
}



void UUI_InGame::DisplayIcon()
{

}
void UUI_InGame::HiddenIcon()
{

}
