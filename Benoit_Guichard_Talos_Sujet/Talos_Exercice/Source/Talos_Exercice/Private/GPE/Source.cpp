// Fill out your copyright notice in the Description page of Project Settings.


#include "GPE/Source.h"
#include "../Utils.h"
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
	
}


void ASource::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

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

