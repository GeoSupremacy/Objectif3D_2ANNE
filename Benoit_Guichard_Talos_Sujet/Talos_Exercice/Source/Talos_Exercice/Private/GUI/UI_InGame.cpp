// Fill out your copyright notice in the Description page of Project Settings.


#include "GUI/UI_InGame.h"
#include "../DebugUtils.h"
#include "../Utils.h"

#pragma region METHOD
void UUI_InGame::Bind()
{
	player = Cast<APlayableCharacter>(GetWorld()->GetFirstPlayerController()->GetPawn());
	if (!player)
		return;

	player->GetInteract()->BIND(OnInteracUI(), this, &UUI_InGame::DisplayInteract);
	player->BIND(OnEnable(), this, &UUI_InGame::DisplayIcon);
	player->BIND(OnCanLinkLocker(), this, &UUI_InGame::Displaylink);

	positionImage = interactImage->GetParent()->GetRenderTransform();
}
void UUI_InGame::DisplayInteract(bool _canDisplay)
{
	//Affcihe une icone d'interaction quand on peut prendre un réflecteur
	onDisplayInteract.Broadcast(_canDisplay);
}
void UUI_InGame::DisplayIcon(bool _canDisplay)
{
	//Affcihe tous les icones quand le joueur prend un réflecteur
	onDisplay.Broadcast(_canDisplay);
}
void UUI_InGame::Displaylink(bool _canDisplay, FVector _position)
{
	//Affcihe une icone d'interaction quand on peut link
	onDisplayLink.Broadcast(_canDisplay, _position);
}
#pragma endregion 