// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "InputMappingContext.h"

#include "GameFramework/Actor.h"
#include "ViewCamera.generated.h"

UCLASS()
class CCC_2023_API AViewCamera : public AActor
{
	GENERATED_BODY()
		UPROPERTY(EditAnywhere, Category ="Target")
		TObjectPtr<AActor> target = nullptr;
	UPROPERTY(EditAnywhere, Category = "Target")
		float dept = 10;
	UPROPERTY(EditAnywhere, Category = "Target")
	FVector2D scrennLocation = FVector2D(0.5f, 0.5f);


#pragma region Movement
	UPROPERTY(EditAnywhere, Category = "Character Input")
		TSoftObjectPtr<UInputMappingContext> inputContext = nullptr;
	UPROPERTY(EditAnywhere, Category = "Character Input")
		TObjectPtr<UInputAction> mouseClikInput = nullptr;
#pragma endregion Movement
public:
	AViewCamera();
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	void MoveTargetWithMouse();
	void MoveTargetAtViewportLocation();
private:
	void InitInputSystem();
	void MappingContext();
	void Move(const FInputActionValue& _value);
};
