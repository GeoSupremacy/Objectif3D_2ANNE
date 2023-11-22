// Fill out your copyright notice in the Description page of Project Settings.


#include "LinetraceTesteur.h"
#include "Kismet/KismetSystemLibrary.h"
#include "DebugUtils.h"


#pragma region UE_METHOD
ALinetraceTesteur::ALinetraceTesteur()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	RootComponent = CreateDefaultSubobject<USceneComponent>("Root");
	
}
void ALinetraceTesteur::BeginPlay()
{
	Super::BeginPlay();
	//currentShot = shotNumber;
	range *= unity;
}
void ALinetraceTesteur::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	//DetectObject();
	ZoyaBounce();
	LOG_WARNING("currentShot: %f", currentShot)
}

#pragma endregion UE_METHOD
#pragma region CUSTOM_METHOD
void ALinetraceTesteur::DetectObject()
{
	FHitResult _result;
	const bool _isHit = LINETRACE(GetActorLocation(), GetActorLocation() + GetActorForwardVector() * range, _result)

		if (_isHit)
			Line(_result);
				

	
}
void ALinetraceTesteur::Line(FHitResult _result)
{
	DrawDebugSphere(GetWorld(), currentImpactPoint, 50, 32, FColor::Red);
	FHitResult  _newResult;
	newImpactPoint = _result.ImpactPoint;
	const float _range = 1 + FMath::Abs(_result.Distance - range);



	FVector _originImpact = GetActorLocation() - newImpactPoint;
	float _length = LENGTH(_originImpact);
	_length = _length != 0 ? _length : 1;
	FVector _directionnal = NORMALIZED(_originImpact, _length);

	_directionnal = _directionnal.Y > 0 ? GetActorRightVector() * (1 * _range) : GetActorRightVector() * (-1 * _range);



	const FVector _direction = (newImpactPoint + (_originImpact + _directionnal)) + GetActorForwardVector() * _range;
	DrawDebugSphere(GetWorld(), _direction, 50, 32, FColor::Blue);
	const bool _hit = LINETRACE_BACK_COLOR(newImpactPoint, _direction, _newResult, Blue);
	if (_hit)
	{
		return;
		if (currentShot == 0)
			return;
		currentImpactPoint = newImpactPoint;
		Line(_newResult);
		currentShot--;
	}
	
}
void ALinetraceTesteur::NewLine(FHitResult _result)
{
	FHitResult _newResult;
	currentShot++;
	DRAW_SPHERE(_result.ImpactPoint, 50, Red, 32)
	const bool _isHit = LINETRACE(_result.ImpactPoint, Reflect(_result.ImpactPoint, _result.Normal), _newResult);
	if(_isHit)
		NewLine(_newResult);
}
void ALinetraceTesteur::ZoyaBounce()
{
	FHitResult _result;
	const bool _isHit = LINETRACE(GetActorLocation(), GetActorLocation() + GetActorForwardVector() * range, _result)
		for (int i = 0; i < shotNumber; i++)
		{
			if (_isHit)
				NewLine(_result);
			UKismetSystemLibrary::PrintString(this, "Range: " + FString::SanitizeFloat(shotNumber));
		}

}

void ALinetraceTesteur::DebugLog(float _f, FVector _FV)
{
	float  d = FVector::Distance(GetActorLocation(), _FV);

	UKismetSystemLibrary::PrintString(this, "Range: " + FString::SanitizeFloat(_f));
	//UKismetSystemLibrary::PrintString(this, _result.GetActor()->GetActorLabel() + ": " + FString::SanitizeFloat(_result.Distance));
	UKismetSystemLibrary::PrintString(this, "Distance: " + FString::SanitizeFloat(d));
}
#pragma endregion CUSTOM_METHOD