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
	UPROPERTY(EditAnywhere) int brancheID = 0;
	UPROPERTY(EditAnywhere) int childrenNumberCapacity =8;
	UPROPERTY(EditAnywhere) int capacity =0;
};



class AOctree;
UCLASS()
class GRID_API AOctreeCell : public AActor
{
	GENERATED_BODY()
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnNumberOfActorInsideUpdate, int, _numberOfActorInside);
	UPROPERTY(BlueprintCallable, BlueprintAssignable) FOnNumberOfActorInsideUpdate onNumberOfActorInsideUpdate;
private:
	UPROPERTY(EditAnywhere, Category= "AOctreeCell|Internals") TObjectPtr<AOctree> octree = nullptr;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Internals") TObjectPtr<AOctreeCell> parent = nullptr;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Internals") TArray<AOctreeCell*> cellChildren;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Internals") TObjectPtr<UBoxComponent> box = nullptr;
	int brancheID;

	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Internals")  FOctreeCellParameter cellParameters = FOctreeCellParameter();
	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Internals") bool isActive= true;


	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Parameter") TArray<TSubclassOf<AActor>> classToDetect;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Parameter") TArray<AActor*> actorInside;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Parameter")  int currentActorInside =0;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Parameter")  int currentNumberOfChildren = 0;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Parameter")  bool shouldTickIfViewportsOnly = false;

	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Debug") bool useDebug = false;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Debug") bool debugArea = false;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Debug", meta =(EditorCondition ="useDebug", EditConditionHides)) 
		int debugTickNess = 0;
	UPROPERTY(EditAnywhere, Category = "AOctreeCell|Debug", meta = (EditorCondition = "useDebug", EditConditionHides)) 
		FColor debugcolor = FColor::Yellow;
public:	
	AOctreeCell();
public:
	FORCEINLINE FOnNumberOfActorInsideUpdate& OnNumberOfActorInsideUpdate() { return onNumberOfActorInsideUpdate; }
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual bool ShouldTickIfViewportsOnly() const override;
	virtual void NotifyActorBeginOverlap(AActor* OtherActor) override;
	virtual void NotifyActorEndOverlap(AActor* OtherActor) override;
	void InitSubCell(const int _branchID, AOctree* _octree, AOctreeCell* _parent);
	void SubDivideCells(const FVector _subLoction);
	void RemoveCells();
	UFUNCTION() void ManageCellBehaviour(const int _numberOfActorInside);
	FVector GetSubLocation(const int _index);
	void DrawDebug();
public:
	void SetCellDimensions(const double _lenght, const double _with, const double _height);
	void SetCellDimensions(const FVector _FVector);
	void CustomDestroy();
	void SetOctree(AOctree* _this);
};
