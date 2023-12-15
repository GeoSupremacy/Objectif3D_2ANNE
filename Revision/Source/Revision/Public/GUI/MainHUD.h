// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GUI/UI_Dialog.h"
#include "Player/myCharacter.h"

#include "GameFramework/HUD.h"
#include "MainHUD.generated.h"

/**
 * 
 */
UCLASS()
class REVISION_API AMainHUD : public AHUD
{
	GENERATED_BODY()
private:
	UPROPERTY()
	TObjectPtr<AmyCharacter> player = nullptr;

	UPROPERTY(EditAnywhere, BlueprintReadWrite, meta = (AllowPrivateAccess))
		TSubclassOf<UUI_Dialog> dialogUiRef = nullptr;

	TObjectPtr<UUI_Dialog> dialogUi = nullptr;
public:
	virtual void BeginPlay() override;
	
	 void InitUI();
	UFUNCTION() void NextDialog();
	UFUNCTION() void ReturnPreviousDialog();
	UFUNCTION() void Display();
	UFUNCTION() void Remove();
};
