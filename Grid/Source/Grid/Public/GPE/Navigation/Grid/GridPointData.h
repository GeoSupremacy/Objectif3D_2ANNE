// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GPE/Navigation/Grid/Node.h"

#include "Engine/DataAsset.h"
#include "GridPointData.generated.h"

/**
 * 
 */
UCLASS()
class GRID_API UGridPointData : public UDataAsset
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, meta = (EditInLine))
		int count;
	UPROPERTY(EditAnywhere, meta = (EditInLine))
	TArray<TObjectPtr<ANodeGrid>> nodes =  TArray<TObjectPtr<ANodeGrid>>();
public:
	FORCEINLINE void SetNodes(int _nodes) { count += _nodes; }
	FORCEINLINE TArray<TObjectPtr<ANodeGrid>> GetNodes() const { return nodes; }
	FORCEINLINE void SetNodes(TArray<TObjectPtr<ANodeGrid>> _nodes)  {  nodes = _nodes; }
};
