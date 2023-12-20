// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "GPE/Reflector.h"

#include "GameFramework/Actor.h"
#include "Source.generated.h"

UCLASS()
class TALOS_EXERCICE_API ASource : public AActor
{
	GENERATED_BODY()
	
#pragma region Event
public:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnReflector);
	FOnReflector onReflector;
#pragma endregion 

#pragma region Source
private:
	UPROPERTY(EditAnywhere, Category = "Source")
		FLinearColor sourceColor = FLinearColor::Red;
	UPROPERTY(EditAnywhere, Category = "Source")
		FColor color = FColor::Red;
	UPROPERTY(EditAnywhere, Category = "Source")
		TObjectPtr<UStaticMeshComponent> mesh = nullptr;
	TObjectPtr<UMaterialInstanceDynamic> dynamicMaterialColor = nullptr;
#pragma endregion 

#pragma region Layer
private:
	UPROPERTY(EditAnywhere, Category = "Layer")
		TArray<TEnumAsByte<EObjectTypeQuery>> interactLayer;
#pragma endregion 
private:
	UPROPERTY(EditAnywhere, Category = "Source")
	TArray<TObjectPtr<AReflector>> allReflectionLink = TArray<TObjectPtr<AReflector>>();
public:	
	ASource();
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
private:
	void Reflection();
	UFUNCTION() void Remove(AReflector* _reflector);
	UFUNCTION() void Dispersion(class AReflector* _reflector);
private:
	void InitMaterial();
	void Bind();
};
