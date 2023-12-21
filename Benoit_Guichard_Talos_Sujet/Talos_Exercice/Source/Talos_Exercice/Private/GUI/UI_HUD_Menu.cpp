// Fill out your copyright notice in the Description page of Project Settings.


#include "GUI/UI_HUD_Menu.h"
#include "../DebugUtils.h"
void AUI_HUD_Menu::InitUI()
{
	inGameUi = CreateWidget<UUI_InGame>(GetWorld(), inGameUiRef);

	if (!inGameUi)
		return;
	inGameUi->AddToViewport();
	inGameUi->SetVisibility(ESlateVisibility::Hidden);
	inGameUi->OnDisplayInteract().AddDynamic(this, &AUI_HUD_Menu::InteractUI);
}

void AUI_HUD_Menu::InteractUI(bool _canInteract)
{
	
	if(_canInteract)
		inGameUi->SetVisibility(ESlateVisibility::Visible);
	else
		inGameUi->SetVisibility(ESlateVisibility::Hidden);
}



