// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"


#include "GameFramework/GameModeBase.h"
#include "BaseGameMode.generated.h"



class UIA_GuardManager;
UCLASS()
class AI_FSM_API ABaseGameMode : public AGameModeBase
{
	GENERATED_BODY()
private:
	UPROPERTY(EditAnywhere, Category = "Manager")
		TSubclassOf<UIA_GuardManager> IA_GuardManagerToCreate = nullptr;
	
	UPROPERTY(VisibleAnywhere, BlueprintReadWrite, Category = "Manager", meta = (EditInLine, AllowPrivateAccess))
		TObjectPtr<UIA_GuardManager> currentIA_GuardManagerInstance = nullptr;


public:
	FORCEINLINE TObjectPtr<UIA_GuardManager> GetGuardManager() const { return currentIA_GuardManagerInstance; }
private:
	virtual void InitGame(const FString& MapName, const FString& Options, FString& ErrorMessage) override;
};
