// Fill out your copyright notice in the Description page of Project Settings.

#include "../Utils.h"
#include "../DebugUtils.h"
#include "Kismet/KismetSystemLibrary.h"
#include "Player/PlayableCharacter.h"
#include "GPE/Source.h"

ASource::ASource()
{
 	PrimaryActorTick.bCanEverTick = true;
	//mesh = CREATE(UStaticMeshComponent, "Mesh");
	//ATTACH_TO(mesh,RootComponent)
	//mesh->SetStaticMesh(LoadObject<UStaticMesh>(this, TEXT("'/Engine/BasicShapes/Sphere.Sphere'")));
	InitMaterial();
}


void ASource::BeginPlay()
{
	Super::BeginPlay();
	Bind();
}
void ASource::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	Reflection();
}



void ASource::Reflection()
{
	FHitResult  _result;
	bool _hit;
	for (auto _reflection : allReflectionLink)
	{
		 _hit = UKismetSystemLibrary::LineTraceSingleForObjects(WORLD, GetActorLocation(), _reflection->FinalPosition(), interactLayer, true, TArray<AActor*>(), EDrawDebugTrace::ForOneFrame, _result, true);
		if (_hit)
		{
			
			if (Cast<APlayableCharacter>(_result.GetActor()))
				_reflection->SetContact(false);
			else
				_reflection->SetContact(true);
		}
	}
}
void ASource::Remove(AReflector* _reflector)
{
	if (!allReflectionLink.Contains(_reflector))
		return;
	_reflector->RemoveLink();
	_reflector->SetContact(false);
	allReflectionLink.Remove(_reflector);
}
void ASource::Dispersion(AReflector* _reflector)
{
	
	if(allReflectionLink.Contains(_reflector))
		return;

	allReflectionLink.Add(_reflector);
}

void ASource::InitMaterial()
{
	if (!mesh)
		return;
	dynamicMaterialColor = mesh->CreateDynamicMaterialInstance(0);
	FHashedMaterialParameterInfo _param;
	_param.Name = FScriptName("SourceColor");
	dynamicMaterialColor->GetVectorParameterValue(_param, sourceColor);
}
void ASource::Bind()
{
	APlayableCharacter* _player = Cast< APlayableCharacter>(FPC->GetPawn());
	if (!_player)
		return;
	
	_player->BIND(OnLinkSource(), this, &ASource::Dispersion);
	_player->BIND(OnDisableAllLink(), this, &ASource::Remove);
}

