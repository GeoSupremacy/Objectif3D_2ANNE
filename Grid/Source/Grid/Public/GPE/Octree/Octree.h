// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Octree.generated.h"


class AOctreeCell;
UCLASS()
class GRID_API AOctree : public AActor
{
	GENERATED_BODY()
		UPROPERTY(EditAnywhere)
		TObjectPtr<AOctreeCell> root = nullptr;
	UPROPERTY(EditAnywhere)
		TSubclassOf<AOctreeCell> cellToSpawn = nullptr;
	UPROPERTY(EditAnywhere)
		int maxBranchingID = 4;
protected:
	UPROPERTY(EditAnywhere, BlueprintReadWrite)
		TObjectPtr<AActor> navMeshBoundsVolume = nullptr;
public:
	TSubclassOf<AOctreeCell> GetOctreeCellToSpawn() { return cellToSpawn; }
	int GetMaxBranchingID() const { return maxBranchingID; }

public:
	AOctree();

protected:

	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual bool ShouldTickIfViewportsOnly() const override;
	void InitRootCell();

public:
	UFUNCTION(CallInEditor) void GenerateOctree();
	UFUNCTION(CallInEditor) void DestroyOctree();
};
