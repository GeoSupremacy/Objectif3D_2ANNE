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

	if (!dialogUi)
		return;

	dialogUi->AddToViewport();

	dialogUi->SetVisibility(ESlateVisibility::Visible);

	//dialogUi->PlayButton()->OnClicked.AddDynamic(this, &AUI_TitleHUD::OpenPlayUI);

	//GetWorld()->GetFirstPlayerController()->SetShowMouseCursor(true);
}

void AMainHUD::NextDialog()
{
	dialogUi->SetVisibility(ESlateVisibility::Visible);
}

void AMainHUD::ReturnPreviousDialog()
{

}
