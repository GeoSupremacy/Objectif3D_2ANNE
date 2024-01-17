// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "PointByWay.h"
#include "Components/BillboardComponent.h"
#include "GameFramework/Actor.h"
#include "WayPoint.generated.h"


UCLASS()
class AI_FSM_API AWayPoint : public AActor
{
	GENERATED_BODY()
private:
		UPROPERTY(EditAnywhere)
		TObjectPtr<UBillboardComponent> icon = nullptr;
	UPROPERTY(EditAnywhere, Category = "PathFinding")
		TArray<APointByWay*> allPoints = {};
	UPROPERTY(VisibleAnywhere, Category = "PathFinding")
		TArray<APointByWay*> currentAllPoints = {};
	UPROPERTY(VisibleAnywhere, Category = "PathFinding")
		TObjectPtr<APointByWay> currentPoint = nullptr;
	UPROPERTY(EditANywhere, Category = "Runtime editor ")
		bool shouldTickIfViewportsOnly = false;
	UPROPERTY(EditANywhere, Category = "Runtime editor ")
		FColor color = FColor::Red;
	bool revers = false;
	int index = 0;
public:
	FORCEINLINE TObjectPtr<APointByWay> GetCurrentPoint() const { return currentPoint; }
	FORCEINLINE void SetCurrentPoint(TObjectPtr<APointByWay> _currentPoint)  {  currentPoint = _currentPoint; }
	FORCEINLINE TArray<APointByWay*> GetCurrentAllPoints() const { return currentAllPoints; }
	FORCEINLINE FColor GetColor() const { return color; }
public:	
	AWayPoint();
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
private:
	void Start();
	virtual bool ShouldTickIfViewportsOnly() const override;
public:
	void DrawDebug();
	void NextWayPoint();
};
