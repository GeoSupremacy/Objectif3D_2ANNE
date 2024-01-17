// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "SightSystemComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class AI_FSM_API USightSystemComponent : public UActorComponent
{
	GENERATED_BODY()
protected:
		UPROPERTY(EditAnywhere) float heightPosition = 100;
		UPROPERTY(EditAnywhere) int range = 100;
		UPROPERTY(EditAnywhere) int sightAngle = 90;
		UPROPERTY(EditAnywhere) TArray<TEnumAsByte<EObjectTypeQuery>> layers = {};
		UPROPERTY(EditAnywhere) TObjectPtr<AActor> Target = nullptr;
public:
	FORCEINLINE FVector SightOffstLocation() const {return GetOwner()->GetActorLocation() + FVector(0, 0, heightPosition);}
	FORCEINLINE TObjectPtr<AActor> GetTarget() const { return Target; }
	FORCEINLINE void CleanTarget() {  Target = nullptr; }
public:	
	USightSystemComponent();
protected:
	virtual void BeginPlay() override;
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;	
	virtual void SightBehaviour();
};
