// Fill out your copyright notice in the Description page of Project Settings.
#include "Player/myCharacter.h"
#include "../DebugUtils.h"

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

void APNJ::OpenChat()
{
	if (!dialogSettings)
	{
		SCREEN_DEBUG_MESSAGE_ERROR(0, 10, TEXT("APNJ No dialog settings "))
			return;
	}
	
	KEY++;
	int _key = KEY;
	DEFINE_KEY_SCREEN(KEY)
	SCREEN_DEBUG_MESSAGE_ERROR(-1,10, dialogSettings->Dialog(0).quote)
		for (size_t i = 0; i < dialogSettings->CountAllAnswers(0); i++)
		{
			SCREEN_DEBUG_MESSAGE_ERROR(i+1, 10, dialogSettings->AllAnswers(0)[i].answer)
		}

}

void APNJ::LeftChat()
{
	if (!dialogSettings)
		return;
	
	
}

void APNJ::Bind()
{
	AmyCharacter* _character = Cast< AmyCharacter>(GetWorld()->GetFirstPlayerController()->GetPawn());
	if (!_character)
		return;
	if (!dialogSettings)
	{
		SCREEN_DEBUG_MESSAGE_ERROR(0, 10, TEXT("APNJ No dialog settings "))
		return;
	}
	_character->OnEnterChat().AddDynamic(this, &APNJ::OpenChat);
	_character->OnLeftChat().AddDynamic(this, &APNJ::LeftChat);
}

