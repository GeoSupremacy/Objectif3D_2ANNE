// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "InputMappingContext.h"
#include "EnhancedInputSubsystems.h" 
#include "EnhancedInputComponent.h"


#include "Engine/DataAsset.h"
#include "InputAsset.generated.h"


UCLASS()
class GRID_API UInputAsset : public UDataAsset
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "Character Input") TSoftObjectPtr<UInputMappingContext> inputContext = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input") TObjectPtr<UInputAction> movementForwardInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input") TObjectPtr<UInputAction> movementStopForwardInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input") TObjectPtr<UInputAction> rotatePitchInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input") TObjectPtr<UInputAction> rotateYawInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input") TObjectPtr<UInputAction> movementRightInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input") TObjectPtr<UInputAction> movementStopRightInput = nullptr;
	TArray<TObjectPtr<UInputAction>> allInput = TArray<TObjectPtr<UInputAction>>();
public:
	FORCEINLINE TSoftObjectPtr<UInputMappingContext> InputContext() const { return inputContext; }
	FORCEINLINE TObjectPtr<UInputAction> MovementForwardInput() const { return movementForwardInput; }
	FORCEINLINE TObjectPtr<UInputAction> MovementStopForwardInput() const { return movementStopForwardInput; }
	FORCEINLINE TObjectPtr<UInputAction> RotatePitchInput() const { return rotatePitchInput; }
	FORCEINLINE TObjectPtr<UInputAction> RotateYawInput() const { return rotateYawInput; }
	FORCEINLINE TObjectPtr<UInputAction> MovementRightInput() const { return movementRightInput; }
	FORCEINLINE TObjectPtr<UInputAction> MovementStopRightInput() const { return movementStopRightInput; }
	FORCEINLINE bool HasInputContext() { if (inputContext == nullptr) return false; else return true; }
	void EnableInputContext(ULocalPlayer* _localPlayer);
	bool InputIsValid();
private:
	void Init();
};
