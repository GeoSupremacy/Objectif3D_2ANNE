// Fill out your copyright notice in the Description page of Project Settings.
#include "../Utils.h"
#include "../DrawDebugUtils.h"
#include "Kismet/KismetSystemLibrary.h"
#include "Player/PlayableCharacter.h"
#include "GUI/UI_HUD_Menu.h"
#include "GPE/Locker.h"


#pragma region Constructeur
ALocker::ALocker()
{
	PrimaryActorTick.bCanEverTick = true;

}
#pragma endregion 



#pragma region UE_METHOD
void ALocker::BeginPlay()
{
	Super::BeginPlay();
	Bind();
	Registre();
}
void ALocker::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	Reflection();
}
#pragma endregion 


#pragma region METHOD
void ALocker::Bind()
{

	APlayableCharacter* _player = Cast< APlayableCharacter>(FPC->GetPawn());
	if (!_player)
		return;

	//Le joueur fa link un réflecteur à un locker ou suprimmer ce lien
	_player->BIND(OnLinkLocker(), this, &ALocker::Dispersion);
	_player->BIND(OnDisableAllLink(), this, &ALocker::Remove);

	AUI_HUD_Menu* hud = Cast<AUI_HUD_Menu>(FPC->GetHUD());
	if (!hud)
		return;
	//Creer une icone spécifique au locker
	BIND(OnRegistre(), hud->Get(), &AUI_HUD_Menu::Create);

}
void ALocker::Reflection()
{
	//Un locker possède un lien un réflecteur qui lui est connecter, il n'y peut avoir qu'un réflecteur
	if (!reflector)
		return;
	FHitResult  _result;
	bool _hit;
	
	_hit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, GetActorLocation(), reflector->FinalPosition(), interactLayer, true, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, _result, true, FLinearColor::Blue, FLinearColor::Green);
	if (_hit)
		if (Cast<APlayableCharacter>(_result.GetActor()) || !reflector->GetContact() || !Cast<AReflector>(_result.GetActor()))
			INVOKE(onOpenDoor, false)
		else
		{
			DRAW_LINE(GetActorLocation(), reflector->FinalPosition(), reflector->GetColor(), 3);
			INVOKE(onOpenDoor, true);
		}



}
void ALocker::Registre()
{
	//Creer une icone spécifique au locker
	INVOKE(onRegistre, "Locker", this);
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
#pragma endregion 