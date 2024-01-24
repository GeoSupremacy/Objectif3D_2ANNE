// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GPE/Component/DetectorSystemComponent.h"
#include "GPE/AI/Custom_AIController.h"

#include "GameFramework/Pawn.h"
#include "Enemy.generated.h"


class UAttackSystemComponent;
UCLASS()
class GRID_API AEnemy : public APawn
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "Skeletal Mesh Component")
		TObjectPtr<USkeletalMeshComponent> skeleton = nullptr;
	UPROPERTY(EditAnywhere, Category = "AI")
		TObjectPtr<ACustom_AIController> aiController = nullptr;
	UPROPERTY(EditAnywhere, Category = "Attack")
		TObjectPtr<UAttackSystemComponent> attack = nullptr;
	UPROPERTY(EditAnywhere, Category = "detection") TObjectPtr<UDetectorSystemComponent> detection = nullptr;

public:
	FORCEINLINE TObjectPtr<ACustom_AIController> GetAIController() const { return aiController; }
	FORCEINLINE TObjectPtr<UDetectorSystemComponent> GetDetection() const { return detection; }
	FORCEINLINE TObjectPtr<UAttackSystemComponent> GetAttack() const { return attack; }
public:
	AEnemy();
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;
private:
	void Init();
};
