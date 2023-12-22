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

#pragma region Settings
private:
	UPROPERTY(EditAnywhere, Category = "Locker")
		TObjectPtr<ALocker> looker = nullptr;
	bool hasSource = false;
	FVector finalPosition,
		    oldPosition;
	UPROPERTY(EditAnywhere, Category = "Locker")
		float speed = 100;
#pragma endregion 

#pragma region Constructeur
public:
	ADoor();
#pragma endregion 

#pragma region Broadcast
public:
	UFUNCTION() void SetHasSource(const bool _asSource) { hasSource = _asSource; }
#pragma endregion 

#pragma region UE_METHOD
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
#pragma endregion 

#pragma region METHOD
private:
	void Move(float DeltaTime);
	void Down(float DeltaTime);
	void Up(float DeltaTime);
#pragma endregion 

#pragma region INIT
private:
	void Init();
#pragma endregion 
};
