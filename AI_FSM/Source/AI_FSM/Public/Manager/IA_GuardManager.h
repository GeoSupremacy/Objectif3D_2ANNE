// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "UObject/NoExportTypes.h"
#include "IA_GuardManager.generated.h"


UCLASS(Blueprintable)
class AI_FSM_API UIA_GuardManager : public UObject
{
	GENERATED_BODY()
		UPROPERTY(VisibleAnywhere)
		TMap<FString, class UAI_GuardManagedComponent*> guards = TMap<FString, class UAI_GuardManagedComponent*>();

public:
	
	TArray<class UAI_GuardManagedComponent*> GetGuardInScene() const;
	bool AddGuard(UAI_GuardManagedComponent* _guard);
	bool RemoveGuard(class UAI_GuardManagedComponent* _guard);
	UFUNCTION(BlueprintCallable) void DisableGuard(FString _id);
	UFUNCTION(BlueprintCallable) void EnableGuard(FString _id);
	
};
