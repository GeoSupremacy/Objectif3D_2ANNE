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
private:
	UPROPERTY(EditAnywhere,Category ="AOctreeCell") TObjectPtr< AOctreeCell> root = nullptr;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell")  int maxBrancheID = 4;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell")  TSubclassOf<AOctreeCell> cellToSPawn = nullptr;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell")  bool shouldTickIfViewportsOnly = false;
protected:
	UPROPERTY(EditAnywhere, Category = "AOctreeCell", BlueprintReadWrite)  TObjectPtr<AActor> navMeshBounsVolume = nullptr;
public:	
	AOctree();
public:
	FORCEINLINE TSubclassOf<AOctreeCell> GetCellToSPawn() const { return cellToSPawn; }
	FORCEINLINE int GetMaxBrancheID() const { return maxBrancheID; }
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual bool ShouldTickIfViewportsOnly() const override;
	void InitRootCell();
public:
	UFUNCTION(CallInEditor) void GenerateOctree();
	UFUNCTION(CallInEditor) void DestroyOctree();
};
