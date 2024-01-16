// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Component/SightSystemComponent.h"
#include "SphereSightComponent.generated.h"


UCLASS(Abstract, Blueprintable)
class AI_FSM_API USphereSightComponent : public USightSystemComponent
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "State Object") TSubclassOf<UFSMObject> currentFSMType = nullptr;
public:
	USphereSightComponent();
protected:
	virtual void BeginPlay() override;
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;
	virtual void SightBehaviour() override;
	float GetVectorAngle(const FVector& _u, const FVector& _v) const;
	void DrawCircle(const FVector& position, const float& radius, const int _definition =20);
};
