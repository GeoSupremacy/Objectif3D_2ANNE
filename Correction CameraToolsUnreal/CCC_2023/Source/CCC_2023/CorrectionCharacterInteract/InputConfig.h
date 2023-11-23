// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "InputMappingContext.h"


#include "Engine/DataAsset.h"
#include "InputConfig.generated.h"

/**
 * 
 */
UCLASS()
class CCC_2023_API UInputConfig : public UDataAsset
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "Character Input") TSoftObjectPtr<UInputMappingContext> inputContext = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input") TObjectPtr<UInputAction> movementForwardInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input") TObjectPtr<UInputAction> interactInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input") TObjectPtr<UInputAction> lookAtInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input") TObjectPtr<UInputAction> jumpInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input") TObjectPtr<UInputAction> rotateInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input") TObjectPtr<UInputAction> actionInput = nullptr;
public:
	FORCEINLINE TSoftObjectPtr<UInputMappingContext> ContextInput() const {return inputContext;}
	FORCEINLINE TObjectPtr<UInputAction> MovementForwardInput() const { return movementForwardInput;}
	FORCEINLINE TObjectPtr<UInputAction> InteractInput() const { return interactInput; }
	FORCEINLINE TObjectPtr<UInputAction> LookAtInput() const { return lookAtInput; }
	FORCEINLINE TObjectPtr<UInputAction> JumpInput() const { return jumpInput; }
	FORCEINLINE TObjectPtr<UInputAction> RotateInput() const { return rotateInput; }
	FORCEINLINE TObjectPtr<UInputAction> ActionInput() const { return actionInput; }
	void EnableInputContext(ULocalPlayer* _lplayer);
	bool IsValid() { return inputContext && movementForwardInput && interactInput && lookAtInput && jumpInput && rotateInput; }
};
