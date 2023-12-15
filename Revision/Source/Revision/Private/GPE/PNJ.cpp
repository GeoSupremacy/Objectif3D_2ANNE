// Fill out your copyright notice in the Description page of Project Settings.
#include "Player/myCharacter.h"
#include "../Utils.h"

#include "GPE/PNJ.h"



APNJ::APNJ()
{
	PrimaryActorTick.bCanEverTick = true;
}

void APNJ::BeginPlay()
{
	Super::BeginPlay();
	Bind();
}

void APNJ::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	
}

void APNJ::OpenChat(FString _id)
{
	if (!dialogSettings)
		return;
	if (_id != dialogSettings->GetID())
		return;
	thisPNJ = true;
	INVOKE(onOpenChat, _id)

	
	SCREEN_DEBUG_MESSAGE_WARNING( 1, "PNJ: " +_id);
}

void APNJ::LeftChat()
{
	if (!dialogSettings)
		return;
	
	thisPNJ = false;
}

void APNJ::Bind()
{
	AmyCharacter* _character = Cast< AmyCharacter>(GetWorld()->GetFirstPlayerController()->GetPawn());
	if (!_character)
		return;
	if (!dialogSettings)
	{
		
		SCREEN_DEBUG_MESSAGE_ERROR(10, "APNJ No dialog settings ")
		return;
	}
	_character->OnEnterChat().AddDynamic(this, &APNJ::OpenChat);
	_character->OnLeftChat().AddDynamic(this, &APNJ::LeftChat);
}

