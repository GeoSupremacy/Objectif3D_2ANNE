// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "InputAsset.h"
#include "InteractComponent.h"
#include "Camera/CameraComponent.h"
#include "GameFramework/SpringArmComponent.h"

#include "GameFramework/Character.h"
#include "PlayableCharacter.generated.h"

UCLASS()
class TALOS_EXERCICE_API APlayableCharacter : public ACharacter
{
	
	GENERATED_BODY()
#pragma region Event Animation
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnMoveForward, float, _axis);
	FOnMoveForward onMoveForward;
#pragma endregion

#pragma region Event Interact
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnInteract);
	FOnInteract onInteract;
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnLinkSource, AReflector *, _this);
	FOnLinkSource onLinkSource;
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnDisableAllLink, AReflector*, _this);
	FOnDisableAllLink onDisableAllLink;
#pragma endregion 

#pragma region Event UI
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnEnable);
	FOnEnable onEnable;
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnDisable);
	FOnDisable onDisable;
#pragma endregion 

#pragma region Camera
private:
	UPROPERTY(EditAnywhere,Category = "Camera Component")
		TObjectPtr<UCameraComponent> camera = nullptr;
	UPROPERTY(EditAnywhere, Category = "Camera Component")
		TObjectPtr<USpringArmComponent> springArm = nullptr;
#pragma endregion Camera

#pragma region Input
private:
	UPROPERTY(EditAnywhere, Category = "Input config")
	TObjectPtr<UInputAsset> inputConfig = nullptr;
#pragma endregion 

#pragma region Interact
private:
	UPROPERTY(EditAnywhere, Category ="Interact")
	TObjectPtr<UInteractComponent> interact = nullptr;
#pragma endregion 

#pragma region Settings
private:
	UPROPERTY(EditANywhere, Category = "Runtime editor ")
		bool shouldTickIfViewportsOnly = false;

	
#pragma endregion

private:
	bool canLink = false, 
		hasObject = false;
	TObjectPtr<AReflector> hadReflector = nullptr;

#pragma region Constructor
public:
	APlayableCharacter();
#pragma endregion

#pragma region Acesseur
public:
	FORCEINLINE TObjectPtr<APlayableCharacter> Get() { return  this; }
	FORCEINLINE void SetCurentReflector(AReflector* _reflector) { hadReflector  = _reflector; }
	FORCEINLINE void SetCanLink(bool _canlink) { canLink= _canlink; } 
	UFUNCTION() void Dispersion(class AReflector* _reflector);
#pragma endregion

#pragma region UI
public:
	UFUNCTION() void EnableIcone();
	UFUNCTION() void DisableIcone();
#pragma endregion

#pragma region Broadcast
public:
	FORCEINLINE FOnMoveForward& OnMoveForward() { return onMoveForward;}
	FORCEINLINE FOnInteract& OnInteract() { return onInteract; }
	FORCEINLINE FOnEnable& OnEnable(){ return onEnable; }
	FORCEINLINE FOnDisable& OnDisable() { return onDisable;}
	FORCEINLINE FOnLinkSource& OnLinkSource() { return onLinkSource; }
	FORCEINLINE FOnDisableAllLink& OnDisableAllLink() { return onDisableAllLink; }
#pragma endregion

#pragma region UNREAL_METHOD
private:
	virtual bool ShouldTickIfViewportsOnly() const override;
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;
#pragma endregion

#pragma region INPUT_METHOD
private:
	void MappingContect();
	void BindInput(class UInputComponent* PlayerInputComponent);
	void CheckInput();
#pragma endregion

#pragma region INIT
private:
	void Init();
	void Bind();
#pragma endregion 

#pragma region MOVEMENT
private:
	void MoveForward(const FInputActionValue& _value);
	void InputRotateYaw(const FInputActionValue& _value);
	void MouseRotatePitch(const FInputActionValue& _value);
	void MouseRotateYaw(const FInputActionValue& _value);
	void Link(const FInputActionValue& _value);
	void ResetAllLink(const FInputActionValue& _value);
#pragma endregion

#pragma region DrawDebug
	private:
	void FlagInteract();
#pragma endregion


};
