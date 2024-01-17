// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"


#include "WayPoint.h"
#include "Component/SphereSightComponent.h"
#include "Component/AI_GuardManagedComponent.h"

#include "GameFramework/Character.h"
#include "IA_Guard.generated.h"

UCLASS()
class AI_FSM_API AIA_Guard : public ACharacter
{
	GENERATED_BODY()

#pragma region Settings
private:
	
	UPROPERTY(EditAnywhere, Category = "PathFinding")
		TObjectPtr<AWayPoint> wayPoint = nullptr;
	UPROPERTY(VisibleAnywhere, Category = "PathFinding")
		TObjectPtr<class APlayableCharacter > currentTarget= nullptr;
	UPROPERTY(EditAnywhere, Category = "PathFinding")
	bool canChangePatrol = false;
	
	bool hasDestination = false,
		 hasTarget = false,
		 move = false;

	UPROPERTY(EditANywhere, Category = "Runtime editor ")
		bool shouldTickIfViewportsOnly = false;

#pragma endregion

#pragma region Component
	UPROPERTY(EditAnywhere, Category = "FSM")
		TObjectPtr<USphereSightComponent> sphereSightComponent = nullptr;
	UPROPERTY(EditAnywhere, Category = "FSM")
		TObjectPtr<UFSMComponent> fsmComponent = nullptr;
	UPROPERTY(EditAnywhere, Category = "FSM")
		TObjectPtr<UAI_GuardManagedComponent> guardManagedComponent = nullptr;
#pragma endregion

#pragma region Constructor
public:
	AIA_Guard();
#pragma endregion

#pragma region Acesseur
public:
	FORCEINLINE TObjectPtr<AWayPoint> GetCurrentWayPoint() const { return wayPoint; }
	FORCEINLINE void SetMove(const bool& _move) { move = _move; }
	FORCEINLINE bool GetMove()const { return move; }
	FORCEINLINE void SetHasDestination(const bool& _hasDestination) { hasDestination = _hasDestination; }
	FORCEINLINE bool GetHasDestination()const { return hasDestination; }
	FORCEINLINE void SetHasTarget(const bool& _hasTarget) { hasTarget = _hasTarget; }
	FORCEINLINE bool GetHasTarget()const { return hasTarget; }
	FORCEINLINE bool GetCanChangePatrol()const { return canChangePatrol; }
#pragma endregion

#pragma region UE_METHOD
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual bool ShouldTickIfViewportsOnly() const override;
#pragma endregion

#pragma region METHOD
public:
	void Look();
	void ClearTarget();
	void DefineNewPatrol();
private:
	void Init();
	void Start();
	void Patrol();
	void SeeTarget();
	void DrawDebug();
	void Destination();
#pragma endregion


};
