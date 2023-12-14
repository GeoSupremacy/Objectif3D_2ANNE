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
class REVISION_API UInputConfig : public UDataAsset
{
	GENERATED_BODY()
		UPROPERTY(EditAnywhere, Category = "Name")
		FString name = "ID";
#pragma region Input
private:
		UPROPERTY(EditAnywhere, Category = "Input")
		TSoftObjectPtr<UInputMappingContext> inputContext = nullptr;
	UPROPERTY(EditAnywhere, Category = "Input")
		TObjectPtr<UInputAction> movementForwardInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Input")
		TObjectPtr<UInputAction> stopMovementForwardInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Input")
		TObjectPtr<UInputAction> movementRightInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Input")
		TObjectPtr<UInputAction> rotateYawInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Input")
		TObjectPtr<UInputAction> rotatePitchInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Input")
		TObjectPtr<UInputAction> jumpInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Input")
		TObjectPtr<UInputAction> interactInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Input")
		TObjectPtr<UInputAction> escapeDialogInput = nullptr;
	TArray<UInputAction*> allAction;
#pragma endregion 
public: 
	FORCEINLINE TSoftObjectPtr<UInputMappingContext> ContextInput() const { return inputContext; }
	FORCEINLINE TObjectPtr<UInputAction> MovementForwardInput() const { return movementForwardInput; }
	FORCEINLINE TObjectPtr<UInputAction> InteractInput() const { return interactInput; }
	FORCEINLINE TObjectPtr<UInputAction> EscapeDialogInput() const { return escapeDialogInput; }
	FORCEINLINE TObjectPtr<UInputAction> StopMovementForwardInput() const { return stopMovementForwardInput; }
	FORCEINLINE TObjectPtr<UInputAction> JumpInput() const { return jumpInput; }
	FORCEINLINE TObjectPtr<UInputAction> RotatePitchInput() const { return rotatePitchInput; }
	FORCEINLINE TObjectPtr<UInputAction> RotateYawInput() const { return rotateYawInput; }
	FORCEINLINE TObjectPtr<UInputAction> MovementRightInput() const{ return movementRightInput; }
	FORCEINLINE TArray<UInputAction*>  AllAction() const { return allAction; }
	FORCEINLINE FString  Name() const { return name; }
public:
	void MappingContext(ULocalPlayer* _local);
	bool IsValid();
	void InitAll();
};
