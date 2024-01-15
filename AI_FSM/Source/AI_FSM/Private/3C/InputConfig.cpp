// Fill out your copyright notice in the Description page of Project Settings.


#include "3C/InputConfig.h"

void UInputConfig::EnableInputContext(ULocalPlayer* _local)
{

	UEnhancedInputLocalPlayerSubsystem* _inputSystem = ULocalPlayer::GetSubsystem<UEnhancedInputLocalPlayerSubsystem>(_local);
	if (!_inputSystem)
		return;
	_inputSystem->ClearAllMappings();
	_inputSystem->AddMappingContext(inputContext.LoadSynchronous(), 0);

}

void UInputConfig::InitArray()
{
	allInput = { inputMoveForward,inputStopMoveForward,inputMoveRight,inputStopMoveRight, };

}

bool UInputConfig::InputIsValid()
{
	for (auto input : allInput)
		if (!input)
			return false;

	return true;
}
