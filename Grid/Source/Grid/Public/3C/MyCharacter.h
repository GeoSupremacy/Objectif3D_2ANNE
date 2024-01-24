// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "InputAsset.h"
#include "Camera/CameraComponent.h"
#include "GameFramework/SpringArmComponent.h"
#include "GameFramework/Character.h"
#include "MyCharacter.generated.h"

UCLASS()
class GRID_API AMyCharacter : public ACharacter
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
		TObjectPtr<UInputAsset> inputConfig = nullptr;
	UPROPERTY(EditAnywhere, Category = "Input config")
		bool desactivateInput = false;
#pragma endregion 


#pragma region Constructor
public:
	AMyCharacter();
#pragma endregion

#pragma region Acesseur
public:
	FORCEINLINE TObjectPtr<AMyCharacter> Get() { return  this; }
	FORCEINLINE TObjectPtr<UCameraComponent> GetCamera() { return  camera; }
#pragma endregion


#pragma region Broadcast
public:
	FORCEINLINE FOnMoveForward& OnMoveForward() { return onMoveForward; }
#pragma endregion


#pragma region UNREAL_METHOD
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;
#pragma endregion

#pragma region INPUT_METHOD
private:
	void MappingContect();
	void BindInput(class UInputComponent* PlayerInputComponent);
	bool CheckInput();
#pragma endregion

#pragma region INIT
private:
	void Init();
	void Bind();
#pragma endregion 

#pragma region MOVEMENT
private:
	void MoveForward(const FInputActionValue& _value);
	void MoveRight(const FInputActionValue& _value);
	void MouseRotatePitch(const FInputActionValue& _value);
	void MouseRotateYaw(const FInputActionValue& _value);
#pragma endregion

};
