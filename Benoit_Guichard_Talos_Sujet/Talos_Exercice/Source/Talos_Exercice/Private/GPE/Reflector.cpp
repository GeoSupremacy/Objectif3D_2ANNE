


#include "../Utils.h"
#include"../DrawDebugUtils.h"
#include"../DebugUtils.h"
#include "Kismet/KismetSystemLibrary.h"
#include "GPE/Source.h"
#include "GPE/Locker.h"

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
	

	if (resultTarget.GetActor() != Cast<ASource>(resultTarget.GetActor()))
		return;

	isDetected = false;

	INVOKE(onLinkSource, this)
}
void AReflector::LinkReflector()
{
	if (!isDetected && !GetContact())
		return;
	
	if (!Cast<AReflector>(resultTarget.GetActor()))
		return;

	if(allLinkReflector.Contains((AReflector*)resultTarget.GetActor()))
		return;
	isDetected = false;
	allLinkReflector.Add((AReflector*)resultTarget.GetActor());


}
void AReflector::LinkLocker()
{
	if (!isDetected && !GetContact())
		return;
	
	if (resultTarget.GetActor() != Cast<ALocker>(resultTarget.GetActor()))
		return;
	isDetected = false;
	INVOKE(onLinkLocker, this)
}
void AReflector::Target()
{

	if (!takeIt ||!character)
		return;


	TArray<AActor*> _this = { this };

	const FVector _end =FinalPosition()+ character->GetActorForwardVector()* 1000;
	
	bool _hisHit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, FinalPosition(), _end, raySourceLayer, false, _this, EDrawDebugTrace::ForOneFrame, resultTarget, true);
	
	if (_hisHit)
	{
		if (Cast<AReflector>(resultTarget.GetActor()) || Cast<ASource>(resultTarget.GetActor()) || Cast<ALocker>(resultTarget.GetActor()))
		{

			DRAW_SPHERE(resultTarget.GetActor()->GetActorLocation() + resultTarget.GetActor()->GetActorUpVector() * 400, 25, FColor::Yellow, 2);
			isDetected = true;
			character->SetCanLink(true);
			
		}
		else
		{
		
			isDetected = false;
			character->SetCanLink(false);
		}
	}
	

}
void AReflector::AllReflect()
{
	
	bool _hit;
	
	for (auto link : allLinkReflector)
	{
		_hit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, FinalPosition(), link->FinalPosition(), raySourceLayer, true, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, resultByEachLink, true);
		if (_hit)
		{

			if (Cast<APlayableCharacter>(resultByEachLink.GetActor()) || !asContact)
			{
				link->SetContact(false);
			}
			else
			{
				DRAW_SPHERE(link->GetActorLocation() + link->GetActorUpVector() * 400, 25, FColor::Yellow, 2);
				link->SetContact(true);
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
	BIND(OnLinkLocker(), character->Get(), &APlayableCharacter::OpenLock);
	character->BIND(OnInteract(), this, &AReflector::LinkReflector);
	character->BIND(OnInteract(), this, &AReflector::LinkSource);
	character->BIND(OnInteract(), this, &AReflector::LinkLocker);
}
#pragma endregion
