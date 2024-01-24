// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "SightComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class GRID_API USightComponent : public UActorComponent
{
	GENERATED_BODY()
private:
#pragma region Event 
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnTarget, AActor*, actor);
	FOnTarget onTarget;
#pragma endregion
protected:
	UPROPERTY(EditAnywhere) float heightPosition = 100;
	UPROPERTY(EditAnywhere) int range = 100;
	UPROPERTY(EditAnywhere) int sightAngle = 90;
	UPROPERTY(EditAnywhere) TArray<TEnumAsByte<EObjectTypeQuery>> layers = {};
	UPROPERTY(EditAnywhere) TObjectPtr<AActor> Target = nullptr;
public:
	FORCEINLINE FOnTarget& OnTarget() { return onTarget; }
	FORCEINLINE FVector SightOffstLocation() const { return GetOwner()->GetActorLocation() + FVector(0, 0, heightPosition); }
	FORCEINLINE TObjectPtr<AActor> GetTarget() const { return Target; }
	FORCEINLINE void CleanTarget() { Target = nullptr; }

public:	
	USightComponent();
protected:
	virtual void BeginPlay() override;
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;
	float GetVectorAngle(const FVector& _u, const FVector& _v) const;
	virtual void SightBehaviour();
		
};
