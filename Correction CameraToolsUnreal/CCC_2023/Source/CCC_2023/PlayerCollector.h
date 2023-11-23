// Fill out your copyright notice in the Description page of Project Settings.

#pragma once



#include "CoreMinimal.h"

#include "InputMappingContext.h"
#include "GameFramework/SpringArmComponent.h"
#include "Camera/CameraComponent.h"

#include "GameFramework/Character.h"
#include "PlayerCollector.generated.h"

UCLASS()
class CCC_2023_API APlayerCollector : public ACharacter
{
	GENERATED_BODY()
#pragma region Settings

#pragma region Event
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnMoveForward, float, _axis);
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnMoveRight, float, _axis);
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnInteract);
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnGround);
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnJump);

	FOnGround onGround;
	FOnJump onJump;
	FOnInteract onInteract;

	UPROPERTY(BlueprintCallable, BlueprintAssignable)
		FOnMoveForward onMoveForward;
	UPROPERTY(BlueprintCallable, BlueprintAssignable)
		FOnMoveRight onMoveRight;
#pragma endregion

#pragma region Camera
		UPROPERTY(EditAnywhere, Category = "Camera")
		TObjectPtr<USpringArmComponent> springArm = nullptr;
	UPROPERTY(EditAnywhere, Category = "Camera")
		TObjectPtr<UCameraComponent> camera = nullptr;
#pragma endregion	

#pragma region Movement
	UPROPERTY(EditAnywhere, Category = "Character Input")
		TSoftObjectPtr<UInputMappingContext> inputContext = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input")
		TObjectPtr<UInputAction> movementForwardInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input")
		TObjectPtr<UInputAction> stopMovementForwardInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input")
		TObjectPtr<UInputAction> movementRightInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input")
		TObjectPtr<UInputAction> movementYawInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input")
	TObjectPtr<UInputAction> movementPitchInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input")
		TObjectPtr<UInputAction> jumpInput = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input")
		TObjectPtr<UInputAction> interactionInput = nullptr;

	bool hasJumping = false, isInteracted = false;
	FVector positionObject;
#pragma endregion Movement

#pragma endregion

#pragma region UE_METHODS
public:
	APlayerCollector();
protected:
	virtual void BeginPlay() override;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;
	virtual void Jump() override;

#pragma endregion

#pragma region CUSTOM_METHOS
private:
	void InitInputSystem();
	void MoveForward(const FInputActionValue& _value);
	void MoveRight(const FInputActionValue& _value);
	void RotateCameraYaw(const FInputActionValue& _value);
	void RotateCameraPitch(const FInputActionValue& _value);
	void Ground();
	void Interact();
	FORCEINLINE	bool IsValid() { return movementForwardInput&& stopMovementForwardInput && movementRightInput && movementPitchInput && movementYawInput && jumpInput && interactionInput; }

#pragma region Broadcast
public:
	FORCEINLINE FOnMoveForward& OnMoveForward() { return onMoveForward; }
	FORCEINLINE FOnMoveRight& OnMoveRight() { return onMoveRight; }
	FORCEINLINE FOnInteract& OnInteract() { return onInteract; }
	FORCEINLINE FOnJump& OnJump() { return onJump; }
#pragma endregion

#pragma region Acesseur
	FORCEINLINE bool GetJump() const { return hasJumping; }
	FORCEINLINE bool GetInteract() const { return isInteracted; }
	FORCEINLINE void SetInteracted(const bool _isInteracted)  {  isInteracted = _isInteracted; }
	FORCEINLINE void TakeObject(const FVector _positionObject) { positionObject = _positionObject; }
	FORCEINLINE FVector CurrentPosition() const { return GetActorLocation()+ GetActorForwardVector()*100; }

	FORCEINLINE void SetJump(const bool _hasJump) { hasJumping = _hasJump; }

#pragma endregion Acesseur
#pragma endregion
};
