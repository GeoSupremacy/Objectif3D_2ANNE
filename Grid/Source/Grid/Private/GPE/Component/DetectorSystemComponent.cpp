#include "\Unreal\Objectif3D_2ANNE\Grid\Source\Grid\Utils.h"
#include "Kismet/KismetSystemLibrary.h"
#include "GPE/Component/DetectorSystemComponent.h"


UDetectorSystemComponent::UDetectorSystemComponent()
{
	PrimaryComponentTick.bCanEverTick = true;

	
}

void UDetectorSystemComponent::BeginPlay()
{
	Super::BeginPlay();


	
}

void UDetectorSystemComponent::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);
	Detection();
}

void UDetectorSystemComponent::Detection()
{
	TArray<AActor*> _toIgnore;
	FHitResult _result;
	const FVector _startLoc = GetOwner()->GetActorLocation();
	const bool _hit =UKismetSystemLibrary::SphereTraceSingleForObjects(GetWorld(), _startLoc, _startLoc, 
													detectedRange, layer, false, _toIgnore,
													EDrawDebugTrace::ForOneFrame, _result, true);
	if (!_hit)
	{
		target = nullptr;
		targetDetected = false;
		INVOKE(onTargetFound, target)
		INVOKE(onTargetDetected, targetDetected)
		return;
	}
	target = _result.GetActor();
	targetDetected = true;
	INVOKE(onTargetFound, target)
	INVOKE(onTargetDetected, targetDetected)
}

void UDetectorSystemComponent::Debug()
{

}

