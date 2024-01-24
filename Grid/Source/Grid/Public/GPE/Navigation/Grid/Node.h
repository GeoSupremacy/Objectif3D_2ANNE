// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "GameFramework/Actor.h"
#include "Node.generated.h"

UCLASS()
class GRID_API ANodeGrid : public AActor
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "Nodes",meta = (EditInLine)) TObjectPtr<class UGridPointData> grid = nullptr;
	UPROPERTY(EditAnywhere, Category ="Nodes", meta = (EditInLine)) TArray<int> successors = TArray<int>();
	UPROPERTY(VisibleAnywhere, Category = "Nodes", meta = (EditInLine)) TObjectPtr<UStaticMeshComponent> cube = nullptr;
	UPROPERTY(EditAnywhere, Category ="Nodes", meta = (EditInLine)) bool isSelected = false;
public:	
	ANodeGrid();
public:
	FORCEINLINE TObjectPtr<class UGridPointData> GetGrid() const { return grid; }
	FORCEINLINE TArray<int> GetSuccessors() const { return successors; }
	FORCEINLINE bool GetIsSelected() const { return isSelected;}
	FORCEINLINE void SetGrid(TObjectPtr<class UGridPointData> _grid)  {  grid = _grid; }
	FORCEINLINE void SetIsSelected(bool _isSelected)  {  isSelected = _isSelected; }
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
public:
	void AddSuccessor(int _successor);
	void DrawGizmos(FColor _nodeColor, FColor _lineColor);
};
