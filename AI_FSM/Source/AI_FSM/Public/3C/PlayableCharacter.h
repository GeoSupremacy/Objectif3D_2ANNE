// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "3C/InputConfig.h"
#include "Camera/CameraComponent.h"
#include "GameFramework/SpringArmComponent.h"

#include "GameFramework/Character.h"
#include "PlayableCharacter.generated.h"

UCLASS()
class AI_FSM_API APlayableCharacter : public ACharacter
{
	GENERATED_BODY()
#pragma region Event Animation
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnMoveForward, float, _axis);
	FOnMoveForward onMoveForward;
#pragma endregion

#pragma region Camera
private:
	UPROPERTY(EditAnywhere, Category = "Camera Component")
		TObjectPtr<UCameraComponent> camera = nullptr;
	UPROPERTY(EditAnywhere, Category = "Camera Component")
		TObjectPtr<USpringArmComponent> springArm = nullptr;
#pragma endregion

#pragma region Input
private:
	UPROPERTY(EditAnywhere, Category = "Input config")
		TObjectPtr<UInputConfig> inputConfig = nullptr;
#pragma endregion 

#pragma region Settings
private:
	UPROPERTY(EditANywhere, Category = "Runtime editor ")
		bool shouldTickIfViewportsOnly = false;
#pragma endregion

private:
	FVector deltaV;
	float hAxis = 0, vAxis = 0;

#pragma region Constructeur
public:
	APlayableCharacter();
#pragma endregion

#pragma region Acesseur
public:
	FORCEINLINE FVector GetDeltaV() const { return (GetActorLocation() + GetVelocity()); }//
	FORCEINLINE float GetVerticalAxis() { return vAxis; }//
	FORCEINLINE float GetHorizontalAxis() { return hAxis; }//
	FORCEINLINE TObjectPtr<APlayableCharacter> Get() { return  this; }
	FORCEINLINE TObjectPtr<UCameraComponent> GetCamera() { return  camera; }
#pragma endregion

#pragma region Broadcast
public:
	FORCEINLINE FOnMoveForward& OnMoveForward() { return onMoveForward; }
#pragma endregion

#pragma region METHOD_UNREAL
protected:
	virtual void BeginPlay() override;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;
#pragma endregion

#pragma region Init
private:
	void Init();
	void MappingContext();
	void BindInput(class UInputComponent* PlayerInputComponent);
	void CheckInput();
#pragma endregion

#pragma region MOVEMENT
private:
	void MoveForward(const FInputActionValue& _value);
	void MoveRight(const FInputActionValue& _value);
	void RotateCameraYaw(float _axis);
#pragma endregion
};
