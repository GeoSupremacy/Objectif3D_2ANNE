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

#pragma region Event
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnDisplayInteract, bool, _candisplay);
	FOnDisplayInteract onDisplayInteract;
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnDisplay, bool, display);
	FOnDisplay onDisplay;
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_TwoParams(FOnDisplayLink, bool, display, FVector, position);
	FOnDisplayLink onDisplayLink;
#pragma endregion 

#pragma region F/P
private:
	TObjectPtr<APlayableCharacter> player = nullptr;
	UPROPERTY(BlueprintReadWrite, meta = (AllowPrivateAccess, BindWidget))
		TObjectPtr<UImage> interactImage = nullptr;
	FWidgetTransform positionImage;
#pragma endregion 

#pragma region Broadcast
public:
	FORCEINLINE FOnDisplayInteract& OnDisplayInteract() { return onDisplayInteract; }
	FORCEINLINE FOnDisplay& OnDisplay() { return onDisplay; }
	FORCEINLINE FOnDisplayLink& OnDisplayLink() { return onDisplayLink; }
#pragma endregion 

#pragma region Acesseur
public:
	//Pour changer la disposition de l'icone d'interaction quand le joueur peut link, sinon retour à sa position de départ
	TObjectPtr<UImage> InteractImage() { return interactImage; }
	void SetInteractImageLocation(FWidgetTransform _fw) { interactImage->GetParent()->SetRenderTransform(_fw); }
	FWidgetTransform PositionImage() { return positionImage; }
#pragma endregion 

#pragma region METHOD
private:
	virtual void Bind() override;
public:
	UFUNCTION() void DisplayInteract(bool _canDisplay);
	UFUNCTION() void DisplayIcon(bool _canDisplay);
	UFUNCTION() void Displaylink(bool _canDisplay, FVector _position);
#pragma endregion 
};
