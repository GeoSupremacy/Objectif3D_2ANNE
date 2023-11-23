// Fill out your copyright notice in the Description page of Project Settings.

#pragma once



#include "CoreMinimal.h"

#include "../Source/CCC_2023/CorrectionCharacterInteract/Interact/InteractComponentCorrection.h"
#include "InputConfig.h"

#include "GameFramework/SpringArmComponent.h"
#include "Camera/CameraComponent.h"

#include "GameFramework/Character.h"
#include "CharacterCollectorCorrection.generated.h"

UCLASS()
class CCC_2023_API ACharacterCollectorCorrection : public ACharacter
{
	GENERATED_BODY()

#pragma region Camera

		UPROPERTY(EditAnywhere, Category = "Camera")
		TObjectPtr<USpringArmComponent> springArm = nullptr;
	UPROPERTY(EditAnywhere, Category = "Camera")
		TObjectPtr<UCameraComponent> camera = nullptr;
	
#pragma endregion	

	UPROPERTY(EditAnywhere, Category = "Character component")
		TObjectPtr<UInteractComponentCorrection> interact = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character component")
		TObjectPtr <UInputConfig>inputConfig = nullptr;
public:
	ACharacterCollectorCorrection();
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

	 void MoveForward(const FInputActionValue& _value);

	 void RotateCharacter(const FInputActionValue& _value);
	
};
