// Fill out your copyright notice in the Description page of Project Settings.


#include "3C/InputAsset.h"

void UInputAsset::EnableInputContext(ULocalPlayer* _localPlayer)
{
	UEnhancedInputLocalPlayerSubsystem* _inputSystem = ULocalPlayer::GetSubsystem<UEnhancedInputLocalPlayerSubsystem>(_localPlayer);
	if (!_inputSystem)
		return;
	_inputSystem->ClearAllMappings();
	_inputSystem->AddMappingContext(inputContext.LoadSynchronous(), 0);
	Init();
}

void UInputAsset::Init()
{
	allInput = { movementForwardInput,movementStopForwardInput,rotatePitchInput,rotateYawInput,movementRightInput,movementStopRightInput, };
}

bool UInputAsset::InputIsValid()
{
	for (auto input : allInput)
		if (!input)
			return false;

	return true;
}
