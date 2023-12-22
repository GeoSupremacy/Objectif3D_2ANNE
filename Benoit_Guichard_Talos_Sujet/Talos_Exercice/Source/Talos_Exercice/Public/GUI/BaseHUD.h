// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/UniformGridPanel.h"
#include "Blueprint/WidgetLayoutLibrary.h"
#include "Player/PlayableCharacter.h"
#include "GameFramework/HUD.h"
#include "../Utils.h"
#include "BaseHUD.generated.h"

/**
 * 
 */
UCLASS()
class TALOS_EXERCICE_API ABaseHUD : public AHUD
{
	GENERATED_BODY()
protected:
		TObjectPtr<APlayableCharacter> player = nullptr;
public:
	virtual void BeginPlay() override;

	virtual void InitUI();
};
