// Fill out your copyright notice in the Description page of Project Settings.


#include "InputConfig.h"
#include "EnhancedInputSubsystems.h"
#include "../Source/CCC_2023/DebugUtils.h"

void UInputConfig::EnableInputContext(ULocalPlayer* _lplayer)
{
	
	UEnhancedInputLocalPlayerSubsystem* _inputSystem = ULocalPlayer::GetSubsystem< UEnhancedInputLocalPlayerSubsystem>(_lplayer);
	if (!_inputSystem)
	{
		LOG_ERROR("UInputConfig: missing localPlayer");
		return;
	}
	_inputSystem->ClearAllMappings();
	_inputSystem->AddMappingContext(inputContext.LoadSynchronous(), 0);



}
