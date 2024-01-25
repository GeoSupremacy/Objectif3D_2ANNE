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
	TArray<FVector> FVectorNodes =  TArray<FVector>();
public:
	FORCEINLINE TArray<FVector> GetFVectorNodes()  { return FVectorNodes; }
	FORCEINLINE void SetFVectorNodes(TArray<FVector> _nodes)  { FVectorNodes = _nodes; }
	void AddVector(FVector _fv) { FVectorNodes.Add(_fv); }
};
