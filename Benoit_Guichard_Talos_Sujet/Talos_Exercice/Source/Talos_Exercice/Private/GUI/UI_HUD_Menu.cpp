// Fill out your copyright notice in the Description page of Project Settings.


#include "GUI/UI_HUD_Menu.h"
#include "Blueprint/UserWidget.h"
#include "../DebugUtils.h"

#pragma region METHOD
void AUI_HUD_Menu::InitUI()
{
	inGameUi = CreateWidget<UUI_InGame>(GetWorld(), inGameUiRef);
	player = Cast<APlayableCharacter>(FPC->GetPawn());
	if (!inGameUi)
		return;

	for (auto ui : uiIcones)
	{
		ui->AddToViewport();
		ui->SetVisibility(ESlateVisibility::Hidden);
	}
	inGameUi->AddToViewport();
	inGameUi->SetVisibility(ESlateVisibility::Hidden);
	inGameUi->OnDisplayInteract().AddDynamic(this, &AUI_HUD_Menu::InteractUI);
	inGameUi->OnDisplay().AddDynamic(this, &AUI_HUD_Menu::Display);
	inGameUi->OnDisplayLink().AddDynamic(this, &AUI_HUD_Menu::DisplayLink);
} 
void AUI_HUD_Menu::InteractUI(bool _canInteract)
{
	//Pour ne pas interférer quand le joueur link ou prend un réflecteur
	if (whileLink)
		return;

		if (_canInteract)
			inGameUi->SetVisibility(ESlateVisibility::Visible);
		else
			inGameUi->SetVisibility(ESlateVisibility::Hidden);
		

	
}
void AUI_HUD_Menu::Display(bool _canDisplay)
{
	if(_canDisplay)
		for (auto ui : uiIcones)
		{
			ui->SetLocation(Projection(ui->GetPosition()->GetActorLocation()));
			ui->SetVisibility(ESlateVisibility::Visible);
		}
	else
		for (auto ui : uiIcones)
			ui->SetVisibility(ESlateVisibility::Hidden);

}
void AUI_HUD_Menu::DisplayLink(bool _canDisplay, FVector position)
{
	//Affiche l'icone d'interaction vers un objet qui peut êtrr linker
	whileLink = _canDisplay;
	if (_canDisplay)
	{
		
		inGameUi->SetInteractImageLocation(Projection(position));
		inGameUi->SetVisibility(ESlateVisibility::Visible);
	}
	else
	{
		//Retour position de passe de l'icone d'interaction
		inGameUi->SetInteractImageLocation(inGameUi->PositionImage());
		inGameUi->SetVisibility(ESlateVisibility::Hidden);
	}
}
#pragma endregion 

#pragma region DYNAMIC_WIDGET
void AUI_HUD_Menu::Create(FString _name, AActor* _actor)
{

	UUI_Icone* _icone = CreateWidget<UUI_Icone>(GetWorld(), uiIconeRef);

	_icone->SetPosition(_actor);
	if (_name == "Reflector")
		_icone->Visibility("Reflector");
	else if (_name == "Source")
		_icone->Visibility("Source");
	else if (_name == "Locker")
		_icone->Visibility("Locker");
	else
		return;
	uiIcones.Add(_icone);
}
FWidgetTransform AUI_HUD_Menu::Projection(FVector _position)
{
	FWidgetTransform _fw;

	FVector2d ScreenPosition;
	FVector2d _pos;

	if (UWidgetLayoutLibrary::ProjectWorldLocationToWidgetPosition(FPC,
		_position, ScreenPosition, false))
	{
		_pos = FVector2d(ScreenPosition.X - ScreenPosition.X / 4, ScreenPosition.Y / 2);
		_fw.Translation = FVector2d(_pos);
		return _fw;
	}
	return FWidgetTransform();
}
#pragma endregion 



