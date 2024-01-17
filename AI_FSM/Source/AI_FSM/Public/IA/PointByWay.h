// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/BillboardComponent.h"
#include "GameFramework/Actor.h"
#include "PointByWay.generated.h"

UCLASS()
class AI_FSM_API APointByWay : public AActor
{
	GENERATED_BODY()
		UPROPERTY(EditAnywhere)
		TObjectPtr<UBillboardComponent> icon = nullptr;
public:	
	APointByWay();

};
