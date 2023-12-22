// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GUI/UI_InGame.h"
#include "GUI/UI_Icone.h"
#include "GUI/BaseHUD.h"


#include "UI_HUD_Menu.generated.h"


UCLASS()
class TALOS_EXERCICE_API AUI_HUD_Menu : public ABaseHUD
{
	GENERATED_BODY()
#pragma region UI_REF
private:
		UPROPERTY(EditAnywhere, BlueprintReadWrite, meta = (AllowPrivateAccess))
		TSubclassOf<UUI_InGame> inGameUiRef = nullptr;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta = (AllowPrivateAccess))
		TSubclassOf<UUI_Icone> uiIconeRef = nullptr;
#pragma endregion 

#pragma region p/f
	TObjectPtr<UUI_InGame> inGameUi = nullptr;
	TArray<TObjectPtr<UUI_Icone>> uiIcones = TArray<TObjectPtr<UUI_Icone>>();
	bool whileLink = false;
#pragma endregion 

#pragma region METHOD
public:
	//Pour registre car c'est le HUD qui créra dynamiquement les icones pour chaque locker, réflecteur et sources
	TObjectPtr<AUI_HUD_Menu> Get() { return this; }
	UFUNCTION() void InteractUI(bool _canInteract);
	UFUNCTION() void Display(bool _canDisplay);
	UFUNCTION() void DisplayLink(bool _canDisplay, FVector position);
private:
	void InitUI() override;
#pragma endregion 

#pragma region DYNAMIC_WIDGET
public:
	UFUNCTION() void Create(FString _name, AActor* _actor);
private:
	//Conversion d'un Vecteur 3D en Vecteur2D pour la position des UI
	FWidgetTransform Projection(FVector _position);
#pragma endregion 

};
