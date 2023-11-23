// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include "PlayerCollector.h" 

#include "CoreMinimal.h"
#include "Animation/AnimInstance.h"
#include "CharacterAnimation.generated.h"

/**
 * 
 */
UCLASS()
class CCC_2023_API UCharacterAnimation : public UAnimInstance
{
	GENERATED_BODY()
#pragma region f/p
		UPROPERTY()
		TObjectPtr<APlayerCollector> character = nullptr;
	UPROPERTY(EditAnywhere, BlueprintReadOnly, meta = (AllowPrivateAccess))
		float forwardSpeed = 0;
	UPROPERTY(EditAnywhere, BlueprintReadOnly, meta = (AllowPrivateAccess))
		float rightSpeed = 0;
	UPROPERTY(EditAnywhere, BlueprintReadOnly, meta = (AllowPrivateAccess))
		bool isJumpInPlace = false;
	UPROPERTY(EditAnywhere, BlueprintReadOnly, meta = (AllowPrivateAccess))
		bool isFall = false;
	UPROPERTY(EditAnywhere, BlueprintReadOnly, meta = (AllowPrivateAccess))
		bool isLanding = false;
	UPROPERTY(EditAnywhere, BlueprintReadOnly, meta = (AllowPrivateAccess))
		bool hadInteracted = false;

	FTimerHandle timerStopInteract;
#pragma endregion f/p

#pragma region UE_UNREAL
private:
	virtual void NativeBeginPlay() override;
	virtual void NativeUpdateAnimation(float _deltaSeconds) override;
#pragma endregion UE_UNREAL

#pragma region UE_CUSTOM

#pragma region Acesseur
private:
	bool GetJump();
	bool GetFall();
	bool GetInteract();
	UFUNCTION() void SetSpeedForward(const float _speed);
	UFUNCTION() void SetSpeedRight(const float _speed);
#pragma endregion Acesseur

#pragma region AnimNotify
private:
	UFUNCTION(BlueprintCallable) void StartJump();
	UFUNCTION(BlueprintCallable) void StopJump();
#pragma endregion AnimNotify

#pragma endregion UE_CUSTOM
};
