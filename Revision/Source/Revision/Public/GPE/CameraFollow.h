// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "CameraFollow.generated.h"

UCLASS()
class REVISION_API ACameraFollow : public AActor
{
	GENERATED_BODY()
public:	
	ACameraFollow();

protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
private:
	void FollowTargetView();
	void FollowTarget(float _deltatime);
	void DrawCircle(FVector _origin, float _radius, FColor _color, int _definition = 20);
	FVector TurnAround();
	void Init();
};
