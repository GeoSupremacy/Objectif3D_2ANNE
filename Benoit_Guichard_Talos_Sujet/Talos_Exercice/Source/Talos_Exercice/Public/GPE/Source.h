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
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_TwoParams(FOnRegistre, FString, name, AActor*, position);
	FOnRegistre onRegistre;
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnReflector);
	FOnReflector onReflector;
#pragma endregion 

#pragma region Source
private:
	UPROPERTY(EditAnywhere, Category = "Source")
		FLinearColor sourceColor = FLinearColor::Red;
	//affiche le  couleur du rayon
	UPROPERTY(EditAnywhere, Category = "Source")
		FColor color = FColor::Red;


	UPROPERTY(EditAnywhere, Category = "Source")
		TObjectPtr<UStaticMeshComponent> mesh = nullptr;

	TObjectPtr<UMaterialInstanceDynamic> dynamicMaterialColor = nullptr;
	UPROPERTY(EditAnywhere, Category = "Source")
	TArray<TObjectPtr<AReflector>> allReflectionLink = TArray<TObjectPtr<AReflector>>();
#pragma endregion 

#pragma region Layer
private:
	UPROPERTY(EditAnywhere, Category = "Layer")
		TArray<TEnumAsByte<EObjectTypeQuery>> interactLayer;
#pragma endregion 

#pragma region Constructeur
public:
	ASource();
#pragma endregion 

#pragma region Broadcast
public:
	FORCEINLINE FOnRegistre& OnRegistre() { return onRegistre; }
#pragma endregion 

#pragma region Acesseur
public:
	//Couleur de la source
	FColor GetColor() { return color; }
#pragma endregion 

#pragma region UE_METHOD
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
#pragma endregion 

#pragma region METHOD
private:
	void Reflection();
	UFUNCTION() void Remove(AReflector* _reflector);
	UFUNCTION() void Dispersion(class AReflector* _reflector);
	void Registre();
#pragma endregion 

#pragma region INIT
private:
	void InitMaterial();
	void Bind();
#pragma endregion 
};
