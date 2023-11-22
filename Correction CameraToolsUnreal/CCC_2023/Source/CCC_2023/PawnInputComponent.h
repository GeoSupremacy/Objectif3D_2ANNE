// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "InputMappingContext.h"


#include "CoreMinimal.h"
#include "GameFramework/Pawn.h"
#include "PawnInputComponent.generated.h"

UCLASS()
class CCC_2023_API APawnInputComponent : public APawn
{
	GENERATED_BODY()
	UPROPERTY(EditAnywhere, Category = "Example Input")
		TSoftObjectPtr<UInputMappingContext> inputContext = nullptr;
	UPROPERTY(EditAnywhere, Category = "Example Input")
		TObjectPtr<UInputAction> movementInput = nullptr;
public:
	APawnInputComponent();
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;
private:
	void InitInputSystem();
	void MoveForward(const FInputActionValue& _value);
};
