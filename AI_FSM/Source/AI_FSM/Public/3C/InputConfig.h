// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "InputMappingContext.h"
#include "EnhancedInputComponent.h"
#include "EnhancedInputSubsystems.h" 

#include "Engine/DataAsset.h"
#include "InputConfig.generated.h"

/**
 * 
 */
UCLASS()
class AI_FSM_API UInputConfig : public UDataAsset
{
	GENERATED_BODY()
#pragma region Input
private:
	UPROPERTY(EditAnywhere) TSoftObjectPtr<UInputMappingContext> inputContext = nullptr;

	UPROPERTY(EditAnywhere) TObjectPtr<UInputAction> inputMoveForward = nullptr;
	UPROPERTY(EditAnywhere) TObjectPtr<UInputAction> inputStopMoveForward = nullptr;
	UPROPERTY(EditAnywhere) TObjectPtr<UInputAction> inputMoveRight= nullptr;
	UPROPERTY(EditAnywhere) TObjectPtr<UInputAction> inputStopMoveRight = nullptr;
	TArray< TObjectPtr<UInputAction>> allInput;
#pragma endregion 

#pragma region Acesseur
public:
	FORCEINLINE TObjectPtr<UInputAction> InputMoveForward() const { return inputMoveForward; }
	FORCEINLINE TObjectPtr<UInputAction> InputStopMoveForward() const { return inputStopMoveForward; }
	FORCEINLINE TObjectPtr<UInputAction> InputMoveRight() const { return inputMoveRight; }
	FORCEINLINE TObjectPtr<UInputAction> InputStopMoveRight() const { return inputStopMoveRight; }
	void EnableInputContext(ULocalPlayer* _local);
	void InitArray();
	bool InputIsValid();
	FORCEINLINE bool HasInputContext() { if (inputContext == nullptr) return false; else return true; }
#pragma endregion 
};
