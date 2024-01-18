// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "../Public/FSM/FSMObject.h"
#include "../Public/FSM/StateObject.h"
#include "IA/IA_Guard.h"

#include "Components/ActorComponent.h"
#include "FSMComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class AI_FSM_API UFSMComponent : public UActorComponent
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "State Object") TSubclassOf<UFSMObject> currentFSMType = nullptr;
	UPROPERTY(VisibleAnywhere, Category = "State Object", meta =(EditInLine)) TObjectPtr<UFSMObject> runningFSM = nullptr;
	UPROPERTY(EditAnywhere, Category = "State Object", meta = (EditInLine)) TObjectPtr< AActor> owner = nullptr;
	UPROPERTY(EditAnywhere, Category = "State Object") bool desactivateMS = false;
public:	
	UFSMComponent();
public:
	FORCEINLINE bool GetDesactivateMS() const { return desactivateMS; }
	FORCEINLINE TObjectPtr<AActor> GetThisOwner() const { return owner; }
protected:
	virtual void BeginPlay() override;
	virtual void TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction) override;
	virtual void EndPlay(EEndPlayReason::Type _type) override;
	void Init();
	void UpdateFSM();
	void CloseFSM();
};
