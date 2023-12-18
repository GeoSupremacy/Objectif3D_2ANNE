// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "InputMappingContext.h"
#include "EnhancedInputComponent.h"
#include "EnhancedInputSubsystems.h" 

#include "Engine/DataAsset.h"
#include "InputAsset.generated.h"

/**
 * 
 */
UCLASS()
class TALOS_EXERCICE_API UInputAsset : public UDataAsset
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere) TSoftObjectPtr<UInputMappingContext> inputContext = nullptr;
	UPROPERTY(EditAnywhere) TObjectPtr<UInputAction> inputMoveForward = nullptr;
	UPROPERTY(EditAnywhere) TObjectPtr<UInputAction> inputStopMoveForward = nullptr;
	UPROPERTY(EditAnywhere) TObjectPtr<UInputAction> inputRotateYaw = nullptr;
	UPROPERTY(EditAnywhere) TObjectPtr<UInputAction> mouseRotateYaw = nullptr;
	UPROPERTY(EditAnywhere) TObjectPtr<UInputAction> mouseRotatePitch = nullptr;
	UPROPERTY(EditAnywhere) TObjectPtr<UInputAction> inputInteract = nullptr;
	UPROPERTY(EditAnywhere) TObjectPtr<UInputAction> inputDrop = nullptr;
	UPROPERTY(EditAnywhere) TObjectPtr<UInputAction> inputResetAllLinkReflector = nullptr;
	TArray< TObjectPtr<UInputAction>> allInput;
public:

	FORCEINLINE TObjectPtr<UInputAction> InputMoveForward() const { return inputMoveForward;}
	FORCEINLINE TObjectPtr<UInputAction> InputStopMoveForward() const { return inputStopMoveForward;}
	FORCEINLINE TObjectPtr<UInputAction> InputRotateYaw() const { return inputRotateYaw;}
	FORCEINLINE TObjectPtr<UInputAction> MouseRotateYaw() const { return mouseRotateYaw;}
	FORCEINLINE TObjectPtr<UInputAction> MouseRotatePitch() const { return mouseRotatePitch;}
	FORCEINLINE TObjectPtr<UInputAction> InputInteract() const { return inputInteract;}
	FORCEINLINE TObjectPtr<UInputAction> InputDrop() const { return inputDrop; }
	FORCEINLINE TObjectPtr<UInputAction> InputResetAllLinkReflector() const { return inputResetAllLinkReflector;}
	void EnableInputContext(ULocalPlayer* _local);
	void InitArray();
	bool InputIsValid();
	FORCEINLINE bool HasInputContext() { if (inputContext == nullptr) return false; else return true;}
};
