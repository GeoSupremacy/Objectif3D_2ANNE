// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "PNJDialogCameraSystem.h"
#include "PNJ.generated.h"


UCLASS()
class CCC_2023_API APNJ : public AActor
{
	GENERATED_BODY()
	UPROPERTY(EditAnywhere)
		TObjectPtr<UPNJDialogCameraSystem> pnjDialogSystem = nullptr;
private:	
	APNJ();
	void Init(); 
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual bool ShouldTickIfViewportsOnly() const override;
};
