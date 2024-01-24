// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GPE/AI/FindRandomPointInAreaTask.h"
#include "GPE/Component/SightComponent.h"
#include "GameFramework/FloatingPawnMovement.h"

#include "GameFramework/Pawn.h"
#include "Alien.generated.h"

UCLASS()
class GRID_API AAlien : public APawn
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "Skeletal Mesh Component")
		TObjectPtr<USkeletalMeshComponent> skeletal = nullptr;
	UPROPERTY(EditAnywhere, Category = "Floating Pawn Movement")
		TObjectPtr<UFloatingPawnMovement> floatingPawn = nullptr;
	UPROPERTY(EditAnywhere, Category = "Sight Component")
		TObjectPtr<USightComponent> sightComponent = nullptr;
	UPROPERTY(EditAnywhere, Category = "Real Time")
		bool shouldTickIfViewportsOnly = false;
	UPROPERTY(EditAnywhere, Category = "AAlien") TObjectPtr<AActor> Target = nullptr;
	UPROPERTY(EditAnywhere, Category = "AAlien") TObjectPtr<UFindRandomPointInAreaTask> randomPoint = nullptr;
public:
	AAlien();
protected:
	virtual bool ShouldTickIfViewportsOnly() const override;
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;
private:
	void Init();
	void Bind();
	UFUNCTION()void SeeTarget(AActor* _actor);
public:
	void ClearTarget();
	bool Destination();
};
