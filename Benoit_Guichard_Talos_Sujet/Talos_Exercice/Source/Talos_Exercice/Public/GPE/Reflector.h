// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "Player/PlayableCharacter.h"

#include "GameFramework/Actor.h"
#include "Reflector.generated.h"

UCLASS()
class TALOS_EXERCICE_API AReflector : public AActor
{
	GENERATED_BODY()

#pragma region Event
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnCanInteract, bool , _link);
	FOnCanInteract onCanInteract;
#pragma endregion

#pragma region Settings
private:
	UPROPERTY(EditAnywhere, Category = "Position Target")
		FVector reflectPosition;

	UPROPERTY(EditANywhere, Category = "Runtime editor ")
		bool shouldTickIfViewportsOnly = false;
	FVector  targetPosition, direction;
	bool interact = false,
		  isAttach =false,
		  isDetected =false,
		takeIt =false;
	UPROPERTY(EditAnywhere, Category = "interact")
		TArray<TEnumAsByte<EObjectTypeQuery>> raySourceLayer;
	FHitResult result;
	TObjectPtr<APlayableCharacter> character = nullptr;
	TArray<AActor*> allLink;
#pragma endregion

#pragma region Constructor
public:
	AReflector();
#pragma endregion

#pragma region Broadcast
public:
	FOnCanInteract& OnCanInteract() { return onCanInteract; }
#pragma endregion


public:
	FORCEINLINE void SetTake(bool _takeIt) { takeIt = _takeIt; }
	FORCEINLINE FVector FinalPosition() { return GetActorLocation() + reflectPosition; }
	FORCEINLINE void SetIsAttach(bool _isAttach) { isAttach = _isAttach; }
#pragma region UE_METHOD
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual bool ShouldTickIfViewportsOnly() const override;
#pragma endregion

#pragma region METHOD
public:
	UFUNCTION() void DetectedSource(bool _interact =false);
	 void Target();
	 UFUNCTION() void InteractTaken(bool _take) { interact = _take; }
	void Reflect(AReflector _other);
	void Transmit(AReflector _other);
	void DrawDebug();
	void AllReflect();
	bool CheckAll();
#pragma endregion

#pragma region INIT
private:
	void Bind();
#pragma endregion

};
