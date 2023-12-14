// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include <Components/TextBlock.h>
#include <Components/Button.h>

#include "Blueprint/UserWidget.h"
#include "GUI.generated.h"

/**
 * 
 */
UCLASS()
class REVISION_API UGUI : public UUserWidget
{
	GENERATED_BODY()
public:
	virtual void NativeConstruct() override;
	virtual void Bind();
};
