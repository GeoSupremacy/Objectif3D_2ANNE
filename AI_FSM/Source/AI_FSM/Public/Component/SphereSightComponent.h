// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Component/SightSystemComponent.h"
#include "SphereSightComponent.generated.h"


UCLASS(ClassGroup = (Custom), meta = (BlueprintSpawnableComponent))
class AI_FSM_API USphereSightComponent : public USightSystemComponent
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere) TArray<TEnumAsByte<EObjectTypeQuery>> masklayers = {};
public:
	USphereSightComponent();
protected:

	virtual void SightBehaviour() override;
	float GetVectorAngle(const FVector& _u, const FVector& _v) const;
	void DrawCircle(const FVector& position, const float& radius, const int _definition =20);
};
