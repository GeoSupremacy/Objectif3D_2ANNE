


#include "../Utils.h"
#include"../DrawDebugUtils.h"
#include"../DebugUtils.h"
#include "Kismet/KismetSystemLibrary.h"

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
void AReflector::DetectedSource(bool _interact)
{
	if (!interact || !isDetected)
		return;
	SCREEN_DEBUG_MESSAGE_WARNING(2, "DetectedSource")

		//if(CheckAll())
			//if(result.GetActor()==Cast<AReflector>(this))
					//allLink.Add(FinalPosition);
	isDetected =interact = false;
}
void AReflector::Target()
{
	if (!takeIt)
		return;
	if (!isAttach)
		return;
	
	const FVector _end =character->GetActorLocation() + character->GetActorForwardVector()* 1000;
	bool _hisHit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, FinalPosition(), _end, raySourceLayer, true, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, result, true);
	
	if (_hisHit)
	{
		isDetected = true;
		targetPosition = _end;
		INVOKE(onCanInteract, true)
		return;
	}
	
	INVOKE(onCanInteract, false)
}
void AReflector::Reflect(AReflector _other)
{
}
void AReflector::Transmit(AReflector _other)
{
}
void AReflector::DrawDebug()
{
	DRAW_SPHERE(FinalPosition(), 25, FColor::Red, 1);
}
void AReflector::AllReflect()
{
	
	for (auto link : allLink)
	
		UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, FinalPosition(), link->GetActorLocation(), raySourceLayer, false, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, result, true);

	
}
bool AReflector::CheckAll()
{
	
	for (auto link : allLink)
		if (link->GetActorLocation() == result.GetActor()->GetActorLocation())
			return false;
	return true;
}
#pragma endregion

#pragma region INIT
void AReflector::Bind()
{
	character = Cast<APlayableCharacter>(FPC->GetPawn());
	if (!character)
		return;
	BIND(OnCanInteract(), character->Get(), &APlayableCharacter::SetCanLink);
	character->BIND(OnInteract(), this, &AReflector::InteractTaken);
	character->BIND(OnInteract(), this, &AReflector::DetectedSource);
}
#pragma endregion
