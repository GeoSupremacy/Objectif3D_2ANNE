// Fill out your copyright notice in the Description page of Project Settings.


#include "Corr/PathActor.h"


APathActor::APathActor()
{
 	PrimaryActorTick.bCanEverTick = true;
	spline = CreateDefaultSubobject<USplineComponent>("Spline");
	RootComponent = spline;
}


void APathActor::BeginPlay()
{
	Super::BeginPlay();
	InitSplineLine();
	SetSecondLinePoint();
}
void APathActor::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	GetIntersectionPoint(LineA, LineB, intersecPoint);
	LineA.DrawLine(GetWorld(), FColor::Red);
	LineB.DrawLine(GetWorld(), FColor::Green);
	DrawDebugSphere(GetWorld(), intersecPoint, 50, 5,FColor::Magenta);
	DrawDebugSphere(GetWorld(), GetSplinePoint(), 50, 5, FColor::Magenta);
}

void APathActor::InitSplineLine()
{
	LineA.Point = GetActorLocation();
	LineA.End = spline->GetLocationAtTime(1, ESplineCoordinateSpace::World);
}

void APathActor::GetIntersectionPoint(FLine _a, FLine _b, FVector& _intersecPoint)
{
	const FVector _lineAB = _b.Point - _a.Point;
	const FVector _crossAB = FVector::CrossProduct(_a.GetDirection(), _b.GetDirection());
	const FVector _crossLineAB = FVector::CrossProduct(_lineAB, _b.GetDirection());
	float _dot = FVector::DotProduct(_lineAB, _crossAB);
	if (FMath::Abs(_dot) < 0.0001f && _crossAB.SizeSquared() > 0.0001f)
	{
		float _angle = FVector::DotProduct(_crossLineAB, _crossAB) / _crossAB.SizeSquared();
		_intersecPoint = _a.Point + (_a.GetDirection() * _angle);
	}
	else
		_intersecPoint = FVector::ZeroVector;
}

void APathActor::SetSecondLinePoint()
{
	if (!target)
		return;

	LineB.Point = target->GetActorLocation();
	LineB.End = LineB.Point+ target->GetActorForwardVector()*500;
}

FVector APathActor::GetSplinePoint() const
{
	const float _from = FVector::Dist(LineA.Point, intersecPoint);
	const float _to = FVector::Dist(LineA.Point, LineA.End);
	const float _alpha = _from/ _to;
	return spline->GetLocationAtTime(_alpha, ESplineCoordinateSpace::World);
}

