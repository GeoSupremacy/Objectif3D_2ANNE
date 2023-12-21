// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GUI/UI_InGame.h"

#include "GUI/BaseHUD.h"
#include "UI_HUD_Menu.generated.h"

/**
 * 
 */
UCLASS()
class TALOS_EXERCICE_API AUI_HUD_Menu : public ABaseHUD
{
	GENERATED_BODY()

	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta = (AllowPrivateAccess))
		TSubclassOf<UUI_InGame> inGameUiRef = nullptr;

	TObjectPtr<UUI_InGame> inGameUi = nullptr;
public:
	void InitUI() override;
	UFUNCTION() void InteractUI(bool _canInteract);
};
