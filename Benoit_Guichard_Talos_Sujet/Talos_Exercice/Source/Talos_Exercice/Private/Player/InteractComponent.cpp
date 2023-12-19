


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

	AReflector* _reflector = Cast<AReflector>(result.GetActor());
	if (!_reflector)
		return;

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

	AReflector* _reflector = Cast<AReflector>(result.GetActor());

	if (!_reflector)
		return;

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
		canGrabItem = true;
	else
		canGrabItem = false;

	DrawDebug(_hisHit, _Vorigin, _VEnd);
}
void UInteractComponent::DrawDebug(bool _hit, FVector _origin, FVector _end)
{
	FColor _color;
	if (_hit)
		_color = FColor::Blue;
	else
		_color = FColor::Red;
	DRAW_LINE(_origin, _end, _color, 5)
}
#pragma endregion