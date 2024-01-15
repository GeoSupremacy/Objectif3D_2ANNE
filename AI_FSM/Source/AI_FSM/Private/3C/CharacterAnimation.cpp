// Fill out your copyright notice in the Description page of Project Settings.

#include "3C/PlayableCharacter.h"
#include "3C/CharacterAnimation.h"

void UCharacterAnimation::NativeBeginPlay()
{
	Bind();
}



void UCharacterAnimation::SetMoveForward(const float _speed)
{
	speedForward = _speed;
}

void UCharacterAnimation::Bind()
{
	APlayableCharacter* _player = Cast< APlayableCharacter>(TryGetPawnOwner());

	if (!_player)
		return;

	_player->OnMoveForward().AddDynamic(this, &UCharacterAnimation::SetMoveForward);
}
