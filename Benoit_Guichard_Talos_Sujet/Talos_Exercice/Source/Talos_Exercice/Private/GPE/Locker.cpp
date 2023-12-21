// Fill out your copyright notice in the Description page of Project Settings.
#include "../Utils.h"
#include "Kismet/KismetSystemLibrary.h"
#include "Player/PlayableCharacter.h"

#include "GPE/Locker.h"


ALocker::ALocker()
{
 	PrimaryActorTick.bCanEverTick = true;

}





void ALocker::BeginPlay()
{
	Super::BeginPlay();
	Bind();
}
void ALocker::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	Reflection();
}

void ALocker::Bind()
{

	APlayableCharacter* _player = Cast< APlayableCharacter>(FPC->GetPawn());
	if (!_player)
		return;

	_player->BIND(OnLinkLocker(), this, &ALocker::Dispersion);
	_player->BIND(OnDisableAllLink(), this, &ALocker::Remove);


}

void ALocker::Reflection()
{
	if (!reflector)
		return;
	FHitResult  _result;
	bool _hit;

		_hit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, GetActorLocation(), reflector->FinalPosition(), interactLayer, true, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, _result, true,FLinearColor::Blue, FLinearColor::Green);
		if (_hit)
			if (Cast<APlayableCharacter>(_result.GetActor()) || !reflector->GetContact() || !Cast<AReflector>(_result.GetActor()))
				INVOKE(onOpenDoor, false)
			else
				INVOKE(onOpenDoor, true);
		
		
	
}


void ALocker::Remove(AReflector* _reflector)
{
	INVOKE(onOpenDoor, false)
	if (!reflector)
		return;
	reflector = nullptr;
	
}

void ALocker::Dispersion(AReflector* _reflector)
{
	reflector = _reflector;
}

