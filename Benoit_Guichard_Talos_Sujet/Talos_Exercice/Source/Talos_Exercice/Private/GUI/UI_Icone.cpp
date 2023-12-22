// Fill out your copyright notice in the Description page of Project Settings.


#include "GUI/UI_Icone.h"


//permet d'afficher que l'icone correspondante
void UUI_Icone::Visibility(FString _name)
{
	if (_name == "Locker")
	{
		sourceImage->SetVisibility(ESlateVisibility::Hidden);
		reflectorImage->SetVisibility(ESlateVisibility::Hidden);

	} 
	else if (_name == "Source")
	{
		lockerImage->SetVisibility(ESlateVisibility::Hidden);
		reflectorImage->SetVisibility(ESlateVisibility::Hidden);
	}
	else if (_name == "Reflector")
	{
		sourceImage->SetVisibility(ESlateVisibility::Hidden);
		lockerImage->SetVisibility(ESlateVisibility::Hidden);
	}
	else
		return;
}
