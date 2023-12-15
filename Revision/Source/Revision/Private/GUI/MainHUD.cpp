// Fill out your copyright notice in the Description page of Project Settings.


#include "GUI/MainHUD.h"

void AMainHUD::BeginPlay()
{
	Super::BeginPlay();
	InitUI();
}

void AMainHUD::InitUI()
{
	player = Cast<AmyCharacter>(GetWorld()->GetFirstPlayerController()->GetPawn());
	dialogUi = CreateWidget<UUI_Dialog>(GetWorld(), dialogUiRef);
	GetWorld()->GetFirstPlayerController()->SetInputMode(FInputModeGameOnly());

	if (!dialogUi || !player)
		return;

	dialogUi->AddToViewport();

	dialogUi->SetVisibility(ESlateVisibility::Hidden);

	player->OnOpenUI().AddDynamic(this, &AMainHUD::Display);
	player->OnLeftChat().AddDynamic(this, &AMainHUD::Remove);
	//player->OnEnterChat().AddDynamic(UUI_Dialog, &UUI_Dialog::Display);
	//GetWorld()->GetFirstPlayerController()->SetShowMouseCursor(true);
}

void AMainHUD::NextDialog()
{

}

void AMainHUD::ReturnPreviousDialog()
{

}

void AMainHUD::Display()
{
	dialogUi->SetVisibility(ESlateVisibility::Visible);
	
	GetWorld()->GetFirstPlayerController()->SetShowMouseCursor(true);
}

void AMainHUD::Remove()
{
	
	dialogUi->SetVisibility(ESlateVisibility::Hidden);

	GetWorld()->GetFirstPlayerController()->SetShowMouseCursor(false);
}
