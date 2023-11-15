// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/GameModeBase.h"
#include "CustomGameMode.generated.h"

/**
 * 
 */
class UCameraManager;
UCLASS()
class MANAGERARCHI_UNREAL_API ACustomGameMode : public AGameModeBase
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "Manager")
		TSubclassOf<UCameraManager> cameraManagerToCreate = nullptr;
	UPROPERTY(VisibleAnywhere, meta = (EditInLine))
		TObjectPtr<UCameraManager> currentCameraManagerInstance = nullptr;
public:
	FORCEINLINE TObjectPtr<UCameraManager> GetCameraManager() const { return currentCameraManagerInstance; }
private:
	virtual void InitGame(const FString& MapName, const FString& Options, FString& ErrorMessage) override;
};
