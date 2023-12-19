// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Source.generated.h"

UCLASS()
class TALOS_EXERCICE_API ASource : public AActor
{
	GENERATED_BODY()
	
	UPROPERTY(EditAnywhere, Category = "Source")
		FLinearColor sourceColor = FLinearColor::Red;
	UPROPERTY(EditAnywhere, Category = "Source")
		FColor color = FColor::Red;
	UPROPERTY(EditAnywhere, Category = "Source")
		TObjectPtr<UStaticMeshComponent> mesh = nullptr;
	TObjectPtr<UMaterialInstanceDynamic> dynamicMaterialColor = nullptr;
public:	
	ASource();
protected:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	void InitMaterial();
};
