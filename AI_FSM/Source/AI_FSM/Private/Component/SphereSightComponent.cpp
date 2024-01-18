// Fill out your copyright notice in the Description page of Project Settings.

#include "Kismet/KismetSystemLibrary.h"
#include "3C/PlayableCharacter.h"
#include "D:\Unreal\Objectif3D_2ANNE\AI_FSM\Source\AI_FSM\DebugLogUtils.h"
#include "Component/SphereSightComponent.h"

USphereSightComponent::USphereSightComponent()
{
	PrimaryComponentTick.bCanEverTick = true;
}


void USphereSightComponent::SightBehaviour()
{
	TArray<AActor*> _me = { GetOwner() };
	TArray<AActor*> _items = {};
	FHitResult _result;
	const float _degToRadSight = FMath::DegreesToRadians(sightAngle / 2);
	
	bool _hit= UKismetSystemLibrary::LineTraceSingleForObjects(this, GetOwner()->GetActorLocation(), GetOwner()->GetActorLocation() +
			   GetOwner()->GetActorForwardVector() * range, masklayers, false, _me, EDrawDebugTrace::ForOneFrame, _result, true);
	DrawDebugLine(GetWorld(), GetOwner()->GetActorLocation(), GetOwner()->GetActorLocation() +
				  GetOwner()->GetActorForwardVector() * range, FColor::Magenta );
	if (_hit)
	{
			SCREEN_DEBUG(1,FColor::Magenta,"_hit")
			return;
	}
	DrawDebugCone(GetWorld(), SightOffstLocation(), GetOwner()->GetActorForwardVector(), range, _degToRadSight, _degToRadSight, 32, Target ? FColor::White : FColor::Red);
	DrawDebugCircleArc(GetWorld(), SightOffstLocation(), range, GetOwner()->GetActorForwardVector(), _degToRadSight, 3, FColor::Magenta, false, -1, 0, 5);
	UKismetSystemLibrary::SphereOverlapActors(this, SightOffstLocation(), range, masklayers, nullptr, TArray<AActor*>(), _items);

	for (size_t i = 0; i < _items.Num(); i++)
	{
		if (_items[i])
		{
			const FVector _direction = (_items[i]->GetActorLocation() - SightOffstLocation()).GetSafeNormal();
			const float _angle = GetVectorAngle(GetOwner()->GetActorForwardVector(), _direction);
			if (_angle < sightAngle / 2)
			{
				Target = _items[i];
				return;
			}
		}
		
	}
	
}

float USphereSightComponent::GetVectorAngle(const FVector& _u, const FVector& _v) const
{
	const float _dot = FVector::DotProduct(_u, _v) / (_u.Size() * _v.Size());
	return FMath::RadiansToDegrees(FMath::Acos(_dot));
}

void USphereSightComponent::DrawCircle(const FVector& position, const float& radius, const int _definition)
{
	int _def = 360 / _definition;

	for (size_t i = 0; i < _def; i++)
	{
		float _a = FMath::DegreesToRadians(_definition *i),
			_b = FMath::DegreesToRadians(_definition *(1+i));

		FVector _from = FVector(0, FMath::Cos(_a)* radius, FMath::Sin(_a) * radius),
				_to = FVector(0, FMath::Cos(_b) * radius, FMath::Sin(_b) * radius) ;

		DrawDebugLine(GetWorld(), position + _from, position + _to, FColor::Blue);
	}
}
