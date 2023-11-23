// Fill out your copyright notice in the Description page of Project Settings.


#include "InteractItem.h"

void AInteractItem::BeginPlay()
{
	Super::BeginPlay();
	Init();

}

void AInteractItem::ApplyInteractColor()
{
	dynamicMaterialColor->SetVectorParameterValue("InteractColor", interactColor);
}

void AInteractItem::ResetDefaultColor()
{
	dynamicMaterialColor->SetVectorParameterValue("InteractColor", FLinearColor::White);
}

void AInteractItem::Init()
{
	dynamicMaterialColor = GetStaticMeshComponent()->CreateDynamicMaterialInstance(0);//Copy temp de tel material
	FHashedMaterialParameterInfo _param;
	_param.Name = FScriptName("InteractColor");
	dynamicMaterialColor->GetVectorParameterValue(_param, defaultColor);

}
