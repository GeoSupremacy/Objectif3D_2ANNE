// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GUI/BaseUserWidget.h"
#include "UI_Icone.generated.h"

/**
 * 
 */
UCLASS()
class TALOS_EXERCICE_API UUI_Icone : public UBaseUserWidget
{
	GENERATED_BODY()

		//Les réflecteurs , lockers et sources auront leur propres icones
private:
	UPROPERTY(BlueprintReadWrite, meta = (AllowPrivateAccess, BindWidget))
		TObjectPtr<UImage> sourceImage = nullptr;
	UPROPERTY(BlueprintReadWrite, meta = (AllowPrivateAccess, BindWidget))
		TObjectPtr<UImage> lockerImage = nullptr;
	UPROPERTY(BlueprintReadWrite, meta = (AllowPrivateAccess, BindWidget))
		TObjectPtr<UImage> reflectorImage = nullptr;

	TObjectPtr<AActor> position = nullptr;
public:
	FORCEINLINE TObjectPtr<AActor>  GetPosition() { return position; }
	FORCEINLINE void SetPosition(TObjectPtr<AActor> _position) { position = _position; }
	FORCEINLINE TObjectPtr<UImage> ReflectorImage() { return reflectorImage; }
	FORCEINLINE TObjectPtr<UImage> LockerImage() { return lockerImage; }
	FORCEINLINE TObjectPtr<UImage> SourceImage() { return sourceImage; }
	 void SetLocation(FWidgetTransform _fw) 
	 { 
		 reflectorImage->GetParent()->SetRenderTransform(_fw);
		 sourceImage->GetParent()->SetRenderTransform(_fw);
		 lockerImage->GetParent()->SetRenderTransform(_fw); 
	 }
	void Visibility(FString _name);
};
