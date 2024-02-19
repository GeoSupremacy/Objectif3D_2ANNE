// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/BoxComponent.h"

#include "GameFramework/Actor.h"
#include "OctreeCell.generated.h"

USTRUCT()
struct FOctreeCellParameter
{
	GENERATED_BODY()
		UPROPERTY(EditAnywhere)
		int childrenNumberToSpawn = 8;
	UPROPERTY(EditAnywhere)
		int capacity = 0;
};



class AOctree;
UCLASS()
class GRID_API AOctreeCell : public AActor
{
	GENERATED_BODY()
		DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnNumberOfActorsInsideUpdate, int, _numberOfActorsInside);

	UPROPERTY(BlueprintCallable, BlueprintAssignable)
		FOnNumberOfActorsInsideUpdate onNumberOfActorsInsideUpdate;

	UPROPERTY(EditAnywhere)
		int branchingID = 1;
	UPROPERTY(EditAnywhere, Category = "OctreeCell|Internals")
		TObjectPtr<AOctree> octree = nullptr;
	UPROPERTY(EditAnywhere, Category = "OctreeCell|Internals")
		TObjectPtr<AOctreeCell> parent = nullptr;
	UPROPERTY(EditAnywhere, Category = "OctreeCell|Internals")
		TObjectPtr<UBoxComponent> box = nullptr;
	UPROPERTY(EditAnywhere, Category = "OctreeCell|Parameters")
		FOctreeCellParameter cellParameters = FOctreeCellParameter();

	UPROPERTY(EditAnywhere, Category = "OctreeCell|Internals")
		TArray<AOctreeCell*> cellChildren;
	UPROPERTY(EditAnywhere, Category = "OctreeCell|Internals")
		bool isActive = true;


	UPROPERTY(EditAnywhere, Category = "OctreeCell|Parameters")
		TArray<TSubclassOf<AActor>> classToDetect;
	UPROPERTY(EditAnywhere)
		TArray<AActor*> actorsInside;
	UPROPERTY(EditAnywhere, Category = "OctreeCell|Internals")
		int currentActorsInside = 0;
	UPROPERTY(EditAnywhere, Category = "OctreeCell|Internals")
		int currentNumberOfChildren = 0;

	UPROPERTY(EditAnywhere, Category = "OctreeCell|Debug")
		bool useDebug = false;
	UPROPERTY(EditAnywhere, Category = "OctreeCell|Debug")
		bool debugArea = false;
	UPROPERTY(EditAnywhere, Category = "OctreeCell|Debug", meta = (EditCondition = "useDebug", EditConditionHides))
		int debugThickness = 0;
	UPROPERTY(EditAnywhere, Category = "OctreeCell|Debug", meta = (EditCondition = "useDebug", EditConditionHides))
		FColor debugColor = FColor::Blue;

	UPROPERTY(EditAnywhere)
		bool canRun = false;
	UPROPERTY(EditAnywhere)
		TSubclassOf<AActor> toSpawn;

public:
	FOnNumberOfActorsInsideUpdate& OnNumberOfActorsInsideUpdate() { return onNumberOfActorsInsideUpdate; }
public:
	AOctreeCell();

protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	void EnableSubidivsion();
	virtual bool ShouldTickIfViewportsOnly() const override;
	bool CheckContains();
	virtual void NotifyActorBeginOverlap(AActor* OtherActor) override;
	virtual void NotifyActorEndOverlap(AActor* OtherActor) override;
	void InitSubCell(const int _branchingID, AOctree* _octree, AOctreeCell* _parent);
	void SubDivideCells(const FVector _subLocation);
	void RemoveSubCells();
	UFUNCTION() void ManageCellBehaviour(const int _numberOfActorsInside);
	FVector GetSubLocation(const int _index);
	void DrawDebug();

public:
	void SetOctree(AOctree* _octree);
	void SetCellDimensions(const double _length, const double _width, const double _height);
	void SetCellDimensions(const FVector& _dimensions);
	void CustomDestroy();
	void SetCanSubdivide(bool _value);
	void SetCanRun(bool _value);
};
