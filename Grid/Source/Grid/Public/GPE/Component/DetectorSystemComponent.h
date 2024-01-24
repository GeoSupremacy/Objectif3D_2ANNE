// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "DetectorSystemComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class GRID_API UDetectorSystemComponent : public UActorComponent
{
	GENERATED_BODY()
		DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnTargetFound, AActor*, _target);
	FOnTargetFound onTargetFound;
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnTargetDetected, bool, targetDetected);
	FOnTargetDetected onTargetDetected;
		UPROPERTY(EditAnywhere)
		TArray<TEnumAsByte<EObjectTypeQuery>> layer;
	UPROPERTY(EditAnywhere)
		float detectedRange = 1000;
	UPROPERTY(EditAnywhere)
		TObjectPtr<AActor> target = nullptr;
	UPROPERTY(EditAnywhere)
		bool targetDetected = false;
public:	
	UDetectorSystemComponent();
	FORCEINLINE FOnTargetFound& OnTargetFond() { return onTargetFound; }
	FORCEINLINE FOnTargetDetected& OnTargetDetected() { return onTargetDetected; }
protected:
	virtual void BeginPlay() override;
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;
	void Detection();
	void Debug();
};
