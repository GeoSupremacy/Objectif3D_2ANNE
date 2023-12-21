// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "GPE/Locker.h"

#include "GameFramework/Actor.h"
#include "Door.generated.h"

UCLASS()
class TALOS_EXERCICE_API ADoor : public AActor
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "Locker")
		TObjectPtr<ALocker> looker = nullptr;
	bool hasSource = false;
	FVector finalPosition,
		    oldPosition;

	float speed = 1;
public:	
	ADoor();
public:
	UFUNCTION() void SetHasSource(const bool _asSource) { hasSource = _asSource; }
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
private:
	void Move(float DeltaTime);
	void Init();
	void Down(float DeltaTime);
	void Up(float DeltaTime);
};
