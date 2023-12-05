// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine/DataAsset.h"
#include "SpawnModule.generated.h"

/**
 * 
 */
UCLASS()
class CCC_2023_API USpawnModule : public UDataAsset
{
	GENERATED_BODY()
protected:
	UPROPERTY(EditAnywhere, Category = "") FString moduleName = "";
	UPROPERTY(EditAnywhere, Category = "") bool  moduleEnable = false;
public:
	FORCEINLINE void SetmoduleEnable(bool _value) {  moduleEnable = _value; }
	FORCEINLINE bool GetModuleEnable() const {return moduleEnable;}
	FORCEINLINE void SetmoduleName(FString _value) { moduleName = _value; }
	FORCEINLINE FString GetModuleName() const { return moduleName; }
	virtual TArray<AActor*> Spawn(class ASpawnerTools* _tool);
	virtual void DrawDebug(UWorld* _wordl, const FVector& _origin);
};
 