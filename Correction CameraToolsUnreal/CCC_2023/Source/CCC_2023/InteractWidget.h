// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include <Components/TextBlock.h>
#include <Components/Button.h>


#include "CoreMinimal.h"
#include "Blueprint/UserWidget.h"
#include "InteractWidget.generated.h"

/**
 * 
 */
UCLASS()
class CCC_2023_API UInteractWidget : public UUserWidget
{
	GENERATED_BODY()
		UPROPERTY( BlueprintReadWrite, meta = (AllowPrivateAccess, BindWidget))
		TObjectPtr<UTextBlock> textInteract = nullptr;
private:
	virtual void NativeConstruct() override;
};
