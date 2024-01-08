// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GPE/LinkTalosObject/TalosNode.h"
#include "TalosSource.generated.h"

/**
 * 
 */
UCLASS()
class TALOS_CORRECTION_API ATalosSource : public ATalosNode
{
	GENERATED_BODY()
public:
	virtual void NodeBehaviour() override;

};
