// Fill out your copyright notice in the Description page of Project Settings.



#include "../DrawDebugUtils.h"
#include "../Utils.h"
#include "../DebugUtils.h"

#include "GPE/Door.h"

#pragma region Constructeur
ADoor::ADoor()
{
	PrimaryActorTick.bCanEverTick = true;

}
#pragma endregion 

#pragma region UE_METHOD
void ADoor::BeginPlay()
{
	Super::BeginPlay();
	Init();
}
void ADoor::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	Move(DeltaTime);
}
#pragma endregion 

#pragma region INIT
void ADoor::Init()
{
	oldPosition = GetActorLocation();
	finalPosition = GetActorLocation() + GetActorUpVector() * 200;


	if (!looker)
	{
		SCREEN_DEBUG_MESSAGE_ERROR(5, "ADoor as not looker")
			return;
	}
	//Pour que le locker change le mouvement de la porte
	//La porte bouge continuellement sauf si il atteind la destination
	//Le looker change la direction de la porte si oui ou non il reçoit un rayon d'un réflecteur
	looker->BIND(OnOpenDoor(), this, &ADoor::SetHasSource);
}
#pragma endregion 

#pragma region METHOD
void ADoor::Move(float DeltaTime)
{
	if (hasSource)
		Up(DeltaTime);
	else
		Down(DeltaTime);


}
void ADoor::Down(float DeltaTime)
{
	if (FVector::Dist(GetActorLocation(), oldPosition) <= 0.5f)
		return;

	SetActorLocation(FMath::VInterpConstantTo(GetActorLocation(), oldPosition, DeltaTime, speed));
}
void ADoor::Up(float DeltaTime)
{
	if (FVector::Dist(GetActorLocation(), finalPosition) <= 0.5f)
		return;


	SetActorLocation(FMath::VInterpConstantTo(GetActorLocation(), finalPosition, DeltaTime, speed));
}
#pragma endregion
