// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include <Components/SplineComponent.h>
#include "GameFramework/Actor.h"
#include "PathActor.generated.h"


USTRUCT()
struct FLine
{
	GENERATED_BODY()
public:
		FVector Point, End;
		FORCEINLINE FVector GetDirection() const {return (End - Point).GetSafeNormal();}
		FORCEINLINE void DrawLine(UWorld* _world, const FColor& _color)  
		{  
			DrawDebugLine(_world, Point, End, _color,false, 0, -1, 3);
		}
};

UCLASS()
class AI_FSM_API APathActor : public AActor
{
	GENERATED_BODY()

private:
	UPROPERTY(EditAnywhere, Category ="Path") TObjectPtr<USplineComponent>  spline = nullptr;
	UPROPERTY(EditAnywhere, Category ="Path") TObjectPtr<AActor>  target = nullptr;
	FVector intersecPoint;
	FLine LineA, LineB;
public:	
	APathActor();
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	void InitSplineLine();
	void GetIntersectionPoint(FLine _a, FLine _b, FVector& _intersecPoint);
	void SetSecondLinePoint();
	FVector GetSplinePoint() const ;
};
