// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "InteractItem.h"
#include "InputMappingContext.h"

#include "Components/ActorComponent.h"
#include "InteractComponentCorrection.generated.h"
 

UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class CCC_2023_API UInteractComponentCorrection : public UActorComponent
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category ="Interact Layer")
		TArray<TEnumAsByte<EObjectTypeQuery>> interactLayer;
	UPROPERTY(EditAnywhere, Category = "Interact Layer", meta = (UIMin =0, ClampMin =0) ) float range = 300;
	UPROPERTY(EditAnywhere, Category = "Interact Layer", meta = (UIMin = 0, ClampMin = 0)) float height = 50;
	UPROPERTY(EditAnywhere, Category = "Interact Layer", meta = (UIMin = 0, ClampMin = 0)) float fall = 200;
	UPROPERTY(EditAnywhere, Category = "Interact Layer") TObjectPtr<AInteractItem> currentItem  = nullptr;
	UPROPERTY(EditAnywhere, Category = "Interact Layer") TObjectPtr<AInteractItem> detectedItem = nullptr;
	FHitResult result;
	bool canGrabItem = false;
public:	
	UInteractComponentCorrection();
protected:
	virtual void BeginPlay() override;
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;
	void DetectedObject();
	void DetectedObjectFeedback(TObjectPtr<AActor> _item);
public:
	void GrabObject(const FInputActionValue& _value);
	void DropObject(const FInputActionValue& _value);
};
