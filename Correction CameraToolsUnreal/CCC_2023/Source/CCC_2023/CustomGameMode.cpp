
#include "CustomGameMode.h"
#include "CameraManager.h"

void ACustomGameMode::InitGame(const FString& MapName, const FString& Options, FString& ErrorMessage)
{
	Super::InitGame(MapName, Options, ErrorMessage);
	if (cameraManagerToCreate)
		currentCameraManagerInstance = NewObject<UCameraManager>(this, cameraManagerToCreate);


}
