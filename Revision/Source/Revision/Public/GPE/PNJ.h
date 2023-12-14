// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GPE/DialogSettings/DialogSettings.h"

#include "GameFramework/Actor.h"
#include "PNJ.generated.h"

UCLASS()
class REVISION_API APNJ : public AActor
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category ="Dialogs")
		TObjectPtr<UDialogSettings> dialogSettings;
public:	
	APNJ();

protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
private:
	UFUNCTION() void OpenChat();
	UFUNCTION()  void LeftChat();
	void Bind();
};
