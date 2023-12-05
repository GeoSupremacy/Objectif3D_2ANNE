// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "../../Tools/SpawnModule.h"
#include "LineModule.generated.h"

/**
 * 
 */
UCLASS()
class CCC_2023_API ULineModule : public USpawnModule
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "Line Spawn", meta =(UIMin = 0, UIMax = 100, ClampMin =1, ClampMax =100)) int itemNumber =10;
	UPROPERTY(EditAnywhere, Category = "Line Spawn", meta = (UIMin = 0, UIMax = 150, ClampMin = 1, ClampMax = 1500)) int gap = 150;
private:
	void DrawDebug(UWorld* _wordl, const FVector& _origin) override;
	TArray<AActor*> Spawn(class ASpawnerTools* _tool) override;
};
