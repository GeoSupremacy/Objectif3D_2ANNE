// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "InteractComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class TALOS_EXERCICE_API UInteractComponent : public UActorComponent
{
	GENERATED_BODY()
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnGrab);
	FOnGrab onGrab;
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnDrop);
	FOnDrop onDrop;
private:
	UPROPERTY(EditAnywhere, Category = "interact")
		TArray<TEnumAsByte<EObjectTypeQuery>> interactLayer;
	UPROPERTY(EditAnywhere, Category = "interact", meta = (UIMin = 0, ClampMin = 0))
		float top;
	UPROPERTY(EditAnywhere, Category = "interact", meta = (UIMin = 0, ClampMin = 0))
		float down;
	UPROPERTY(EditAnywhere, Category = "interact", meta = (UIMin = 0, ClampMin =0 ))
		float range;
	FHitResult result;
	bool canGrabItem = false;

public:
	UInteractComponent();
protected:
	virtual void BeginPlay() override;
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;
public:
	FORCEINLINE FOnGrab& OnGrab()  {return onGrab;}
	FORCEINLINE FOnDrop& OnDrop()  { return onDrop;}
public:
	void Drop();
	void Grab();
private:
	void DetectedObjectFeedback(TObjectPtr<AActor>);
	void DetectedObject();
};
