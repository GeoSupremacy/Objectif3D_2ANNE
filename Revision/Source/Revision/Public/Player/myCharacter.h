// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GPE/PNJ.h"
#include "Camera/CameraComponent.h"
#include "GameFramework/SpringArmComponent.h"
#include "InputMappingContext.h"
#include "Player/InputConfig.h"


#include "GameFramework/Character.h"
#include "myCharacter.generated.h"

UCLASS()
class REVISION_API AmyCharacter : public ACharacter
{

	GENERATED_BODY()
#pragma region Anime
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnMoveForward, float, _axis);
		FOnMoveForward onMoveForward;
#pragma endregion

#pragma region Dialog
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnEnterChatUI, APNJ*, png);
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnEnterChat, FString, _string);
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnLeftChat);
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnOpenUI);
	FOnOpenUI onOpenUI;
	FOnEnterChatUI onEnterChatUI;
	FOnEnterChat onEnterChat;
	FOnLeftChat onLeftChat;
#pragma endregion

#pragma region Camera
private:
	UPROPERTY(EditAnywhere, Category = "Camera")
		TObjectPtr<USpringArmComponent> arm = nullptr;
	UPROPERTY(EditAnywhere, Category = "Camera")
		TObjectPtr<UCameraComponent> camera = nullptr;
#pragma endregion 

#pragma region Settings
private:
	UPROPERTY(EditAnywhere, Category = "LayerMask")
		TArray<TEnumAsByte<EObjectTypeQuery>> objectLayer = TArray<TEnumAsByte<EObjectTypeQuery>>();

	bool hasCurrentDialog =false,
		 leftDialog = false;
	FVector cameralocation;
	FTimerHandle quiteDialog;
#pragma endregion 

#pragma region Input

	UPROPERTY(EditAnywhere, Category = "Input")
		TObjectPtr<UInputConfig> inputConfig;
	
#pragma endregion 
	
#pragma region Broadcast
public:
	FORCEINLINE FOnMoveForward& OnMoveForward() { return onMoveForward; }
	FORCEINLINE FOnEnterChat& OnEnterChat() { return onEnterChat;}
	FORCEINLINE FOnEnterChatUI& OnEnterChatUI() { return onEnterChatUI; }
	FORCEINLINE FOnLeftChat& OnLeftChat() { return onLeftChat; }
	FORCEINLINE FOnOpenUI& OnOpenUI() { return onOpenUI; }
#pragma endregion 

#pragma region METHOD_UE
public:
	AmyCharacter();
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;
	virtual bool ShouldTickIfViewportsOnly() const override;
#pragma endregion 

#pragma region Init
private:
	void Init();
	void MappingContext();
	void BindAction(UInputComponent* PlayerInputComponent);
#pragma endregion 

#pragma region Movement
private:
	void MoveForward(const FInputActionValue& _value);
	void MoveRight(const FInputActionValue& _value);
	void RotateYaw(const FInputActionValue& _value);
	void RotatePitch(const FInputActionValue& _value);
	void Jump() override;
#pragma endregion 

#pragma region Action_Input
private:
	void Interact();
	void QuitDialog();
	void EscapeDialog();
#pragma endregion 

#pragma region Movement
private:
	void DrawDebug();
#pragma endregion 

};
