// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Animation/AnimInstance.h"
#include "CharacterAnimation.generated.h"

/**
 * 
 */
UCLASS()
class AI_FSM_API UCharacterAnimation : public UAnimInstance
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, BlueprintReadOnly, meta = (AllowPrivateAccess))
		float speedForward;
private:
	virtual void NativeBeginPlay() override;
private:
	UFUNCTION() void SetMoveForward(const float _speed);
	void Bind();
};
