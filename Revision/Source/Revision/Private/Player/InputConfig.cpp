// Fill out your copyright notice in the Description page of Project Settings.


#include "Player/InputConfig.h"
#include "EnhancedInputSubsystems.h" 
#include "EnhancedInputComponent.h"
#include "Player/myCharacter.h"

void UInputConfig::MappingContext(ULocalPlayer* _local)
{
	
	UEnhancedInputLocalPlayerSubsystem* _inputSystem = ULocalPlayer::GetSubsystem<UEnhancedInputLocalPlayerSubsystem>(_local);
	if (!_inputSystem)
		return;
	_inputSystem->ClearAllMappings();
	_inputSystem->AddMappingContext(inputContext.LoadSynchronous(), 0);
}


bool UInputConfig::IsValid()
{
	for (TObjectPtr<UInputAction> action : allAction)
	{
		if (action == nullptr)
			return false;
	}
	return true;
}

void UInputConfig::InitAll()
{
	allAction = { movementForwardInput, movementRightInput, rotatePitchInput, rotateYawInput, jumpInput,stopMovementForwardInput, interactInput, escapeDialogInput };
}
