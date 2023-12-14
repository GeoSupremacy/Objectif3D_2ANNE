// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GUI/GUI.h"
#include "UI_Dialog.generated.h"

/**
 * 
 */
UCLASS()
class REVISION_API UUI_Dialog : public UGUI
{
	GENERATED_BODY()
		UPROPERTY(BlueprintReadWrite, meta = (AllowPrivateAccess, BindWidget))
		TObjectPtr<UButton> continueButton = nullptr;
public:
	virtual void Bind() override;
	FORCEINLINE UButton* NextDialog() { return continueButton; }
	UFUNCTION() void OpenPlayUI();
};
