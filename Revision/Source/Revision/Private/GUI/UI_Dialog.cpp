// Fill out your copyright notice in the Description page of Project Settings.


#include "GUI/UI_Dialog.h"
#include "../DebugUtils.h"

void UUI_Dialog::Bind()
{
	
	
	player = Cast<AmyCharacter>(GetWorld()->GetFirstPlayerController()->GetPawn());
	if (!player)
		return;
	
	player->OnEnterChatUI().AddDynamic(this, &UUI_Dialog::Display);
	panel = Cast<UPanelWidget>(GetRootWidget());
}

void UUI_Dialog::Display( APNJ* _png)
{
	text->SetText(FText::FromString(""));
	button = nullptr;
	currentPng = Cast<APNJ>(_png);
	if (!currentPng->ThisPNJ())
		return;
	if (currentPng->DialogSettings()->Count() == 0)
		return;
	for (int i = 0; i < currentPng->DialogSettings()->Dialog(0).Count(); i++)
	{
		
			UButton* _new = NewObject<UButton>(this);
			answersButton.Add(_new);
			button =answersButton[i];
	}
	
	text->SetText(FText::FromString(currentPng->DialogSettings()->Dialog(0).quote));
}
