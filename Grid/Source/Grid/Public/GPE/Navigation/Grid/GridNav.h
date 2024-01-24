// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GPE/Navigation/Grid/GridPointData.h"
#include "GameFramework/Actor.h"
#include "GridNav.generated.h"

UCLASS()
class GRID_API AGridNav : public AActor
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "Grid Nav")
		int size = 4;
	UPROPERTY(EditAnywhere, Category = "Grid Nav")
		int gap = 100;
	UPROPERTY(EditAnywhere, Category = "Grid Nav")
		FColor gridNodeColor = FColor::Green, gridLinesColor = FColor::Red;
	UPROPERTY(EditAnywhere, Category = "Grid Nav", meta = (EditInLine))
		TObjectPtr<UGridPointData> data = nullptr;
	TObjectPtr<ANodeGrid> currentNode = nullptr;
public:	
	AGridNav();
public:
	FORCEINLINE TObjectPtr<UGridPointData> GetData() const { return data; }
	FORCEINLINE void SetData(TObjectPtr< UGridPointData> _data) { data = _data; }
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
private:
	void SetSuccessors();
	void DrawDebug();
public:
	void Generate();
};
