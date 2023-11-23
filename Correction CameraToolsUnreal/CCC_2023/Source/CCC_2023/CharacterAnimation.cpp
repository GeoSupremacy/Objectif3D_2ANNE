

// Fill out your copyright notice in the Description page of Project Settings.


#include "CharacterAnimation.h"
#include "DebugUtils.h"

#pragma region UE_UNREAL
void UCharacterAnimation::NativeBeginPlay()
{
	Super::NativeBeginPlay();
	character = Cast<APlayerCollector>(TryGetPawnOwner());
	if (!character)
		return;
	character->OnMoveForward().AddDynamic(this, &UCharacterAnimation::SetSpeedForward);
	character->OnMoveRight().AddDynamic(this, &UCharacterAnimation::SetSpeedRight);
	character->OnJump().AddDynamic(this, &UCharacterAnimation::StartJump);
}
void UCharacterAnimation::NativeUpdateAnimation(float _deltaSeconds)
{
	Super::NativeUpdateAnimation(_deltaSeconds);

	isJumpInPlace = GetJump();
	isFall = GetFall();
	hadInteracted = GetInteract();
}
#pragma endregion UE_UNREAL
#pragma region UE_CUSTOM

#pragma region Acesseur

bool UCharacterAnimation::GetJump()
{
	if (!character)
		return false;
	return character->GetJump();
}
bool UCharacterAnimation::GetFall()
{
	if (!character || !character->GetCharacterMovement())
		return false;
	return true;
}
bool UCharacterAnimation::GetInteract()
{
	if (!character)
		return false;
	return character->GetInteract();
}

void UCharacterAnimation::SetSpeedForward(const float _speed)
{
	if (rightSpeed)
		return;
	forwardSpeed = _speed;
}
void UCharacterAnimation::SetSpeedRight(const float _speed)
{
	if (forwardSpeed)
		return;
	rightSpeed = _speed;
}
void UCharacterAnimation::StartJump()
{
	if (!character)
		return;
	character->SetJump(true);
}
void UCharacterAnimation::StopJump()
{
	if (!character)
		return;
	character->SetJump(false);
}
#pragma endregion Acesseur

#pragma endregion UE_CUSTOM