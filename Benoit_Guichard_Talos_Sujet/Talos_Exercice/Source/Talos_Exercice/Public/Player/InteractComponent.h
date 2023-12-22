// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "InteractComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class TALOS_EXERCICE_API UInteractComponent : public UActorComponent
{
	GENERATED_BODY()

#pragma region Event UI
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnInteracUI, bool, canInteract);
	FOnInteracUI onInteracUI;
#pragma endregion

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
	UPROPERTY(EditAnywhere, Category = "interact")
		float top;
	UPROPERTY(EditAnywhere, Category = "interact")
		float down;
	UPROPERTY(EditAnywhere, Category = "interact")
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
	FORCEINLINE FOnInteracUI& OnInteracUI() { return onInteracUI; }
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
	void FlagInteract(bool _flag);
#pragma endregion
};
