// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "AttackSystemComponent.generated.h"


UCLASS(ClassGroup = (Custom), meta = (BlueprintSpawnableComponent))
class GRID_API UAttackSystemComponent : public UActorComponent
{
	GENERATED_BODY()
		DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnRangeUpdate, bool, _value);
	FOnRangeUpdate onRangeUpdate;
	UPROPERTY(EditAnywhere)
		float attackRange = 50;
	UPROPERTY(EditAnywhere)
		float currentTime = 0;
	UPROPERTY(EditAnywhere)
		float maxTime = 1.5f;
	UPROPERTY(EditAnywhere)
		float attackSpeed = 1;
	UPROPERTY(EditAnywhere)
		float attackBoxSize = 25;
	UPROPERTY(EditAnywhere)
		TObjectPtr<AActor> target = nullptr;
	UPROPERTY(EditAnywhere)
		bool canAttack= true;
	UPROPERTY(EditAnywhere)
		bool isInRange = true;
	UPROPERTY(EditAnywhere)
		float boxOffset =20.f;
	UPROPERTY(EditAnywhere)
		TArray<TEnumAsByte<EObjectTypeQuery>>layer;
public:
	FORCEINLINE FOnRangeUpdate& OnRangeUpdate() {return onRangeUpdate;}
public:	
	UAttackSystemComponent();
protected:
	virtual void BeginPlay() override;
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;
private:
	float UpdateTime( float _current, const float& _max);
	bool CheckIsInRange(const float& _range);
public:
	UFUNCTION(BlueprintCallable) void Attack();
	UFUNCTION() void SetTarget(AActor* _target);
};
