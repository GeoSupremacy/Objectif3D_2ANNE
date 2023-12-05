// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "Kismet/KismetArrayLibrary.h"
#include "SpawnModule.h"
#include "Components/BillboardComponent.h"
#include "GameFramework/Actor.h"
#include "SpawnerTools.generated.h"



USTRUCT()
struct FTaMere
{
	GENERATED_BODY()
		TArray <AActor*> fuckit;
	FTaMere() {}
	FTaMere(TArray <AActor*> _items) 
	{
		fuckit = _items;
	}
};




UCLASS()
class CCC_2023_API ASpawnerTools : public AActor
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "Spawn Tools") TObjectPtr<UBillboardComponent> icon = nullptr;
	UPROPERTY(EditAnywhere, Category = "Spawn Tools") TArray<USpawnModule*> modules = {};
	UPROPERTY(EditAnywhere, Category = "Spawn Tools") TObjectPtr<USpawnModule> currentmodule = nullptr;
	UPROPERTY(EditAnywhere, Category = "Spawn Tools") bool useSingleItem= false;
	UPROPERTY(EditAnywhere, Category = "Spawn Tools", meta = (EditCondition = "useSingleItem")) TSubclassOf<AActor> item = nullptr;
	UPROPERTY(EditAnywhere, Category = "Spawn Tools", meta =(EditCondition ="useSingleItem")) TArray<TSubclassOf<AActor>> items ={};
	UPROPERTY(EditAnywhere, Category = "Spawn Tools") TMap<FString, FTaMere > historic = {};

public:	
	ASpawnerTools();
public:
	TSubclassOf<AActor> PickItem() {return useSingleItem ? item : GetRandomItem();}
	void AddNewItems(FString _id, TArray<AActor*> _items);
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual bool ShouldTickIfViewportsOnly() const override;
	//
	UFUNCTION(CallinEditor, Category = "Spawn Tools")void Spawn();
	UFUNCTION(CallinEditor, Category = "Spawn Tools")void Delete();
	void DrawAllModules();
	TSubclassOf<AActor> GetRandomItem();
};
