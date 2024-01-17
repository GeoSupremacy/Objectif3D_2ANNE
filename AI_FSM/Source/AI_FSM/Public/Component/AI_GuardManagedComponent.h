// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Components/ActorComponent.h"
#include "AI_GuardManagedComponent.generated.h"


UCLASS( ClassGroup=(Custom), meta=(BlueprintSpawnableComponent) )
class AI_FSM_API UAI_GuardManagedComponent : public UActorComponent
{
	GENERATED_BODY()
	UPROPERTY(EditAnywhere, Category = "Manager")
		FString id = "Guard";

	UPROPERTY(VisibleAnywhere, BlueprintReadWrite, Category = "Manager", meta = (EditInline, AllowPrivateAccess))
		bool isManaged = false;
	UPROPERTY(VisibleAnywhere, BlueprintReadWrite, Category = "Manager", meta = (EditInline, AllowPrivateAccess))
		TObjectPtr<class AIA_Guard> managed = nullptr;
	

public:	
	UAI_GuardManagedComponent();
public:
	FORCEINLINE TObjectPtr<class AIA_Guard> GetManaged()const { return managed; }
	FORCEINLINE FString ID() const { return id; }
	UFUNCTION(BlueprintCallable, Category = "Manager") virtual void Enable();
	UFUNCTION(BlueprintCallable, Category = "Manager") virtual void Disable();
	UFUNCTION(BlueprintCallable, Category = "Manager") virtual void RemoveGuard();
public:
	class UIA_GuardManager* GetManager();
	void Init();

		
};
