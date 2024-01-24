#include "\Unreal\Objectif3D_2ANNE\Grid\Source\Grid\Utils.h"
#include "Kismet/KismetSystemLibrary.h"
#include "GPE/Component/SightComponent.h"



USightComponent::USightComponent()
{
	PrimaryComponentTick.bCanEverTick = true;

}



void USightComponent::BeginPlay()
{
	Super::BeginPlay();


	
}
void USightComponent::TickComponent(float DeltaTime, ELevelTick TickType, FActorComponentTickFunction* ThisTickFunction)
{
	Super::TickComponent(DeltaTime, TickType, ThisTickFunction);
	SightBehaviour();
	
}


void USightComponent::SightBehaviour()
{
	TArray<AActor*> _me = { GetOwner() };
	TArray<AActor*> _items = {};
	FHitResult _result;
	const float _degToRadSight = FMath::DegreesToRadians(sightAngle / 2);

	//bool _hit = UKismetSystemLibrary::LineTraceSingleForObjects(this, GetOwner()->GetActorLocation(), GetOwner()->GetActorLocation() +
	//	GetOwner()->GetActorForwardVector() * range, masklayers, false, _me, EDrawDebugTrace::ForOneFrame, _result, true);
	DrawDebugLine(GetWorld(), GetOwner()->GetActorLocation(), GetOwner()->GetActorLocation() +
		GetOwner()->GetActorForwardVector() * range, FColor::Magenta);
	//if (_hit)
	//{
	//	SCREEN_DEBUG(1, FColor::Magenta, "_hit")
		//	return;
	//}
	DRAW_SPHERE(SightOffstLocation(), range, Target ? FColor::White : FColor::Red,2)
	//DrawDebugCone(GetWorld(), SightOffstLocation(), GetOwner()->GetActorForwardVector(), range, _degToRadSight, _degToRadSight, 32, Target ? FColor::White : FColor::Red);
	//DrawDebugCircleArc(GetWorld(), SightOffstLocation(), range, GetOwner()->GetActorForwardVector(), _degToRadSight, 3, FColor::Magenta, false, -1, 0, 5);
	UKismetSystemLibrary::SphereOverlapActors(this, SightOffstLocation(), range, layers, nullptr, TArray<AActor*>(), _items);

	for (size_t i = 0; i < _items.Num(); i++)
	{
		if (_items[i])
		{
			//const FVector _direction = (_items[i]->GetActorLocation() - SightOffstLocation()).GetSafeNormal();
			//const float _angle = GetVectorAngle(GetOwner()->GetActorForwardVector(), _direction);
			//if (_angle < sightAngle / 2)
			//{
			
				Target = _items[i];
				INVOKE(onTarget, Target)
				return;
			//}
		}

	}
}

	float USightComponent::GetVectorAngle(const FVector & _u, const FVector & _v) const
	{
		const float _dot = FVector::DotProduct(_u, _v) / (_u.Size() * _v.Size());
		return FMath::RadiansToDegrees(FMath::Acos(_dot));
	}

