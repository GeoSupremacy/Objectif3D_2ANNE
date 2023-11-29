// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "GameFramework/SpringArmComponent.h"
#include "Camera/CameraComponent.h"
#include "InputMappingContext.h"


#include "GameFramework/Character.h"
#include "DiabloCharacter.generated.h"

UCLASS()
class CCC_2023_API ADiabloCharacter : public ACharacter
{
	GENERATED_BODY()
		
#pragma region Camera
private:
	UPROPERTY(EditAnywhere, Category = "Diablo/Camera")
		TObjectPtr<USpringArmComponent> springArm = nullptr;
	UPROPERTY(EditAnywhere, Category = "Diablo/Camera")
		TObjectPtr<UCameraComponent> camera = nullptr;
#pragma endregion

#pragma region Input
private:
	UPROPERTY(EditAnywhere, Category = "Diablo/Input")
		TSoftObjectPtr<UInputMappingContext> inputContext = nullptr;
	UPROPERTY(EditAnywhere, Category = "Diablo/Input")
		TObjectPtr<UInputAction> mouseClikInput = nullptr;
#pragma endregion Input

#pragma region Settings
private:
	UPROPERTY(EditAnywhere, Category = "Diablo")
		float  minRange;
	UPROPERTY(EditAnywhere, Category = "Diablo/LayerMask")
		TArray<TEnumAsByte<EObjectTypeQuery>> objectLayer = TArray<TEnumAsByte<EObjectTypeQuery>>();
	TArray<AActor*> actorToIgnore = { this };
	FVector destination;
#pragma endregion


#pragma region Constructeur
public:
	ADiabloCharacter();
#pragma endregion Constructeur
public:
	FORCEINLINE bool IsAsLocation() const { return FVector::Distance(GetActorLocation(), destination) < minRange; }

public:
#pragma region UE_METHOD
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;
#pragma endregion UE_METHOD
#pragma region METHOD
private:
	void MoveTo(float _delta);
	void RotateTo(float _delta);
	void MousePosition();
	void GetTargetLocation(const FInputActionValue& _value);
	void InitInputSystem(UInputComponent* PlayerInputComponent);
	void MappingContext();
#pragma endregion METHOD
};
