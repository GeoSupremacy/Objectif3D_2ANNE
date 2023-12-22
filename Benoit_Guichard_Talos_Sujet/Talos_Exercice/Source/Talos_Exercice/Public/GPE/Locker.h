// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "GPE/Reflector.h"
#include "GameFramework/Actor.h"
#include "Locker.generated.h"

UCLASS()
class TALOS_EXERCICE_API ALocker : public AActor
{
	GENERATED_BODY()

#pragma region Event
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_TwoParams(FOnRegistre, FString, name, AActor*, position);
	FOnRegistre onRegistre;
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnOpenDoor, bool, _open);
	FOnOpenDoor onOpenDoor;
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnReflector);
	FOnReflector onReflector;
#pragma endregion 

#pragma region Layer
private:
	UPROPERTY(EditAnywhere, Category = "Layer")
		TArray<TEnumAsByte<EObjectTypeQuery>> interactLayer;
#pragma endregion 

#pragma region SETTING
private:
	TObjectPtr<AReflector> reflector = nullptr;
#pragma endregion 

#pragma region Constructeur
public:
	ALocker();
#pragma endregion 

#pragma region Broadcast
public:
	FORCEINLINE FOnOpenDoor& OnOpenDoor() { return onOpenDoor; }
	FORCEINLINE FOnRegistre& OnRegistre() { return onRegistre; }
#pragma endregion 

#pragma region UE_METHOD
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
#pragma endregion 

#pragma region METHOD
private:
	void Bind();
	void Reflection();
	void Registre();
	UFUNCTION() void Remove(AReflector* _reflector);
	UFUNCTION() void Dispersion(class AReflector* _reflector);
#pragma endregion 
};
