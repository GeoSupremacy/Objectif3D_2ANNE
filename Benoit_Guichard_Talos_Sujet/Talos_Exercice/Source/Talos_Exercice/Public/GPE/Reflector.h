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
	DECLARE_DYNAMIC_MULTICAST_DELEGATE_OneParam(FOnLinkLocker, AReflector*, _this);
	FOnLinkLocker onLinkLocker;
#pragma endregion



#pragma region Settings
private:
	//La position des reflets des r�flecteurs
	UPROPERTY(EditAnywhere, Category = "Position Target")
		FVector reflectPosition;

	UPROPERTY(EditANywhere, Category = "Runtime editor ")
		bool shouldTickIfViewportsOnly = false;


		//Si le r�flecteur pris par le joueur d�tecte quelquechose
	bool isDetected =false,
		//Si le r�flecteur  est pris par le joueur
		 takeIt =false,
		//Si le r�flecteur  a un contact avec la source ou avec un autre r�flecteur li� � la source
		 asContact =false;
	

	//Sert pour la d�tection quand le joueur veut link
	UPROPERTY(EditAnywhere, Category = "interact")
	TArray<TEnumAsByte<EObjectTypeQuery>> raySourceLayer;
	

	//Le 1er pour li� les r�flecteurs avec d'autre, la source ou le locker
	// Le 2�me tous les r�flecteurs li� � celui-ci
	FHitResult resultTarget, resultByEachLink;


	//On a besoin de o� regard le joueur quand il prend un r�flecteur
	TObjectPtr<APlayableCharacter> character = nullptr;

	// Tous les r�flecteurs li� � celui-ci
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
	FORCEINLINE FOnLinkLocker& OnLinkLocker() { return onLinkLocker; }
#pragma endregion

#pragma region Acesseur
public:
	FORCEINLINE void SetTake(bool _takeIt) { takeIt = _takeIt; }
	FORCEINLINE FVector FinalPosition() { return GetActorLocation() + reflectPosition; }
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
	UFUNCTION() void LinkLocker();
private:

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
