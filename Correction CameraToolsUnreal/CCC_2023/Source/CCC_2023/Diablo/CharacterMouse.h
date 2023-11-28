// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "InputMappingContext.h"
#include "GameFramework/SpringArmComponent.h"
#include "Camera/CameraComponent.h"

#include "GameFramework/Character.h"
#include "CharacterMouse.generated.h"

UCLASS()
class CCC_2023_API ACharacterMouse : public ACharacter
{
	GENERATED_BODY()
#pragma region Settings
private:
	UPROPERTY(EditAnywhere, Category = "Settings")
		float speed = 5;
	UPROPERTY(EditAnywhere, Category = "Settings")
		FVector2D scrennLocation = FVector2D(0.5f, 0.5f);
	UPROPERTY(EditAnywhere, Category = "Settings")
		float distance;
	UPROPERTY(EditAnywhere, Category = "Settings")
		float depth;
	UPROPERTY(EditAnywhere, Category = "Settings/LayerMask")
		TArray<TEnumAsByte<EObjectTypeQuery>> objectLayer = TArray<TEnumAsByte<EObjectTypeQuery>>();
	FVector location, direction, positionTarget, deltaV;
	float hAxis, vAxis;
	bool hasTarget = false;
#pragma endregion Settings
#pragma region Camera
private:
	UPROPERTY(EditAnywhere, Category = "Camera")
		TObjectPtr<USpringArmComponent> springArm = nullptr;
	UPROPERTY(EditAnywhere, Category = "Camera")
		TObjectPtr<UCameraComponent> camera = nullptr;
#pragma endregion	

#pragma region Input
private:
	UPROPERTY(EditAnywhere, Category = "Character Input")
		TSoftObjectPtr<UInputMappingContext> inputContext = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input")
		TObjectPtr<UInputAction> mouseClikInput = nullptr;
#pragma endregion Input

#pragma region Constructeur
public:
	ACharacterMouse();
#pragma endregion Constructeur

#pragma region METHODE_UE
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;
#pragma endregion METHODE_UE

#pragma region Movement
private:
	void MousePosition();
	void Target();
	void InitInputSystem(UInputComponent* PlayerInputComponent);
	void MappingContext();
	void MoveForward(const FInputActionValue& _value);
	void MoveToTarget();
	void RotateCameraYaw();
#pragma endregion Movement

public:
	FORCEINLINE FVector GetDeltaV() const { return (GetActorLocation() + GetVelocity()); }
};
