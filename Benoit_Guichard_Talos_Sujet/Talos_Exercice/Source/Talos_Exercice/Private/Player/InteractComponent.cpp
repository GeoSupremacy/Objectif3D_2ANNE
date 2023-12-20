


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
	hasObject = false;
	APlayableCharacter* _character = Cast<APlayableCharacter>(OWNER);
	AReflector* _reflector = Cast<AReflector>(result.GetActor());
	if (!_reflector|| !_character)
		return;
	

	_character ->SetCurentReflector(nullptr);
	_reflector->SetTake(false);
	_reflector->SetIsAttach(false);
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

	if (!_reflector || !_character)
		return;
	_character->SetCurentReflector(_reflector);
	_reflector->AttachToActor(OWNER, FAttachmentTransformRules::KeepWorldTransform);
	_reflector->SetTake(true);
	_reflector->SetIsAttach(true);
	INVOKE(onGrab)
}
#pragma endregion

#pragma region DETECTED
void UInteractComponent::DetectedObject()
{
	const FVector _Vorigin = OWNER->GetActorLocation() + OWNER->GetActorUpVector() * top,
		_VEnd = OWNER->GetActorLocation() + OWNER->GetActorUpVector() * -down + OWNER->GetActorForwardVector() * range;

	bool _hisHit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, _Vorigin, _VEnd, interactLayer, false, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, result, true);

	if (_hisHit)
	{
		DrawDebug();
		canGrabItem = true;
	}
	else
		canGrabItem = false;


}
void UInteractComponent::DrawDebug()
{
	
	DRAW_SPHERE(OWNER->GetActorLocation()+ OWNER->GetActorUpVector()*100 + OWNER->GetActorRightVector()*100, 25, FColor::Blue,2)
	
}
#pragma endregion