// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GPE/Component/DetectorSystemComponent.h"
#include "GPE/Alien/Alien.h"

#include "AIController.h"
#include "Custom_AIController.generated.h"

/**
 * 
 */
UCLASS()
class GRID_API ACustom_AIController : public AAIController
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere)
		TObjectPtr<UBehaviorTree> tree = nullptr;
		TObjectPtr<APawn> controlledPawn = nullptr;
		UPROPERTY(EditAnywhere)
			FBlackboardKeySelector key;
		UPROPERTY(EditAnywhere)
			FName patrolLockKeyName ="patrolLocation";
		UPROPERTY(EditAnywhere)
			TObjectPtr<UDetectorSystemComponent> detectedSystem = nullptr;
		UPROPERTY(EditAnywhere)
			FName keyTarget = "target";
		UPROPERTY(EditAnywhere)
			FName keyDetected = "targetDetected";
		UPROPERTY(EditAnywhere)
			FName keyIsinRange = "isInRange";
public:
	ACustom_AIController();
public:
	FORCEINLINE FName GetKeyTarget() const { return keyTarget; }
	FORCEINLINE FName GetKeyDetected() const { return keyDetected; }
	FORCEINLINE FName GetKeyIsinRange() const { return keyIsinRange; }
	FORCEINLINE TObjectPtr<APawn> GetControlledPawn() const { return controlledPawn; }
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float _time) override;
	void Init();
	void Debug();
public:
	UFUNCTION() void ReceiveTargetDetected(bool _targetDetected);
	UFUNCTION() void ReceiveIsInRange(bool _value);
	UFUNCTION() void ReceiveTarget(AActor* _target);
};
