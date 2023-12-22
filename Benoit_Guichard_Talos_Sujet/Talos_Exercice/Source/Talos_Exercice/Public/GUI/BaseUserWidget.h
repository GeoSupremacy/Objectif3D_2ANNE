// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/UniformGridPanel.h"
#include "Blueprint/WidgetLayoutLibrary.h"
#include "Blueprint/UserWidget.h"
#include <Components/TextBlock.h>
#include "Components/Image.h"
#include <Components/Button.h>
#include "BaseUserWidget.generated.h"


UCLASS()
class TALOS_EXERCICE_API UBaseUserWidget : public UUserWidget
{
	GENERATED_BODY()
public:
	virtual void NativeConstruct() override;
	virtual void Bind();
};
