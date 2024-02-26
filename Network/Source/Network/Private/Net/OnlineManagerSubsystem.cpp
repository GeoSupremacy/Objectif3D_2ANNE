// Fill out your copyright notice in the Description page of Project Settings.


#include "Net/OnlineManagerSubsystem.h"
#include "Utils/MyClass.h"
#include "OnlineSessionSettings.h"
#include "OnlineSubsystemTypes.h"
#include <Online/OnlineSessionNames.h>


#define IS_LAN() IOnlineSubsystem::Get()->GetSubsystemName() =="NULL"

UOnlineManagerSubsystem::UOnlineManagerSubsystem()
{
	sessionName = "O3D-Session";
}

void UOnlineManagerSubsystem::Initialize(FSubsystemCollectionBase& _collection)
{
	Super::Initialize( _collection);
	InitOnline();

}

void UOnlineManagerSubsystem::Deinitialize()
{
	Super::Deinitialize();
	UKismetSystemLibrary::PrintString(this, "EXIT", true, true, FLinearColor::Red);
}

void UOnlineManagerSubsystem::InitOnline()
{
	LOG_C("ENTER", Green);
	online = IOnlineSubsystem::Get();//Le service en ligne
	if (online)
	{
		LOG("ONLINE : "+online->GetSubsystemName().ToString());
		session = online->GetSessionInterface();
		if (session.IsValid())
		{
			session->OnCreateSessionCompleteDelegates.AddUObject(this, &UOnlineManagerSubsystem::OnCreateSessionComplete);//Après la crétion d'un serveur ouvre un lvl choisi
			session->OnFindSessionsCompleteDelegates.AddUObject(this, &UOnlineManagerSubsystem::OnFindSessionComplete);//Après la recherche de serveur montrer le résultat
		}
	}
}

void UOnlineManagerSubsystem::CreateServer()
{
	if (serverName == "")
		return;
	LOG_C("Server create "+ serverName.ToString(), Green);
	
	//TODO AVOID MULTI SESSION
	if (session->GetNamedSession(sessionName))
	{
		session->DestroySession(sessionName);
		return;
	}
	
	//Règle spécifique d'un serveur (LAN, nbr max de joeur...)
	FOnlineSessionSettings _sessionSettings;
	_sessionSettings.bAllowJoinInProgress = true;
	_sessionSettings.bIsDedicated = false;	
	_sessionSettings.NumPublicConnections = 20;
	_sessionSettings.bUsesPresence = true;
	_sessionSettings.bAllowJoinViaPresence = true;
	_sessionSettings.bUseLobbiesIfAvailable = true;
	_sessionSettings.bIsLANMatch = IS_LAN();
	//NAME
	_sessionSettings.Set(FName("SERVER_NAME"), serverName.ToString(), 
		EOnlineDataAdvertisementType::ViaOnlineServiceAndPing);//! Définir une session avant l création attention nom
	session->CreateSession(0, sessionName, _sessionSettings);//0 nvbr de player host la partie, le nom de session et les settings
}

void UOnlineManagerSubsystem::FindServer()
{
	if (serverName == "")
		return;
	LOG_C("Server join " + serverName.ToString(), Yellow);
	sessionSearch = MakeShareable(new FOnlineSessionSearch());
	sessionSearch->bIsLanQuery = IS_LAN();
	sessionSearch->MaxSearchResults = 999;
	sessionSearch->QuerySettings.Set(SEARCH_PRESENCE, true, EOnlineComparisonOp::Equals);
	session->FindSessions(0, sessionSearch.ToSharedRef());
}

void UOnlineManagerSubsystem::OnCreateSessionComplete(FName _sessionName, bool _success)
{
	if (_success)
	{
		LOG_C("Server Sucess " + serverName.ToString(), Green);
		const FString _path = "/Game/Levels/GameLevels?listen"; //Le serveur est en écoute ou Uworld lvl->GetLongPackageName() + ?listen
		GetWorld()->ServerTravel(_path);
	}
	else
		LOG_C("Session failed  " + serverName.ToString(), Red);
}

void UOnlineManagerSubsystem::OnFindSessionComplete(bool _success)
{
	if (_success)
	{
		TArray<FOnlineSessionSearchResult>_result = sessionSearch->SearchResults;
		if(_result.Num()>0)
			LOG_C("Session >FOUND "+FString::FromInt(_result.Num()+1) , Green)
		else
			LOG_C("0 Session", Red);
	}
	else
		LOG_C("0 Session", Red);

}
