// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "TalosDoor.h"
#include "GPE/LinkTalosObject/TalosNode.h"
#include "TalosLocker.generated.h"

/**
 * 
 */
UCLASS()
class TALOS_CORRECTION_API ATalosLocker : public ATalosNode
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category ="Door") TObjectPtr<ATalosDoor> door = nullptr;
	FTimerHandle checkTimer;
public:
	virtual void NodeBehaviour() override;
	virtual void BeginPlay() override;
	void CheckOpenDoor() ;
};
