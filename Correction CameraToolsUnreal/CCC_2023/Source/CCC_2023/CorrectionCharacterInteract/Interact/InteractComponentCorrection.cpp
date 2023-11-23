// Fill out your copyright notice in the Description page of Project Settings.


#include "InteractComponentCorrection.h"
#include "Kismet/KismetSystemLibrary.h"
#include "../Source/CCC_2023/DebugUtils.h"


UInteractComponentCorrection::UInteractComponentCorrection()
{
	
	PrimaryComponentTick.bCanEverTick = true;

	
}
void UInteractComponentCorrection::BeginPlay()
{
	Super::BeginPlay();
	SetComponentTickInterval(1);
	
}
void UInteractComponentCorrection::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);

	DetectedObject();
}





void UInteractComponentCorrection::DetectedObject()
{
	
	FVector _start = GetOwner()->GetActorLocation() + FVector(0, 0, height) + GetOwner()->GetActorForwardVector() *10,
		_to = _start + (GetOwner()->GetActorForwardVector() - FVector(0, 0, fall)) +GetOwner()->GetActorForwardVector() * range;

	bool _isHit =UKismetSystemLibrary::LineTraceSingleForObjects(GetWorld(), _start, _to, interactLayer, true, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, result, false, FLinearColor::Red, FLinearColor::Green, 5);

	canGrabItem = _isHit && result.Distance < 100;
	DetectedObjectFeedback(result.GetActor());
}
void UInteractComponentCorrection::DetectedObjectFeedback(TObjectPtr<AActor> _item)
{
	
	if (canGrabItem)
	{
		
		if (detectedItem)
			detectedItem->ResetDefaultColor();
		detectedItem = Cast<AInteractItem>(_item);
		detectedItem->ApplyInteractColor();
	}
	else
	{
		detectedItem->ResetDefaultColor();
	}
}
void UInteractComponentCorrection::GrabObject(const FInputActionValue& _value)
{
	if (currentItem)
		return;
	if (canGrabItem)
	{
		PRINT_STRING("GRAB");
		currentItem = Cast <AInteractItem>(result.GetActor());
		currentItem->ApplyInteractColor();
		currentItem->SetActorEnableCollision(false);
		currentItem->AttachToActor(GetOwner(), FAttachmentTransformRules::KeepWorldTransform);
		detectedItem = Cast<AInteractItem>(result.GetActor());
		detectedItem->ApplyInteractColor();
	}
}
void UInteractComponentCorrection::DropObject(const FInputActionValue& _value)
{
	if (currentItem)
		return;
	currentItem->DetachFromActor(FDetachmentTransformRules::KeepWorldTransform);
	currentItem->SetActorEnableCollision(true);
	currentItem->ResetDefaultColor();
	currentItem = nullptr;
}

