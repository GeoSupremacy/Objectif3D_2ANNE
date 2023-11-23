// Fill out your copyright notice in the Description page of Project Settings.

#pragma once
#include"PlayerCollector.h"

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "InteractableObjectComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class CCC_2023_API UInteractableObjectComponent : public UActorComponent
{
	GENERATED_BODY()
		TObjectPtr<APlayerCollector> character = nullptr;
public:	
	UInteractableObjectComponent();
protected:
	virtual void BeginPlay() override;
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;
private:
	void Init();
	UFUNCTION()	void HasInteractableObject();
		
};
