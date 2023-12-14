// Fill out your copyright notice in the Description page of Project Settings.


#include "GUI/UI_Dialog.h"

void UUI_Dialog::Bind()
{
	//GetWorld()->GetFirstPlayerController()->SetInputMode(FInputModeUIOnly::FInputModeUIOnly());
	if (!continueButton)
		return;
	continueButton->OnClicked.AddDynamic(this, &UUI_Dialog::OpenPlayUI);
}

void UUI_Dialog::OpenPlayUI()
{
}
