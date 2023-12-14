// Fill out your copyright notice in the Description page of Project Settings.

#include "Player/myCharacter.h"
#include "GPE/CameraFollow.h"
#include "../../../../../../Source/Runtime/Engine/Classes/Kismet/KismetMathLibrary.h"

// Sets default values
ACameraFollow::ACameraFollow()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void ACameraFollow::BeginPlay()
{
	Super::BeginPlay();
	Init();
}

// Called every frame
void ACameraFollow::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	FollowTarget(DeltaTime);
	FollowTargetView();

}

void ACameraFollow::FollowTargetView()
{
	AmyCharacter* _player = Cast< AmyCharacter>(GetWorld()->GetFirstPlayerController()->GetPawn());
	if (!_player)
		return;
	FRotator _rot = UKismetMathLibrary::FindLookAtRotation(GetActorLocation(), _player->GetActorLocation());
	SetActorRotation(_rot);
	DrawDebugLine(GetWorld(), GetActorLocation(), GetActorLocation() + GetActorForwardVector() * 200, FColor::Blue);
}

void ACameraFollow::FollowTarget(float _deltatime)
{
	AmyCharacter* _player = Cast< AmyCharacter>(GetWorld()->GetFirstPlayerController()->GetPawn());
	if (!_player)
		return;

	FVector _finalPosition =  _player->GetActorLocation()+ TurnAround();
	SetActorLocation(_finalPosition);
}

void ACameraFollow::DrawCircle(FVector _origin, float _radius, FColor _color, int _definition)
{
	int _part = 360 / _definition;

	for (int i = 0; i <= _part; i++)
	{
		float _a = FMath::DegreesToRadians(_part * i),
			_b = FMath::DegreesToRadians(_part * (i + 1));
		FVector _from = FVector(FMath::Cos(_a )* _radius, 0, FMath::Sin(_a) * _radius),
				  _to = FVector(FMath::Cos(_b) * _radius, 0, FMath::Sin(_b) * _radius);
		DrawDebugLine(GetWorld(), _origin + _from, _origin + _to, _color);
	}

}

FVector ACameraFollow::TurnAround()
{
	float angle = GetWorld()->LastRenderTime * 360;
	float _x = FMath::Cos(FMath::DegreesToRadians(angle)) * 500,
		  _y=  FMath::Sin(FMath::DegreesToRadians(angle)) * 500;
	
	return FVector(_x, _y, 0);
}

void ACameraFollow::Init()
{
	AmyCharacter* _player = Cast< AmyCharacter>(GetWorld()->GetFirstPlayerController()->GetPawn());
	if (!_player)
		return;
	FVector _location = _player->GetActorLocation() + GetActorForwardVector() * 500;
	SetActorLocation(_location);
}

