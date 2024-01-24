#include "Kismet/KismetSystemLibrary.h"
#include "\Unreal\Objectif3D_2ANNE\Grid\Source\Grid\Utils.h"
#include "GPE/Component/AttackSystemComponent.h"


UAttackSystemComponent::UAttackSystemComponent()
{
	
	PrimaryComponentTick.bCanEverTick = true;

	
}


void UAttackSystemComponent::BeginPlay()
{
	Super::BeginPlay();

	
	
}
void UAttackSystemComponent::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);
	if(!canAttack)
		currentTime =UpdateTime(currentTime, maxTime);
	isInRange = CheckIsInRange(attackRange);
}

void UAttackSystemComponent::Attack()
{
	if (!isInRange || !canAttack || !target)
		return;
	canAttack = false;
	const TArray<AActor*> _toIgnore;
	const FVector _loc = GetOwner()->GetActorLocation();
	const FRotator _rot = GetOwner()->GetActorRotation();
	const FVector _dir = GetOwner()->GetActorForwardVector();
	 FHitResult _result;
	const bool _hit = UKismetSystemLibrary::BoxTraceSingleForObjects(GetWorld(), _loc+ _dir *boxOffset, _loc + _dir * boxOffset,
		FVector::One() * attackBoxSize, _rot, layer, 
		false, _toIgnore, EDrawDebugTrace::ForOneFrame,
		_result, true);

	if (!_hit) return;
	AActor* _target = _result.GetActor();
	if (!_target) return;
	//TODO dammage

}

float UAttackSystemComponent::UpdateTime( float _current, const float& _max)
{
	_current += GetWorld()->DeltaTimeSeconds * attackSpeed;
	if (_current >= _max)
	{
		canAttack = true;
		_current = 0;
	}
	return _current;
}

bool UAttackSystemComponent::CheckIsInRange(const float& _range)
{
	if (!target) return false;
	const float _distance = FVector::Dist(GetOwner()->GetActorLocation(), target->GetActorLocation());
	const bool _value = _distance <= _range;
	INVOKE(onRangeUpdate, _value);
	return _value;
}

void UAttackSystemComponent::SetTarget(AActor* _target)
{
	target = _target;
}

