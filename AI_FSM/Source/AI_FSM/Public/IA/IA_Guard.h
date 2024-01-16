// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"


#include "WayPoint.h"

#include "../Component/SphereSightComponent.h"
#include "GameFramework/Character.h"
#include "IA_Guard.generated.h"

UCLASS()
class AI_FSM_API AIA_Guard : public ACharacter
{
	GENERATED_BODY()

#pragma region Settings
private:
	UPROPERTY(EditAnywhere, Category="PathFinding")
	TArray<AWayPoint*> checkPoints = {};
	UPROPERTY(VisibleAnywhere, Category = "PathFinding")
		TObjectPtr<AWayPoint> currentWayPoint = nullptr;


	int index = 0;
	bool revers = false,
		hasDestination = false,
		 move = false;

	UPROPERTY(EditANywhere, Category = "Runtime editor ")
		bool shouldTickIfViewportsOnly = false;
#pragma endregion

#pragma region Component
	TObjectPtr<USightSystemComponent> sphereSightComponent = nullptr;
	UPROPERTY(EditAnywhere, Category = "FSM")
		TObjectPtr<UFSMComponent> fsmComponent = nullptr;
#pragma endregion


public:
	AIA_Guard();
public:
	FORCEINLINE void SetMove(const bool& _move) { move = _move; }
	FORCEINLINE bool GetMove()const { return move; }
	FORCEINLINE void SetHasDestination(const bool& _hasDestination) { hasDestination = _hasDestination; }
	FORCEINLINE bool GetHasDestination()const { return hasDestination; }
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual bool ShouldTickIfViewportsOnly() const override;
private:
	void Init();
	void Start();
	void Patrol();
	void Look();
	void NextWayPoint();
	void DrawDebug();
};
