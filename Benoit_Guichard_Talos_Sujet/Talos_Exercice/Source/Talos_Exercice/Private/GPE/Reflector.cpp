


#include "../Utils.h"
#include"../DrawDebugUtils.h"
#include"../DebugUtils.h"
#include "Kismet/KismetSystemLibrary.h"
#include "GPE/Source.h"
#include "GPE/Reflector.h"



#pragma region Constructor
AReflector::AReflector()
{
	PrimaryActorTick.bCanEverTick = true;
#if WITH_EDITOR 
	PrimaryActorTick.bStartWithTickEnabled = true;
#endif
}
#pragma endregion

#pragma region UE_METHOD
void AReflector::BeginPlay()
{
	Super::BeginPlay();
	Bind();
}
void AReflector::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	Target();
	AllReflect();
	DrawDebug();
	actor = result.GetActor();
}
bool AReflector::ShouldTickIfViewportsOnly() const
{
	return shouldTickIfViewportsOnly;
}
#pragma endregion

#pragma region METHOD
void AReflector::LinkSource()
{
	if (!isDetected)
		return;
	ASource* _source = Cast<ASource>(result.GetActor());

	if (!_source)
		return;



	INVOKE(onLinkSource, this)
}
void AReflector::LinkReflector()
{
	if (!isDetected || !GetContact())
		return;
	AReflector* _reflector = Cast<AReflector>(result.GetActor());

	if (!_reflector)
		return;
	allLinkReflector.Add(_reflector);


}
bool AReflector::CheckReflector(AReflector* _reflector)
{
	for (auto link : allLinkReflector)
		if (_reflector->GetActorLocation() == link->GetActorLocation())
			return true;
	return false;
}
void AReflector::Target()
{

	if (!takeIt|| !character)
		return;
	TArray<AActor*> _this = { this };
	const FVector _end =FinalPosition()+ character->GetActorForwardVector()* 1000;
	bool _hisHit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, FinalPosition(), _end, raySourceLayer, false, _this, EDrawDebugTrace::ForOneFrame, result, true);
	
	if (_hisHit)
	{
		DRAW_SPHERE(result.GetActor()->GetActorLocation() + result.GetActor()->GetActorUpVector() * 200, 25, FColor::Yellow, 2);
		isDetected = true;
		character->SetCanLink(true);
		return;
	}
	
	character->SetCanLink(false);
}
void AReflector::AllReflect()
{
	if (!GetContact())
		return;

	bool _hit;
	for (auto link : allLinkReflector)
	{
		DRAW_SPHERE(link->GetActorLocation() + link->GetActorUpVector() * 200, 25, FColor::Yellow, 2);
		DRAW_LINE(GetActorLocation(), link->GetActorLocation(), FColor::Yellow, 2)
			_hit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, FinalPosition(), link->FinalPosition(), raySourceLayer, true, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, result, true);
		if (_hit)
		{
			if (result.GetActor() == Cast<APlayableCharacter>(result.GetActor()))
			{
				SCREEN_DEBUG_MESSAGE_WARNING(2, "Found player by reflector ")
					link->SetContact(false);

			}

		}
	}
}
#pragma endregion

#pragma region DRAW

void AReflector::DrawDebug()
{
	DRAW_SPHERE(FinalPosition(), 25, FColor::Red, 1);
}
#pragma endregion

#pragma region INIT
void AReflector::Bind()
{
	
	character = Cast<APlayableCharacter>(FPC->GetPawn());
	if (!character)
		return;
	BIND(OnLinkSource(), character->Get(), &APlayableCharacter::Dispersion);
	character->BIND(OnInteract(), this, &AReflector::LinkReflector);
	character->BIND(OnInteract(), this, &AReflector::LinkSource);
}
#pragma endregion
