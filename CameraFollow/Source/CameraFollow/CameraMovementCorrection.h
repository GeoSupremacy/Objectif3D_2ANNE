// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Camera/CameraActor.h"
#include "CameraMovementCorrection.generated.h"

/**
 * 
 */
UCLASS(ABSTRACT)
class CAMERAFOLLOW_API ACameraMovementCorrection : public ACameraActor
{
	GENERATED_BODY()
protected:
		UPROPERTY(Editanywhere, Category = "Settings")
		TObjectPtr<AActor> target = nullptr;
#pragma region Debug
protected:
	UPROPERTY(Editanywhere, Category = "Debug")
		bool useDebug = true;
	UPROPERTY(Editanywhere, Category = "Debug")
		FColor validDebugColor = FColor::Green;
	UPROPERTY(Editanywhere, Category = "Debug")
		FColor novalidDebugColor = FColor::Red;
#pragma endregion Debug

#pragma region Propertie
public:
	ACameraMovementCorrection();
	FORCEINLINE bool IsValid() const {
		return (target != nullptr);
		
	}
	FORCEINLINE FVector CurrentPosition() const {
		return GetActorLocation();
	}
	FORCEINLINE  virtual FVector TargetPosition() const {
		if (IsValid()) return target->GetActorLocation();
		return FVector(0);
	}
	FORCEINLINE virtual  FVector FinalPosition() const {
		return TargetPosition() + Offset();
	}
	FORCEINLINE virtual  FVector Offset() const {
		return FVector(0);
	}
#pragma endregion Propertie
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float _delataime) override;
	virtual void UpdateCameraPosition();
	virtual bool ShouldTickIfViewportsOnly() const override;
	virtual void DrawDebug();
	FORCEINLINE FVector GetLocalOffset(const float& _x, const float& _y, const float& _z) const
	{
		return FVector((target->GetActorLocation().X * _x),
				(target->GetActorLocation().Y * _y),
				(target->GetActorLocation().Z * _z));
	}
	//UPROPERTY(Editanywhere, Category = "Settings")
	//	TObjectPtr <UCameraSettings> CameraSettings = nullptr;
	//UPROPERTY(Editanywhere, Category = "Settings")
	//	FSettings settings;
};

