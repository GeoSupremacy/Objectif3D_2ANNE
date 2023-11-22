
#pragma once
#include "InteractWidget.h"


#include "CoreMinimal.h"
#include "GameFramework/HUD.h"
#include "HUDInteract.generated.h"

/**
 * 
 */
UCLASS()
class CCC_2023_API AHUDInteract : public AHUD
{
	GENERATED_BODY()
		UPROPERTY(BlueprintReadWrite, meta = (AllowPrivateAccess, BindWidget))
		TObjectPtr<UInteractWidget> UI = nullptr;

	UPROPERTY(EditAnywhere)
		TSoftObjectPtr<UWorld> gameLevel = nullptr;

};
