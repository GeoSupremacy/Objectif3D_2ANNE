// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include <iostream>
#include "CameraSettings.h"


#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "CameraMovement.generated.h"

using namespace std;

USTRUCT()
struct FSettings
{
	GENERATED_BODY()
public:
		OffsetType offsetType = OffsetType();
		MovementType movementType =  MovementType();
};

UCLASS()
 class CAMERAFOLLOW_API ACameraMovement : public AActor
{
	GENERATED_BODY()


protected:
	UPROPERTY(Editanywhere, Category = "Settings")
		TObjectPtr<AActor> target = nullptr;

	UPROPERTY(Editanywhere, Category = "Settings")
		TObjectPtr <UCameraSettings> CameraSettings = nullptr;
	UPROPERTY(Editanywhere, Category = "Settings")
	FSettings settings;
	FVector3d ancientLocation;
public:	
	ACameraMovement();
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
protected:
	virtual void UpdateCameraPosition(){ }
	FVector3d GetLocalOffset(const float _x, const float _y, const float _z)
	{
		return FVector3d(target->GetActorLocation().X * _x, target->GetActorLocation().Y * _y, target->GetActorLocation().Z * _z);
	}
public:
	bool IsValid() { if (target) return true; return false; }
	FSettings Settings() { return settings; };
	virtual FVector3d GetTargetPosition() const 
	{
		if (!target)
			throw  string("Not Target, retun nullptr");
		return target->GetActorLocation();
	}
	virtual FVector3d GetFinaltPosition() { return GetTargetPosition() + Offset(); }
	virtual FVector3d Offset() {  return FVector3d(0); }
	virtual void DrawDebug();
};
