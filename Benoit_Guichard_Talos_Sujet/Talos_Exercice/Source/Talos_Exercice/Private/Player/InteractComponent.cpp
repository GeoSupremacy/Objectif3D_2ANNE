


#include "Kismet/KismetSystemLibrary.h"
#include "../Utils.h"
#include "../DrawDebugUtils.h"
#include "../DebugUtils.h"
#include "GPE/Reflector.h"
#include "Player/InteractComponent.h"

#pragma region Constructor
UInteractComponent::UInteractComponent()
{

	PrimaryComponentTick.bCanEverTick = true;

}
#pragma endregion

#pragma region UE_METHOD
void UInteractComponent::BeginPlay()
{
	Super::BeginPlay();



}
void UInteractComponent::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);
	DetectedObject();

}
#pragma endregion

#pragma region  Grab/Drop
void UInteractComponent::Drop()
{
	if (!hasObject)
		return;
	canGrabItem = false;
	hasObject = false;
	APlayableCharacter* _character = Cast<APlayableCharacter>(OWNER);
	AReflector* _reflector = Cast<AReflector>(result.GetActor());
	if (!_reflector && !_character)
		return;
	

	_character ->SetCurentReflector(nullptr);
	_reflector->SetTake(false);
	_reflector->DetachFromActor(FDetachmentTransformRules::KeepWorldTransform);
	INVOKE(onDrop)
}
void UInteractComponent::Grab()
{
	if (!canGrabItem)
		return;
	
	hasObject = true;
	APlayableCharacter* _character = Cast<APlayableCharacter>(OWNER);
	AReflector* _reflector = Cast<AReflector>(result.GetActor());

	if (!_reflector && !_character)
		return;
	
	_character->SetCurentReflector(_reflector);
	_reflector->AttachToActor(OWNER, FAttachmentTransformRules::KeepWorldTransform);
	_reflector->SetTake(true);
	INVOKE(onGrab)
}
#pragma endregion

#pragma region DETECTED
void UInteractComponent::DetectedObject()
{
	const FVector _Vorigin = OWNER->GetActorLocation() + OWNER->GetActorUpVector()*top,
		_VEnd = OWNER->GetActorLocation()+OWNER->GetActorUpVector() * down +OWNER->GetActorForwardVector() * range;

	bool _hisHit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, _Vorigin, _VEnd, interactLayer, false, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, result, true);

	if (_hisHit)
	{
		FlagInteract(true);
		canGrabItem = true;
	}
	else
	{
		FlagInteract(false);
		canGrabItem = false;
	}

}
void UInteractComponent::FlagInteract(bool _flag)
{
	//Sert � afficher une icone d'interaction, le joeur le r�cupp�re est l'envoie au UI
	if (hasObject)
	{
		INVOKE(onInteracUI, false)
		return;
	}
	
	INVOKE(onInteracUI, _flag)
	
}
#pragma endregion