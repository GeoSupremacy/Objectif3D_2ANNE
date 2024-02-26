// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"


#include <OnlineSubsystem.h>
#include <Interfaces/OnlineSessionInterface.h>
#include "Subsystems/GameInstanceSubsystem.h"
#include "OnlineManagerSubsystem.generated.h"

/**
 * 
 */
UCLASS()
class NETWORK_API UOnlineManagerSubsystem : public UGameInstanceSubsystem
{
	GENERATED_BODY()
private:
		UPROPERTY(EditAnywhere, BlueprintReadWrite, meta = (AllowPrivateAccess)) FName sessionName = "O3D-Session";
		UPROPERTY(EditAnywhere, BlueprintReadWrite, meta = (AllowPrivateAccess)) FName serverName = "O3DProg";
#pragma region net ptr
		IOnlineSubsystem* online = nullptr;
		IOnlineSessionPtr session;
		TSharedPtr<FOnlineSessionSearch> sessionSearch;
#pragma endregion net ptr
private:
	UOnlineManagerSubsystem();
	void Initialize(FSubsystemCollectionBase& _collection) override;
	void Deinitialize()override;
private:
	void InitOnline();
public:
	UFUNCTION(BlueprintCallable)void CreateServer();
	UFUNCTION(BlueprintCallable)void FindServer();
private:
	//EVENTS
	void OnCreateSessionComplete(FName _sessionName, bool _success);
	void OnFindSessionComplete( bool _success);
};
