// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "LinetraceTesteur.generated.h"

UCLASS()
class CCC_2023_API ALinetraceTesteur : public AActor
{
	GENERATED_BODY()
	UPROPERTY(EditAnywhere, Category = "LayerMask")
		TArray<TEnumAsByte<EObjectTypeQuery>> objectLayer = TArray<TEnumAsByte<EObjectTypeQuery>>();
	UPROPERTY(EditAnywhere, Category = "LayerMask", meta = (UMIN = 10))
		float range = 2;
	UPROPERTY(EditAnywhere, Category = "LayerMask", meta = (UMIN = 1))
		int shotNumber = 2;

	int currentShot = 0;
	TArray<FVector> ImpactPoint;
	const float unity =100;

	FVector currentImpactPoint = FVector(0,0,0);
	FVector newImpactPoint = FVector(0, 0, 0);
	FHitResult _default;
public:	
	ALinetraceTesteur();

protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
private:
	void DetectObject();
	void DebugLog(float _f, FVector _FV);
	void Line(FHitResult _result);
	void NewLine(FHitResult _result);
	void ZoyaBounce();
	FVector Reflect(FVector _direction, FVector _normal) { return _direction - 2 * _direction.Dot(_normal) * _normal;}

};
