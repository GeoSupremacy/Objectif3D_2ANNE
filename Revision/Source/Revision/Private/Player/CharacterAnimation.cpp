// Fill out your copyright notice in the Description page of Project Settings.


#include "Player/CharacterAnimation.h"
#include "Player/myCharacter.h"

void UCharacterAnimation::NativeBeginPlay()
{
	Bind();
}

void UCharacterAnimation::NativeUpdateAnimation(float _deltaSeconds)
{
}

void UCharacterAnimation::SetMoveForward(const float _speed)
{
	
	speedForward = _speed;
}

void UCharacterAnimation::Bind()
{
	AmyCharacter* _player = Cast< AmyCharacter>(TryGetPawnOwner());

	if (!_player)
		return;

	_player->OnMoveForward().AddDynamic(this, &UCharacterAnimation::SetMoveForward);
}
