// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"

#include "Player/PlayableCharacter.h"

#include "GameFramework/Actor.h"
#include "Reflector.generated.h"

UCLASS()
class TALOS_EXERCICE_API AReflector : public AActor
{
	GENERATED_BODY()

#pragma region Event
private:
	DECLARE_DYNAMIC_MULTICAST_DELEGATE(FOnCanInteract);
	FOnCanInteract onCanInteract;

	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnLinkSource, AReflector*, _this);
	FOnLinkSource onLinkSource;

#pragma endregion

#pragma region Settings
private:
	UPROPERTY(EditAnywhere, Category = "Position Target")
		FVector reflectPosition;

	UPROPERTY(EditANywhere, Category = "Runtime editor ")
		bool shouldTickIfViewportsOnly = false;

	bool 
		 isAttach =false,
		 isDetected =false,
		 takeIt =false,
		 asContact =false;
	UPROPERTY(EditAnywhere, Category = "interact")
		TArray<TEnumAsByte<EObjectTypeQuery>> raySourceLayer;
	UPROPERTY(EditAnywhere, Category = "interact")
		TObjectPtr<AActor>actor = nullptr;
	FHitResult result;
	TObjectPtr<APlayableCharacter> character = nullptr;

	UPROPERTY(EditAnywhere, Category = "interact")
	TArray<TObjectPtr<AReflector>> allLinkReflector;

	 
#pragma endregion

#pragma region Constructor
public:
	AReflector();
#pragma endregion

#pragma region Broadcast
public:
	FORCEINLINE FOnCanInteract& OnCanInteract() { return onCanInteract; }
	FORCEINLINE FOnLinkSource& OnLinkSource() { return onLinkSource; }
#pragma endregion

#pragma region Acesseur
public:
	FORCEINLINE void SetTake(bool _takeIt) { takeIt = _takeIt; }
	FORCEINLINE FVector FinalPosition() { return GetActorLocation() + reflectPosition; }
	FORCEINLINE void SetIsAttach(bool _isAttach) { isAttach = _isAttach; }
	FORCEINLINE void SetContact(bool _asContact) { asContact = _asContact; }
	FORCEINLINE bool GetContact() const{ return  asContact; }
#pragma endregion

#pragma region UE_METHOD
private:
	virtual void BeginPlay() override;
	virtual void Tick(float DeltaTime) override;
	virtual bool ShouldTickIfViewportsOnly() const override;
#pragma endregion

#pragma region METHOD
public:
	FORCEINLINE void RemoveLink() { allLinkReflector.Empty(); }
	UFUNCTION() void LinkSource();
	UFUNCTION() void LinkReflector();
private:
	bool CheckReflector(AReflector* _reflector);
	void Target();
	void AllReflect();
#pragma endregion

#pragma region DRAW
private:
	void DrawDebug();
#pragma endregion

#pragma region INIT
private:
	void Bind();
#pragma endregion

};
