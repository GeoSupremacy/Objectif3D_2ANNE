// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "GameFramework/SpringArmComponent.h"
#include "Camera/CameraComponent.h"
#include "InputMappingContext.h"

#include "GameFramework/Character.h"
#include "ReworkDiabloCharacter.generated.h"

UCLASS()
class CCC_2023_API AReworkDiabloCharacter : public ACharacter
{
	GENERATED_BODY()
	UPROPERTY(EditAnywhere, Category ="Camera Player")
		TObjectPtr<UCameraComponent> camera = nullptr;
	UPROPERTY(EditAnywhere, Category ="Camera Player")
		TObjectPtr<USpringArmComponent> springArm = nullptr;
	UPROPERTY(EditAnywhere, Category = "Target Player")
		float minRange = 100;
	FVector destination = FVector(0);
	UPROPERTY(EditAnywhere, Category = "Input Player")
		TSoftObjectPtr<UInputMappingContext> context = nullptr;
	UPROPERTY(EditAnywhere, Category = "Input Player")
		TObjectPtr<UInputAction> mouseAction = nullptr;

	UPROPERTY(EditAnywhere, Category = "Diablo/LayerMask")
		TArray<TEnumAsByte<EObjectTypeQuery>> objectLayer = TArray<TEnumAsByte<EObjectTypeQuery>>();
public:
	AReworkDiabloCharacter();
public:
	FORCEINLINE bool HasHitToTarget() const { return FVector::Distance(GetActorLocation(),destination) < minRange; }
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;
private:
	void MoveTo(float delta);
	void DrawDebug();
	void MousePosition();
	void MappingContext();
	void InitInput(UInputComponent* PlayerInputComponent);
	void DefineTarget();
};
