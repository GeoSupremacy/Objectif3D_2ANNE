// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "InteractComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class TALOS_EXERCICE_API UInteractComponent : public UActorComponent
{
	GENERATED_BODY()
#pragma region Event Drop/Grab
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnGrab);
	 FOnGrab onGrab;
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnDrop);
	 FOnDrop onDrop;
#pragma endregion

#pragma region Settings
private:
	UPROPERTY(EditAnywhere, Category = "interact")
		TArray<TEnumAsByte<EObjectTypeQuery>> interactLayer;
	UPROPERTY(EditAnywhere, Category = "interact", meta = (UIMin = 0, ClampMin = 0))
		float top;
	UPROPERTY(EditAnywhere, Category = "interact", meta = (UIMin = 0, ClampMin = 0))
		float down;
	UPROPERTY(EditAnywhere, Category = "interact", meta = (UIMin = 0, ClampMin = 0))
		float range;

	FHitResult result;
	bool canGrabItem = false,
		hasObject = false;
#pragma endregion

#pragma region Constructor
public:
	UInteractComponent();
#pragma endregion

#pragma region Broadcast
public:
	FORCEINLINE  FOnGrab& OnGrab() { return onGrab; }
	FORCEINLINE  FOnDrop& OnDrop() { return onDrop; }
#pragma endregion

#pragma region UE_METHOD
private:
	virtual void BeginPlay() override;
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;
#pragma endregion

#pragma region Grab/Drop
public:
	void Drop();
	void Grab();
#pragma endregion

#pragma region DETECTED
private:
	void DetectedObject();
	void DrawDebug(bool _hit, FVector _origin, FVector _end);
#pragma endregion
};
