// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Player/myCharacter.h"
#include "GPE/PNJ.h"

#include "GUI/GUI.h"
#include "UI_Dialog.generated.h"

/**
 * 
 */
UCLASS()
class REVISION_API UUI_Dialog : public UGUI
{
	GENERATED_BODY()
	UPROPERTY()
		TObjectPtr<AmyCharacter> player = nullptr;
	UPROPERTY(BlueprintReadWrite, meta = (AllowPrivateAccess, BindWidget))
		TArray<UButton*> answersButton;
	UPROPERTY(BlueprintReadWrite, meta = (AllowPrivateAccess, BindWidget))
	TObjectPtr<UButton> button = nullptr;
	UPROPERTY(BlueprintReadWrite, meta = (AllowPrivateAccess, BindWidget))
		TObjectPtr<UTextBlock> textButton = nullptr;
	UPROPERTY(BlueprintReadWrite, meta = (AllowPrivateAccess, BindWidget))
		TObjectPtr<UTextBlock> text = nullptr;
	UPROPERTY()
		TObjectPtr<APNJ> currentPng = nullptr;
	TObjectPtr < UPanelWidget> panel;
	TObjectPtr < UWidgetTree> widget;
public:
	virtual void Bind() override;
	//FORCEINLINE UButton* NextDialog() { return continueButton; }
	UFUNCTION() void Display(APNJ* _png);
};
