

#include "Player/InputAsset.h"




void UInputAsset::EnableInputContext(ULocalPlayer* _local)
{
	UEnhancedInputLocalPlayerSubsystem* _inputSystem = ULocalPlayer::GetSubsystem<UEnhancedInputLocalPlayerSubsystem>(_local);
	if (!_inputSystem)
		return;
	_inputSystem->ClearAllMappings();
	_inputSystem->AddMappingContext(inputContext.LoadSynchronous(), 0);
}

void UInputAsset::InitArray()
{
	allInput = { inputMoveForward,inputStopMoveForward,inputRotateYaw,mouseRotateYaw,mouseRotatePitch,inputInteract,inputResetAllLinkReflector, inputDrop };
}

bool UInputAsset::InputIsValid()
{
	for (auto input : allInput)
		if (!input)
			return false;

	return true;
}
