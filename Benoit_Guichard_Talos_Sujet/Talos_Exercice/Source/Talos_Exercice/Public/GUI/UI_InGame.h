// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Player/PlayableCharacter.h"

#include "GUI/BaseUserWidget.h"
#include "UI_InGame.generated.h"

/**
 * 
 */
UCLASS()
class TALOS_EXERCICE_API UUI_InGame : public UBaseUserWidget
{
	GENERATED_BODY()
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnDisplayInteract, bool, _candisplay);
	FOnDisplayInteract onDisplayInteract;
private:
		TObjectPtr<APlayableCharacter> player = nullptr;
	UPROPERTY(BlueprintReadWrite, meta = (AllowPrivateAccess, BindWidget))
		TObjectPtr<UImage> interactImage = nullptr;
	
public:
	FORCEINLINE FOnDisplayInteract& OnDisplayInteract(){ return onDisplayInteract; }
public:
	virtual void Bind() override;
	UFUNCTION() void DisplayInteract(bool _canDisplay);
	UFUNCTION() void DisplayIcon();
	UFUNCTION() void HiddenIcon();
};
